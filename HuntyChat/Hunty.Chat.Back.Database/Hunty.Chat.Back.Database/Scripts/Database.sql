CREATE DATABASE Hunty;
GO

USE Hunty
GO

CREATE SCHEMA Chat;
GO

CREATE TABLE Chat.Users (
    Id INT NOT NULL,
    Uid NVARCHAR(300) NOT NULL,
    Name VARCHAR(100) NOT NULL,
    AccessToken NVARCHAR(200) NOT NULL,
	ExpirationToken DATETIME NOT NULL,
);
GO

CREATE TABLE Chat.Conversations (
    Id INT NOT NULL IDENTITY(1,1),
    Id_User INT NOT NULL,
	Id_Room INT NOT NULL,
);
GO

CREATE TABLE Chat.Rooms (
    Id INT NOT NULL,
    Uid NVARCHAR(300) NOT NULL,
    Name VARCHAR(100) NOT NULL,
);
GO

CREATE TABLE Chat.Messages (
    Id INT NOT NULL,
    Text NVARCHAR(300) NOT NULL,
	DateCreated DATETIME NOT NULL,
	IsFromWebhook BIT NOT NULL,
	Id_Conversation INT NOT NULL,
);
GO

----PRIMARY KEY
ALTER TABLE Chat.Users
ADD CONSTRAINT PK_IdUser PRIMARY KEY (Id);
GO

ALTER TABLE Chat.Conversations
ADD CONSTRAINT PK_Id_Conversation PRIMARY KEY (Id);
GO

ALTER TABLE Chat.Rooms
ADD CONSTRAINT PK_IdRoom PRIMARY KEY (Id);
GO

ALTER TABLE Chat.Messages
ADD CONSTRAINT PK_IdMessage PRIMARY KEY (Id);
GO

----FOREIGN KEY
ALTER TABLE Chat.Conversations
ADD CONSTRAINT FK_Users_Conversations
FOREIGN KEY (Id_User) REFERENCES Chat.Users(Id);
GO

ALTER TABLE Chat.Conversations
ADD CONSTRAINT FK_Rooms_Conversations
FOREIGN KEY (Id_Room) REFERENCES Chat.Rooms(Id);
GO

ALTER TABLE Chat.Messages
ADD CONSTRAINT FK_Conversations_Messages
FOREIGN KEY (Id_Conversation) REFERENCES Chat.Conversations(Id);

---- Inserts
INSERT INTO Chat.Users
           (Id
		   ,Uid
           ,Name
		   ,AccessToken
		   ,ExpirationToken)
     VALUES
           (5,
		   'FrontendUser',
           'Frontend User',
		   Getdate(),
		   '')