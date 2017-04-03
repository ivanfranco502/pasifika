'use strict';
angular.module('nouislider', []).directive('slider', function () {
  return {
    restrict: 'A',
    scope: {
      start: '@',
      step: '@',
      end: '@',
      ngModel: '=',
      ngFrom: '=',
      ngTo: '='
    },
    link: function (scope, element, attrs) {
      var fromParsed, parsedValue, slider, toParsed;
      slider = $(element);
      if (scope.ngFrom != null && scope.ngTo != null) {
        fromParsed = null;
        toParsed = null;
        
        slider.noUiSlider({
            range: {
                'min': parseInt(scope.start, 10),
                'max': parseInt(scope.end, 10)
            },
          start: [
            scope.ngFrom || parseInt(scope.start, 10),
            scope.ngTo || parseInt(scope.end, 10)
          ],
          step: parseInt(scope.step, 10) || 1,
          connect: true,
          slide: function () {
              var from, to, _ref;
            _ref = slider.val(), from = _ref[0], to = _ref[1];
            fromParsed = parseFloat(from);
            toParsed = parseFloat(to);
            scope.values = [
              fromParsed,
              toParsed
            ];
            return scope.$apply(function () {
              scope.ngFrom = fromParsed;
              return scope.ngTo = toParsed;
            });
          }
        });
        scope.$watch('ngFrom', function (newVal, oldVal) {
          if (newVal !== fromParsed) {
            return slider.val([
              newVal,
              null
            ]);
          }
        });
        return scope.$watch('ngTo', function (newVal, oldVal) {
          if (newVal !== toParsed) {
            return slider.val([
              null,
              newVal
            ]);
          }
        });
      } else {
        parsedValue = null;
        slider.noUiSlider({
            range: {
                'min': parseInt(scope.start, 10),
                'max': parseInt(scope.end, 10)
            },
            start: [scope.ngModel || parseInt(scope.start, 10)],
          step: parseInt(scope.step, 10) || 1,
          handles: 1,
          slide: function () {
            parsedValue = slider.val();
            return scope.$apply(function () {
              return scope.ngModel = parseFloat(parsedValue);
            });
          }
        });
        return scope.$watch('ngModel', function (newVal, oldVal) {
          if (newVal !== parsedValue) {
            return slider.val(newVal);
          }
        });
      }
    }
  };
});