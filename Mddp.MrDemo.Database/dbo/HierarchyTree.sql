CREATE TABLE [dbo].[HierarchyTree]
(
	[Id] INT NOT NULL CONSTRAINT [PK_HierarchyTreeId] PRIMARY KEY,
	[ResourceId] INT NOT NULL,
	[ResourceParentId] INT NULL,
	[ResourceManagerId] INT NULL,
	CONSTRAINT [FK_HierarchyTreeResourceId_ResourceId] FOREIGN KEY ([ResourceId]) REFERENCES [dbo].[Resource]([Id]),
	CONSTRAINT [FK_HierarchyTreeResourceParentId_ResourceId] FOREIGN KEY ([ResourceParentId]) REFERENCES [dbo].[Resource]([Id]),
	CONSTRAINT [FK_HierarchyTreeResourceManagerId_ResourceId] FOREIGN KEY ([ResourceManagerId]) REFERENCES [dbo].[Resource]([Id])
)
