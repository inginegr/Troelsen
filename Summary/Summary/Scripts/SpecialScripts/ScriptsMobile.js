// Кодировка скрытых данных
var hideEmail = [11.2, 9.7, 11.5, 10.7, 9.7, 10.8, 10.4, 10.1, 10.8, 11.2, 6.4, 11, 9.7, 11.4, 11.1, 10, 4.6, 11.4, 11.7];
var hidePhone = [5.6, 5.7, 5, 5.1, 5.4, 5.6, 4.8, 5, 5, 5.6, 5.3];

// Show, if clicked on button
var flagClick = false;

// Показать скрытые данные
var showHiddenData = (eventObj) => {

    // Источник сообщения
    var parsData = eventObj.id == "phoneId" ? hidePhone : hideEmail;

    // Получаем кодировку символов
    var codedSymbols = "";

    for (var i = 0; i < parsData.length; i++)
        codedSymbols += "&#" + parsData[i] * 10 + ";";

    // Отображаем скрытые данные
    eventObj.innerHTML = codedSymbols;
}

// Add data after button
var addElemennt = (elementParam) => {
    var el = document.getElementById("s" + elementParam.id);
    elementParam.insertAdjacentHTML("afterend", el.innerHTML);
}

// Set flag to clicked
var setClickedFlag = () => {
    flagClick = true;
}

// Reset clicked flag
var resetClick = () => {
    flagClick = false;
}

// Remove element after button
var removeElemennt = (elementParam) => {
    var el = elementParam.nextSibling;
    if (el.className == undefined) el.className = "fake";

    while ((el.className.search("link-to-content") < 0) && (el.tagName != "SCRIPT")) {
        el.parentElement.removeChild(el);
        el = elementParam.nextSibling;
        if (el.className == undefined) el.className = "fake";
    }
}

// Process container button click
var showContainerClick = (eventObj) => {

    if (!flagClick) return false;

    var el = eventObj.target;
    if (el.className == "link-to-content unpressed") {
        var pressedClassName = el.className.split(" ")[0] + " " + "pressed";
        el.setAttribute("class", pressedClassName);
        addElemennt(el);
    } else if (el.className == "link-to-content pressed") {
        var pressedClassName = el.className.split(" ")[0] + " " + "unpressed";
        el.setAttribute("class", pressedClassName);
        removeElemennt(el);
    }
}


var processClick = (eventObj) => {
    showContainerClick(eventObj);
}

window.onload = () => {
    window.ontouchstart = setClickedFlag;
    window.ontouchend = processClick;
    window.ontouchmove = resetClick;
}