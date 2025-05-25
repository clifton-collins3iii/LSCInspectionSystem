define(function () {
    var ctor = function () {
        this.displayName = 'LSC System';
        this.description = 'A web application to assist in the operations of the company.';
        this.features = [
            'Building Management',
            '     --  Inspection',
            '     --  Maintenance',
            '     --  Repair',
            '     --  Remodel',
            'Reports',
            '     --  Inspection',
            '     --  Other',
            'Integrates with other systems',
            '...'
        ];

    };

    //Note: This module exports a function. That means that you, the developer, can create multiple instances.
    //This pattern is also recognized by Durandal so that it can create instances on demand.
    //If you wish to create a singleton, you should export an object instead of a function.
    //See the "flickr" module for an example of object export.

    return ctor;
});