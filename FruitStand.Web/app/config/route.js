// unmatched url
app.config(function ($stateProvider, $urlRouterProvider) {
    // For any unmatched url, redirect to /home
    $urlRouterProvider.otherwise("/fruits");
});

 app.config(function ($stateProvider, $urlRouterProvider) {

     $stateProvider.state('fruit_add', {
        url: "/fruit/add",
        views: {
            'header': {
                templateUrl: "/app/views/navbar.html",
            },
            'content': {
                templateUrl: "/app/views/fruit/fruit-add.html",
                controller: "fruitCtrl"
            }
        } 
    })
    .state('fruits', {
        url: "/fruits",
        views: {
            'header': {
                templateUrl: "/app/views/navbar.html",
            },
            'content': {
                templateUrl: "/app/views/fruit/fruits.html",
                controller: "fruitCtrl"
            }
        }
    })
     .state('page-not-exist', {
         url: "/page-not-exist",
         views: {
             'content': {
                 templateUrl: "/app/views/page-not-exist.html"
             }
         }
     })
});

 