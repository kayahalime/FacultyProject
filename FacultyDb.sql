CREATE TABLE [dbo].[DepartmentInformations] (
    [DepartmentInformationId] INT          IDENTITY (1, 1) NOT NULL,
    [DepartmentId]            INT          NOT NULL,
    [LecturerId]              INT          NOT NULL,
    [StudentId]               INT          NOT NULL,
    [StudentNo]               VARCHAR (50) NOT NULL,
    [Status]                  VARCHAR (50) NOT NULL,
    [StudentScoreId]          INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([DepartmentInformationId] ASC),
    CONSTRAINT [FK_DepartmentInformations_Departments] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]),
    CONSTRAINT [FK_DepartmentInformations_Lecturers] FOREIGN KEY ([LecturerId]) REFERENCES [dbo].[Lecturers] ([LecturerId]),
    CONSTRAINT [FK_DepartmentInformations_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([StudentId]),
    CONSTRAINT [FK_DepartmentInformations_StudentScores] FOREIGN KEY ([StudentScoreId]) REFERENCES [dbo].[StudentScores] ([StudentScoreId])
);

CREATE TABLE [dbo].[Departments] (
    [DepartmentId]   INT          IDENTITY (1, 1) NOT NULL,
    [DepartmentName] VARCHAR (50) NOT NULL,
    [DepartmentCode] VARCHAR (50) NOT NULL,
    [Value]          VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);

CREATE TABLE [dbo].[Lecturers] (
    [LecturerId]        INT          IDENTITY (1, 1) NOT NULL,
    [LecturerFirstName] VARCHAR (50) NOT NULL,
    [LecturerLastName]  VARCHAR (50) NOT NULL,
    [RegisterNo]        VARCHAR (50) NOT NULL,
    [DepartmentId]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([LecturerId] ASC)
);
CREATE TABLE [dbo].[Lessons] (
    [LessonId]     INT          IDENTITY (1, 1) NOT NULL,
    [LecturerId]   INT          NOT NULL,
    [DepartmentId] INT          NOT NULL,
    [LessonCode]   VARCHAR (50) NOT NULL,
    [CourseCredit] INT          NOT NULL,
    [Classroom]    VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([LessonId] ASC),
    CONSTRAINT [FK_Lessons_Departments] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]),
    CONSTRAINT [FK_Lessons_Lecturers] FOREIGN KEY ([LecturerId]) REFERENCES [dbo].[Lecturers] ([LecturerId])
);

CREATE TABLE [dbo].[Students] (
    [StudentId]        INT          IDENTITY (1, 1) NOT NULL,
    [StudentFirstName] VARCHAR (50) NOT NULL,
    [StudentLastName]  VARCHAR (50) NOT NULL,
    [TelephoneNumber]  VARCHAR (50) NOT NULL,
    [IdentityNumber]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentId] ASC)
);

CREATE TABLE [dbo].[StudentScores] (
    [StudentScoreId]          INT        IDENTITY (1, 1) NOT NULL,
    [StudentId]               INT        NOT NULL,
    [FirstExam]               INT        NOT NULL,
    [SecondExam]              INT        NOT NULL,
    [StudentAverage]          FLOAT (53) NOT NULL,
    [LessonId]                INT        NOT NULL,
    [DepartmentInformationId] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentScoreId] ASC),
    CONSTRAINT [FK_StudentScores_Students] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([StudentId]),
    CONSTRAINT [FK_StudentScores_Lessons] FOREIGN KEY ([LessonId]) REFERENCES [dbo].[Lessons] ([LessonId]),
    CONSTRAINT [FK_StudentScores_DepartmentInformations] FOREIGN KEY ([DepartmentInformationId]) REFERENCES [dbo].[DepartmentInformations] ([DepartmentInformationId])
);

CREATE TABLE [dbo].[Users] (
    [UserID]       INT             IDENTITY (1, 1) NOT NULL,
    [LastName]     NVARCHAR (50)   NOT NULL,
    [FirstName]    NVARCHAR (50)   NOT NULL,
    [Email]        NVARCHAR (50)   NOT NULL,
    [PasswordHash] VARBINARY (500) NOT NULL,
    [PasswordSalt] VARBINARY (500) NOT NULL,
    [Status]       BIT             NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

CREATE TABLE [dbo].[OperationClaims] (
    [OperationClaimID]   INT          IDENTITY (1, 1) NOT NULL,
    [OperationClaimName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([OperationClaimID] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [UserOperationClaimID] INT IDENTITY (1, 1) NOT NULL,
    [UserID]               INT NOT NULL,
    [OperationClaimID]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserOperationClaimID] ASC),
    CONSTRAINT [FK_UserOperationClaims_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID]),
    CONSTRAINT [FK_UserOperationClaims_OptionClaims] FOREIGN KEY ([OperationClaimID]) REFERENCES [dbo].[OperationClaims] ([OperationClaimID])
);



