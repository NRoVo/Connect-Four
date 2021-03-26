# Connect-Four
A simple console game for two players of connecting four cells on the grid.

# What
The game of Connect Four is a simple and interesting game played on a grid with six rows and seven columns. Two players take turns taking tokens and dropping them into one of the 
seven columns, where it falls down to either the bottom if the column is currently empty or to the top of the pile if it is not. The goal of the game is to get four of your tokens 
in a row, up and down, side to side, or diagonally, before the other player does. The game is fully console based without any GUI.

# Features
This project has nothing special in sense of used technologies, only basic C# functionality. Here is the information about the code structure:

* ```enum TokenType```. Lists the states that the single cell on the grid can contain: Red (filled by red player), Black (filled by black player), Empty (not filled by anybody).
* ```class Position```. Represents the column chosen by player to drop the token on the highest empty cell. Translates the keyboard input from the player into position above the
column with which player wants to interact. Accepts numbers from 1 to 7 (all the columns from left to right) and arrow keys to switch between columns.
* ```class Board```. Central data structure of the game. Contains the array of ```TokenType``` values and ```Rows``` and ```Columns``` properties used to initialize mentioned array 
in constructor. Class has the functionality of populating the grid by empty ```TokenType``` states at the start of the game, adding the colored state by any of two players on the
empty cell, ensuring that the occupied cell cannot change it's state and checking if the column is already full of tokens and new tokens could not be added to it.
* ```class WinChecker```. The class checks if the four tokens of same color are connected horizontally vertically or diagonally and prints win conditions if it does.
* ```class Renderer```. Draws the current state of the grid.
