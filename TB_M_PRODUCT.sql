CREATE TABLE TB_M_PRODUCT(
	ID [UNIQUEIDENTIFIER] NOT NULL DEFAULT NEWID(),
	NAME VARCHAR(20) NOT NULL,
	DESCRIPTION VARCHAR(100) NOT NULL,
	PRICE DECIMAL NOT NULL,
	STOK INT NOT NULL,
	PRODUCT_CATEGORY_ID [UNIQUEIDENTIFIER],
	PRIMARY KEY (ID),
	CONSTRAINT FK_PRODUCT_PRODUCT_CATEGORY_ID FOREIGN KEY (PRODUCT_CATEGORY_ID)
	REFERENCES TB_M_PRODUCT_CATEGORY(ID)
);

INSERT INTO TB_M_PRODUCT VALUES (NEWID(), 'MAN', 'DESC', 10000, 50, '6AEC42BF-D4B1-4B47-B71F-A82BB7CAB153');