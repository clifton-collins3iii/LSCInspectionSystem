define(['plugins/http', 'durandal/app', 'jquery', 'knockout', 'jtable'],
    function (http, app, $, ko, jtable) {
        //Note: This module exports an object.
        //That means that every module that "requires" it will get the same object instance.
        //If you wish to be able to create multiple instances, instead export a function.
        //See the "welcome" module for an example of function export.
        var isLoading = ko.observable(false);
        var webServiceURL = ko.observable(sessionStorage.getItem('WebService'));
        var buildingOptionsArray;
        var rentpaymentOptionsArray;

        var buildingOptionsJSON = function (data) {
            return buildingOptionsArray;
            //return [{ Value: '1', DisplayText: 'Admin Office' }, { Value: '5', DisplayText: 'Dartmoor' }, { Value: '6', DisplayText: 'Next2' }];
        }

        var rentpaymentfrequencyOptionsJSON = function (data) {
            return rentpaymentOptionsArray;
            //return [{ Value: '1', DisplayText: 'Admin Office' }, { Value: '5', DisplayText: 'Dartmoor' }, { Value: '6', DisplayText: 'Next2' }];
        }

        var activate = function () {
            //the router's activator calls this function and waits for it to complete before proceding
            
                $.ajax({
                    url: webServiceURL() + '/jTableOptions/BuildingOptionsSelect',     //  ?' + postData,
                    type: 'POST',
                    dataType: 'json',
                    success: function (data) {      // {"Result":"OK", "Options":[{"DisplayText": "", "Value":"FK_Building_ID"}, {}, {}]}
                        //buildingOptionsArray = JSON.stringify(data.Options);
                        buildingOptionsArray = data.Options;
                    },
                    error: function (request, error, exception) {
                        
                    }
                });

            $.ajax({
                url: webServiceURL() + '/jTableOptions/RentPaymentFrequencyOptionsSelect',     //  ?' + postData,
                type: 'POST',
                dataType: 'json',
                success: function (data) {      // {"Result":"OK", "Options":[{"DisplayText": "", "Value":"FK_Building_ID"}, {}, {}]}
                    //buildingOptionsArray = JSON.stringify(data.Options);
                    rentpaymentOptionsArray = data.Options;
                },
                error: function (request, error, exception) {

                }
            });
        }

        var compositionComplete = function () {
            $('#RoomTableContainer').jtable({
                title: 'Room Edit',
                actions: {
                    listAction: Roomselect,     // this calls the javascript function Roomselect() below
                    createAction: Roomcreate,
                    updateAction: Roomupdate,
                    deleteAction: Roomdelete,
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
                                $('#RoomTableContainer').jtable('reload');
                            }
                        }
                    ]
                },
                fields: {
                    PK_BuildingRoom_Id: {
                        key: true,
                        list: false
                    },
                    FK_Building_Id: {
                        title: 'Building',
                        width: '10%',
                        //options: Buildingoptions
                        options: buildingOptionsJSON
                    },
                    Name_Short: {
                        title: 'Room Short Name',
                        width: '10%'
                    },
                    Name_Long: {
                        title: 'Room Long Name',
                        width: '20%'
                    },
                    Description: {
                        title: 'Description of the Room',
                        width: '20%'
                    },
                    RentPaymentFrequency: {
                        title: 'Payment Period',
                        width: "10%'",
                        options: rentpaymentfrequencyOptionsJSON
                    },
                    RentPaymentAmount: {
                        title: 'Payment Amount',
                        width: '10%'
                    },
                    IsActive: {
                        title: 'Active',
                        type: 'checkbox',
                        values: { 'false': 'Inactive', 'true': 'Active' },
                        defaultValue: true
                    },
                    IsDeleted: {
                        title: 'Deleted',
                        type: 'checkbox',
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
            });
            $('#RoomTableContainer').jtable('load');
            return true;
        };

        var Buildingoptions = function (data) {
            var params = data;
            if (data.source == 'list') {
                //  returns matching building shortname from FK
                
            }
            //  Runs only when user opens the edit/create dialog to create dropdown/option combobox
            //data.source == 'edit' || data.source == 'create'
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTableOptions/BuildingOptionsSelect',     //  ?' + postData,
                    type: 'POST',
                    dataType: 'json',
                    data: params,
                    success: function (data) {      // {"Result":"OK", "Options":[{"DisplayText": "", "Value":"FK_Building_ID"}, {}, {}]}
                        $dfd.resolve(JSON.stringify(data.Records));
                    },
                    error: function (request, error, exception) {
                        $dfd.reject();
                    }
                });
            });
        }

        //  Used by jTable deleteAction method
        var Roomdelete = function (postData, jtParams) {
            var r = confirm('Do you wish to delete ALL rooms and associated invoices ?');
            if (r == true) {
                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: webServiceURL() + '/jTable/RoomDelete',
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
                        url: webServiceURL() + '/jTable/NopBuildingRoom',
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
        var Roomcreate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/RoomCreate',
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
        var Roomupdate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/RoomUpdate',
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
        var Roomselect = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/RoomSelect',     //  ?' + postData,
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
        displayName: 'Room',
        images: ko.observableArray([]),
        isLoading: isLoading,
        activate: activate,
        compositionComplete: compositionComplete,
        webServiceURL: webServiceURL,
    };
});