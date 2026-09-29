# Docking Bay Bug Log

**Name:** Chris Estrada
**Date:** 9/29/30
**Assignment Name:** Bug Hunt Docking Bay
**What you did:** Went through the API and fixed errors noted below.
**Peer Review:** Valery Lot
**Review:** Still some bugs, the results aren't fully as expected. I've listed them below.

Ships: 01 GET /api/ships results in 405 Method Not Allowed

Pilots: 13 GET /api/pilots results in 405 Method Not Allowed
21 PUT /api/pilots/3/log-hours/0 gives 204 status code instead of 400 status code.
25 POST /api/pilots results in ID number still remaining at 4, not 5.

Log **every** bug as you fix it, one row per bug. There are **15**: 5 syntax, 4 runtime, 6 logic.

- **File**: which file the bug was in, e.g. `Services/ShipService.cs`
- **Line**: the line number where you made the fix
- **Kind**: `Syntax`, `Runtime` or `Logic`
- **What was wrong**: what the code did, and how you noticed (the build error, the exception, or the wrong result in Postman)
- **How I fixed it**: exactly what you changed

## Example (not one of the 15)

| # | File | Line | Kind | What was wrong | How I fixed it |
|---|------|------|------|----------------|----------------|
| 0 | `Services/ExampleService.cs` | 22 | Logic | `GET /api/example/cheapest` returned the **most** expensive item. The list was sorted with `OrderByDescending(i => i.Price)`, so the first item was the priciest. | Changed `OrderByDescending` to `OrderBy`. |

## My bugs

| # | File | Line | Kind | What was wrong | How I fixed it |
|---|------|------|------|----------------|----------------|
| 1 | Program.cs           |8 |Runtime | both builders were for IShipService and ShipService | changed line 8 to IPilotService and PilotService |
| 2 | ShipService.cs       |10 | Syntax |missing a comma after "Iron Comet"| added comma | 
| 3 | Ship.cs              | 6 | Syntax | missing a ; after string.Empty  | added ; |
| 4 | ShipsController.cs   | 32 | Syntax | missing a ] after [HttpGet("{id}") | added bracket ] |
| 5 | PilotsController.cs  | 9 | Syntax | misspelled PilotController | changed to PilotsController |
| 6 | IPilotService.cs      | 5 | Syntax | error is on Pilot Service line 9 list was not Pascal case  | corrected to List |
| 7 | PilotService.cs      | 28  | Logic | (p => p.IsOnDuty == true) still returns false checks | removed == true |
| 8 |ShipsController.cs   | 37 |Logic| if was != and should be == | changed to == |
| 9 |ShipService.cs       | 21 | Runtime | first was used instead of first or default and threw 500 error | changed to firstordefault|
| 10 |ShipsController.cs   | 49 | Logic | was returning 200 instead of 201 because there was no CreatedAtAction instruction | replaced Ok with CreatedAtAction(nameof(GetById), new { id = created.Id }, created);  |
| 11 |ShipService.cs       | 54 | Logic| Refuel was setting fuel at +100 instead of to 100 | changed += to = |
| 12 |ShipService.cs       | 62 | Runtime | show as 500 because missing the .ToList  | added .ToList |
| 13 |PilotService.cs      | 55 | Logic | hours was overwriting with an = instead of adding hours with a +=| changed to +=
| 14 |PilotService.cs      | 50 | Runtime | no false return so returned 500 |  added false return so 404 showed up
| 15 |PilotsController.cs  | 62 | Logic | 0 was not returning a 400 because the if was only < | Changed to <= 0

## Tally

| Kind | Found |
|------|-------|
| Syntax | _5__ / 5 |
| Runtime | _4_ / 4 |
| Logic | __6_ / 6 |

## Reflection

Answer each in 2–3 sentences.

1. Which bug took you the longest to find? What finally led you to it? the fuel count adding 100 to the count for only one ship was pretty infuriating. I finally saw that the line was equal instead of += so it was overwriting instead of adding
2. Pick one **runtime** error. What exception did it throw, and how did the error message help
   you find the line?
3. `DELETE /api/ships/3` crashed with `Collection was modified`. Why can't a `foreach` loop keep
   going after you remove something from the list it's looping over? because we have to copy the list so it doesn't change by using .ToList. The loop expects the collection to stay the same or else it will throw an error.
4. Every `/api/pilots` request crashed until you fixed one line in `Program.cs`. Explain what
   dependency injection was trying to do and why it failed.- Both of the builders were for ships and there should be one for ships and one for pilot. Dependency injection supplies the constructor dependencies and it cannot find them if the builder isn't registered in Program.cs
5. Several logic bugs were a single character, like `!=` versus `==`, `<` versus `<=`, or
   `=` versus `+=`. Why doesn't the compiler catch these? because they still return a valid code and work in some way even if the logic isn't working as intended. We need to find and catch these.
6. Some bugs hid until you fixed a different one. Give one example. the first 3 syntax errors were because the proper separation or endpoints were not used on the line. after those were fixes, two more showed up that were spelling or grammar errors.

