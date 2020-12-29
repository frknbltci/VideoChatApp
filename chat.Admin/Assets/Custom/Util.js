
function LoginControlAdmin() {
    var data = {
        UserName: $("#UserName").val(),
        Password: $("#Password").val(),
    };

    if (data.UserName.trim() != "" && data.Password.trim() != "") {
        $.ajax({
            url: "/Login/LoginControl",
            type: "post",
            data: data,
            success: function (e) {
                var sonuc = e;
                if (e != true) {
                    errorMes("Kullanıcı adı veya parola hatalı!", "Giriş Hatası!");
                    window.location("/");
                }
                else {
                    sucMes(data.ID, "Hoşgeldin!")
                    setInterval(function () {
                        window.location.replace("/Home/Index");
                    }, 1000); //3 seconds
                }
            }
        });
    }
    else {
        warningMes("Kullanıcı adı ve Parola Boş Geçilemez", "Giriş Hatası!");
        window.location("/");
    }
}


function errorMes(message, errorTitle) {
    toastr.error(message, errorTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function sucMes(message, sucTitle) {

    toastr.success(message, sucTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "700",
        "hideDuration": "1000",
        "timeOut": "3000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};

function warningMes(message, warTitle) {
    toastr.warning(message, warTitle, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "1000",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })
};


$('.makePassive').on('click', function myfunction() {

    var cusId = $(this).attr('cusid');
    $('.onayBtn').attr('cusID', cusId);
    $('.onayBtnMod').attr('cusID', cusId);

});


$('.makeActive').on('click', function myfunction() {

    var cusId = $(this).attr('cusid');

    $('.onayBtn').attr('cusID', cusId);
    $('.onayBtnMod').attr('cusID', cusId);

});


$('.onayBtn').on('click', function myfunction() {

    var ID = $(this).attr('cusID');
    if (ID == null || ID == undefined || ID == "") {
        warningMes("Müşteri Bilgisine ulaşılamadı");
    }

    else {

        var data = {
            ID: ID
        };

        $.ajax({
            url: "/ACustomer/UpdateIsActive",
            type: "post",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes("İşlem Başarılı");
                    setTimeout(function myfunction() {
                        window.location.reload();
                    }, 1000);
                } else {
                    errorMes("", "Hata İle Karşılaşıldı");
                }

            }
        });
    }


});



function updateCustomer(formData) {

    var ajaxConfig = {
        type: "post",
        url: "/ACustomer/editCus",
        data: new FormData(formData),
        success: function (e) {
            console.log(e);
        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;

}



$('.onayBtnMod').on('click', function myfunction() {

    var ID = $(this).attr('cusID');
    if (ID == null || ID == undefined || ID == "") {
        warningMes("Müşteri Bilgisine ulaşılamadı");
    }

    else {

        var data = {
            ID: ID
        };

        $.ajax({
            url: "/AEmployee/UpdateIsActive",
            type: "post",
            data: data,
            success: function (e) {
                if (e == true) {
                    sucMes("İşlem Başarılı");
                    setTimeout(function myfunction() {
                        window.location.reload();
                    }, 1000);
                } else {
                    errorMes("", "Hata İle Karşılaşıldı");
                }

            }
        });
    }


});


$(".sendMesCus").on('click', function myfunction() {

    var mess = $(this).attr('mess');

    $(".pushMesCus").html(mess);

});


$(".sendMesEmp").on('click', function myfunction() {

    var mess = $(this).attr('mess');

    $(".pushMesEmp").html(mess);

});


//Customer'a mesaj gönderim

function sendToMessagePost(formData) {

    var ajaxConfig = {
        type: "post",
        url: "/AMessage/sendMessageToCustomer",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes("Mesaj gönderildi");
                setTimeout(function myfunction() {
                    window.location.reload();
                }, 2000);
            } else {
                warningMes("Mesajınız Gönderilemedi", "Hata ile karşılaşıldı");
            }
        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;

}


//Employee'e mesaj gönderim
function sendToMessagePostEmp(formData) {

    var ajaxConfig = {
        type: "post",
        url: "/AMessage/sendMessageToEmployee",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes("Mesaj gönderildi");
                setTimeout(function myfunction() {
                    window.location.reload();
                }, 2000);
            }
            else {
                warningMes("Mesajınız Gönderilemedi", "Hata ile karşılaşıldı");
            }
        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;

};


function sendToMessageAllUsers(formData) {
    var ajaxConfig = {
        type: "post",
        url: "/AMessage/sendMessageToAllUsers",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes("İşlem Başarılı");
                setTimeout(function myfunction() {
                    window.location.reload();
                }, 2000);
            }
            else {
                warningMes("Mesajlar iletilemedi", "Hata ile karşılaşıldı");
            }
        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;

}


$('.calculate').on('click', function myfunction() {

    $(".pushDeserve").html("");

    var val = $(this).attr('empDeserveId');

    $(".calc2").attr('eid', val);


});


$(".calc2").on('click', function myfunction() {

    var startDate = $('#startDate').val();
    var endDate = $('#endDate').val();

    var empid = $(this).attr('eid');

    var data = {

        StartDate: startDate,
        EndDate: endDate,
        EmpID: empid

    };


    if (data.StartDate == "" || data.StartDate == null || data.StartDate == undefined) {
        warningMes("Başlangıç Tarihini Giriniz");
    } else if (data.EndDate == "" || data.EndDate == null || data.EndDate == undefined) {
        warningMes("Bitiş Tarihini Giriniz");
    } else if (data.EmpID == null || data.EmpID == undefined) {
        warningMes("Modele ulaşamadı", "Hata Kodu:01");
    }
    else if (data.StartDate > data.EndDate) {
        warningMes("Başlangıç zamanı ileride olamaz");
    }
    else {
        $.ajax({
            url: "/Payment/calcDeserve",
            type: "post",
            data: data,
            success: function (control) {

                for (var i = 0; i < control.length; i++) {
                    var date = new Date(parseInt(control[i].startTime.replace("/Date(", "").replace(")/", "")));
                    var fdate = (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear();
                    control[i].startTime = fdate;

                }

                var hmtlInside = "";
               
                    for (var i = 0; i < control.length; i++) {

                        hmtlInside += ` <tr >  
                             <td>${control[i].CustomerName}</td>

                             <td>${control[i].Credit}</td>

                            <td>${control[i].startTime}</td>

                      
                       </tr>`;
                    }
              
                    $(".pushDeserve").html(hmtlInside);

                var sumofDes=0;
                for (var i = 0; i < control.length; i++) {
                    sumofDes = sumofDes + control[i].Credit;
                }

                $(".sumOfDeserve").html(sumofDes + " Kredi kazandırmış "+ sumofDes*0.56+" TL Ödeme yapılacaktır.(Ödemeler %56 üzerinden hesaplanmaktadır.)");
                
            }
        });
    }

});



$(".getEmpList").on('click', function myfunction() {

    $.ajax({
        url: "/AEmployee/getEmp",
        type: "get",
        success: function (list) {

            var htmlList = `<option selected value="${0}">Seçim Yapınız</option>`;

            for (var i = 0; i < list.length; i++) {

                htmlList += `<option value="${list[i].ID}">${list[i].UserName}</option>`;
            }
            $('#makePayEmpList').html(htmlList);
            }
    });

});

function entriesPaymnet(formData) {

    var ajaxConfig = {
        type: "post",
        url: "/Payment/sendPaymentInfo",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes("Ödeme Bilgisi Kaydedildi");
                setTimeout(function myfunction() {
                    window.location.reload();
                }, 2000);
            }
            else {
                warningMes("Ödeme Bilgisi Kaydedilemedi", "Hata ile karşılaşıldı");
            }
        }
    }
    if ($(formData).attr('enctype') == "multipart/form-data") {
        ajaxConfig["contentType"] = false;
        ajaxConfig["processData"] = false;
    }
    $.ajax(ajaxConfig);

    return false;

};



$('.sTakeId').on('click', function takeId() {
    $('.sonayBtn').attr('okscusid', $(this).attr('scusid'));
});


$('.sonayBtn').on('click', function takeId() {
  
    var data ={ ID:$(this).attr('okscusid') };
    
    if (data) {
        $.ajax({
            url: "/ACustomer/UpdateStatus",
            type: "post",
            data:data,
            success: function (data) {
                if (data == true) {
                    sucMes("Kullanıcı durumu değiştirildi", "Başarılı");
                    setTimeout(function myfunction() {
                        window.location.reload();
                    },1000);
                }
                else {
                     warningMes('Kullanıcıya durumu değiştirilemedi', "Hata ile karşılaşıldı");
                }
            }
        });
    } else {
        warningMes('Kullanıcıya ulaşılamadı', "Hata ile karşılaşıldı");
    }
});

$('.sempTakeId').on('click', function takeId() {
    $('.sempOnayBtn').attr('sempOnId', $(this).attr('sempid'));
});


$('.sempOnayBtn').on('click', function takeId() {
  
    var data = { ID: $(this).attr('sempOnId') };
    
    if (data) {
        $.ajax({
            url: "/AEmployee/UpdateStatus",
            type: "post",
            data:data,
            success: function (data) {
                if (data == true) {
                    sucMes("Kullanıcı durumu değiştirildi", "Başarılı");
                    setTimeout(function myfunction() {
                        window.location.reload();
                    },1000);
                }
                else {
                     warningMes('Kullanıcıya durumu değiştirilemedi', "Hata ile karşılaşıldı");
                }
            }
        });
    } else {
        warningMes('Kullanıcıya ulaşılamadı', "Hata ile karşılaşıldı");
    }
});


    //var selValue = $("#makePayEmpList").val();

