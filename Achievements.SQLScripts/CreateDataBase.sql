CREATE DATABASE Achievements

USE Achievements

CREATE TABLE Users(
ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
USER_LOGIN nvarchar(50) NOT NULL,
USER_PASSWORD int NOT NULL
)

CREATE TABLE Achievements(
ID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Achievements PRIMARY KEY,
ACHIEVEMENT_NAME nvarchar(100) NOT NULL,
ACHIEVEMENT_DESCRIPTION nvarchar(200) NOT NULL
)

CREATE TABLE User_To_Achievement(
ID_USER int CONSTRAINT FK_User_To_Achievement_Users FOREIGN KEY(ID_USER) REFERENCES Users(ID),
ID_ACHIEVEMENT int CONSTRAINT FK_User_To_Achievement_Achievements FOREIGN KEY(ID_ACHIEVEMENT) REFERENCES Achievements(ID)
)