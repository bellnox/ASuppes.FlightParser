$('input.datepicker-input').datepicker();

var sfApp = angular.module('sfApp', []);

sfApp.service('SearchService', ['$http', '$q',
    function ($http, $q) {
        this.search = function (departurePlace, destinationPlace, departureDate, returnDate) {
            deferred = $q.defer();
            var requestData = {
                DeparturePlace: departurePlace,
                DestinationPlace: destinationPlace,
                DepartureDate: departureDate ? departureDate.toISOString().slice(0, 10) : null,
                DepartureLocalTime: departureDate ? departureDate.toISOString() : null,
                ReturnDate: returnDate ? returnDate.toISOString().slice(0, 10) : null,
                ReturnLocalTime: returnDate ? returnDate.toISOString() : null
            };
            $http.post('/api/Search/', requestData)
                .success(function (response) {
                    deferred.resolve({ error: null, results: response });
                })
                .error(function (error, status) {
                    deferred.resolve({ error: error, results: null });
                });
            return deferred.promise;
        }
    }
]);

sfApp.controller('SearchController', ['$scope', 'SearchService',
    function ($scope, searchService) {
        $scope.isLoading = false;
        $scope.errorMessage = null;
        $scope.searchResult = null;

        $scope.search = function () {
            var departureDate = $scope.departureDate ? new Date($scope.departureDate) : null;
            var returnDate = $scope.returnDate ? new Date($scope.returnDate) : null;
            $scope.isLoading = true;
            $scope.errorMessage = null;
            $scope.searchResult = null;
            searchService.search($scope.departurePlace, $scope.destinationPlace, departureDate, returnDate)
                .then(function (response) {
                    $scope.isLoading = false;
                    if (response) {
                        if (response.error) {
                            $scope.errorMessage = response.error;
                        }
                        else {
                            $scope.searchResult = response.results;
                        }
                    }
                });
        };
    }
]);