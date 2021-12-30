# GraphStudy
Test project to study Avalonia UI and graph algorithms. 

## Basics
The application builds a graph consisting of specified number of vertices (nodes) and adds connecting edges between them. The vertices and edges can be selected and two vertices can be marked as start and end node. 

There are two algorithms that can be applied to the graph - Dijkstra shortest path search and random walk. More algorithms can be easily added.

There is no serialization, the application state is lost on exit.

## Usage
Start the program and:

- Click 'Generate' button to populate the canvas with random graph. 
- Select start and end node for path traversal. 
- Click 'Execute' to run algorithm to find path from start to end.
- Click 'Reset' to clear selection

## Preview
![Preview.](./preview.png "Preview.")
