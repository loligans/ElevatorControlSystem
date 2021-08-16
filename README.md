# Elevator Control System
The elevator control system is a Web API for controlling elevators.

## Running the API
The quickest way to get a running instance of the API is by executing the following commands from the repository root directory.

_Note: This project requires `dotnet` version `5.0`_

From the repository root directory open a terminal and execute:  
`dotnet restore`  
`dotnet build`  
`dotnet run --project ./ElevatorControl.Api`

## Making changes
If you need to make changes, simply open the `ElevatorControlSystem.sln` in your preferred IDE.

The solution is structured into 4-projects:
1. `Elevator.Api` - The Web API for processing incoming requests.
2. `Elevator.Application` - The library for handling business logic on how the elevator should function.
3. `Elevator.Contract` - The bounded context of the Web API. It contains the request models that we expose to consumers.
4. `Elevator.Tests` - The unit tests that ensure the business logic in `Elevator.Application` is correct.

## Out of scope
- Authorization/Authentication
