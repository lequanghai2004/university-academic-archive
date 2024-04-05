@REM .\search.bat .\RobotNav-test.txt BreadthFirstSearch

@echo off
javac -d bin src/*.java
java -cp bin Program %1 %2