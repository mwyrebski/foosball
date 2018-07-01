# Foosball

Simple web service with API for tracking game stats for three-set Foosball games.

## Domain

Domain of this application contains three major types:
* `Game` - representing a single game played by two teams
* `Set` - a part of a game consisting of goals
* `Goal` - which is a goal shoot by a team

```
    +------+      0..3 +-----+     0..10 +--------+
    | Game | --------> | Set | --------> | Goal   |
	|      |           |     |           | - Team |
    +------+           +-----+           +--------+
```

Basic assumptions:
* each `Game` consists of maximum number of 3 `Set`s
* each `Set` concists of maximum number of 10 `Goal`s
* team wins a `Set` when shooting 10 goals
* team wins a `Game` by winning any of two `Set`s
* `Game` can be in three states:
  - `NotStarted` - when a `Game` is newly created and until first goal is shot
  - `InProgress` - after first shot and until `Game` is `Finished`
  - `Finished` - when any of teams win whole `Game`

## Persistence

Foosball web service uses Sqlite as a persistence mechanism.

The connection string can be configured in the `appsettings.json` file.
By default data will be stored in `Foosball.db`.