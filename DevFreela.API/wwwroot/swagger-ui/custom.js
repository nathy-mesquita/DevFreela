var changeFavicon = function () {
    var favicon = undefined;
    var nodeList = document.getElementsByTagName("link");
    for (var i = 0; i < nodeList.length; i++) {
        if (nodeList[i].getAttribute("rel") === "icon" || nodeList[i].getAttribute("rel") === "shortcut icon") {
            favicon = nodeList[i];
            favicon["href"] = "https://image.flaticon.com/icons/png/512/2219/2219609.png";
        }
    }
    return favicon;
};
changeFavicon();