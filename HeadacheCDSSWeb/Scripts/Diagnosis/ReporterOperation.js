$(function () {
    var OCX = document.getElementById('Reporter2');
    try {
        OCX.OpenReport("D:\\CDSSOCX");
    }
    catch (err) {
        var b = confirm("是否下载显示控件");
        if (b) {
            var strOCXURL;
            strOCXURL = "http://" + location.host + "/HeadacheCDSS/OCXForHeadacheCDSS.exe";

            window.location.href = strOCXURL;
        }
    }




    OCX.ShowReport();
    OCX.ShowThisPage("基本筛查");

    $("#btn2").hide();
    $("#btn2").click(function () {
        $(".selected").last().removeClass("selected");
        var name = $(".selected").last().attr("id");
        $(".active").prev().addClass("active");
        $(".active").last().removeClass("active");
        OCX.ShowReport();

        if (name == "头痛问诊") {
            name = "头痛概述";
            $("#OcxContent").show();
            $("#Hplace").hide();
            $("#direct").hide();
            $("#Reporter2").css("height", "500");
            $(".on").removeClass("on");
            $(".nav-tabs li:lt(1) ").addClass("on");
            $("#submenu").show();
        }
        if (name == "基本筛查") {
            $("#btn2").hide();
            $("#submenu").hide();
            $("#Reporter2").css("height", "540");
            $("#direct").show();
        }
        if (name == "医嘱处置") {
            $("#btn1").html("下一步");
            deleteprint();

            var diagnosis = OCX.GetObjectInfo("ComboBox_31", "text");
            switch (diagnosis) {
                case "紧张型头痛":
                    name = "紧张型头痛";
                    break;
                case "偏头痛":
                    name = "偏头痛";
                    break;
                case "丛集性头痛和其他原发性三叉神经痛":
                    name= "丛集性头痛";
                    break;
                case "颅神经痛和中枢源性面痛":
                    name = "神经痛";
                    break;
                case "慢性每日头痛":
                   name = "慢性每日头痛";
                    break;
                default:
                    name= "其他类型头痛";

                    break;

            }
        }
        OCX.ShowThisPage(name);
    });


});