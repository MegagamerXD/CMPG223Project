# One Stop Events

One Stop Events is a CMPG223 Windows Forms application for maintaining clients,
partners, partner professions, venues and event bookings. It also provides
date-filtered operational reports.

**Student:** Wiid de Wet

## Technology

- C# Windows Forms
- .NET Framework 4.7.2
- Microsoft SQL Server

## Open and build

1. Create the database by running `database/DatabaseSetup.sql` against
   `(LocalDB)\MSSQLLocalDB`, or import `database/OnestopEvents.bacpac`.
2. Open `ONESTOPEVENTS.sln` in Visual Studio.
3. Build the solution using the `Release` configuration.
4. Run the `ONESTOPEVENTS` project.

The default database connection is stored under `OneStopEvents` in
`ONESTOPEVENTS/App.config`. Change only that setting when using another SQL
Server instance.

The project documentation is included as
`CMPG223_43700292_Documentation.docx`.
