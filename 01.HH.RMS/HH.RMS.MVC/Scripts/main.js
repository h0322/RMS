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