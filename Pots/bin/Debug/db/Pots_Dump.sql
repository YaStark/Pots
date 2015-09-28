BEGIN TRANSACTION;

CREATE TABLE [PotPeriodFiller] (
    [PotKey] int NOT NULL,
    [PeriodKey] int NOT NULL,
    [FillerKey] int NOT NULL,
    [Quantity] real NOT NULL,
    PRIMARY KEY ([PotKey], [PeriodKey], [FillerKey]),
    FOREIGN KEY ([PotKey], [PeriodKey]) REFERENCES [PotPeriodAvailable] ([PotKey], [PeriodKey]) on delete cascade,
    FOREIGN KEY ([FillerKey]) REFERENCES [Fillers] ([FillerKey]) on delete cascade
);

CREATE TABLE [PotPeriodAvailable] (
    [PotKey] int NOT NULL,
    [PeriodKey] int NOT NULL,
    [Empty] int NOT NULL,
    [MethodKey] int NOT NULL default -1,
    [StateKey] int NOT NULL default -1,
    [MinutesSpent] real NOT NULL,
    PRIMARY KEY ([PotKey], [PeriodKey]),
    FOREIGN KEY ([PotKey], [PeriodKey]) REFERENCES [PotPeriod] ([PotKey], [PeriodKey]) on delete cascade,
    FOREIGN KEY ([MethodKey]) REFERENCES [Methods] ([MethodKey]) on delete set default,
    FOREIGN KEY ([StateKey]) REFERENCES [States] ([StateKey]) on delete set default
);
CREATE TABLE [PotPeriod] (
    [PotKey] int NOT NULL,
    [PeriodKey] int NOT NULL,
    [Availability] int NOT NULL,
    PRIMARY KEY ([PotKey], [PeriodKey]),
    FOREIGN KEY ([PeriodKey]) REFERENCES [Periods] ([PeriodKey]) on delete cascade,
    FOREIGN KEY ([PotKey]) REFERENCES [Pots] ([PotKey]) on delete cascade
);
CREATE TABLE [Methods] (
    [MethodKey] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [MName] text NOT NULL,
    [MDescription] text
);
CREATE TABLE [States] (
    [StateKey] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [SName] text NOT NULL,
    [SDescription] text
);
CREATE TABLE [Fillers] (
    [FillerKey] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [FName] text NOT NULL,
    [FDescription] text
);
CREATE TABLE [Pots] (
    [PotKey] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [PName] text NOT NULL UNIQUE,
    [PDescription] text
);
CREATE TABLE [Periods] (
    [PeriodKey] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [PTimeStamp] date NOT NULL UNIQUE,
    [PDescription] text
);

insert into methods values(1, "F", "Funnel");
insert into methods values(2, "T", "Tube");

insert into states values(1, "Opened", "Opened");
insert into states values(2, "Closed", "Closed");
insert into states values(3, "Sealed", "Sealed");
insert into states values(4, "Broken", "Broken");

insert into fillers values(1, "Hg", "Hydrargirum");
insert into fillers values(2, "Water", "Aqua");
