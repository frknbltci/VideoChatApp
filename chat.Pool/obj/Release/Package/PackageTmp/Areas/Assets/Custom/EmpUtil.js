//function readURL(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();

//        reader.onload = function (e) {
//            $('#uploadImage').attr('src', e.target.result);
//        }

//        reader.readAsDataURL(input.files[0]);
//    }
//}

//$("#EmpProfilePhoto").change(function () {
//    readURL(this);
//});


$('.showD').on('click', function () {

    var sImg = $(this).attr('imgUrl');

    $("#showDk").attr('src', sImg);

});

function answerCall(name) {

    toastr["success"](`<div>${name}</div><div><button type='button' onclick='refuse()' id='refuseBtn'class='btn btn-danger'>Reddet</button><button type='button' id='acceptBtn' class='btn btn-success' onclick='accept()' style='margin: 0 8px 0 8px; float:right;'>Kabul Et</button></div>`);

toastr.options = {
  "closeButton": true,
  "debug": false,
  "newestOnTop": false,
  "progressBar": true,
  "positionClass": "toast-top-right",
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
}
}

function infoMes(message, title) {

    toastr.info(message, title, toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    })



};
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

//function Accept() {
//    alert("Kabul Edildi");
//}

//window.onload = function () {

//    // Normalize the various vendor prefixed versions of getUserMedia.
//    navigator.getUserMedia = (navigator.getUserMedia ||
//        navigator.webkitGetUserMedia ||
//        navigator.mozGetUserMedia ||
//        navigator.msGetUserMedia);

//    // Check that the browser supports getUserMedia.
//    // If it doesn't show an alert, otherwise continue.
//    if (navigator.getUserMedia) {
//        // Request the camera.
//        navigator.getUserMedia(
//            // Constraints
//            {
//                video: true
//            },

//            // Success Callback
//            function (localMediaStream) {
//                // Get a reference to the video element on the page.
//                var vid = document.getElementById('camera-stream');

//                // Create an object URL for the video stream and use this 
//                // to set the video source.
//                vid.src = window.URL.createObjectURL(localMediaStream);

//            },

//            // Error Callback
//            function (err) {
//                // Log the error to the console.
//                console.log('The following error occurred when trying to use getUserMedia: ' + err);
//            }
//        );

//    } else {
//        alert('Sorry, your browser does not support getUserMedia');
//    }




//}


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


function EmployeeLogin(formData) {


    var ajaxConfig = {
        type: "post",
        url: "/Employee/EmpLogin/doLogin",
        data: new FormData(formData),
        success: function (e) {
            if (e == true) {
                sucMes("Başarılı Yönlendiriliyorsunuz");
                setTimeout(function myfunction() {
                    window.location.href = "/Employee/EmpHome/Index";
                }, 1000);   
            }
            else {
                errorMes("Email veya Şifre Hatalı");
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


//global defines
var eid;
var ownid;
var refuseId;
var acceptId;
var ownName;


$(document).ready(function () {

    $.connection.hub.start({ transport: ['webSockets', 'longPolling'] });
    var noti = $.connection.notificationHub;


    console.log($.connection.hub.start({ transport: ['webSockets', 'longPolling'] }));

    noti.client.getMessageOther = function (eid, ownid, name) {

      //  console.log("Arama Geldi");

        refuseId = ownid;
        acceptId = ownid;

        var empown = $("#empOwnId").val();
        //Burdan arama düşüyor mu diye bak
        console.log("eid :" + eid + "empown : " + empown);

        if (eid == empown) {
            answerCall(name);
        }

    };

});


//Kabul Red Durumları 


function accept() {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < 13; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    ownid = $("#empOwnId").val();
  
    var stData = {
        CusID: acceptId,
        EmpID: ownid
    };

    $.ajax({

        type: "post",
        url: "/SpecialRoom/inRoomChangeStatus",
        data: stData,
        dataType: "json",
        success: function (e) {

        }
    });

    var data = {
        roomNumber: result,
        cusId: acceptId,
        empId: ownid
    };

    $.ajax({

        type: "post",
        url: "/SpecialRoom/createRoom",
        data: data,
        dataType: "json",
        success: function (e) {

            $.connection.hub.start({ transport: ['webSockets', 'longPolling'] });
            var noti = $.connection.notificationHub;

            try {
                noti.server.sendRouteMessage(data.roomNumber, data.cusId, data.empId);
            } catch (e) {

                alert("Yönlenme Başarısız");
                //post yaptırıp 20 kredisini geri yükleyip anasayfaya döndür

            }

            var currentHost = window.location.origin;
            window.location.href = currentHost + "/SpecialRoom/Oda?room_id=" + e + "&userid=" + data.cusId + "&empid=" + data.empId + "";

        }
    });

}

function refuse() {
    $.connection.hub.start({ transport: ['webSockets', 'longPolling'] });
    var noti = $.connection.notificationHub;

    var refId = refuseId;
    var refuseName = $("#empName").html();
    try {
        noti.server.sendRefuseMessage(refId, refuseName);
        $(".toast-success").hide();
        infoMes("Aramayı Reddettiniz", "");
    } catch (e) {
        alert(e);
        warningMes("Cevap Gönderilemedi", "");
    }

}



$(".takems").on("click", function myfunction() {


    var message = $(this).attr('mssg');
    $(".pushMes").html(message);


    var messageId = $(this).attr('mid');
   
    var data = {
        ID: messageId
    };

    $.ajax({
        url: "/Employee/EmpMessages/changeView",
        data: data,
        type: "post",
        success: function (e) {


        }

    });

});


 // Çevrimdurumu güncelleme

$('#statu').on('change', function myfunction() {

    var statId = $('#statu').val();
    var empsesid = $(this).attr('empsesid');

    if (statId == null || statId == undefined || empsesid == null || empsesid == undefined) {
        warningMes("Bilgiler alınamadı", "Tekrar sisteme giriş yapıp deneyebilirsiniz");

    } else {
        var data = {
            statusId: statId,
            empId: empsesid
        };


        $.ajax({
            url: "/Employee/EmpProfile/changeStatus",
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


$(".calc").on('click', function myfunction() {

  

    var startDate = $('#startDate').val();
    var endDate = $('#endDate').val();

    var empid = $('#empOwnId').val();

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
            url: "/Employee/EmpKazanc/calcOwnDeserve",
            type: "post",
            data: data,
            success: function (control) {

                for (var i = 0; i < control.length; i++) {
                    var date = new Date(parseInt(control[i].Time.replace("/Date(", "").replace(")/", "")));
                    var fdate = (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear();
                    control[i].Time = fdate;
                }

                var hmtlInside = "";

                for (var i = 0; i < control.length; i++) {

                    hmtlInside += ` <tr >  
                             <td>${control[i].CustomerName}</td>

                             <td>${control[i].Credit}</td>

                            <td>${control[i].Time}</td> 

                   
                       </tr>`;
                }

                $(".pushOwnDeserve").html(hmtlInside);


                var sumOfCre=0;
                for (var i = 0; i < control.length; i++) {
                    sumOfCre = sumOfCre + control[i].Credit;
                }

                //var sumofDes = control.length * 50;
                $(".infoOwnDeserve").html(sumOfCre + " Kredi kazandırmışssınız. Bu kredi üzerinden  anasayfanızda belirtilen yüzdelik dilimine göre <span class='red'> " + sumOfCre * 0.56 + " TL </span> ödeme alacaksınız.");

            }
        });
    }

});

$('.galImg').on('click', function myfunction() {

    var fname = $(this).attr('src');

    $('.galImg').removeClass('border-success');

    $(this).addClass('border-success');

    $('.saveRes').attr('fname', fname);
    
});


$('.saveRes').on('click', function myfunction() {

    var pName = $(this).attr('fname');

    $('#uploadImage').attr('src', pName);
    
    $('.sendValImg').val(pName);
});



//f12 ve dev-tool kapatıyoruz

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
