movieApp.controller('movieController', ['$scope', '$http', '$element', 'uiGridConstants', function ($scope, $http, $element, uiGridConstants) {
    GetMovieResponse();

    $scope.grdMovies = {
        enableFiltering: true,
        enableSorting: false,
        enableColumnMenus: false,
        columnDefs: [
            { field: "Id", type: "number", sort: { direction: uiGridConstants.ASC, priority: 1}},
            { field: "Title", name: "Movie Title"},
            { field: "YearReleased", name:  "Year Released"},
            { field: "Rating" },
            { field: "Delete", enableFiltering: false, cellEditableCondition: false, cellTemplate: '<button style="width: 100%" ng-click="grid.appScope.Delete(row.entity.Id, grid.appScope.GetMovieIndex(row.entity))">Delete</button>' }
        ]
    };

    $scope.GetMovieIndex = function(entity){
        return $scope.movies.map(function(m) { return m['Id']; }).indexOf(entity.Id);
    };

    $scope.Save = function (form) {
        var movie = { Title: $scope.Title, YearReleased: $scope.YearReleased, Rating: $scope.Rating };

        $http.post(getApiServer() + '/movie/', movie).then(function (response) {

            movie.Id = response.data;

            $scope.movies.push(movie);

            $scope.Title = '';
            $scope.YearReleased = '';
            $scope.Rating = '';

            if (form) {
              form.$setPristine();
              form.$setUntouched();
            }
        });
    };

    $scope.Delete = function(id, index){
      $http.delete(getApiServer() + '/movie?id=' + id).then(function(response){
          $scope.movies.splice(index, 1);
      });
    }

    function GetMovieResponse() {
        $http.get(getApiServer() + '/movie/').then(function (response) {
            $scope.movies = response.data;
            $scope.grdMovies.data = $scope.movies;
        });
    };
}]);