-- Remove [Team] constraints in table [Tournament_Team] and [Match] tables
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Team]') AND type in (N'U'))
BEGIN
  ALTER TABLE [Tournament_Team] DROP CONSTRAINT [FK_TournamentTeam_Team]
  ALTER TABLE [Match] DROP CONSTRAINT [FK_Match_TeamA], [FK_Match_TeamB]
  DROP TABLE [Team]
END

CREATE TABLE [dbo].[Team]
(
  [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Team] PRIMARY KEY,
  [Name] NVARCHAR(100) NOT NULL,
  [UserAId] INT NOT NULL,
  [UserBId] INT NOT NULL,
  CONSTRAINT [FK_Team_UserA] FOREIGN KEY (UserAId) REFERENCES [User](Id),
  CONSTRAINT [FK_Team_UserB] FOREIGN KEY (UserBId) REFERENCES [User](Id)
)

-- Add [FK_TournamentTeam_Team] foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_TournamentTeam_Team'))
BEGIN
  ALTER TABLE [Tournament_Team] ADD CONSTRAINT [FK_TournamentTeam_Team] FOREIGN KEY (TeamId) REFERENCES Team(Id)
END

-- Add [FK_Match_TeamA] foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Match_TeamA'))
BEGIN
  ALTER TABLE [Match] ADD CONSTRAINT [FK_Match_TeamA] FOREIGN KEY (TeamAId) REFERENCES Team(Id)
END

-- Add [FK_Match_TeamB] foreign key
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'FK_Match_TeamB'))
BEGIN
  ALTER TABLE [Match] ADD CONSTRAINT [FK_Match_TeamB] FOREIGN KEY (TeamBId) REFERENCES Team(Id)
END