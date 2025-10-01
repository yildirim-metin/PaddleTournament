-- Remove [User] table constraints (FK) in [Team] table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
  ALTER TABLE [Team] DROP CONSTRAINT [FK_Team_UserA], [FK_Team_UserB]
  DROP TABLE [User]
END

CREATE TABLE [dbo].[User]
(
  [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_User] PRIMARY KEY,
  [Username] NVARCHAR(50) NOT NULL,
  [Email] NVARCHAR(100) NOT NULL,
  [PasswordHash] NVARCHAR(256) NOT NULL,
  [Role] NVARCHAR(20) NOT NULL CONSTRAINT [DF_Role] DEFAULT 'User',
)

-- Add [FK_Team_UserA] foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Team_UserA'))
  AND EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Team]') AND type in (N'U'))
BEGIN
  ALTER TABLE [Team] ADD CONSTRAINT [FK_Team_UserA] FOREIGN KEY (TeamId) REFERENCES Team(Id)
END

-- Add [FK_Team_UserB] foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Team_UserB'))
  AND EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Team]') AND type in (N'U'))
BEGIN
  ALTER TABLE [Team] ADD CONSTRAINT [FK_Team_UserB] FOREIGN KEY (TeamId) REFERENCES Team(Id)
END