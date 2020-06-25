# Project Title

Turtle Challenge problem solution.

## Getting Started

This solution uses AspNetCore 2.1 framework with C# 7.0. It is made of three projects:
0. Command line application that builds to TurtleChallenge.exe
0. Shared library that builds to TurtleChallenge.Library.dll
0. Unit tests library that builds to TurtleChallenge.Library.dll

Newtonsoft.Json is used to read json formatted data from files.

### Prerequisites
What things you need to install the software and how to install them

```
SDK: Microsoft.NETCore.App/2.1
```

## General usage
```sh
dotnet TurtleChallenge.dll game-settings.json moves.json
```

Sample board.config.json contains:
```json
{
  "boardWidth": 5,
  "boardHeight": 4,
  "startingDirection": "N",
  "startingPoint": {
    "x": 0,
    "y": 1
  },
  "exitPoint": {
    "x": 4,
    "y": 2
  },
  "mines": [
    {
      "x": 1,
      "y": 1
    },
    {
      "x": 3,
      "y": 1
    },
    {
      "x": 3,
      "y": 3
    }
  ]
}
```
N - direction north

Sample sequences.json contains:
```json
[
  "rm",
  "mrmm",
  "rrmrrrmmmmmr"
]
```
m - move

r - rotate

## Running the tests

Testing project uses XUnit framework. 

End-to-end WhenRunningAllSequencesTest outputs:
```sh
Sequence 1: Mine hit!
Sequence 2: Still in danger!
Sequence 3: Success!
```

## Authors

Dubliner.Sptephen

## License

TBD