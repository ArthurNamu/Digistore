CREATE TABLE [dbo].[t_User] (
    [UserID]   INT            IDENTITY (1, 1) NOT NULL,
    [UserName] VARCHAR (200)  NULL,
    [Password] NVARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

