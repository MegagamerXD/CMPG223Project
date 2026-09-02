# Database setup

`DatabaseSetup.sql` creates the `OnestopEvents` database, its five application
tables, referential constraints, booking-conflict indexes and sample data. The
script is safe to run repeatedly because it creates objects and sample rows only
when they are absent.

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
