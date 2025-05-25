define(['plugins/http', 'durandal/app', 'jquery', 'knockout', 'jtable'],
    function (http, app, $, ko, jtable) {
        //Note: This module exports an object.
        //That means that every module that "requires" it will get the same object instance.
        //If you wish to be able to create multiple instances, instead export a function.
        //See the "welcome" module for an example of function export.
        var isLoading = ko.observable(false);
        var webServiceURL = ko.observable(sessionStorage.getItem('WebService'));
        var stateOptionsArray;

        var stateOptionsJSON = function (data) {
            return stateOptionsArray;
            //return [{ Value: '1', DisplayText: 'Admin Office' }, { Value: '5', DisplayText: 'Dartmoor' }, { Value: '6', DisplayText: 'Next2' }];
        }

        var activate = function () {
            //the router's activator calls this function and waits for it to complete before proceding
            $.ajax({
                url: webServiceURL() + '/jTableOptions/StateOptionsSelect',     //  ?' + postData,
                type: 'POST',
                dataType: 'json',
                success: function (data) {      // {"Result":"OK", "Options":[{"DisplayText": "", "Value":"FK_Building_ID"}, {}, {}]}
                    //buildingOptionsArray = JSON.stringify(data.Options);
                    stateOptionsArray = data.Options;
                },
                error: function (request, error, exception) {

                }
            });
        }

        var compositionComplete = function () {
            $('#ResidentTableContainer').jtable({
                title: 'Resident Edit',
                actions: {
                    listAction: residentselect,     // this calls the javascript function buildingselect() below
                    createAction: residentcreate,
                    updateAction: residentupdate,
                    deleteAction: residentdelete,
                },
                messages: {
                    deleteConfirmation: 'Edit/Update the Deleted Flag\r\nPressing DELETE is permanent!',
                },
                toolbar: {
                    items: [
                        {
                            icon: '/Content/images/exceliconbw16.png',
                            text: 'Export to Excel',
                            click: function () {
                                //perform your custom job...
                            }
                        }, {
                            icon: '/Content/images/pdficon16.png',
                            text: 'Export to Pdf',
                            click: function () {
                                //perform your custom job...
                            }
                        }, {
                            icon: '/Content/images/refreshred16.png',
                            text: 'REFRESH',
                            click: function () {
                                $('#BuildingTableContainer').jtable('reload');
                            }
                        }
                    ]
                },
                fields: {
                    PK_Resident_Id: {
                        key: true,
                        list: false
                    },
                    Name_First: {
                        title: 'Resident First Name',
                        width: '10%'
                    },
                    Name_Middle: {
                        title: 'Resident Middle Name',
                        width: '10%'
                    },
                    Name_Second: {
                        title: 'Resident Last Name',
                        width: '10%'
                    },
                    Description: {
                        title: 'Description',
                        width: '20%'
                    },
                    PhoneNumber: {
                        title: 'Phone Number',
                        width: '5%'
                    },
                    EmailAddress: {
                        title: 'Email Address',
                        width: '10%'
                    },
                    AddressStreet: {
                        title: 'Street Address',
                        width: "20%'",
                        defaultValue: 'NA'
                    },
                    AddressUnit: {
                        title: 'Apt/Ste',
                        width: '10%'
                    },
                    AddressCity: {
                        title: 'City',
                        width: '10%',
                        defaultValue: 'Baton Rouge'
                    },
                    AddressState: {
                        title: 'STATE',
                        width: '5%',
                        options: stateOptionsJSON
                    },
                    AddressZip: {
                        title: 'Zip code',
                        width: '5%',
                        defaultValue: '70809'
                    },
                    IsActive: {
                        title: 'Active',
                        type: 'checkbox',
                        width: '5%',
                        values: { 'false': 'Inactive', 'true': 'Active' },
                        defaultValue: true
                    },
                    IsDeleted: {
                        title: 'Deleted',
                        type: 'checkbox',
                        width: '5%',
                        values: { 'false': 'NO', 'true': 'DELETED' }
                    }
                },
                formCreated: function (event, data) {
                   // $('#jtable-edit-form').css('height', 'auto');
                   // $('#jtable-edit-form').css('width', '300px');
                    $('input[type=text]').each(function () {
                        $(this).css('width', '100%');
                    });
                }
                //formCreated: function (event, data) {
                //    var dlgOptions = {
                //        resizable: false
                //    };
                //    $(".jtable-create-form").parent().dialog(dlgOptions);
                //}
            });
            $('#ResidentTableContainer').jtable('load');
            return true;
        };

        //  Used by jTable deleteAction method
        var residentdelete = function (postData, jtParams) {
            var r = confirm('Do you wish to delete ALL associated records ?');
            if (r == true) {
                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: webServiceURL() + '/jTable/ResidentDelete',
                        type: 'POST',
                        dataType: 'json',
                        data: postData,
                        success: function (data) {
                            $dfd.resolve(data);
                        },
                        error: function (request, error, exception) {
                            $dfd.reject();
                        }
                    });
                });
            } else {
                //return $.Deferred(function ($dfd) {
                //    try {
                //        //$dfd.reject();
                //        $dfd.resolve();
                //    } catch {
                //    }
                //});
                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: webServiceURL() + '/jTable/NopResident',
                        type: 'POST',
                        dataType: 'json',
                        data: postData,
                        success: function (data) {
                            $dfd.resolve(data);
                        },
                        error: function (request, error, exception) {
                            $dfd.reject();
                        }
                    });
                });
            };
            
        }

        //  Used by jTable createAction method
        var residentcreate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/ResidentCreate',
                    type: 'POST',
                    dataType: 'json',
                    data: postData,
                    success: function (data) {
                        $dfd.resolve(data);
                    },
                    error: function (request, error, exception) {
                        $dfd.reject();
                    }
                });
            });
        }

        //  Used by jTable updateAction method
        var residentupdate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/ResidentUpdate',
                    type: 'POST',
                    dataType: 'json',
                    data: postData,
                    success: function (data) {
                        $dfd.resolve(data);
                    },
                    error: function (request, error, exception) {
                        $dfd.reject();
                    }
                });
            });
        }

        //  Used by jTable listAction method
        var residentselect = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/ResidentSelect',     //  ?' + postData,
                    type: 'POST',
                    dataType: 'json',
                    data: postData,
                    success: function (data) {
                        $dfd.resolve(data);
                    },
                    error: function (request, error, exception) {
                        $dfd.reject();
                    }
                });
            });
        }

        var jtableCallback = function (evt) {
            isLoading(true);
        }
        var select = function (item) {
            //the app model allows easy display of modal dialogs by passing a view model
            //views are usually located by convention, but you an specify it as well with viewUrl
            item.viewUrl = 'views/detail';
            app.showDialog(item);
        };

        var canDeactivate = function () {
            //the router's activator calls this function to see if it can leave the screen
            return app.showMessage('Are you sure you want to leave this page?', 'Navigate', ['Yes', 'No']);
        };


    return {
        displayName: 'Resident',
        images: ko.observableArray([]),
        isLoading: isLoading,
        activate: activate,
        compositionComplete: compositionComplete,
        webServiceURL: webServiceURL,
    };
});