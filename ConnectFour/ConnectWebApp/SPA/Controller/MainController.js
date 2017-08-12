var MainController = function ($scope, $http)
{
    $scope.models = {
        rows: 6,
        columns: 7,
        rowIds: [],
        columnIds: [],
        gameBoard: [],
    };
    $scope.boardDimensionTest = "Nothing now";

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
            board[i][j] = "#";
        }
        
    }
    $scope.models.gameBoard = board;
    
   
    $scope.inputMove = function (columnId)
    {
        var moveUrl = location.origin + "/api/Move/" + columnId;
    
        $http.put(moveUrl, JSON.stringify(columnId))
            .then(function (response) {
                if (response.data)
                {

                    $scope.boardDimensionTest = response;

                    var moveResultStatus = response.data.MoveResultStatus;

                    if (moveResultStatus == 0) {
                        var rowIndex = response.data.Move.RowIndex;
                        var player = response.data.Move.Player;
                        var playerId = player.PlayerID;
                        //var playerID = response.data.Player.PlayerID;
                        $scope.models.gameBoard[rowIndex][columnId] = playerId;
                    }

                    

                }
                else
                {
                    $scope.boardDimensionTest = "Input request failed";
                }
                

            });
        
        //for (i = $scope.models.rows - 1; i >= 0; i--) {
        //    if ($scope.models.gameBoard[i][columnId] === "#") {
        //        $scope.models.gameBoard[i][columnId] = "O";
        //        break;
        //    }
        //}
    }
}

MainController.$inject = ['$scope', '$http'];
