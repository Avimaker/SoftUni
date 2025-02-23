erDiagram
      
"dbo.Characters" {
    int Id "PK"
          nvarchar(50) Name ""
          int StatisticId "FK"
          
}
"dbo.Games" {
    int Id "PK"
          nvarchar(50) Name ""
          datetime Start ""
          int Duration ""
          int GameTypeId "FK"
          bit IsFinished ""
          
}
"dbo.GameTypeForbiddenItems" {
    int ItemId "FK, PK"
          int GameTypeId "FK, PK"
          
}
"dbo.GameTypes" {
    int Id "PK"
          nvarchar(50) Name ""
          int BonusStatsId "FK"
          
}
"dbo.Items" {
    int Id "PK"
          nvarchar(50) Name ""
          int ItemTypeId "FK"
          int StatisticId "FK"
          money Price ""
          int MinLevel ""
          
}
"dbo.ItemTypes" {
    int Id "PK"
          nvarchar(50) Name ""
          
}
"dbo.Statistics" {
    int Id "PK"
          int Strength ""
          int Defence ""
          int Mind ""
          int Speed ""
          int Luck ""
          
}
"dbo.UserGameItems" {
    int ItemId "FK, PK"
          int UserGameId "FK, PK"
          
}
"dbo.Users" {
    int Id "PK"
          nvarchar(50) Username ""
          nvarchar(50) FirstName ""
          nvarchar(50) LastName ""
          nvarchar(50) Email ""
          datetime RegistrationDate ""
          bit IsDeleted ""
          nvarchar(15) IpAddress ""
          
}
"dbo.UsersGames" {
    int Id "PK"
          int GameId "FK"
          int UserId "FK"
          int CharacterId "FK"
          int Level ""
          datetime JoinedOn ""
          money Cash ""
          
}
      "dbo.Characters" |o--|{ "dbo.Statistics": "Id"
"dbo.Games" ||--|{ "dbo.GameTypes": "Id"
"dbo.GameTypeForbiddenItems" ||--|{ "dbo.Items": "Id"
"dbo.GameTypeForbiddenItems" ||--|{ "dbo.GameTypes": "Id"
"dbo.GameTypes" |o--|{ "dbo.Statistics": "Id"
"dbo.Items" ||--|{ "dbo.ItemTypes": "Id"
"dbo.Items" ||--|{ "dbo.Statistics": "Id"
"dbo.UserGameItems" ||--|{ "dbo.Items": "Id"
"dbo.UserGameItems" ||--|{ "dbo.UsersGames": "Id"
"dbo.UsersGames" ||--|{ "dbo.Games": "Id"
"dbo.UsersGames" ||--|{ "dbo.Users": "Id"
"dbo.UsersGames" ||--|{ "dbo.Characters": "Id"
