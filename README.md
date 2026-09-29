



# STARBASE-7 Docking Bay API: Bug Hunt

Remember Jacob, the programmer who left STARBASE-7's systems-check terminal in a mess? Before he
ran off, he also built the station's **Docking Bay API** — the system that tracks which ships are
parked at the station and which pilots are flying them.

It is worse than the terminal. It will not even compile.

Jacob didn't leave a single comment in the code. The only description of what the API is supposed
to do is the **API spec** and the **Expected results** checklist in this README.

Your mission: **find and fix every bug** so the API behaves exactly the way the spec says.

---

## What is in this folder

| File | What it is |
|------|------------|
| `DockingBayApi/` | The broken API. **Bugs can be in any `.cs` file inside it.** |
| `README.md` | This file. Read all of it before you start. |
| `BUG_LOG.md` | A table you fill in with every bug you find and fix. |
| `DockingBay.postman_collection.json` | Every request from the checklist, ready to import into Postman. |

### The code

| File | What it does |
|------|--------------|
| `Models/Ship.cs` | One ship |
| `Models/Pilot.cs` | One pilot |
| `Services/IShipService.cs` | The promises the ship service makes |
| `Services/IPilotService.cs` | The promises the pilot service makes |
| `Services/ShipService.cs` | Keeps the list of ships and does the work |
| `Services/PilotService.cs` | Keeps the list of pilots and does the work |
| `Controllers/ShipsController.cs` | The `/api/ships` endpoints |
| `Controllers/PilotsController.cs` | The `/api/pilots` endpoints |
| `Program.cs` | Startup and service registration |

---

## The three kinds of bugs

There are **15 bugs** hidden in the API:

| Kind | How many | How you'll know |
|------|----------|-----------------|
| **Syntax errors** | 5 | The API will not build. `dotnet build` prints an `error CS…` with the **file name and line number**. |
| **Runtime errors** | 4 | It builds and starts, but a request **crashes**: Postman shows **`500`**, with the exception in the response body. Read it in the terminal too. |
| **Logic errors** | 6 | Nothing crashes, but you get the **wrong status code** or the **wrong data** compared with the Expected results. |

Some bugs hide behind others. Fixing one compile error can reveal another, and some requests keep
crashing until a bug somewhere *else* is fixed. That is normal. Keep going.

---

## How to run the API

Open a terminal in the `DockingBayApi` folder:

```bash
dotnet build
```

Once it builds with no errors, start it:

```bash
dotnet run
```

The API runs at **http://localhost:5120**. Leave that terminal open while you test in Postman.

- **To stop it:** press **Ctrl + C** in the terminal.
- **To pick up your code changes:** stop it and `dotnet run` again.

> **The data resets every time you restart.** The ships and pilots live in a list in memory, so
> every restart puts them back to the starting data. Always restart before working through the
> Expected results checklist.

---

## The rules

1. **Fix, do not rewrite.** Every bug is fixed by changing, adding, or removing a small piece of
   code on or near one line. Never delete a whole method and write your own version.
2. **The spec is the boss.** There are no comments in the code. If you're not sure what a method
   is supposed to do, check the **API spec** below, not what the code currently does.
3. **Do not change the starting data** (the ships and pilots in the services) or any text inside
   quotes, unless the bug is *in* that line — for example, a missing comma.
4. **Only use what we have learned:** controllers, models, interfaces, services, dependency
   injection, `List<T>`, `if / else`, loops, and `Where`, `FirstOrDefault`, `OrderBy` and `Sum`.
5. **Log every bug** in `BUG_LOG.md` as you fix it. One row per bug.

---

