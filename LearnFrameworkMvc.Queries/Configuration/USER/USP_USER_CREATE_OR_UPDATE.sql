CREATE OR ALTER PROCEDURE USP_USER_CREATE_OR_UPDATE
@Id			uniqueidentifier
,@Fullname		varchar(50)
,@Username		varchar(50)
,@Email			varchar(50)
,@Telp1			varchar(50)
,@Description	varchar(200)
,@Roles			varchar(200)
,@Is_Active		bit
,@CreatedBy		varchar(50)
,@IsValid		BIT OUTPUT
,@MsgError		VARCHAR(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	SET @IsValid = 1
	SET @MsgError = ''

	--#01 User
	IF (@Id IS NOT NULL AND @Id != CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER))
	BEGIN
		IF(NOT EXISTS(SELECT TOP 1 1 FROM TB_M_USER WHERE ID = @Id))
		BEGIN
			SET @IsValid = 0 
			SET @MsgError = 'Id doesnt Exists'
			RETURN;
		END
		ELSE IF(EXISTS(SELECT TOP 1 1 FROM TB_M_USER WHERE EMAIL = @Email AND ID != @Id) OR EXISTS(SELECT TOP 1 1 FROM TB_M_USER WHERE USERNAME = @Username AND ID != @Id))
		BEGIN
			SET @IsValid = 0 
			SET @MsgError = 'Duplicate Data'
			RETURN;
		END
		ELSE 
		BEGIN
			UPDATE TB_M_USER
			SET USERNAME = @Username, EMAIL = @Email, FULLNAME = @Fullname, [PASSWORD] = '123', TELP1 = @Telp1, [DESCRIPTION] = @Description, IS_ACTIVE = @Is_Active
			WHERE ID = @Id
		END
	END
	ELSE
	BEGIN
		IF(EXISTS(SELECT TOP 1 1 FROM TB_M_USER WHERE EMAIL = @Email AND ID != @Id) OR EXISTS(SELECT TOP 1 1 FROM TB_M_USER WHERE USERNAME = @Username AND ID != @Id))
		BEGIN
			SET @IsValid = 0 
			SET @MsgError = 'Duplicate Data'
			RETURN;
		END
		ELSE
		BEGIN
			SET @Id = NEWID();
			INSERT INTO TB_M_USER VALUES(@Id, @Username, @Email, @Fullname, 'pw', @Telp1, @Description, @Is_Active);
		END
	END

	--#02 UserRole
	BEGIN
		if(@Roles = null or @Roles = '')
		begin
			delete TB_M_USER_ROLE where USER_ID = @Id
		end
		else
		begin
			delete TB_M_USER_ROLE 
			where USER_ID = @Id and 
			ROLE_ID not in (select value from string_split(@Roles,','))

			insert into tb_m_user_role(USER_ID, ROLE_ID)
			select @Id, value 
			from string_split(@Roles,',') 
			where value not in (select ROLE_ID from TB_M_USER_ROLE where USER_ID = @Id)
		end
	END
END