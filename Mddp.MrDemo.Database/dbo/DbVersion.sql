CREATE TABLE [dbo].[DbVersion]
(
	[Number] NVARCHAR(50) NOT NULL CONSTRAINT [PK_DbVersionId] PRIMARY KEY,
	[CreatedOn] DATETIME2 NOT NULL,
	[CreatedBy] NVARCHAR(255) NOT NULL
);
GO

CREATE TRIGGER [dbo].[TR_DbVersion_InsteadOfInsert] ON [dbo].[DbVersion]
INSTEAD OF INSERT AS
BEGIN
	INSERT INTO [dbo].[DbVersion] ([Number], [CreatedOn], [CreatedBy])
	SELECT i.Number, GETDATE(), SUSER_NAME()
	FROM INSERTED i
END;
GO

