### To run the project:

Move to this directory and run the following command, replace the map data file and search algorithm correspondingly

```bash
.\search.bat .\RobotNav-test.txt BreadthFirstSearch
.\search.bat .\RobotNav-test.txt AStarSearch

### Description:

The environment is an NxM grid (where N > 1 and M > 1) with a number of walls occupying some cells (marked as grey cells). The robot is initially located 
in one of the empty cells and required to find a path to visit one of the designated cells of the grid.

Assume that the cells of the grid are located by their coordinates with the leftmost top cell being considered to be at the coordinate (0, 0). A wall is a rectangle whose leftmost top corner occupies a cell (x,y) and whose 
width (w) and height (h) capture its size. For instance, the above environment can be expressed by the following specification: 

[5,11]         

(0,1)          

(7,0) | (10,3)  

(2,0,2,2)      

(8,0,1,2)       

(10,0,1,1)      

(2,3,1,2) 

(3,4,3,1) 

(9,3,1,1) 

(8,4,2,1) 

- Grid Size: [5,11] (5 rows and 11 columns)
- Initial State: (0,1) (coordinates of the red cell)
- Goal States: (7,0) and (10,3) (coordinates of the green cells)
- Walls:
  - (2,0,2,2) (square wall with top-left corner at (2,0), 2 cells wide and 2 cells high)
  - (8,0,1,2)
  - (10,0,1,1)
  - (2,3,1,2)
  - (3,4,3,1)
  - (9,3,1,1)
  - (8,4,2,1)
