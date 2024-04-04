@REM .\search.bat .\RobotNav-test.txt BreadthFirstSearch

@echo off
javac -d bin *.java
java -cp bin Program %1 %2