IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tournament]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[Tournament]
  (
    [Id] INT NOT NULL PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Location] NVARCHAR(100) NOT NULL,
    [StartDate] DATE NOT NULL,
    [NbrMinTeams] INT NOT NULL,
    [NbrMaxTeams] INT NOT NULL
  )
END