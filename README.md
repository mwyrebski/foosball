# Foosball

Simple API for tracking game stats for three-set Foosball games.

## Diagram

Basic assumptions:
* each `Game` consists of maximum number of 3 `Set`s
* each `Set` concists of maximum number of 10 `Goal`s

```
    +------+      0..3 +-----+     0..10 +------+
    | Game | --------> | Set | --------> | Goal |
    +------+           +-----+           +------+
```
