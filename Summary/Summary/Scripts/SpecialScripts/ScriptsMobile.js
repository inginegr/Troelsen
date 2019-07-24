var showContainerClick = (eventObj) => {
    var el = eventObj.target;
    if (el.className == "link-to-content unpressed") {
        var pressedClassName = el.className.split(" ")[0] + " " + "pressed";
        el.setAttribute("class", pressedClassName);
    } else if (el.className == "link-to-content pressed") {
        var pressedClassName = el.className.split(" ")[0] + " " + "unpressed";
        el.setAttribute("class", pressedClassName);
    } 
}


var processClick = (eventObj) => {
    showContainerClick(eventObj);
}

window.onload = () => {
    window.onclick = processClick;
}

//window.location.reload(true);