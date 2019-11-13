function openPopup(
    {
        url = "",
        param =
        {
            w: 800, h: 800, top: 0, bottom: 0
        },
        isPopup = true
    }) {
    var pa = url.indexOf("?") == -1 ? "?" : "";
    window.open(url + pa + "&isPopup=" + isPopup, "", "width=" + param.w + ",height=" + param.h + ",top=" + param.top + "bottom=" + param.bottom);
}