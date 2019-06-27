// Установить начальные размеры панелей
restorePanels(procentFactors);

//Заполняем панели информацией
fillSkillsOnStartUp();




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

