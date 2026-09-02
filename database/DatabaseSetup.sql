/*
    One Stop Events database setup
    Safe to run more than once: tables and sample rows are created only when absent.
*/

USE [master];
GO

IF DB_ID(N'OnestopEvents') IS NULL
BEGIN
    CREATE DATABASE [OnestopEvents];
END;
GO

USE [OnestopEvents];
GO

IF OBJECT_ID(N'dbo.CLIENTS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.CLIENTS
    (
        Client_ID INT IDENTITY(1, 1) CONSTRAINT PK_CLIENTS PRIMARY KEY,
        Client_FirstName VARCHAR(50) NOT NULL,
        Client_SurName VARCHAR(50) NOT NULL,
        Client_Email VARCHAR(100) NOT NULL,
        Client_ContactNumber VARCHAR(10) NOT NULL,
        CONSTRAINT CK_CLIENTS_Email CHECK (Client_Email LIKE '%_@_%._%'),
        CONSTRAINT CK_CLIENTS_Contact CHECK
            (LEN(Client_ContactNumber) = 10 AND Client_ContactNumber NOT LIKE '%[^0-9]%')
    );
END;
GO

IF OBJECT_ID(N'dbo.PARTNER_PROFESSIONS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PARTNER_PROFESSIONS
    (
        Profession_ID INT IDENTITY(1, 1) CONSTRAINT PK_PARTNER_PROFESSIONS PRIMARY KEY,
        Partner_Profession VARCHAR(150) NOT NULL,
        Partner_Cost MONEY NOT NULL,
        CONSTRAINT CK_PARTNER_PROFESSIONS_Cost CHECK (Partner_Cost > 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.VENUES', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.VENUES
    (
        Venue_ID INT IDENTITY(1, 1) CONSTRAINT PK_VENUES PRIMARY KEY,
        Venue_Name VARCHAR(50) NOT NULL,
        Venue_HasKitchen CHAR(1) NOT NULL,
        Venue_Size INT NOT NULL,
        Venue_Description VARCHAR(255) NOT NULL,
        Venue_Rating DECIMAL(4, 2) NULL,
        Venue_Price MONEY NOT NULL,
        Venue_Address VARCHAR(255) NOT NULL,
        CONSTRAINT CK_VENUES_Kitchen CHECK (Venue_HasKitchen IN ('Y', 'N')),
        CONSTRAINT CK_VENUES_Size CHECK (Venue_Size > 0),
        CONSTRAINT CK_VENUES_Rating CHECK
            (Venue_Rating IS NULL OR (Venue_Rating >= 0 AND Venue_Rating <= 10)),
        CONSTRAINT CK_VENUES_Price CHECK (Venue_Price > 0)
    );
END;
GO

IF OBJECT_ID(N'dbo.PARTNERS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.PARTNERS
    (
        Partner_ID INT IDENTITY(1, 1) CONSTRAINT PK_PARTNERS PRIMARY KEY,
        Profession_ID INT NOT NULL,
        Partner_FirstName VARCHAR(50) NOT NULL,
        Partner_SurName VARCHAR(50) NOT NULL,
        Partner_Email VARCHAR(100) NOT NULL,
        Partner_Domain VARCHAR(100) NOT NULL,
        Partner_ContactNumber VARCHAR(15) NOT NULL,
        CONSTRAINT FK_PARTNERS_PROFESSIONS FOREIGN KEY (Profession_ID)
            REFERENCES dbo.PARTNER_PROFESSIONS (Profession_ID),
        CONSTRAINT CK_PARTNERS_Email CHECK (Partner_Email LIKE '%_@_%._%'),
        CONSTRAINT CK_PARTNERS_Contact CHECK
            (LEN(Partner_ContactNumber) = 10 AND Partner_ContactNumber NOT LIKE '%[^0-9]%')
    );
END;
GO

IF OBJECT_ID(N'dbo.EVENTS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.EVENTS
    (
        Event_ID INT IDENTITY(1, 1) CONSTRAINT PK_EVENTS PRIMARY KEY,
        Event_Name VARCHAR(50) NOT NULL,
        Venue_ID INT NOT NULL,
        Client_ID INT NOT NULL,
        Partner_ID INT NOT NULL,
        Event_Date DATE NOT NULL,
        Event_Description VARCHAR(255) NOT NULL,
        Event_Cost MONEY NOT NULL,
        CONSTRAINT FK_EVENTS_VENUES FOREIGN KEY (Venue_ID) REFERENCES dbo.VENUES (Venue_ID),
        CONSTRAINT FK_EVENTS_CLIENTS FOREIGN KEY (Client_ID) REFERENCES dbo.CLIENTS (Client_ID),
        CONSTRAINT FK_EVENTS_PARTNERS FOREIGN KEY (Partner_ID) REFERENCES dbo.PARTNERS (Partner_ID),
        CONSTRAINT CK_EVENTS_Cost CHECK (Event_Cost >= 0)
    );
END;
GO

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.EVENTS') AND name = N'UX_EVENTS_Venue_Date'
)
BEGIN
    CREATE UNIQUE INDEX UX_EVENTS_Venue_Date ON dbo.EVENTS (Venue_ID, Event_Date);
END;
GO

IF NOT EXISTS
(
    SELECT 1 FROM sys.indexes
    WHERE object_id = OBJECT_ID(N'dbo.EVENTS') AND name = N'UX_EVENTS_Partner_Date'
)
BEGIN
    CREATE UNIQUE INDEX UX_EVENTS_Partner_Date ON dbo.EVENTS (Partner_ID, Event_Date);
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.CLIENTS)
BEGIN
    INSERT dbo.CLIENTS
        (Client_FirstName, Client_SurName, Client_Email, Client_ContactNumber)
    VALUES
        ('John', 'Doe', 'john.doe@example.com', '0712345678'),
        ('Jane', 'Smith', 'jane.smith@example.com', '0723456789'),
        ('Alice', 'Johnson', 'alice.johnson@example.com', '0734567890'),
        ('Bob', 'Brown', 'bob.brown@example.com', '0745678901');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.PARTNER_PROFESSIONS)
BEGIN
    INSERT dbo.PARTNER_PROFESSIONS (Partner_Profession, Partner_Cost)
    VALUES
        ('Photographer', 500.00),
        ('Caterer', 1500.00),
        ('Decorator', 800.00),
        ('DJ', 600.00);
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.VENUES)
BEGIN
    INSERT dbo.VENUES
        (Venue_Name, Venue_HasKitchen, Venue_Size, Venue_Description,
         Venue_Rating, Venue_Price, Venue_Address)
    VALUES
        ('The Grand Hall', 'Y', 300, 'Spacious hall with modern amenities', 9.00, 2000.00, '123 Grand St, Cityville'),
        ('Riverside Pavilion', 'N', 150, 'Elegant pavilion by the river', 8.50, 1500.00, '456 Riverside Dr, Townsville'),
        ('Country Estate', 'Y', 500, 'Rustic estate with beautiful gardens', 9.50, 3000.00, '789 Country Rd, Countryside'),
        ('City Loft', 'N', 100, 'Trendy loft in the city centre', 7.75, 1200.00, '101 City Ave, Metropolis');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.PARTNERS)
BEGIN
    INSERT dbo.PARTNERS
        (Profession_ID, Partner_FirstName, Partner_SurName, Partner_Email,
         Partner_Domain, Partner_ContactNumber)
    VALUES
        (1, 'Emily', 'Clark', 'emily.clark@example.com', 'emilyclarkphoto.com', '0756789012'),
        (2, 'Michael', 'Davis', 'michael.davis@example.com', 'michaeldavis.cater.com', '0767890123'),
        (3, 'Olivia', 'Martinez', 'olivia.martinez@example.com', 'oliviamartinez.decor.com', '0778901234'),
        (4, 'James', 'Wilson', 'james.wilson@example.com', 'jameswilson.dj.com', '0789012345');
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.EVENTS)
BEGIN
    INSERT dbo.EVENTS
        (Event_Name, Venue_ID, Client_ID, Partner_ID, Event_Date, Event_Description, Event_Cost)
    VALUES
        ('Summer Gala', 1, 1, 1, '2026-09-15', 'Annual gala with dinner and entertainment', 14375.00),
        ('Wedding Reception', 3, 2, 2, '2026-09-20', 'Wedding reception at the country estate', 16675.00),
        ('Corporate Meeting', 2, 3, 3, '2026-10-10', 'Business meeting with refreshments and decor', 14145.00),
        ('Birthday Party', 4, 4, 4, '2026-10-15', 'Birthday party with a DJ and refreshments', 13570.00);
END;
GO

SELECT name AS TableName
FROM sys.tables
WHERE name IN ('CLIENTS', 'PARTNERS', 'PARTNER_PROFESSIONS', 'VENUES', 'EVENTS')
ORDER BY name;
GO
