# Database setup

`DatabaseSetup.sql` creates the `OnestopEvents` database, its five application
tables, referential constraints, booking-conflict indexes and sample data. The
script is safe to run repeatedly because it creates objects and sample rows only
when they are absent.

It also creates three stored procedures used by the event form:

- `usp_Event_Create`
- `usp_Event_Update`
- `usp_Event_Delete`

## SQL Server Management Studio

1. Connect to `(LocalDB)\MSSQLLocalDB` or another SQL Server instance.
2. Open `DatabaseSetup.sql`.
3. Execute the complete script.

## Command line

```powershell
sqlcmd -S "(LocalDB)\MSSQLLocalDB" -E -i ".\database\DatabaseSetup.sql"
```

If a different instance is used, update the `OneStopEvents` connection string
in `ONESTOPEVENTS\App.config` before building the application.

## Verification

After setup, run `Verification.sql` against the same instance. It checks the
five-table schema, foreign keys, stored procedures, leading-zero phone storage,
booking-conflict protection, dependent-record protection, CRUD workflows and
the four date-filtered reports. Temporary test records are rolled back.
