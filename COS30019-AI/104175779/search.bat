@REM .\search.bat .\tests\RobotNav-test.txt BreadthFirstSearch

@echo off
javac -Xlint:deprecation -d bin src/*.java
java -cp bin Program %1 %2
