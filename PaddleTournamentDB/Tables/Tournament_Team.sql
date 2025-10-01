CREATE TABLE [dbo].[Tournament_Team]
(
  [Id] INT IDENTITY NOT NULL CONSTRAINT [PK_TournamentTeam] PRIMARY KEY,
  [TournamentId] INT NOT NULL,
  [TeamId] INT NOT NULL,
  [DateTournament] DATE NOT NULL,
  CONSTRAINT [FK_TournamentTeam_Tournament] FOREIGN KEY (TournamentId) REFERENCES Tournament(Id),
  CONSTRAINT [FK_TournamentTeam_Team] FOREIGN KEY (TeamId) REFERENCES Team(Id),
  CONSTRAINT [UQ_TournamentTeam_TournamentId_TeamId] UNIQUE (TournamentId, TeamId)
)