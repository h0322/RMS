function DataGridDateTime(value, format) {
    if (value == undefined) {
        return "";
    }
    value = value.substr(1, value.length - 2);
    var obj = eval('(' + "{Date: new " + value + "}" + ')');
    var dateValue = obj["Date"];
    if (dateValue.getFullYear() < 1900) {
        return "";
    }

    return dateValue.formatDateTime(format)
}
Date.prototype.formatDateTime = function (format) {
    var o = {
        "M+": this.getMonth() + 1, // month
        "d+": this.getDate(), // day
        "h+": this.getHours(), // hour
        "m+": this.getMinutes(), // minute
        "s+": this.getSeconds(), // second
        "q+": Math.floor((this.getMonth() + 3) / 3), // quarter
        "S": this.getMilliseconds()
        // millisecond
    }
    if (/(y+)/.test(format))
        format = format.replace(RegExp.$1, (this.getFullYear() + "")
          .substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(format))
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
    return format;
}

function ClearSearchCookie() {
    $.cookie("searchText", "", { path: "/" });
    $.cookie("searchStatus", "", { path: "/" });
    $.cookie("searchDateFrom", "", { path: "/" });
    $.cookie("searchDateTo", "", { path: "/" });
    $.cookie("searchType", "", { path: "/" });
    $.cookie("searchRole", "", { path: "/" });
    $.cookie("searchId", "", { path: "/" });
}
function GetSexDescription(sex)
{
    if (sex == 1)
    {
        return "男";
    }
    else if (sex == 0)
    {
        return "女";
    }
}

/**
 *  页面加载等待页面
 *
 * @author gxjiang
 * @date 2010/7/24
 *
 */
var height = window.screen.height - 250;
var width = window.screen.width;
var leftW = 300;
if (width > 1200) {
    leftW = 500;
} else if (width > 1000) {
    leftW = 350;
} else {
    leftW = 100;
}

var loadingHtml = "<div id='div_loading' style='position:absolute;left:0;width:100%;height:" + height + "px;top:0;background:#efefef;opacity:0.8;filter:alpha(opacity=80);'>\
 <div style='position:absolute; font-size:12px;	cursor1:wait;left:"+ leftW + "px;top:200px;width:auto;height:16px;padding:12px 5px 10px 30px;\
 background:#fff url(/easyui/themes/default/images/loading.gif) no-repeat scroll 5px 10px;border:2px solid #ccc;color:#000;'>\
 正在加载，请等待...\
 </div></div>";

//window.onload = function () {
//    var _mask = document.getElementById('div_loading');
//    _mask.parentNode.removeChild(_mask);
//}
//window.onload = function () {
//    document.write(loadingHtml);
//}
function AddLoading()
{
    if ($("#div_loading").is(":Visible"))
    {
        return false;
    }
    $("#div_loading").show();
}
var loadingBox = {
    isLoading: function () {
        if ($("#div_loading").is(":visible")) {
            return true;
        }
        else {
            return false;
        }
    },
    show: function (msg) {
        $("body").append(loadingHtml);
        if (typeof (msg) == "undefined")
        {
            msg = "正在加载，请等待...";
        }
        $("#div_loading").children("div").text(msg)
    },
    hide: function () {
        var mask = document.getElementById('div_loading');
        mask.parentNode.removeChild(mask);
    }
};

function SetFormValue(form, Json) {
    for (var name in Json) {
        var element = $("#" + form).find("[textboxname='" + name + "']");
        if (element.length > 0) {
            if (typeof (element.attr("comboname")) != "undefined" && element.attr("comboname") == name) {
                element.combobox('setValue', Json[name])
            }
            else if (typeof (element.attr("numberboxname")) != "undefined" && element.attr("numberboxname") == name) {
                element.numberbox('setValue', Json[name])
            }
            else if (typeof (element.attr("dateboxname")) != "undefined" && element.attr("dateboxname") == name) {
                element.datebox('setValue', Json[name])
            }
            else{
                element.textbox('setValue', Json[name])
            }
        }
        else {
            element = $("#" + form).find("[name='" + name + "']");
            console.log(element)
            if (element.length > 0) {
                if (element[0].tagName == "INPUT") {
                    if (element.attr("type") == "text" || element.attr("type")=="hidden") {
                        element.val(Json[name]);
                    }
                    else if (element.attr("type") == "checkbox") {
                        var values = "," + Json[name] + ",";
                        element.each(function () {
                            if (values.indexOf("," + this.value + ",") >= 0) {
                                this.checked = true;
                            }
                            else {
                                this.checked = false;
                            }
                        });
                    }
                    else if (element.attr("type") == "radio") {
                        element.each(function () {
                            if (Json[name] == this.value) {
                                this.checked = true;
                            }
                            else {
                                this.checked = false;
                            }
                        });
                    }
                }
                else if (element[0].tagName == "SELECT")
                {
                    element.val(Json[name]);
                }
            }

        }

    }
}
function BindBox(control,url,type)
{
    if (type == "combobox") {
        $(control).combobox({
            url: url,
            valueField: 'value',
            textField: 'text',
            required: false,
            editable: false,
            value: 0
        });
    }
}