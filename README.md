# ConnectFour

ConnectWebAPP- is the SPA, and has full functionalities
  * Human vs Human is implemented
  * Human vs an Block AI is implemented
  * Humam vs an Boss AI is implemented. Game will first search for immediate winning move, then considers blocking human player from winning. There could be additional AI strategies, such as depth search.
  * Human will always take a first move
  * User can reset game at anytime. Recommend doing this every time user switchs opponents, when there are moves on the board
  * Win and Tie scenarios are implemented
  * Unit tests are written to test Block AI logic
  
Connect4ConsoleUI- is the console version of the game. Currently only allows Player vs. Player game
  Win and Tie scenarios are implemented

Common-defines data classes and interfaces shared by all other projects

GameEngine - this is the core gameing logic used by both ConnectWebAPP and Connect4ConsoleUI

Players - this implements different player types: human player, AIPlayer, BossAIPlayer

PlayerUnitTests - unit tests to test AI player logics that generate next move, based on current board data.

Persistence to DB is started, but not done. The idea is to save to a no-sql DB for simplicity.
