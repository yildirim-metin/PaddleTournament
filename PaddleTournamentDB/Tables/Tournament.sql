-- Remove [Tournament] constraints
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tournament]') AND type in (N'U'))
BEGIN
  ALTER TABLE [Tournament_Team] DROP CONSTRAINT [FK_TournamentTeam_Tournament]
  ALTER TABLE [Match] DROP CONSTRAINT [FK_Match_Tournament]
  DROP TABLE [Tournament]
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tournament]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[Tournament]
  (
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Tournament] PRIMARY KEY,
    [Name] NVARCHAR(100) NOT NULL,
    [Location] NVARCHAR(100) NOT NULL,
    [StartDate] DATE NOT NULL,
    [NbrMinTeams] INT NOT NULL,
    [NbrMaxTeams] INT NOT NULL
  )
END

-- Add FK_TournamentTeam_Tournament foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_TournamentTeam_Tournament'))
  AND EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tournament_Team]') AND type in (N'U'))
BEGIN
  ALTER TABLE [Tournament_Team] ADD CONSTRAINT [FK_TournamentTeam_Tournament] FOREIGN KEY (TournamentId) REFERENCES Tournament(Id)
  
END

-- Add FK_Match_Tournament foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Match_Tournament'))
  AND EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Match]') AND type in (N'U'))
BEGIN
  ALTER TABLE [Match] ADD CONSTRAINT [FK_Match_Tournament] FOREIGN KEY (TournamentId) REFERENCES Tournament(Id)
END