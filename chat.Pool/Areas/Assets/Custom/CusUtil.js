//Customer special scripts

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


function cusLoginPost(formData) {

    var cEmail = $('#cEmail').val();
    var cPassword = $('#cPassword').val();

    var ajaxConfig = {
        type: "post",
        url: "/Customer/CusLogin/doLogin",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes(cEmail, "Başarılı Yönlendiriliyorsunuz");
                setTimeout(function () {
                    window.location.href = "/MainPage/Index";
                   
                },1000)
            }
            else {
                errorMes("Kullanıcı Adı veya Şifre Hatalı");
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


function callMes(message, title) {
    toastr.success(message, title, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-full-width",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "5000",
        "hideDuration": "50000",
        "timeOut": "50000",
        "extendedTimeOut": "50000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut",
        "tapToDismiss": false

    });
}

function reload() {
    window.location.reload();

}

$(".takeCusms").on("click", function myfunction() {

    var message = $(this).attr('mss');
    $(".pushMes").html(message);

    var messageId = $(this).attr('mid');
    console.log(messageId);
    var data = {
        ID: messageId
    };

    $.ajax({
        url: "/Customer/Messages/changeView",
        data: data,
        type: "post",
        success: function (e) {
            

        }

    });

});



$('.outBan').on("click", function nextFunction() {

    var empId = $(this).attr('mid'); 
    $(".sendBanId").attr("eid", empId);

});

$('.sendBanId').on("click", function nextFunction() {

    var OwnId = $('#empOwnId').val();
    var empId = $(this).attr('eid');

    if (OwnId == null || empId == null) {

        warningMes("Modele ulaşırken hata ile karşılaşıldı");
    }
    else {

        var data = {
            CustomerId: OwnId,
            EmployeeId: empId
        };

        $.ajax({
            url: "/Customer/CusModal/outBan",
            data: data,
            type: "post",
            success: function (e) {
                if (e == true) {
                    sucMes("Başarıyla Kaldırıldı");
                    setInterval(function myfunction() {
                        window.location.reload();
                    }, 1000);
                } else {
                    warningMes("Hata ile Karşılaşıldı");
                }

            }

        });
    }


});



//Favorilerden kaldırma işlemleri
$('.sendtoBtnFavId').on('click', function myfunction() {

    var mid = $(this).attr('mid');

    if (mid == null || mid == undefined || mid == 0) {
        warningMes("Model Bilgisine ulaşılamadı","Sayfayı yenileyip yada tekrar giriş yapmayı deneyebilirsiniz.");
    }
    else {
        $('.sendFavId').attr('eid', mid);
    }
   
});



$('.sendFavId').on('click', function myfunction() {

    var OwnId = $('#empOwnId').val();
    var modelId = $(this).attr('eid');

    if (OwnId == null || modelId == null || modelId == undefined || modelId == 0 || OwnId == undefined) {
        warningMes("Modele ulaşırken hata ile karşılaşıldı.");
    }
    else {

        var data = {
            CustomerId: OwnId,
            EmployeeId: modelId
        };

        $.ajax({
            url: "/Customer/CusModal/outFav",
            data: data,
            type: "post",
            success: function (e) {
                if (e == true) {
                    sucMes("Başarıyla Kaldırıldı");
                    setInterval(function myfunction() {
                        window.location.reload();
                    }, 1000);
                } else {
                    warningMes("Hata ile Karşılaşıldı");
                }

            }

        });
    }
});


$('.sendFavEmpId').on('click', function myfunction() {

    var mid = $(this).attr('mid');
    $(".makeFavCall").attr('empFavid', mid);

});

$(".makeFavCall").on('click', function myfunction() {

    var param1 = $(this).attr('empfavid');
    var param2 = $("#empOwnId").val(); 
    var param3 = $("#empName").attr('uname');


    //Param2 arayan Id  

    var dsuit = {
        CustomerId: param2
    };

    $.ajax({
        type: "post",
        url: "/MainPage/isCreditSuit",
        dataType: "json",
        data: dsuit,
        success: function (e) {
            if (e==true) {
                var d = {
                    eid: param1
                };

                $.ajax({
                    type: "post",
                    url: "/MainPage/isStatusOnline",
                    dataType: "json",
                    data: d,
                    success: function (e) {
                        if (e==1) {

                            $.connection.hub.start({ transport: ['webSockets', 'longPolling'] });
                            var noti = $.connection.notificationHub;


                            try {
                                noti.server.sendMessage(param1, param2, param3);
                                $(".toast-success").show();
                                callMes("Arama yapılıyor lütfen bekleyin", "Cevap bekleniyor");
                            } catch (e) {

                                alert("Arama Gönderilemedi");
                            }


                        } else if (e == 2) {
                            warningMes("Model şuan çevrimdışı", "Başka bir modeli aramayı deneyebilirsiniz");

                        } else if (e == false) {
                            errorMes("Hata ile karşılaşıldı", "Hata kodu:23-2");
                        }
                        else {
                            warningMes("Model şuan meşgul", "Başka bir modeli aramayı deneyebilirsiniz.");
                        }
                    }
                    });
            }
            else {
                warningMes("Yetersiz Kredi", "Giriş Ekranından Kredi Satın Alabilirsiniz.");
            }
        }


    });

    //param1 model ıd si oda çevrim durumu kontrol edilecek

});



$(document).ready(function () {


    $.connection.hub.start({ transport: ['webSockets', 'longPolling'] });
    var noti = $.connection.notificationHub;

    // Aramayı red durumu
    noti.client.getRefuseMessageOther = function (refuseid, name) {
        ownid = $("#empOwnId").val(); 
        if (refuseid == ownid) {

            $(".toast-success").hide();
            infoMes("kullanıcısı aramanızı reddetti. Aramayı kapatıp yeni bir arama yapabilirsiniz.", name);


        }
    };

    // Yönlenme Durumu
    noti.client.getSendRouteAll = function (roomNumber, cusId, empId) {
        ownid = $("#empOwnId").val();
        if (ownid == cusId) {
            var currentHost = window.location.origin;
            window.location.href = currentHost + "/SpecialRoom/Oda?room_id=" + roomNumber + "&userid=" + cusId + "&empid=" + empId + "&cal1=" + cusId + "" + empId + "&cal2=" + empId + "" + cusId + + "";
        }
    }
});



//Status Güncelleme

$('#statuCus').on('change', function myfunction() {

    var statId = $('#statuCus').val();
    var cussesid = $(this).attr('cussesid');

    if (statId == null || statId == undefined || cussesid == null || cussesid == undefined) {
        warningMes("Bilgiler alınamadı", "Tekrar sisteme giriş yapıp deneyebilirsiniz");

    } else {
        var data = {
            statusId: statId,
            cusId: cussesid
        };

        $.ajax({
            url: "/Customer/CusProfile/changeStatus",
            data: data,
            type: "post",
            success: function (e) {

                if (e == true) {
                    sucMes("Durum Güncellemesi başarılı");
                } else {
                    warningMes("Durumu güncellemesi sırasında hata oluştu");
                }
            }

        });
    }




});


//Galeri

$('.galImgCus').on('click', function myfunction() {

  

    var fname = $(this).attr('src');

    $('.galImgCus').removeClass('border-success');

    $(this).addClass('border-success');

    $('.saveResCus').attr('fname', fname);

});


$('.saveResCus').on('click', function myfunction() {

    var pName = $(this).attr('fname');

    $('#uploadImage').attr('src', pName);

    $('.sendValImgCus').val(pName);
});


var dataPayErr = $('#mesErrPayment').html();

if (dataPayErr.length > 50) {
   setTimeout(logOut,5000);
    }
else {

}
function logOut() {
    window.location.href="/PoolLogin/Logout";
}

//f12 ve sol tık kapatıyoruz

window.addEventListener('keydown', e => {
    if (e.key === 'F12') // detect f12
        e.preventDefault();
})
jQuery(document).ready(function () {
    function disableSelection(e) {
        if (typeof e.onselectstart != "undefined") e.onselectstart = function () {
            return false
        };
        else if (typeof e.style.MozUserSelect != "undefined") e.style.MozUserSelect = "none";
        else e.onmousedown = function () {
            return false
        };
        e.style.cursor = "default"
    }
    window.onload = function () {
        disableSelection(document.body)
    };

    window.addEventListener("keydown", function (e) {
        if (e.ctrlKey && (e.which == 65 || e.which == 66 || e.which == 67 || e.which == 70 || e.which == 73 || e.which == 80 || e.which == 83 || e.which == 85 || e.which == 86)) {
            e.preventDefault()
        }
    });
    document.keypress = function (e) {
        if (e.ctrlKey && (e.which == 65 || e.which == 66 || e.which == 70 || e.which == 67 || e.which == 73 || e.which == 80 || e.which == 83 || e.which == 85 || e.which == 86)) { }
        return false
    };

    document.onkeydown = function (e) {
        e = e || window.event;
        if (e.keyCode == 123 || e.keyCode == 18) {
            return false
        }
    };

    document.oncontextmenu = function (e) {
        var t = e || window.event;
        var n = t.target || t.srcElement;
        if (n.nodeName != "A") return false
    };
    document.ondragstart = function () {
        return false
    };

});
