CREATE TABLE [dbo].[Student] (
    [Id]      INT           NOT NULL,
    [Name]    NVARCHAR (50) NULL,
    [Subject] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

insert into Student(Id, Name, Subject) values(1, 'tegar', 'subject1');
insert into Student(Id, Name, Subject) values(2, 'swasono', 'subject2');
insert into Student(Id, Name, Subject) values(3, 'tgr', 'subject3');