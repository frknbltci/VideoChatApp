$(document).ready(function CustomerSearch() {
    $("#cusSearch").click(function () {
        var data = {
            Phone: $("#inputPhone").val()
        };
        $.ajax({
            url: "/Customer/Search",
            type: "post",
            data: data,
            success: function (e) {
                if (e != false) {
                    $("#cusStatus").html("");
                    $("#FirstName").val(e.FirstName);
                    $("#LastName").val(e.LastName);
                    $("#Phone").val(e.Phone);
                    $("#Email").val(e.Email);
                    $("#CompanyName").val(e.CompanyName);
                    $("#cusStatus").html("Müşteri Daha Önce Eklenmiş");
                    $("#ekleme").attr("disabled", "disable");
                }
                else {
                    $("#cusStatus").html("");
                    $("#cusStatus").html("Müşteri Bulunamadı");
                    $("#FirstName").val("");
                    $("#LastName").val("");
                    $("#Phone").val("");
                    $("#Email").val("");
                    $("#CompanyName").val("");
                    $("#ekleme").removeAttr("disabled", "disable");

                }
            }
        });
    });
});


$(document).ready(function ProductSearch() {
    $("#barSearch").click(function () {
        var data = {
            Barcode: $("#inputBarcode").val()
        };
        $.ajax({
            url: "/Product/Search",
            type: "post",
            data: data,
            success: function (e) {
                if (e != false) {
                    $("#stokDurum").html("");
                    $("#ProductName").val(e.ProductName);
                    $("#ProductID").val(e.ID);
                    $("#SellPrice").val(e.SellPrice);
                    $("#Stock").val(e.Stock);
                    $("#Barcode").val(e.Barcode);
                    $("#CriticalStockPiece").val(e.CriticalStockPiece);
                    $("#stokDurum").html("Mevcut Stok Durumunuz :" + e.Stock);
                }
                else {
                    $("#stokDurum").html("");
                    $("#stokDurum").html("Ürün Bulunamadı");
                    $("#ProductName").val("");
                    $("#ProductID").val("");
                    $("#Barcode").val("");
                    $("#SellPrice").val("");
                    $("#Stock").val("");
                }
            }
        });
    });
});

//function ProductSearch() {
//    $("#stokDurum").html("");
//    var data = {
//        Barcode: $("#inputBarcode").val()
//    };
//    $.ajax({
//        url: "/Product/Search",
//        type: "post",
//        data: data,
//        success: function (e) {
//            if (e != false) {
//                $("#stokDurum").html("");
//                $("#ProductName").val(e.ProductName);
//                $("#ProductID").val(e.ID);
//                $("#SellPrice").val(e.SellPrice);
//                $("#BuyPrice").val(e.BuyPrice);
//                $("#Stock").val(e.Stock);
//                $("#CriticalStockPiece").val(e.CriticalStockPiece);
//                $("#stokDurum").html("Mevcut Stok Durumunuz :" + e.Stock);
//            }
//            else {
//                $("#stokDurum").html("");
//                $("#stokDurum").html("Ürün Bulunamadı");
//                $("#ProductName").val("");
//                $("#ProductID").val("");
//                $("#SellPrice").val("");
//                $("#BuyPrice").val("");
//                $("#Stock").val("");
//            }

//        }
//    });
//};

function LoginControlAdmin() {
    var data = {
        ID: $("#UserName").val(),
        Password: $("#Password").val(),
    }
    if (data.ID.trim() != "" && data.Password.trim() != "") {
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

$(document).ready(function magazaGetir() {
    $.ajax({
        url: "/Shared/MagazaGetir",
        type: "get",
        success: function (data) {
            var html = '<li> <a class="menu-item" href="/Order/Index" data-i18n="nav.dash.ecommerce"><i class="la la-list"></i>Tüm Siparişler</a> </li>';
            html += '<li> <a class="menu-item" href="/Warranty/Index" data-i18n="nav.dash.ecommerce"><i class="la la-list"></i>Garantili Siparişler</a> </li>';

            for (var i = 0; i < data.length; i++) {
                html += '<li>' +
                    '<a class="menu-item" href="/Order/BranchOrder/' + data[i].ID + '"data-i18n="nav.dash.ecommerce"><i class="la la-list"></i>' + data[i].StoreName + '&nbsp; Siparişler</a>'
                '</li>'
            }

            $('#magaza').html(html);
        }
    });
});