CREATE TABLE [dbo].[Tournament]
(
  [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Tournament] PRIMARY KEY,
  [Name] NVARCHAR(100) NOT NULL,
  [Location] NVARCHAR(100) NOT NULL,
  [StartDate] DATE NOT NULL,
  [NbrMinTeams] INT NOT NULL,
  [NbrMaxTeams] INT NOT NULL
)