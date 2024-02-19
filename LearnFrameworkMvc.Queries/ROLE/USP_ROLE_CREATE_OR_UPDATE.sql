
CREATE OR ALTER PROCEDURE USP_ROLE_CREATE_OR_UPDATE
@Id			uniqueidentifier
,@Name			varchar(50)
,@Description	varchar(200)
,@CreatedBy		varchar(50)
,@IsValid		BIT OUTPUT
,@MsgError		VARCHAR(MAX) OUTPUT
AS
BEGIN
	SET NOCOUNT ON
	SET @IsValid = 1
	SET @MsgError = ''
	IF (@Id IS NOT NULL AND @Id != CAST(CAST(0 AS BINARY) AS UNIQUEIDENTIFIER))
	BEGIN
		IF(NOT EXISTS(SELECT TOP 1 1 FROM TB_M_ROLE WHERE ID = @Id))
		BEGIN
			SET @IsValid = 0 
			SET @MsgError = 'Id doesnt Exists'
			RETURN;
		END
		ELSE IF(EXISTS(SELECT TOP 1 1 FROM TB_M_ROLE WHERE NAME = @Name AND ID != @Id))
		BEGIN
			SET @IsValid = 0 
			SET @MsgError = 'Duplicate Data'
			RETURN;
		END
		ELSE 
		BEGIN
			UPDATE TB_M_ROLE
			SET NAME = @Name, DESCRIPTION = @Description
			WHERE ID = @Id
		END
	END
	ELSE
	BEGIN
		IF(EXISTS(SELECT TOP 1 1 FROM TB_M_ROLE WHERE NAME = @Name))
		BEGIN
			SET @IsValid = 0 
			SET @MsgError = 'Duplicate Data'
			RETURN;
		END
		ELSE
		BEGIN
			INSERT INTO TB_M_ROLE VALUES(NEWID(), @Name, @Description);
		END
	END
END