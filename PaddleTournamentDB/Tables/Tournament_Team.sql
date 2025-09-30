IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tournament_Team]') AND type in (N'U'))
BEGIN
  CREATE TABLE [dbo].[Tournament_Team]
  (
    [Id] INT NOT NULL PRIMARY KEY,
    [TournamentId] INT NOT NULL,
    [TeamId] INT NOT NULL,
    [DateTournament] DATE NOT NULL,
    CONSTRAINT [FK_TournamentTeam_Tournament] FOREIGN KEY (TournamentId) REFERENCES Tournament(Id),
    CONSTRAINT [FK_TournamentTeam_Team] FOREIGN KEY (TeamId) REFERENCES Team(Id),
    CONSTRAINT [UQ_TournamentTeam_TournamentId_TeamId] UNIQUE (TournamentId, TeamId)
  )
END