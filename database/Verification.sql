/*
    One Stop Events verification
    Run after DatabaseSetup.sql. Test data is wrapped in a transaction and rolled back.
*/

USE [OnestopEvents];
GO

SET NOCOUNT ON;
SET XACT_ABORT OFF;

IF (SELECT COUNT(*) FROM sys.tables
    WHERE name IN ('CLIENTS', 'PARTNERS', 'PARTNER_PROFESSIONS', 'VENUES', 'EVENTS')) <> 5
    THROW 51000, 'Five-table schema verification failed.', 1;

IF (SELECT COUNT(*) FROM sys.foreign_keys
    WHERE parent_object_id IN
        (OBJECT_ID('dbo.PARTNERS'), OBJECT_ID('dbo.EVENTS'))) <> 4
    THROW 51000, 'Foreign-key verification failed.', 1;

IF (SELECT COUNT(*) FROM sys.procedures
    WHERE name IN ('usp_Event_Create', 'usp_Event_Update', 'usp_Event_Delete')) <> 3
    THROW 51000, 'Stored-procedure verification failed.', 1;

IF NOT EXISTS
(
    SELECT 1 FROM dbo.CLIENTS
    WHERE Client_ContactNumber LIKE '0%'
      AND LEN(Client_ContactNumber) = 10
)
    THROW 51000, 'Leading-zero phone verification failed.', 1;

DECLARE @ExistingEventId INT;
DECLARE @ExistingVenueId INT;
DECLARE @ExistingClientId INT;
DECLARE @ExistingPartnerId INT;
DECLARE @ExistingEventDate DATE;

SELECT TOP (1)
    @ExistingEventId = Event_ID,
    @ExistingVenueId = Venue_ID,
    @ExistingClientId = Client_ID,
    @ExistingPartnerId = Partner_ID,
    @ExistingEventDate = Event_Date
FROM dbo.EVENTS
ORDER BY Event_ID;

BEGIN TRY
    EXEC dbo.usp_Event_Create
        @EventName = 'Conflict Test',
        @VenueId = @ExistingVenueId,
        @ClientId = @ExistingClientId,
        @PartnerId = @ExistingPartnerId,
        @EventDate = @ExistingEventDate,
        @Description = 'This insert must be rejected.',
        @EventCost = 1.00;
    THROW 51000, 'Booking-conflict verification failed.', 1;
END TRY
BEGIN CATCH
    IF ERROR_NUMBER() NOT IN (50001, 50002)
        THROW;
END CATCH;

BEGIN TRY
    DELETE dbo.CLIENTS WHERE Client_ID = @ExistingClientId;
    THROW 51000, 'Referenced-client deletion verification failed.', 1;
END TRY
BEGIN CATCH
    IF ERROR_NUMBER() <> 547
        THROW;
END CATCH;

BEGIN TRANSACTION;

BEGIN TRY
    INSERT dbo.PARTNER_PROFESSIONS (Partner_Profession, Partner_Cost)
    VALUES ('Verification Specialist', 250.00);
    DECLARE @ProfessionId INT = SCOPE_IDENTITY();

    INSERT dbo.CLIENTS
        (Client_FirstName, Client_SurName, Client_Email, Client_ContactNumber)
    VALUES ('Test', 'Client', 'test.client@example.com', '0123456789');
    DECLARE @ClientId INT = SCOPE_IDENTITY();

    INSERT dbo.VENUES
        (Venue_Name, Venue_HasKitchen, Venue_Size, Venue_Description,
         Venue_Rating, Venue_Price, Venue_Address)
    VALUES
        ('Verification Venue', 'N', 80, 'Temporary venue used by the verification script.',
         NULL, 750.00, '1 Verification Road');
    DECLARE @VenueId INT = SCOPE_IDENTITY();

    INSERT dbo.PARTNERS
        (Profession_ID, Partner_FirstName, Partner_SurName, Partner_Email,
         Partner_Domain, Partner_ContactNumber)
    VALUES
        (@ProfessionId, 'Test', 'Partner', 'test.partner@example.com',
         'example.com', '0987654321');
    DECLARE @PartnerId INT = SCOPE_IDENTITY();

    EXEC dbo.usp_Event_Create
        @EventName = 'Verification Event',
        @VenueId = @VenueId,
        @ClientId = @ClientId,
        @PartnerId = @PartnerId,
        @EventDate = '2099-12-31',
        @Description = 'Temporary event used by the verification script.',
        @EventCost = 12650.00;
    DECLARE @EventId INT;
    SELECT @EventId = Event_ID
    FROM dbo.EVENTS
    WHERE Event_Name = 'Verification Event'
      AND Venue_ID = @VenueId
      AND Event_Date = '2099-12-31';

    UPDATE dbo.CLIENTS SET Client_SurName = 'Client Updated' WHERE Client_ID = @ClientId;
    UPDATE dbo.VENUES
    SET Venue_Size = 90,
        Venue_Rating = 9.75
    WHERE Venue_ID = @VenueId;
    UPDATE dbo.PARTNERS SET Partner_SurName = 'Partner Updated' WHERE Partner_ID = @PartnerId;
    UPDATE dbo.PARTNER_PROFESSIONS SET Partner_Cost = 275.00 WHERE Profession_ID = @ProfessionId;

    EXEC dbo.usp_Event_Update
        @EventId = @EventId,
        @EventName = 'Verification Event Updated',
        @VenueId = @VenueId,
        @ClientId = @ClientId,
        @PartnerId = @PartnerId,
        @EventDate = '2099-12-31',
        @Description = 'Updated temporary verification event.',
        @EventCost = 12678.75;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.EVENTS AS E
        INNER JOIN dbo.CLIENTS AS C ON E.Client_ID = C.Client_ID
        INNER JOIN dbo.VENUES AS V ON E.Venue_ID = V.Venue_ID
        INNER JOIN dbo.PARTNERS AS P ON E.Partner_ID = P.Partner_ID
        INNER JOIN dbo.PARTNER_PROFESSIONS AS PP ON P.Profession_ID = PP.Profession_ID
        WHERE E.Event_ID = @EventId
          AND C.Client_ContactNumber = '0123456789'
          AND C.Client_SurName = 'Client Updated'
          AND V.Venue_Size = 90
          AND V.Venue_Rating = 9.75
          AND P.Partner_SurName = 'Partner Updated'
          AND PP.Partner_Cost = 275.00
    )
        THROW 51000, 'CRUD update verification failed.', 1;

    EXEC dbo.usp_Event_Delete @EventId = @EventId;
    DELETE dbo.PARTNERS WHERE Partner_ID = @PartnerId;
    DELETE dbo.VENUES WHERE Venue_ID = @VenueId;
    DELETE dbo.CLIENTS WHERE Client_ID = @ClientId;
    DELETE dbo.PARTNER_PROFESSIONS WHERE Profession_ID = @ProfessionId;

    ROLLBACK TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;

DECLARE @StartDate DATE = '2026-01-01';
DECLARE @EndDateExclusive DATE = '2027-01-01';

SELECT 'Highest-value partners' AS ReportName, COUNT(*) AS ResultRows
FROM
(
    SELECT P.Partner_ID
    FROM dbo.EVENTS AS E
    INNER JOIN dbo.PARTNERS AS P ON E.Partner_ID = P.Partner_ID
    WHERE E.Event_Date >= @StartDate AND E.Event_Date < @EndDateExclusive
    GROUP BY P.Partner_ID
) AS R
UNION ALL
SELECT 'Most popular venues', COUNT(*)
FROM
(
    SELECT V.Venue_ID
    FROM dbo.EVENTS AS E
    INNER JOIN dbo.VENUES AS V ON E.Venue_ID = V.Venue_ID
    WHERE E.Event_Date >= @StartDate AND E.Event_Date < @EndDateExclusive
    GROUP BY V.Venue_ID
) AS R
UNION ALL
SELECT 'Highest-value events', COUNT(*)
FROM dbo.EVENTS AS E
WHERE E.Event_Date >= @StartDate AND E.Event_Date < @EndDateExclusive
UNION ALL
SELECT 'Highest-spending clients', COUNT(*)
FROM
(
    SELECT C.Client_ID
    FROM dbo.EVENTS AS E
    INNER JOIN dbo.CLIENTS AS C ON E.Client_ID = C.Client_ID
    WHERE E.Event_Date >= @StartDate AND E.Event_Date < @EndDateExclusive
    GROUP BY C.Client_ID
) AS R;

PRINT 'All database verification checks passed.';
GO
