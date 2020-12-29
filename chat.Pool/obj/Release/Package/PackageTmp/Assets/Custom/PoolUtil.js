//f12 ve dev tool kapadık

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
    //window.onload = function () {
    //    disableSelection(document.body)
    //};

    //window.addEventListener("keydown", function (e) {
    //    if (e.ctrlKey && (e.which == 65 || e.which == 66 || e.which == 67 || e.which == 70 || e.which == 73 || e.which == 80 || e.which == 83 || e.which == 85 || e.which == 86)) {
    //        e.preventDefault()
    //    }
    //});
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
        "hideDuration": "3000",
        "timeOut": "8000",
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

function answerCall(name) {

    toastr["success"](`<span>${name}</span><div></div><div><button type='button' onclick='refuse()' id='refuseBtn'class='btn btn-danger'>Reddet</button><button type='button' id='acceptBtn' class='btn btn-success' onclick='accept()' style='margin: 0 8px 0 8px; float:right;'>Kabul Et</button></div>`);

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": true,
        "positionClass": "toast-top-right messagecall",
        "preventDuplicates": false,
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



//$('.createRoom').on('click',function(){

//    var odaNumber=makeid(8);

//    //Oda numarasını post edip bu oda numarasını bildirim olarak göndericez
//    //Employe karşı tarafta bildirimi alıp aynı url'ye geçiş yapıcak


//});

function poolLoginPost(formData) {
    var ajaxConfig = {
        type: "post",
        url: "/PoolLogin/doLogin",
        data: new FormData(formData),
        success: function (e) {
            if (e == "emp") {
                sucMes("Başarılı Yönlendiriliyorsunuz");
                setTimeout(function myfunction() {
                    window.location.href = "/Employee/EmpHome/Index";
                }, 1000);
            }
            else if (e == "cus") {
                sucMes("Başarılı Yönlendiriliyorsunuz");
                setTimeout(function myfunction() {
                    window.location.href = "/MainPage/Index";
                }, 1000);
            }
            else if (e == true) {
                errorMes("Hesabınız henüz aktif edilmedi.Giriş yapmak için size ulaşmamızı bekleyin.");
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
var comeConv = new Array();


$('.showPopUpCall').on("click", function myfunction() {
    eid = $(this).attr("eid");
    ownid = $(".ownid").html();
});

$('.stclr').on('click', function myfunction() {
    sessionStorage.clear();
});

$(document).ready(function () {
    var retrievedObject = JSON.parse(sessionStorage.getItem('abc'));
    if (retrievedObject != null) {
       
        comeConv = retrievedObject;
        $('.convCount').html(comeConv.length);
    }


    //$.connection.hub.disconnected(function () {
    //    alert('Server has disconnected');
    //});

    //console.log("Bağlantı" + $.connection.hub.start());

    //console.log("Bağlantı sonu" + $.connection.hub.disconnected());



    $.connection.hub.start({ transport: ['webSockets', 'longPolling'] });
    var mess = $.connection.notificationHub;

    //setTimeout(function gossterr() {
    //    console.log(mess);

    //}, 2000);

    mess.client.sendInfo = function (uname, message, imgUrl) {

        var ownName = $('#uNamePool').html();

        if (uname === ownName) {

            var html = `<div style="padding:8px;" class="chat">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${imgUrl}" alt="avatar" />
                            <span class="musname">${uname}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${message}</p>
                                    </div>
                                </div>
                            </div>`;

        } else {
            var html = `<div style="padding:8px;" class="chat chat-left">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${imgUrl}" alt="avatar" />
                            <span class="musname">${uname}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${message}</p>
                                    </div>
                                </div>
                            </div>`;
        }




        $(".pshMes").append(html);


    };

    //mess.client.sendConvMessage = function (convMes,uname,imgUrl,reciveID) {

    //    var data = {
    //        a: convMes,
    //        b: uname,
    //        c: imgUrl,
    //        d: reciveID
    //    };

    //    console.log(data);

    //}

   var video = document.querySelector("#videoElement");

    if (navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices.getUserMedia({ video: true })
            .then(function (stream) {
                video.srcObject = stream;
            })
            .catch(function (err0r) {
                console.log("Something went wrong!");
            });
    }
    
    function stop(e) {
        var stream = video.srcObject;
        var tracks = stream.getTracks();

        for (var i = 0; i < tracks.length; i++) {
            var track = tracks[i];
            track.stop();
        }

        video.srcObject = null;
    }

    $.connection.hub.start();
    var noti = $.connection.notificationHub;

    //Havuzdan bil
    noti.client.getMessageOther = function (eid, ownid, name) {

        // console.log("Arama Pool");
        refuseId = ownid;
        acceptId = ownid;
        ownid = $(".ownid").html();
        if (eid == ownid) {
            answerCall(name);
        }
    };

    //Havuzdaki Aramayı red durumu
    noti.client.getRefuseMessageOther = function (refuseid, name) {
        ownid = $(".ownid").html();
        if (refuseid == ownid) {

            $(".toast-success").hide();
            infoMes("kullanıcısı aramanızı reddetti. Aramayı kapatıp yeni bir arama yapabilirsiniz.", name);


        }
    };

    //Havuzdan Yönlenme Durumu
    noti.client.getSendRouteAll = function (roomNumber, cusId, empId) {
        ownid = $(".ownid").html();
        if (ownid == cusId) {
            var currentHost = window.location.origin;
            window.location.href = currentHost + "/SpecialRoom/Oda?room_id=" + roomNumber + "&userid=" + cusId + "&empid=" + empId + "&cal1=" + cusId + "" + empId + "&cal2=" + empId + "" + cusId + + "";
        }
    }


    $('.makeCall').click(function () {

        var cuid = ownid;
        var dataSuit = {
            CustomerId: cuid
        };

        $.ajax({
            type: "post",
            url: "/MainPage/isCreditSuit",
            dataType: "json",
            data: dataSuit,
            success: function (e) {

                if (e == true) {

                    var dt = {
                        eid: eid
                    };

                    $.ajax({
                        type: "post",
                        url: "/MainPage/isStatusOnline",
                        dataType: "json",
                        data: dt,
                        success: function (e) {
                            if (e == 1) {
                                var param1 = eid;
                                var param2 = ownid;
                                var param3 = $("#uNamePool").html();
                                try {
                                    noti.server.sendMessage(param1, param2, param3);
                                    $(".toast-success").show();
                                    callMes("Arama yapılıyor lütfen bekleyin", "Cevap bekleniyor");
                                } catch (e) {

                                    alert("Arama Gönderilemedi");
                                }
                            } else if (e == 2) {
                                warningMes("Model şuan çevrimdışı", "Başka bir modeli aramayı deneyebilirsiniz");
                            }
                            else if (e == false) {
                                errorMes("Hata ile karşılaşıldı", "Hata kodu:23")
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

    });


    //$.ajax({
    //    type: "post",
    //    url: "/MainPage/getUsers",
    //    dataType: "json",
    //    success: function (e) {

    //        $('.userCount').html(e.length);
    //    }
    //});

   
    
    mess.client.sendMessageConvOther = function (messageSpecial, uname, imgUrl, recId,senderid) {

        if (ansid == senderid) {
            console.log("Yes");
        }
        else {
            console.log("No");
        }

        //var ownName = $('#uNamePool').html();
        var ownId = $('.ownid').html();

        if (recId == ownId) {

            var html = `<div style="padding:8px;" class="chat chat-left">
                                    <div class="chat-avatar">
                                        <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                            <img class="poolPP" src="${imgUrl}" alt="avatar" />
                                <span class="musname">${uname}</span>
                                        </a>
                                    </div>
                                    <div class="chat-body">
                                        <div class="chat-content">
                                            <p>${messageSpecial}</p>
                                        </div>
                                    </div>
                                </div>`;
            

                if (comeConv.length == 0) {
                    var comeData = {
                        UserName: uname,
                        Message: messageSpecial,
                        SenderID: senderid
                    };
                   
                    comeConv.push(comeData);   
                    sessionStorage.setItem('abc', JSON.stringify(comeConv));
                    var retrievedObject = sessionStorage.getItem('abc');

                    
                 
                } else {
                 
                    var diziName = new Array();
                    for (var i = 0; i < comeConv.length; i++) {
                        diziName.push(comeConv[i].UserName);
                    }
                
                 
                    var sonuc = diziName.indexOf(uname);

                    if (sonuc === -1) {
                   
                        var comeData = {
                                UserName: uname,
                                Message: messageSpecial,
                                SenderID: senderid
                            };

                            comeConv.push(comeData);
                        sessionStorage.setItem('abc', JSON.stringify(comeConv));
                    } else {

                    }
                    
                }
                
            $('.convCount').html(comeConv.length);
          
            if (ansid == senderid) {
                $(".spMessage").append(html);
            }

        } else {
            //var html = `<div style="padding:8px;" class="chat">
            //                        <div class="chat-avatar">
            //                            <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
            //                                <img class="poolPP" src="${imgUrl}" alt="avatar" />
            //                    <span class="musname">${uname}</span>
            //                            </a>
            //                        </div>
            //                        <div class="chat-body">
            //                            <div class="chat-content">
            //                                <p>${messageSpecial}</p>
            //                            </div>
            //                        </div>
            //                    </div>`;

        }
    }

});

//Employe havuz konuşmasındayken bildirim düştüğünde kabule basma durumu parametreleri alıp post işlemi ile oda yönlendirilmesi yapılmaktadır.

function accept() {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < 13; i++) {
        result += characters.charAt(Math.floor(Math.random() * charactersLength));
    }
    ownid = $(".ownid").html();


    //Odaya düşme anında statusleri güncellenecek
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

            $.connection.hub.start();
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

//Bildirimi arayan tarafında yakalayabilmek için önce dinleyip arayanın Idsini yakalıyoruz sonra da send ile göndericez

function refuse() {
    $.connection.hub.start();
    var noti = $.connection.notificationHub;

    var refId = refuseId;
    var refuseName = $("#uNamePool").html();
    try {
        noti.server.sendRefuseMessage(refId, refuseName);
        $(".toast-success").hide();
        infoMes("Aramayı Reddettiniz", "");
    } catch (e) {

        warningMes("Cevap Gönderilemedi", "");
    }

}



//Anasayfadan kişinin ismine göre yönlendirme
function sendtoHome() {
    var usname = $("#uNamePool").html();

    var data = {
        UserName: usname
    };

    $.ajax({
        type: "post",
        url: "/MainPage/routuToHome",
        data: data,
        dataType: "json",
        success: function (e) {
            if (e == "emp") {
                setTimeout(function myfunction() {
                    window.location.href = "/Employee/EmpHome/Index";
                }, 1000);
            }
            else if (e == "cus") {
                setTimeout(function myfunction() {
                    window.location.href = "/Customer/CusHome/Index";
                }, 1000);
            }
            else {
                setTimeout(function myfunction() {
                    warningMes("Problemle Karşılaşıldı", "Tekrar Giriş Yapmayı Deneyebilirsiniz");
                }, 1000);
            }

        }
    });
}



$(".takeId").on('click', function myfunction() {

    var data = {
        ID: $(".ownid").html(),
        UserName: $("#uNamePool").html()
    };


    $.ajax({
        type: "post",
        url: "/MainPage/getMessage",
        data: data,
        dataType: "json",
        success: function (e) {
            let notReadCount = 0;

            for (var i = 0; i < e.length; i++) {
                var date = new Date(parseInt(e[i].SendDate.replace("/Date(", "").replace(")/", "")));
                var fdate = (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear();
                e[i].SendDate = fdate;
                if (e[i].Viewed == false) {
                    notReadCount++;
                }
            }
            $(".notViewed").html(notReadCount + " Okunmamış Bildirim");
            
            var hmtlInside = "";
            for (var i = 0; i < e.length; i++) {
                if (e[i].Viewed == false) {
                    hmtlInside += `<li data-target="#showMessagePop" data-toggle="modal" class="scrollable-container media-list w-100">
                                        <a href="#" >
                                            <div class="media">
                                                <div class="media">
                                                    <div class="media-left">
                                                    </div> <div class="media-body">
                                                        <h6 class="media-heading">Admin<span class="notification-tag badge badge-default badge-warning float-right m-0" style=" float: inherit!important; top: initial !important; right: inherit !important; left: 3px; "> </span></h6>
                                                        <p class="notification-text font-small-3 text-muted" ms=${e[i].Message}>${e[i].About}</p>
                                                        <small>
                                                            <time class="media-meta text-muted">${e[i].About}</time>
                                                        </small>
                                                    </div>
                                                </div>
                                            </div>
                                        </a>
                                    </li>`;
                }
                else {
                    hmtlInside += `<li data-target="#showMessagePop" data-toggle="modal" class="scrollable-container media-list w-100">
                                        <a href="#">
                                            <div class="media">
                                                <div class="media">
                                                    <div class="media-left">
                                                    </div> <div class="media-body">
                                                        <h6 class="media-heading">Admin</h6>
                                                        <p class="notification-text font-small-3 text-muted" ms="${e[i].Message}">${e[i].About}</p>
                                                        <small>
                                                            <time class="media-meta text-muted">${e[i].SendDate}</time>
                                                        </small>
                                                    </div>
                                                </div>
                                            </div>
                                        </a>
                                    </li>`;
                }
            }

            $(".appendMessage").html(hmtlInside);

        }
    });
});



$('.goMessages').on("click", function myfunction() {
    var UserName = $("#uNamePool").html();
    var ID = $(".ownid").html();
    var data = {
        UserName: UserName,
        ID: ID
    };


    $.ajax({
        type: "post",
        url: "/MainPage/routeToMessages",
        data: data,
        dataType: "json",
        success: function (e) {
            if (e == "emp") {
                setTimeout(function myfunction() {
                    window.location.href = "/Employee/EmpMessages/Messages";
                }, 1000);
            }
            else if (e == "cus") {
                setTimeout(function myfunction() {
                    window.location.href = "/Customer/Messages/Messages";
                }, 1000);
            }
            else {
                setTimeout(function myfunction() {
                    warningMes("Problemle Karşılaşıldı", "Tekrar Giriş Yapmayı Deneyebilirsiniz");
                }, 1000);
            }

        }
    });
});


//$(".takeParams").on("click", function myfunction() {
//    var data = {
//       
//    }
//    console.log(data);

//});


$(".faviadd").on("click", function cvcbj() {

    var efid = $(this).attr("efid");

    $(".addFav").attr("eid", efid);
    $(".addBan").attr("eid", efid);
    $(".delFav").attr("eid", efid);

    if (efid == null || efid == undefined) {
        warningMes("Kullanıcıya ulaşılamadı");
    }
    else {
   
        var data = {
            ID: efid
        };

        $.ajax({
            type: "post",
            url: "/MainPage/getEmployeeInfo",
            data: data,
            dataType: "json",
            success: function (emp) {
                var html =
                    `<div class="col-md-6"> Yaş:${emp.Yas} <br />  Kilo:${emp.Weight} <br /> Boy:${emp.Length} <br /> Saç Tipi:${emp.HairTypeName} <br /> Saç Rengi:${emp.HairColorName} <br /> Göz Rengi:${emp.EyeColorName} <br /> Vücut Tipi:${emp.BodyTypeName} <br /> Hakkında:${emp.About} <br /> </div>
                        <div class="col-md-6">
                        <img height="250" width="200" src="${emp.ImgUrl}" /> </div>
                            `;

                $("#empData").html(html);
                $("#empData2").html(html);
            }
        });
    }




});

//Favorilere Ekle
$(".addFav").on("click", function asd() {

    data = {
        CustomerID: $(".ownid").html(),
        EmployeeID: $(this).attr("eid")

    };

    $.ajax({
        type: "post",
        url: "/MainPage/addFav",
        data: data,
        dataType: "json",
        success: function (e) {
            if (e == true) {
                $(".addFavIcon" + data.EmployeeID + "").html('<i class="la la-heart" style="color:red"></i>')

                $(".addPopUpIcon" + data.EmployeeID + "").html(`<a href="javascript:void(0)" class="faviadd" efid="${data.EmployeeID}" style="text-decoration:none;" data-target="#favnotPopUp" data-toggle="modal"> <i  class="la la-info-circle infoIcon"></i></a>`)

                sucMes("Başarıyla Eklendi", "");

            }
            else {
                errorMes("Favorilere Eklerken hata ile karşılaşıldı.")
            }
        }
    });

});

$(".delFav").on("click", function mfunction() {
    
    data = {
        CustomerID: $(".ownid").html(),
        EmployeeID: $(this).attr("eid")

    };

    $.ajax({
        type: "post",
        url: "/MainPage/delFav",
        data: data,
        dataType: "json",
        success: function (e) {
            if (e == true) {

                $(".addPopUpIcon" + data.EmployeeID + "").html(`<a href="javascript:void(0)" class="faviadd" efid="${data.EmployeeID}" style="text-decoration:none;" data-target="#favPopUp" data-toggle="modal"> <i  class="la la-info-circle infoIcon"></i></a>`)

                $(".addFavIcon" + data.EmployeeID + "").html('')
                sucMes("Favorilerden başarıyla Çıkarıldı", "");

            }
            else {
                errorMes("Favorilerden çıkarırken hata ile karşılaşıldı.")
            }
        }
    });

});


$(".addBan").on("click", function myfnc() {

    var data = {
        CustomerID: $(".ownid").html(),
        EmployeeID: $(this).attr("eid"),
    };

    if (data.CustomerID == null || data.EmployeeID == null) {
        warningMes("Engelleme sırasında bir hata oluştu", "Hata Kodu 81");
    } else {
        $.ajax({
            type: "post",
            url: "/MainPage/addBan",
            data: data,
            dataType: "json",
            success: function (e) {
                if (e == true) {
                    sucMes("Engelleme İşlemi Başarılı");
                    setInterval(function myfunction() {
                        window.location.reload();
                    }, 1000);
                }
                else {
                    warningMes("Engelleme sırasında bir hata ile karşılaşıldı", "Hata Kodu 82")
                }
            }
        });
    }

});



$(".getUsers").on('click', function myfunction() {

    $.ajax({
        type: "post",
        url: "/MainPage/getUsers",
        dataType: "json",
        success: function (e) {
            if (e == false) {
                warningMes("Kullanıcıları listelerken hata oluştu", "");
            }
            else {

                var hmtlInside = "";
                for (var i = 0; i < e.length; i++) {
                    if (e[i].StatusID == 1) {
                        hmtlInside += `<li data-target="#showMessagePop" data-toggle="modal" class="scrollable-container media-list w-100">
                                        <a href="#" >
                                            <div style="margin-top:15px;" class="media border-0">
                        <!--Special Room href    pop up açılcak tıklarsa gidecek-->
                        <div class="media-left pr-1">
                            <span id="listStatus" class="avatar avatar-md avatar-online">
                                <img class="media-object rounded-circle" src="${e[i].ImageURL}" />
                                <i></i>
                            </span>
                        </div>
                        <div class="media-body w-100">
                            <h6 class="list-group-item-heading">
                                ${e[i].UserName}

                            </h6>
                            <p class="list-group-item-text text-muted mb-0">
                                Çevrimiçi
                                <span class="float-right primary"></span>
                            </p>
                        </div>
                    </div>
                                        </a>
                                    </li>`;
                    }
                    else {
                        hmtlInside += `<li data-target="#showMessagePop" data-toggle="modal" class="scrollable-container media-list w-100">
                                        <a href="#">
                                            <div style="margin-top:15px;" class="media border-0">
                        <!--Special Room href    pop up açılcak tıklarsa gidecek-->
                        <div class="media-left pr-1">
                            <span id="listStatus" class="avatar avatar-md avatar-busy">
                                <img class="media-object rounded-circle" src="${e[i].ImageURL}" />
                                <i></i>
                            </span>
                        </div>
                        <div class="media-body w-100">
                            <h6 class="list-group-item-heading">
                                ${e[i].UserName}

                            </h6>
                            <p class="list-group-item-text text-muted mb-0">
                                Meşgul
                                <span class="float-right primary"></span>
                            </p>
                        </div>
                    </div>
                                        </a>
                                    </li>`;
                    }
                }
            }

            $(".appendUsers").html(hmtlInside);

        }
    });
});



// Customer Register
$(".cusModRegister").on("click", function myfunction() {

    var confirmPass = $('#confirmPass').val();

    var cusEmail = $('#cusEmail').val();

    var cusPass = $('#cusPass').val();

    var uname = $('#cusKullaniciAdi').val();

    var ContractAcc = document.getElementById("contractCus").checked;

    if (confirmPass == null || confirmPass == undefined || confirmPass == "" || cusEmail == null || cusEmail == undefined || cusEmail == "" || cusPass == null || cusPass == undefined || cusPass == "" ||
        uname == null || uname == undefined || uname == "") {
        warningMes("Bilgileri eksiksiz ve doğru giriniz", "Hata ile karşılaşıldı");
    } else if (confirmPass != cusPass) {
        warningMes("Girdiğiniz şifreler aynı olmalıdır", "Hata ile karşılaşıldı");
    } else if (ContractAcc == false) {
        warningMes("Sözleşmeyi kabul etmeden sisteme kayıt olamazsınız", "");
    }
    else {
        var data = {
            Email: cusEmail,
            Pass: cusPass,
            UserName: uname
        };

        $.ajax({
            type: "post",
            url: "/Register/makeCusRegister",
            dataType: "json",
            data: data,
            success: function (e) {
                if (e == "email") {
                    warningMes("Sistemde böyle bir email bulunmaktadır", "Kayıtlı Email");
                }
                else if (e == "uname") {
                    warningMes("Sistemde böyle bir kullanıcı bulunmaktadır", "Kayıtlı Kullanıcı");
                }
                else if (e == true) {
                    sucMes("Kaydınız başarıyla alınmıştır. 5 dakika içerisinde hesabınız aktif durumda olacaktır.", "Kayıt Başarılı");
                    setTimeout(function myfunction() {
                        window.location.reload(); //Burayı Anasayfaya yönlendir
                    }, 5000);

                } else {
                    errorMes("Kayıt olurken hata ile karşılaşıldı", "Kayıt Hatası");
                }

            }

        })
    }

});


//Employee Register
$(".empModRegister").on("click", function myfunction() {

    var FirstName = $('#EmpRegisFirstName').val();
    var UserName = $('#EmpRegisUserName').val();
    var Password = $('#EmpRegisPass').val();
    var confirmPass = $('#EmpRegisConfirmPass').val();
    var Email = $('#EmpRegisEmail').val();
    var LastName = $('#EmpRegisLastName').val();
    var NickName = $('#EmpRegisNickName').val();
    var BirthDate = $('#EmpRegisBirthdate').val();
    var HairColorID = $('#EmpRegisterGender').val();
    var EyeColorID = $('#EmpRegisterEyeColor').val();
    var HairTypeID = $('#EmpRegisterHairType').val();
    var BodyTypeID = $('#EmpRegisterBodyType').val();
    var ContractAcc = document.getElementById("contractEmp").checked;



    if (FirstName == null || FirstName == undefined || FirstName == "" || UserName == null || UserName == undefined || UserName == "" || Password == null || Password == undefined || Password == "" || Email == null || Email == undefined || Email == "" || LastName == null || LastName == undefined || LastName == "" || NickName == null || NickName == undefined || NickName == "") {
        warningMes("Bilgileri eksiksiz ve doğru giriniz", "Hata ile karşılaşıldı");
    } else if (confirmPass != Password) {
        warningMes("Girdiğiniz şifreler aynı olmalıdır", "Hata ile karşılaşıldı");
    } else if (ContractAcc == false) {
        warningMes("Sözleşmeyi kabul etmeden sisteme kayıt olamazsınız", "");
    }
    else {

        var data = {
            FirstName: FirstName,
            UserName: UserName,
            Password: Password,
            Email: Email,
            LastName: LastName,
            NickName: NickName,
            BirthDate: BirthDate,
            HairColorID: HairColorID,
            EyeColorID: EyeColorID,
            HairTypeID: HairTypeID,
            BodyTypeID: BodyTypeID,
            ContractAcceptance: ContractAcc
        };


        $.ajax({
            type: "post",
            url: "/Register/makeRegister",
            dataType: "json",
            data: data,
            success: function (e) {
                if (e == "email") {
                    warningMes("Sistemde böyle bir email bulunmaktadır", "Kayıtlı Email");
                }
                else if (e == "uname") {
                    warningMes("Sistemde böyle bir kullanıcı bulunmaktadır", "Kayıtlı Kullanıcı");
                }
                else if (e == true) {
                    sucMes("Kaydınız başarıyla alınmıştır 1 saat içerisinde hesabınız aktif olacaktır.", "Kayıt Başarılı");
                    setTimeout(function myfunction() {
                        window.location.reload(); //Burayı Anasayfaya yönlendir
                    }, 7000);

                } else {
                    errorMes("Kayıt olurken hata ile karşılaşıldı", "Kayıt Hatası");
                }

            }

        })
    }

});


//CHAT MESSAFE SCRİPTS

$('.chat-header .menu .menu-ico').click(function () {
    $('.chat-header .menu ul.list').slideToggle('fast');
});
$(document).click(function () {
    $(".chat-header .menu ul.list").slideUp('fast');
});
$(".chat-header .menu ul.list,.chat-header .menu .menu-ico").click(function (e) {
    e.stopPropagation();
});
$('.chat-inp .emoji').click(function () {
    $('.emoji-dashboard').slideToggle('fast');
});
$(document).click(function () {
    $(".emoji-dashboard").slideUp('fast');
});
$(".chat-header .menu ul.list,.chat-inp .emoji").click(function (e) {
    e.stopPropagation();
});
$('.emoji-dashboard li .em').click(function () {
    var emo = $(this).css('background-image').split('"')[1];
    $('.chat-inp .input').find('div').remove();
    $('.chat-inp .input').append('<img src="' + emo + '">');
    $(".emoji-dashboard").slideUp('fast');

});
//Chat Message Send



//Enter keyword active
var input = document.getElementById("poolMess");
input.addEventListener("keyup", function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();

        var val = $('.input').html();
        if (val.length > 0) {

            $.connection.hub.start();
            var mess = $.connection.notificationHub;

            var message = $("#poolMess").html();
            var uname = $("#uNamePool").html();
            var imgUrl = $(".imglyout").attr('src');

            mess.server.sendPoolMessage(uname, message, imgUrl);

        }
        $('.chat-inp .input').html('');
        $('.chats-text-cont div').remove();
    }
});


$('.chat-inp .opts .send').click(function () {
    var val = $('.chat-inp .input').html();
    if (val.length > 0) {

        $.connection.hub.start();
        var mess = $.connection.notificationHub;

        var message = $("#poolMess").html();
        var uname = $("#uNamePool").html();
        var imgUrl = $(".imglyout").attr('src');

        mess.server.sendPoolMessage(uname, message, imgUrl);

        //$('.chat-body .chats-text-cont').append('<p class="chat-text"><span>' + val + '</span></p>')
    }
    $('.chat-inp .input').html('');
    $('.chats-text-cont div').remove();
});


$('input,.input').each(function () {
    tmpval = $(this).text().length;
    if (tmpval != '') {
        $(this).prev().addClass('trans');
        $(this).parent().addClass('lined');
    }
});
$('input,.input').focus(function () {

    $(document).keypress(function (e) {
        if (e.which == 13) {
            $('.chat-inp .opts .send').click();
        }
    });
}).blur(function () {
    if ($(this).text().length == '') {
        $(this).prev().removeClass('trans');
        $(this).parent().removeClass('lined');
    }
});




//Conversation Start Process

//CHAT CONVERSATİON SCRİPTS

$('.chat-header .menu .menu-ico').click(function () {
    $('.chat-header .menu ul.list').slideToggle('fast');
});
$(document).click(function () {
    $(".chat-header .menu ul.list").slideUp('fast');
});
$(".chat-header .menu ul.list,.chat-header .menu .menu-ico").click(function (e) {
    e.stopPropagation();
});
$('.chat-inpcnv .emojicnv').click(function () {
    $('.emoji-dashboardcnv').slideToggle('fast');
});
$(document).click(function () {
    $(".emoji-dashboardcnv").slideUp('fast');
});
$(".chat-header .menu ul.list,.chat-inpcnv .emojicnv").click(function (e) {
    e.stopPropagation();
});
$('.emoji-dashboardcnv li .em').click(function () {
    var emo = $(this).css('background-image').split('"')[1];
    $('.chat-inpcnv .inputcnv').find('div').remove();
    $('.chat-inpcnv .inputcnv').append('<img src="' + emo + '">');
    $(".emoji-dashboardcnv").slideUp('fast');

});

//CHAT CONVERSATİON SCRİPTS END

//Chat Conv Send

//Chat CONVERSATİON Message Send

//Enter keyword active
var ansid = 0;
var inputConvMess = document.getElementsByClassName("inputcnv");
inputConvMess[0].addEventListener("keyup", function (event) {
    
    if (event.keyCode === 13) {
        event.preventDefault();
        

        var val = $('.inputcnv').html();

        if (val.length > 0) {

            $.connection.hub.start();
            var mess = $.connection.notificationHub;

            var convMes = $('.inputcnv').html();
            var uname = $("#uNamePool").html();
            var imgUrl = $(".imglyout").attr('src');
            var reciveID = parseInt($('.ConvMake').attr('eid'));

            

            var oid = $(".ownid").html();
       
            var data = {
                convMes: convMes,
                uname: uname,
                imgUrl: imgUrl,
                reciveID: reciveID,
                ownId: oid
            };

            if (isNaN(reciveID)) {
                reciveID = ansid;
            }
            console.log(data);
            var html = `<div style="padding:8px;" class="chat">
                                    <div class="chat-avatar">
                                        <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                            <img class="poolPP" src="${imgUrl}" alt="avatar" />
                                <span class="musname">${uname}</span>
                                        </a>
                                    </div>
                                    <div class="chat-body">
                                        <div class="chat-content">
                                            <p>${convMes}</p>
                                        </div>
                                    </div>
                                </div>`;

            $(".spMessage").append(html);

            var convData = {
                SenderID: oid,
                Message: convMes,
                ReceiverID: reciveID
            };

            $.ajax({
                type: "post",
                url: "/MainPage/sendConv",
                data: convData,
                success: function (e) {
                    if (e == false) {
                        warningMes("Mesaj Gönderilemedi", "Hata Kodu:19");
                    } else {
                       
                        mess.server.sendSpecialConvMessage(convMes, uname, imgUrl, reciveID, oid);
                        console.log("mesaj eklendi");
                    }
                }
            });

        }
        $('.chat-inpcnv .inputcnv').html('');
        $('.chats-text-cont div').remove();
    }
});


$('.chat-inpcnv .optscnv .sendcnv').click(function () {
    var val = $('.chat-inpcnv .inputcnv').html();
    if (val.length > 0) {

        $.connection.hub.start();
        var mess = $.connection.notificationHub;

        var convMes = $('.inputcnv').html();
        var uname = $("#uNamePool").html();
        var imgUrl = $(".imglyout").attr('src');
        var reciveID = parseInt($('.ConvMake').attr('eid'));



        var oid = $(".ownid").html();

        var data = {
            convMes: convMes,
            uname: uname,
            imgUrl: imgUrl,
            reciveID: reciveID,
            ownId: oid
        };

        if (isNaN(reciveID)) {
            reciveID = ansid;
        }
 
        var html = `<div style="padding:8px;" class="chat">
                                    <div class="chat-avatar">
                                        <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                            <img class="poolPP" src="${imgUrl}" alt="avatar" />
                                <span class="musname">${uname}</span>
                                        </a>
                                    </div>
                                    <div class="chat-body">
                                        <div class="chat-content">
                                            <p>${convMes}</p>
                                        </div>
                                    </div>
                                </div>`;

        $(".spMessage").append(html);

        var convData = {
            SenderID: oid,
            Message: convMes,
            ReceiverID: reciveID
        };

        $.ajax({
            type: "post",
            url: "/MainPage/sendConv",
            data: convData,
            success: function (e) {
                if (e == false) {
                    warningMes("Mesaj Gönderilemedi", "Hata Kodu:19");
                } else {

                    mess.server.sendSpecialConvMessage(convMes, uname, imgUrl, reciveID, oid);
                    console.log("mesaj eklendi");
                }
            }
        });

   

    }
    $('.chat-inpcnv .inputcnv').html('');
    $('.chats-text-cont div').remove();
});


$('inputcnv,.inputcnv').each(function () {
    tmpval = $(this).text().length;
    if (tmpval != '') {
        $(this).prev().addClass('trans');
        $(this).parent().addClass('lined');
    }
});

$('inputcnv,.inputcnv').focus(function () {

    $(document).keypress(function (e) {
        if (e.which == 13) {
            $('.chat-inpcnv .optscnv .sendcnv').click();
        }
    });
}).blur(function () {
    if ($(this).text().length == '') {
        $(this).prev().removeClass('trans');
        $(this).parent().removeClass('lined');
    }
});


$(".showPopUpConv").on('click', function myfunction() {

    
    $('.inputcnv').html('');
    $('.spMessage').html('');

    var eidfc = $(this).attr('eid');
    empidConv = eidfc;
    $('.ConvMake').attr('eid', eidfc);

    //Bu işlem customer için own = cusid
    var dataForConv = {
        SenderID: $(".ownid").html(),
        ReceiverID: eidfc
    };

    $.ajax({
        type: "post",
        url: "/MainPage/getMessagesLastTen",
        dataType: "json",
        data: dataForConv,
        success: function (e) {
            if (e != false) {

                for (var i = 0; i < e.length; i++) {
                    var date = new Date(parseInt(e[i].CreatedDate.replace("/Date(", "").replace(")/", "")));
                    var fdate = (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear() + ' Saat ' + date.getHours() + ':' + date.getMinutes();
                    e[i].CreatedDate = fdate;
                    if (e[i].Viewed == false) {
                        notReadCount++;
                    }
                }


                var html = "";

                for (var i = 0; i < e.length; i++) {

                    if (e[i].SenderID == $(".ownid").html()) {

                        html += `<div style="padding:8px;" class="chat">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${e[i].Sender1Img}" alt="avatar" />
                            <span class="musname">${e[i].SenderName1}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${e[i].Message}</p>
                                    </div>
                                </div>
                            </div>`;
                    } else {
                        html += `<div style="padding:8px;" class="chat chat-left">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${e[i].Sender2Img}" alt="avatar" />
                            <span class="musname">${e[i].SenderName2}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${e[i].Message}</p>
                                    </div>
                                </div>
                            </div>`;
                    }

                }

                $('.spMessage').html(html);
            }
        }

    })


   
    var ownid = $(".ownid").html();
    var datafm = {
        CustomerID: ownid,
        EmployeeID: eidfc
    };

    $.ajax({
        type: "post",
        url: "/MainPage/isSuitCreditForMessage",
        dataType: "json",
        data: datafm,
        success: function (e) {
            if (e == false) {
                $('.ConvMake').attr('data-target', 'epcent');
            } else {
                $('.ConvMake').attr('data-target', '#messagePanel');
            }
        }
    })

});


$('.ConvMake').on('click', function myfunction() {

    var epcent=$(this).attr('data-target');
    if (epcent == "epcent") {
        warningMes("Mesaj görüşmesi başlatmak için krediniz yetersiz.", "Lütfen kredi yüklemesi yapınız.");
    } else {
        var eidd = $(this).attr('eid');
        var ownid = $(".ownid").html();

        var data = {
            ReceiverID: eidd,
            SenderID: ownid
        };

        $.ajax({
            type: "post",
            url: "/MainPage/ControlForMessageTime",
            dataType: "json",
            data: data,
            success: function (e) {
                if (e == true) {
                    var kr = $('#kredi').html();
                    kr = kr - 1;
                    if (kr <= 0) {
                        kr = 0;
                        $('#kredi').html(kr);
                    } else if (kr > 0) {
                        kr = kr;
                        $('#kredi').html(kr);
                    }
                } else {
                
                }
            }
        })
    }
 

});


$('.openMsg').on('click', function myfunction() {

    $('.spMessage').html('');

    var dataForConv = {
        SenderID: $(".ownid").html(),
        ReceiverID: ansid
    };

        
    $.ajax({
        type: "post",
        url: "/MainPage/getMessagesLastTen",
        dataType: "json",
        data: dataForConv,
        success: function (e) {

            console.log(e);

            if (e != false) {

                for (var i = 0; i < e.length; i++) {
                    var date = new Date(parseInt(e[i].CreatedDate.replace("/Date(", "").replace(")/", "")));
                    var fdate = (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear() + ' Saat ' + date.getHours() + ':' + date.getMinutes();
                    e[i].CreatedDate = fdate;
                    if (e[i].Viewed == false) {
                        notReadCount++;
                    }
                }


                var html = "";

                for (var i = 0; i < e.length; i++) {

                    if (e[i].SenderID == $(".ownid").html()) {


                        html += `<div style="padding:8px;" class="chat">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${(e[i].Sender2Img == "") ? e[i].Sender1Img : e[i].Sender2Img}" alt="avatar" />
                            <span class="musname">${(e[i].SenderName2 == "") ? e[i].SenderName1 : e[i].SenderName2}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${e[i].Message}</p>
                                    </div>
                                </div>
                            </div>`;
                    } else {

                        html += `<div style="padding:8px;" class="chat chat-left">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${(e[i].Sender1Img == "") ? e[i].Sender2Img : e[i].Sender1Img}" alt="avatar" />
                            <span class="musname">${(e[i].SenderName1 == "") ? e[i].SenderName2 : e[i].SenderName1}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${e[i].Message}</p>
                                    </div>
                                </div>
                            </div>`;
                    }

                }

                $('.spMessage').html(html);
            }
        }

    })



    if (comeConv.length==0) {

    } else {
        var convShowList = "";
        for (var i = 0; i < comeConv.length; i++) {
            convShowList += `<li data-target="#messagePanel" conv=${comeConv[i].UserName} onclick="takeAnsId(${comeConv[i].SenderID})" class="xklm"  data-toggle="modal" class="scrollable-container media-list w-100 ">
                                        <a href="javascript:void(0)" >
                                            <div class="media">
                                                <div class="media">
                                                    <div class="media-left ">
                                                    </div> <div  class="media-body ">
                                                        <h6 class="media-heading">${comeConv[i].UserName}<span class="notification-tag badge badge-default badge-warning float-right m-0" style=" float: inherit!important; top: initial !important; right: inherit !important; left: 3px; "> </span></h6>
                                                        <p class="notification-text font-small-3 text-muted" >${comeConv[i].Message}</p>
                                                        <small>
                                                            <time class="media-meta text-muted"></time>
                                                        </small>
                                                    </div>
                                                </div>
                                            </div>
                                        </a>
                                    </li>`;
        }

        $(".appendConversation").html(convShowList);
    }

});

function takeAnsId(id) {
    ansid = id;
}

//Employee sadece bu class ile etkileşime geçebilir
$('.showMessagePanel').on('click', function myfunction() {

    $('.spMessage').html("");
    

    var CustomerID = $(this).attr('cusid');
    ansid = CustomerID;
    var EmployeeID = $(".ownid").html();

    var datasp = {
        SenderID: EmployeeID,
        ReceiverID: CustomerID
    };

    $.ajax({
        type: "post",
        url: "/MainPage/getMessagesLastTen",
        dataType: "json",
        data: datasp,
        success: function (e) {
            if (e != false) {

                for (var i = 0; i < e.length; i++) {
                    var date = new Date(parseInt(e[i].CreatedDate.replace("/Date(", "").replace(")/", "")));
                    var fdate = (date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear() + ' Saat ' + date.getHours() + ':' + date.getMinutes();
                    e[i].CreatedDate = fdate;
                    if (e[i].Viewed == false) {
                        notReadCount++;
                    }
                }


                var html = "";

                for (var i = 0; i < e.length; i++) {

                    if (e[i].SenderID == $(".ownid").html()) {


                        html += `<div style="padding:8px;" class="chat">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${(e[i].Sender2Img == "") ? e[i].Sender1Img : e[i].Sender2Img}" alt="avatar" />
                            <span class="musname">${(e[i].SenderName2 == "") ? e[i].SenderName1 : e[i].SenderName2}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${e[i].Message}</p>
                                    </div>
                                </div>
                            </div>`;
                    } else {

                        html += `<div style="padding:8px;" class="chat chat-left">
                                <div class="chat-avatar">
                                    <a class="avatar" data-toggle="tooltip" href="#" data-placement="left" title="" data-original-title="">
                                        <img class="poolPP" src="${(e[i].Sender1Img == "") ? e[i].Sender2Img : e[i].Sender1Img}" alt="avatar" />
                            <span class="musname">${(e[i].SenderName1 == "") ? e[i].SenderName2 : e[i].SenderName1}</span>
                                    </a>
                                </div>
                                <div class="chat-body">
                                    <div class="chat-content">
                                        <p>${e[i].Message}</p>
                                    </div>
                                </div>
                            </div>`;
                    }

                }

                $('.spMessage').html(html);
            }
        }

    })


});
