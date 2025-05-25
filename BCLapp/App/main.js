requirejs.config({
    paths: {
        'text': '../Scripts/text',
        'durandal': '../Scripts/durandal',
        'plugins': '../Scripts/durandal/plugins',
        'transitions': '../Scripts/durandal/transitions',
        'bootstrap': '../Scripts/bootstrap.bundle.min',
        'jquery': '../Scripts/jquery-3.7.1',
        'jquery-ui': '../Scripts/jquery-ui-1-13.3',
        'knockout': '../Scripts/knockout-3.5.1',
        'jtable': '../Scripts/jtable/jquery.jtable',
        '@servicestack/client': '../ServiceStack/servicestack-client.mjs'
    },
    shim: {
        'jquery-ui': ['jquery'],
        'bootstrap': {
            deps: ['jquery', 'jquery-ui'],
            exports: 'jQuery'
        },
        'jtable': {
            deps: ['jquery', 'jquery-ui']
        }
    }
});

//define('jquery', function() { return jQuery; });
//define('knockout', ko);

define(['durandal/system', 'durandal/app', 'durandal/viewLocator', 'jquery', 'knockout', 'bootstrap'],
    function (system, app, viewLocator, $, ko, bs) {
    //>>excludeStart("build", true);
    system.debug(true);
    //>>excludeEnd("build");

    app.title = 'LSC System';

    app.configurePlugins({
        router: true,
        dialog: true,
        widget: true
    });

    app.start().then(function() {
        //Replace 'viewmodels' in the moduleId with 'views' to locate the view.
        //Look for partial views in a 'views' folder in the root.
        viewLocator.useConvention();
         
        //Show the app by setting the root view model for our application with a transition.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});