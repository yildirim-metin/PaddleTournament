IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[User]
  (
    [Id] INT NOT NULL PRIMARY KEY,
    [Username] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [PasswordHash] NVARCHAR(256) NOT NULL,
    [Role] NVARCHAR(20) NOT NULL CONSTRAINT [DF_Role] DEFAULT 'User',
  )
END