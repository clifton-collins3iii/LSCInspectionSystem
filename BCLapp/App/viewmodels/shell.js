define(['plugins/router', 'durandal/app', 'jquery'], function (router, app, $) {
    return {
        router: router,
        search: function () {
            //It's really easy to show a message box.
            //You can add custom options too. Also, it returns a promise for the user's response.
            app.showMessage('Search not yet implemented...');
        },
        activate: function () {
            router.map([
                { route: '', title: 'Welcome', moduleId: 'viewmodels/welcome', nav: true },
                { route: 'mysurvey', title: 'My Survey', moduleId: 'viewmodels/mysurvey', nav: true },
                { route: 'campus', title: 'Campus Edit', moduleId: 'viewmodels/campus', nav: true },
                { route: 'building', title: 'Building Edit', moduleId: 'viewmodels/building', nav: true },
                //{ route: 'room', title: 'Room Edit', moduleId: 'viewmodels/room', nav: true },
                //{ route: 'resident', title: 'Resident Edit', moduleId: 'viewmodels/resident', nav: true },
                //{ route: 'source', title: 'Source Edit', moduleId: 'viewmodels/source', nav: true },
                { route: 'contact', title: 'Contact Edit', moduleId: 'viewmodels/contact', nav: true }
            ]).buildNavigationModel();

            return router.activate();
        }
        //$.('#menuToggle').click(function () {
        //
        //});
    };
});