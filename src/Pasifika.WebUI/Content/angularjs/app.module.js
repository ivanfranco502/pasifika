var myApp = angular.module("exampleApp", ['nouislider', 'ngResource', 'ngRoute'])
.config(function ($routeProvider, $locationProvider) {
    /*
    if (window.history && history.pushState) {
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });

        $locationProvider.hashPrefix('#');
    }
    */

    /*
    $routeProvider.when("/presupuesto/:presupuestoRango/duracion/:duracionRango/tags/:tags", {
        template: "aaa ",
        controller: "Tipo1Ctrl"
    });

    $routeProvider.otherwise({
        template: " ",
        controller: "Tipo1Ctrl"
    });
    */
});

var model = [];

function getObjects(obj, key, val) {
    var objects = [];
    for (var i in obj) {
        if (!obj.hasOwnProperty(i)) continue;
        if (typeof obj[i] == 'object') {
            objects = objects.concat(getObjects(obj[i], key, val));
        } else
            //if key matches and value matches or if key matches and value is not passed (eliminating the case where key matches but passed value does not)
            if (i == key && obj[i] == val || i == key && val == '') { //
                objects.push(obj);
            } else if (obj[i] == val && key == '') {
                //only add if the object is not already in the array
                if (objects.lastIndexOf(obj) == -1) {
                    objects.push(obj);
                }
            }
    }
    return objects;
}