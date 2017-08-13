var MainController = function ($scope, $http)
{
    $scope.models = {
        rows: 6,
        columns: 7,
        rowIds: [],
        columnIds: [],
        gameBoard: [],
    };

    $scope.selectedOponent = "Human";
    $scope.gameInstruction = "Player 1 click a column number to start";

    var boardDimensionUrl = location.origin + "/api/BoardDimension"
    $scope.getDimension = function () {
        $http.get(boardDimensionUrl).then(function (data) {
            $scope.boardDimensionTest = data.data;
            
        });
    };

    for (i = 0; i < $scope.models.columns; i++)
    {
        $scope.models.columnIds[i] = i;
    }

    var board = new Array($scope.models.rows);
    for (i = 0; i < $scope.models.rows; i++)
    {
        board[i] = new Array($scope.models.columns);
        for (j = 0; j < $scope.models.columns; j++) {
            board[i][j] = "";
        }
        
    }
    $scope.models.gameBoard = board;

    // Process user change oponent
    $scope.changeOponent = function () {


        var moveUrl = location.origin + "/api/ChangeOponent/" + $scope.selectedOponent;

        $http.put(moveUrl, JSON.stringify($scope.selectedOponent))
            .then(function (response) {
                $scope.gameInstruction = "Opponent changed to " + $scope.selectedOponent;
            });
      
    }

    // Process user change oponent
    $scope.reset = function () {

        var moveUrl = location.origin + "/api/ResetGame";

        $http.post(moveUrl, JSON.stringify("1"))
            .then(function (response) {
                ResetBoard();
                $scope.gameInstruction = " Game Cleared";
            });
    }

    // Process user input
    $scope.inputMove = function (columnId)
    {
        var moveUrl = location.origin + "/api/Move/" + columnId;
    
        $http.put(moveUrl, JSON.stringify(columnId))
            .then(function (response) {
                if (response.data)
                {
                    $scope.boardDimensionTest = response;

                    var moveResultStatus = response.data.MoveResultStatus;
                    var move = response.data.Move;
                    if (moveResultStatus == 0) {
                        var rowIndex = move.RowIndex;
                        var colIndex = move.ColumnIndex;
                        var player = move.Player;
                        var playerId = player.PlayerID;
                        $scope.models.gameBoard[rowIndex][colIndex] = playerId;
                        $scope.gameInstruction = "Next player please make a move";
                    }
                    else if (moveResultStatus == 1)
                    {
                        var rowIndex = move.RowIndex;
                        var colIndex = move.ColumnIndex;
                        var player = move.Player;
                        var playerId = player.PlayerID;
                        $scope.models.gameBoard[rowIndex][colIndex] = playerId;
                        $scope.gameInstruction = player.PlayerName + " has won the game in " + move.SequenceNumber + " moves!";
                    }
                    else if (moveResultStatus == 4)
                    {
                        $scope.gameInstruction = "Invalid move, please try again.";
                    }
                    else if (moveResultStatus == 3)
                    {
                        $scope.gameInstruction = "Tie game! Good luck next time!";
                    }
                }
                else
                {
                    $scope.gameInstruction = "Input request failed";
                }
                

            });

    }

    // Utility functions
    function ResetBoard()
    {
        for (i = 0; i < $scope.models.rows; i++) {
            for (j = 0; j < $scope.models.columns; j++) {
                $scope.models.gameBoard[i][j] = "";
            }

        }
    }
}

MainController.$inject = ['$scope', '$http'];
