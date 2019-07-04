//Заполняем панели информацией
fillSkillsOnStartUp();


//var skillsMassiv = document.getElementById("s1").innerText;

//document.getElementsByClassName("foreground left skills")[0].innerHTML = skillsMassiv;




window.onload = function (eventObj) {

    //===========================================Обработчики событий=======================================//

    //===========================================Элементы, вращающие барабан=======================================//
    document.getElementById('skills').getElementsByClassName("switch left")[0].onclick = doSwitch;
    document.getElementById("skills").getElementsByClassName('switch right')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch left')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch right')[0].onclick = doSwitch;

    //===========================================Показать скрытые данные=======================================//
    document.getElementById("phoneId").onclick = showHiddenData;
    document.getElementById("emailId").onclick = showHiddenData;
}

window.onresize = function (eventObj) {
    restoreAllPanels(procentFactors);
}