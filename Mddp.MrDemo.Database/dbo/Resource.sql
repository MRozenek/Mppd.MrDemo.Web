CREATE TABLE [dbo].[Resource]
(
	[Id] INT NOT NULL CONSTRAINT [PK_ResourceId] PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [ResourceTypeId] SMALLINT NOT NULL,
    CONSTRAINT [FK_ResourceTypeId_ResourceTypeId] FOREIGN KEY ([ResourceTypeId]) REFERENCES [dbo].[ResourceType]([Id])
)
