define(['plugins/http', 'durandal/app', 'jquery', 'knockout', 'jtable'],
    function (http, app, $, ko, jtable) {
        //Note: This module exports an object.
        //That means that every module that "requires" it will get the same object instance.
        //If you wish to be able to create multiple instances, instead export a function.
        //See the "welcome" module for an example of function export.
        var isLoading = ko.observable(false);
        var webServiceURL = ko.observable(sessionStorage.getItem('WebService'));
        var showRooms = ko.observable(false);
        var stateOptionsArray;
        var residentOptionsArray;
        var campusOptionsArray;
        var campusselected;

        var stateOptionsJSON = function (data) {
            return stateOptionsArray;
            //return [{ Value: '1', DisplayText: 'Admin Office' }, { Value: '5', DisplayText: 'Dartmoor' }, { Value: '6', DisplayText: 'Next2' }];
        }

        var campusOptionsJSON = function (data) {
            return campusOptionsArray;
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

        var getbuildingOptionsJSON = function (data) {
            campusselected = data.PK_Campus_Id;
            var DTO = {
                PK_Campus_Id: data.PK_Campus_Id
            }
            $.ajax({
                url: webServiceURL() + '/jTableOptions/BuildingOptionsSelect',     //  ?' + postData,
                type: 'POST',
                dataType: 'json',
                data: JSON.stringify(DTO),
                success: function (data) {      // {"Result":"OK", "Options":[{"DisplayText": "", "Value":"FK_Building_ID"}, {}, {}]}
                    campusOptionsArray = data.Options;
                           // CampusBuildingControl(DTO);
                },
                error: function (request, error, exception) {

                }
            });
        }

        var CampusBuildingControl = function (dto) {
            $('#CampusBuildingTableContainer').jtable({
                title: 'Buildings',
                actions: {
                    listAction: buildingroomresidentselect,
                    createAction: buildingroomresidentcreate,
                    updateAction: buildingroomresidentupdate,
                    deleteAction: buildingroomresidentdelete
                },
                messages: {
                    deleteConfirmation: 'Edit/Update the Deleted Flag\r\nPressing DELETE is permanent!',
                },
                fields: {
                    PK_RoomResident_Id: {
                        key: true,
                        list: false
                    },
                    FK_BuildingRoom_Id: {
                        title: 'Room Name',
                        width: '10%',
                        options: roomOptionsJSON
                    },
                    FK_Resident_Id: {
                        title: 'Resident Name',
                        width: '10%',
                        options: residentOptionsJSON,
                        //display: function (data) {
                        //    if (data.record.FK_Resident_Id == 0) {
                        //        return '<span style="background-color: yellow">Vacant</span>'
                        //    } else {
                        //        return data.record.FK_Resident_Id;
                        //    }
                        //}
                    },
                    RentPaymentFrequency: {
                        title: 'Payment Period',
                        width: '5%',
                        options: rentpaymentfrequencyOptionsJSON
                    },
                    RentPaymentAmount: {
                        title: 'Payment Amount',
                        width: '5%',
                        defaultvalue: 0
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
                        display: function (data) {
                            if (data.record.FK_Resident_Id == 0 && data.record.IsActive == true) {
                                return '<span style="background-color: yellow">Vacant</span>'
                            } else {
                                return data.record.IsActive;
                            }
                        }
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
            $('#CampusBuildingTableContainer').jtable('load');
            //$('#CampusBuildingTableContainer').show();
            showRooms(true);
            return true;
        }

        var compositionComplete = function () {
            $('#CampusTableContainer').jtable({
                title: 'Campus Edit',
                selecting: true, //Enable selecting
                multiselect: false, //Allow multiple selecting
                selectingCheckboxes: true, //Show checkboxes on first column
                selectOnRowClick: true, //Enable this to only select using checkboxes
                actions: {
                    listAction: campusselect,     // this calls the javascript function campusselect() below
                    createAction: campuscreate,
                    updateAction: campusupdate,
                    deleteAction: campusdelete,
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
                    PK_Building_Id: {
                        key: true,
                        list: false
                    },
                    Name_Short: {
                        title: 'Campus Short Name',
                        width: '10%'
                    },
                    Name_Long: {
                        title: 'Campus Long Name',
                        width: '10%'
                    },
                    Description: {
                        title: 'Description of the Campus',
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
                    var $selectedRows = $('#CampusTableContainer').jtable('selectedRows');

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
                            //  show room - resident table
                            //BuildingRoomResidentControl(record);
                            getresidentOptionsJSON(record);
                        });
                    } else {
                        //No rows selected
                        //$('#SelectedRowList').append('No row selected! Select rows to see here...');
                        //
                        //  hide the room - resident table
                        //$('#CampusBuildingTableContainer').hide();
                        showRooms(false);
                    }
                },
            });
            $('#CampusTableContainer').jtable('load');
            return true;
        };

        //  Used by jTable deleteAction method
        var campusdelete = function (postData, jtParams) {
            var r = confirm('Do you wish to delete ALL Buildings and associated inspections ?');
            if (r == true) {
                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: webServiceURL() + '/jTable/CampusDelete',
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
                        url: webServiceURL() + '/jTable/NopBuilding',
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
        var campuscreate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/CampusCreate',
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
        var campusupdate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/CampusUpdate',
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
        var campusselect = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/campusselect',     //  ?' + postData,
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

        var buildingroomresidentselect = function (postData, jtParams) {
            var DTO = {
                FK_Building_Id: campusselected
            }
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/BuildingRoomResidentSelect',     //  ?' + postData,
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

        var buildingroomresidentcreate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/BuildingRoomResidentCreate',     //  ?' + postData,
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

        var buildingroomresidentdelete = function (postData, jtParams) {
            var r = confirm('Do you wish to delete this room-resident relationship ?');
            if (r == true) {
                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: webServiceURL() + '/jTable/BuildingRoomResidentDelete',
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
                        url: webServiceURL() + '/jTable/NopBuilding',
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

        var buildingroomresidentupdate = function (postData, jtParams) {
            return $.Deferred(function ($dfd) {
                $.ajax({
                    url: webServiceURL() + '/jTable/BuildingRoomResidentUpdate',     //  ?' + postData,
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
            displayName: 'Campus',
            images: ko.observableArray([]),
            isLoading: isLoading,
            activate: activate,
            compositionComplete: compositionComplete,
            webServiceURL: webServiceURL,
            showRooms: showRooms,
        };
    });