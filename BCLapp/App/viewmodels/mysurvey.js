define(['plugins/http', 'durandal/app', 'jquery', 'knockout', 'jtable'],
    function (http, app, $, ko, jtable) {
        //Note: This module exports an object.
        //That means that every module that "requires" it will get the same object instance.
        //If you wish to be able to create multiple instances, instead export a function.
        //See the "welcome" module for an example of function export.
        var isLoading = ko.observable(false);
        var webServiceURL = ko.observable(sessionStorage.getItem('WebService'));
        var showContacts = ko.observable(false);
        var stateOptionsArray;
        var mysurveyUserOptionsArray;
        var rentpaymentOptionsArray;
        var mysurveyselected;

        var stateOptionsJSON = function (data) {
            return stateOptionsArray;
            //return [{ Value: '1', DisplayText: 'Admin Office' }, { Value: '5', DisplayText: 'Dartmoor' }, { Value: '6', DisplayText: 'Next2' }];
        }

        var mysurveyUserOptionsJSON = function (data) {
            return mysurveyUserOptionsArray;
        }
        var activate = function () {
            //the router's activator calls this function and waits for it to complete before proceding
            $.ajax({
                url: webServiceURL() + '/jTableOptions/StateOptionsSelect',     //  ?' + postData,
                type: 'POST',
                dataType: 'json',
                success: function (data) {      // {"Result":"OK", "Options":[{"DisplayText": "", "Value":"FK_Source_ID"}, {}, {}]}
                    //sourceOptionsArray = JSON.stringify(data.Options);
                    stateOptionsArray = data.Options;
                },
                error: function (request, error, exception) {

                }
            });
        }

        var getmysurveyOptionsJSON = function (data) {
            mysurveyselected = data.PK_Source_Id;
            var DTO = {
                PK_Source_Id: data.PK_Source_Id
            }
            $.ajax({
                url: webServiceURL() + '/jTableOptions/ContactOptionsSelect',     //  ?' + postData,
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(DTO),
                success: function (data) {      // {"Result":"OK", "Options":[{"DisplayText": "", "Value":"FK_Building_ID"}, {}, {}]}
                    //buildingOptionsArray = JSON.stringify(data.Options);
                    mysurveyOptionsArray = data.Options;
                },
                error: function (request, error, exception) {

                }
            });
        }

        var SourceContactsControl = function (dto) {
            $('#SourceContactsTableContainer').jtable({
                title: 'mysurveys',
                actions: {
                    listAction: sourcemysurveyselect,
                    createAction: sourcemysurveycreate,
                    updateAction: sourcemysurveyupdate,
                    deleteAction: sourcemysurveydelete
                },
                messages: {
                    deleteConfirmation: 'Edit/Update the Deleted Flag\r\nPressing DELETE is permanent!',
                },
                fields: {
                    PK_mysurvey_Id: {
                        key: true,
                        list: false
                    },
                    FK_Sourcemysurvey_Id: {
                        title: 'mysurvey Name',
                        width: '10%',
                        options: mysurveyOptionsJSON
                    },
                    EffectiveDate: {
                        title: 'Effective Date',
                        width: '5%',
                        type: 'date',
                        displayFormat: 'yy-mm-dd'
                    },
                    TerminationDate: {
                        title: 'Termination Date',
                        list: false,
                        type: 'date',
                        displayFormat: 'yy-mm-dd',
                        defaultValue: '2099-12-31'
                    },
                    IsActive: {
                        title: 'Active',
                        width: '5%',
                        type: 'checkbox',
                        values: { 'false': 'Inactive', 'true': 'Active' },
                        defaultValue: true,
                    },
                    IsDeleted: {
                        title: 'Deleted',
                        width: '5%',
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
                },
            })
            $('#SourceContactsTableContainer').jtable('load');
            //$('#SourceContactsTableContainer').show();
            showContacts(true);
            return true;
        }

        var compositionComplete = function () {
            $('#MysurveyTableContainer').jtable({
                title: 'Mysurvey Edit',
                selecting: true, //Enable selecting
                multiselect: false, //Allow multiple selecting
                selectingCheckboxes: true, //Show checkboxes on first column
                selectOnRowClick: true, //Enable this to only select using checkboxes
                actions: {
                    listAction: mysurveyselect,     // this calls the javascript function mysurveyselect() below
                    createAction: sourcecreate,
                    updateAction: sourceupdate,
                    deleteAction: sourcedelete,
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
                                $('#SourceTableContainer').jtable('reload');
                            }
                        }
                    ]
                },
                fields: {
                    PK_Source_Id: {
                        key: true,
                        list: false
                    },
                    Source_Name: {
                        title: 'Source Name',
                        width: '10%'
                    },
                    SourceDescription: {
                        title: 'Description of the source',
                        width: '20%'
                    },
                    AddressStreet: {
                        title: 'Street Address',
                        width: "20%'"
                    },
                    AddressUnit: {
                        title: 'Apt/Ste',
                        width: '10%'
                    },
                    AddressCity: {
                        title: 'City',
                        width: '10%'
                    },
                    AddressState: {
                        title: 'STATE',
                        width: '5%',
                        options: stateOptionsJSON
                    },
                    AddressZip: {
                        title: 'Zip code',
                        width: '5%',
                    },
                    IsActive: {
                        title: 'Active',
                        width: '5%',
                        type: 'checkbox',
                        values: { 'false': 'Inactive', 'true': 'Active' },
                        defaultValue: true
                    },
                    IsDeleted: {
                        title: 'Deleted',
                        width: '5%',
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
                },
                //Register to selectionChanged event to hanlde events
                selectionChanged: function () {
                    //Get all selected rows
                    var $selectedRows = $('#SourceTableContainer').jtable('selectedRows');

                    $('#SelectedRowList').empty();
                    if ($selectedRows.length > 0) {
                        //Show selected rows
                        $selectedRows.each(function () {
                            var record = $(this).data('record');
                            //$('#SelectedRowList').append(
                            //'<b>StudentId</b>: ' + record.StudentId +
                            //'<br /><b>Name</b>:' + record.Name + '<br /><br />'
                            //);
                            //
                            //  show mysurvey - resident table
                            getmysurveyOptionsJSON(record);
                            //SourceContactsControl(record);
                        });
                    } else {
                        //No rows selected
                        //$('#SelectedRowList').append('No row selected! Select rows to see here...');
                        //
                        //  hide the mysurvey - resident table
                        //$('#SourceContactsTableContainer').hide();
                        showContacts(false);
                    }
                },
            });
            $('#SourceTableContainer').jtable('load');
            return true;
        };

        //  Used by jTable deleteAction method
        var sourcedelete = function (postData, jtParams) {
            var r = confirm('Do you wish to delete ALL mysurveys and associated invoices ?');
            if (r == true) {
                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: webServiceURL() + '/jTable/SourceDelete',
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
                        url: webServiceURL() + '/jTable/NopSource',
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
        var sourcecreate = function (postData, jtParams) {
            var ph = 0;
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/SourceCreate',
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
        var sourceupdate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/SourceUpdate',
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
        var mysurveyselect = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/MySurveySelect',     //  ?' + postData,
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

        var sourcemysurveyselect = function (postData, jtParams) {
            var DTO = {
                FK_Source_Id: mysurveyselected
            }
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/SourceContactsSelect',     //  ?' + postData,
                    type: 'POST',
                    dataType: 'json',
                    data: DTO,
                    success: function (data) {
                        $dfd.resolve(data);
                    },
                    error: function (request, error, exception) {
                        $dfd.reject();
                    }
                });
            });
        }

        var sourcemysurveycreate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/SourceContactsCreate',     //  ?' + postData,
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

        var sourcemysurveydelete = function (postData, jtParams) {
            var r = confirm('Do you wish to delete this source - mysurvey relationship ?');
            if (r == true) {
                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: webServiceURL() + '/jTable/SourceContactsDelete',
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
                        url: webServiceURL() + '/jTable/NopSource',
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

        var sourcemysurveyupdate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/SourceContactsUpdate',     //  ?' + postData,
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
            displayName: 'Source',
            images: ko.observableArray([]),
            isLoading: isLoading,
            activate: activate,
            compositionComplete: compositionComplete,
            webServiceURL: webServiceURL,
            showContacts: showContacts,
        };
    });