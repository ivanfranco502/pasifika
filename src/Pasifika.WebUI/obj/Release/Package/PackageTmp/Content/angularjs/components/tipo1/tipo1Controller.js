myApp.controller('Tipo1Ctrl', function ($scope, $http, $location) {
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
    $scope.tipoViaje = '';

    $scope.tagsSelected = [];

    $scope.presupuesto = {};
    $scope.presupuesto.from = Math.min.apply(Math, $scope.data.filter(function(n) { return n.EsBannerContextual == false}).map(function (o) { return o.Precio; }));
    $scope.presupuesto.min = $scope.presupuesto.from;
    $scope.presupuesto.to = Math.max.apply(Math, $scope.data.filter(function (n) { return n.EsBannerContextual == false }).map(function (o) { return o.Precio; }));
    $scope.presupuesto.max = $scope.presupuesto.to;

    $scope.duracion = {};
    $scope.duracion.from = Math.min.apply(Math, $scope.data.filter(function (n) { return n.EsBannerContextual == false }).map(function (o) { return o.Duracion; }));
    $scope.duracion.min = $scope.duracion.from;
    $scope.duracion.to = Math.max.apply(Math, $scope.data.filter(function (n) { return n.EsBannerContextual == false }).map(function (o) { return o.Duracion; }));
    $scope.duracion.max = $scope.duracion.to;

    //agarro las rutas creadas
    var parameters = $location.$$path.split('/');
    if (parameters.length == 11) {
        //presupuesto
        var presupuesto = parameters[2].split('-');
        $scope.presupuesto.from = presupuesto[0];
        $scope.presupuesto.to = presupuesto[1];

        //duracion
        var duracion = parameters[4].split('-');
        $scope.duracion.from = duracion[0];
        $scope.duracion.to = duracion[1];

        //tags
        var tags = parameters[6].split(',');

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

        var destino = parameters[8];
        $scope.ciudad = '';
        if (destino != 'all') {
            $scope.ciudad = destino;
            $("#destino").val(destino);
        }

        var tipoViaje = parameters[10];
        if (tipoViaje != 'all') {
            $scope.tipoViaje = tipoViaje;
            $("#tipoViaje").val(tipoViaje);
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

        var existe2 = true;
        if ($scope.tipoViaje != '')
        {
            var obj = getObjects(item.Tags, 'Url', $scope.tipoViaje);
            if (obj.length == 0)
                existe2 = false;
        }

        return item.EsBannerContextual || (item.Duracion >= $scope.duracion.from && item.Duracion <= $scope.duracion.to &&
            item.Precio >= $scope.presupuesto.from && item.Precio <= $scope.presupuesto.to &&
            (item.DestinoUrl == $scope.ciudad || $scope.ciudad == '') &&
            existe && existe2);
    }

    $scope.SinBanner = function (item) {
        
        return !item.EsBannerContextual;
    }

    $scope.$watchGroup(['presupuesto.from'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.$watchGroup(['presupuesto.to'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.$watchGroup(['duracion.from'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.$watchGroup(['duracion.to'], function (newValue, oldValue) {
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

    $scope.$watchGroup(['tipoViaje'], function (newValue, oldValue) {
        if (newValue != oldValue)
            $scope.generateUrl();
    });

    $scope.generateUrl = function () {
        var path = '/presupuesto/' + $scope.presupuesto.from + '-' + $scope.presupuesto.to;
        path += '/duracion/' + $scope.duracion.from + '-' + $scope.duracion.to;

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

        path += '/destino/';
        if ($scope.ciudad == '')
            path += 'all';
        else
            path += $scope.ciudad;

        path += '/tipoviaje/';
        if ($scope.tipoViaje == '')
            path += 'all';
        else
            path += $scope.tipoViaje;

        $location.path(path);
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