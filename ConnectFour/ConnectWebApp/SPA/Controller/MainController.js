var MainController = function ($scope)
{
    $scope.models = {
        rows: 6,
        columns: 7,
        rowIds: [],
        columnIds: [],
        gameBoard: [],
        localtions: [
            { id: "1", Location: "here 1" },
            { id: "2", Location: "here 2" },
            { id: "3", Location: "here 3" },
        ]
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
   

    //$scope.selectedLocation = $scope.models.localtions[0];

    $scope.myVariable = "hello";

    $scope.changeLocation = function (loc) {
        $scope.selectedLocation = loc;
    }

    $scope.inputMove = function (columId)
    {

        for (i = 0; i < $scope.models.rows; i++) {

            $scope.models.gameBoard[i][columId] = "O";
        }
        //$scope.$apply(function () {
        //    for (i = 0; i < $scope.models.rows; i++) {

        //        $scope.gameBoard[i][columnId] = "O";
        //    }
        //});
    }
}

MainController.$inject = ['$scope'];