DROP TABLE IF EXISTS [Match]

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Match]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[Match]
  (
    [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_Match] PRIMARY KEY,
    [TournamentId] INT NOT NULL,
    [TeamAId] INT NOT NULL,
    [TeamBId] INT NOT NULL,
    [ScoreTeamA] INT NOT NULL CONSTRAINT [DF_ScoreTeamA] DEFAULT 0,
    [ScoreTeamB] INT NOT NULL CONSTRAINT [DF_ScoreTeamB] DEFAULT 0,
    CONSTRAINT [FK_Match_Tournament] FOREIGN KEY (TournamentId) REFERENCES Tournament(Id),
    CONSTRAINT [FK_Match_TeamA] FOREIGN KEY (TeamAId) REFERENCES Team(Id),
    CONSTRAINT [FK_Match_TeamB] FOREIGN KEY (TeamBId) REFERENCES Team(Id)
  )
END