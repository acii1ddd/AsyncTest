# AsyncTest

Demo comparing sync vs async processing performance.

## Run

```bash
dotnet run --project AsyncTest
```

## What it does

Processes 3 tasks (3 seconds each):
- **Sync**: Sequential (~9 seconds)
- **Async**: Concurrent (~3 seconds)

Shows timing difference between approaches.
