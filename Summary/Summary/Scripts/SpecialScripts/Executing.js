//Fill massives with content
for (var i = 1; i < 4; i++) {
    containerPhoto.push(document.getElementById("me" + i).innerHTML);
    containerSkills.push(document.getElementById("s" + i).innerHTML);
}




window.onload = function (eventObj) {


    fillPhotoOnStartUp();

    fillSkillsOnStartUp();

    getRemainedXML();
    //===========================================Обработчики событий=======================================//

    //===========================================Элементы, вращающие барабан=======================================//
    document.getElementById('skills').getElementsByClassName("switch left")[0].onclick = doSwitch;
    document.getElementById("skills").getElementsByClassName('switch right')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch left')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch right')[0].onclick = doSwitch;
    document.getElementById("hRight").onclick = sendMessage;


    ////===========================================Показать скрытые данные=======================================//
    //document.getElementById("phoneId").onclick = showHiddenData;
    //document.getElementById("emailId").onclick = showHiddenData;
}

window.onresize = function (eventObj) {
    restoreAllPanels(procentFactors);
}

window.onmouseover = function (eventObj) {
    increaseFromPhoto(eventObj);
}

window.onmouseout = function (eventObj) {
    removeFromPhoto(eventObj);
}

window.onclick = function (eventObj) {
    increaseFromSkills(eventObj);
    closeMessageWindow(eventObj);
    ajaxSendMessageToDevelopper(eventObj);
    showAdminEnterWindow(eventObj);
    ajaxAdminRequest(eventObj);
}


