myApp.controller('Tipo2Ctrl', function ($scope, $http, $location) {
    // Controller-specific code goes here

    $(".mainContainer").show();

    $scope.$on(
        "$routeChangeSuccess",
        function ($currentRoute, $previousRoute) {
            //console.log('asdasd');
        }
    );

    //$scope.data = angular.fromJson(viajesJson);
    $scope.data = viajesJson;

    $scope.ciudad = '';
    $scope.viaje = '';

    $scope.tagsSelected = [];

    $scope.presupuesto = {};
    $scope.presupuesto.from = Math.min.apply(Math, $scope.data.map(function (o) { return o.Precio; }));
    $scope.presupuesto.min = $scope.presupuesto.from;
    $scope.presupuesto.to = Math.max.apply(Math, $scope.data.map(function (o) { return o.Precio; }));
    $scope.presupuesto.max = $scope.presupuesto.to;

    //agarro las rutas creadas
    var parameters = $location.$$path.split('/');
    if (parameters.length == 9) {
        //presupuesto
        var presupuesto = parameters[2].split('-');
        $scope.presupuesto.from = presupuesto[0];
        $scope.presupuesto.to = presupuesto[1];

        //tags
        var tags = parameters[3].split(',');

        $http.post("/tag/get", {
            tags: tags
            })
            .success(function (data) {
                $scope.tagsSelected = data.tags;
            })
            .error(function (error) {
                $scope.data.orderError = error;
            }).finally(function () {

            });

        var nombre = parameters[6];
        if (nombre != 'all') {
            $scope.viaje = nombre;
            $("#nombre").val(nombre);
        }

        var destino = parameters[8];
        $scope.ciudad = '';
        if (destino != 'all') {
            $scope.ciudad = destino;
            $("#destinos").val(destino);
        }
    }

    $scope.addTag = function (url, nombre) {
        var obj = getObjects($scope.tagsSelected, 'Url', url);
        if (obj.length == 0) {
            var tag = {};
            tag.Url = url;
            tag.Nombre = nombre;
            $scope.tagsSelected.push(tag);
        }
    }

    $scope.removeTag = function (index) {
        $scope.tagsSelected.splice(index, 1);
    }

    $scope.removeTags = function () {
        $scope.tagsSelected = [];
    }

    $scope.categoryFilterFn = function (item) {
        var existe = true;
        if ($scope.tagsSelected.length > 0) {
            existe = true;
            angular.forEach($scope.tagsSelected, function (value, key) {
                var obj = getObjects(item.Tags, 'Nombre', value.Nombre);
                if (obj.length == 0)
                    existe = false;
            });
        }

        return item.Precio >= $scope.presupuesto.from && item.Precio <= $scope.presupuesto.to && (item.CiudadUrl == $scope.ciudad || $scope.ciudad == '') && (item.Url == $scope.viaje || $scope.viaje == '') && existe;
    }

    $scope.$watchGroup(['presupuesto.from'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.$watchGroup(['presupuesto.to'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.$watchGroup(['tagsSelected.length'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.$watchGroup(['ciudad'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.$watchGroup(['viaje'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.generateUrl = function () {
        var path = '/presupuesto/' + $scope.presupuesto.from + '-' + $scope.presupuesto.to;

        path += '/tags/';
        var tags = '';
        angular.forEach($scope.tagsSelected, function (value, key) {
            tags += value.Url + ','
        });
        if (tags != '')
            tags = tags.slice(0, -1);
        else
            tags = 'all';
        path += tags;

        path += '/nombre/';
        if ($scope.viaje == '')
            path += 'all';
        else
            path += $scope.viaje;

        path += '/ciudad/';
        if ($scope.ciudad == '')
            path += 'all';
        else
            path += $scope.ciudad;

        $location.path(path);

        $('[data-toggle="tooltip"]').tooltip();

        /*
        $('.flexslider-small').flexslider({
            animation: "fade",
            controlNav: true,
            directionNav: true,
            slideshow: false
        });
        */
    }
})
.directive('myRepeatDirective', function ($timeout) {
    return {
        restrict: "A",
        replace: true,
        link: function (scope, element, attrs) {
            $timeout(function () {
                element.flexslider({
                    animation: "fade",
                    controlNav: true,
                    directionNav: true,
                    slideshow: false
                });
            });
        }
    }
})
.filter("skip", function () {
    return function (data, count) {
        if (angular.isArray(data) && angular.isNumber(count)) {
            if (count > data.length || count < 1) {
                return data;
            } else {
                return data.slice(count);
            }
        } else {
            return data;
        }
    }
});