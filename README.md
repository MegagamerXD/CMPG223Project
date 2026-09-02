# One Stop Events

One Stop Events is a CMPG223 Windows Forms application for maintaining clients,
partner professions, service partners, venues and event bookings. It calculates
booking costs, prevents resource conflicts, produces date-filtered reports and
includes an offline help assistant.

**Student:** Wiid de Wet

## Main features

- Create, view, update and delete workflows for all five database entities.
- Shared validation for names, email, phone, website, descriptions, positive
  prices and venue capacity.
- Typed SQL parameters and deterministic disposal of database resources.
- Event creation, update and deletion through three stored procedures.
- Venue and partner double-booking prevention at application and database level.
- Dependency guards and confirmation before valid deletions.
- Four inclusive date-range reports.
- Integrated keyword-based help chatbot that works without an account, API key
  or internet connection.

## Technology

- C# Windows Forms
- .NET Framework 4.7.2
- Microsoft SQL Server LocalDB
- `System.Data.SqlClient`

## Data model

The `OnestopEvents` database contains five related tables:

- `CLIENTS`
- `PARTNER_PROFESSIONS`
- `PARTNERS`
- `VENUES`
- `EVENTS`

`EVENTS` references one client, venue and partner. `PARTNERS` references one
profession. Unique indexes prevent the same venue or partner from being assigned
to two events on the same date.

## Set up and run

1. Install Visual Studio 2022 with the .NET desktop development workload and
   .NET Framework 4.7.2 targeting pack.
2. Install SQL Server Express LocalDB.
3. Run `database/DatabaseSetup.sql` against `(LocalDB)\MSSQLLocalDB`.
   Alternatively, import `database/OnestopEvents.bacpac`.
4. Open `ONESTOPEVENTS.sln` in Visual Studio.
5. Select `Release`, rebuild the solution and run the `ONESTOPEVENTS` project.

The default database connection is the `OneStopEvents` entry in
`ONESTOPEVENTS/App.config`. Change only that value when using another SQL Server
instance.

## Verify the database

After setup, run `database/Verification.sql` against the same instance. It checks
the tables, foreign keys, procedures, leading-zero phone storage, conflict rules,
referential integrity, transactional CRUD and all four reports. A successful run
ends with:

```text
All database verification checks passed.
```

## Understand the implementation

- `Database.cs` owns the connection factory, query/command methods and typed
  parameter helpers used by every form.
- `ValidationHelper.cs` contains reusable input rules.
- `EventForm.cs` validates selections, checks availability, calculates
  `(R10 000 + venue price + profession cost) × 1.15`, and calls the event stored
  procedures.
- `Reporting.cs` selects one of four fixed parameterised queries and treats the
  chosen ending date as inclusive.
- `HelpAssistantForm.cs` normalises a question, counts topic-keyword matches and
  returns the highest-scoring verified answer.

## Documentation

The complete submission report is
[`CMPG223_43700292_Documentation.docx`](CMPG223_43700292_Documentation.docx).
It contains the physical data model, four primitive process models, data
dictionary, code examples, generated report screenshots, user manual,
verification evidence and a demonstration guide.
