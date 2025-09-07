REM Use start /b to run in background in the same console
@REM /b runs the command in the same terminal, but in the background.
@REM Output from both commands may mix in the console.

@echo off

REM CleanArchitecture API
start  /b kubectl port-forward service/clean-architecture-api-service 30080:80 30443:443

REM vscode API
start  /b kubectl port-forward service/vscode-api-service 30002:80

pause