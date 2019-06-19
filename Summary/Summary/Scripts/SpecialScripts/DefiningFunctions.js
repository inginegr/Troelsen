//Процентные соотношения для панелей
var procentFactors = {
    heightPanel: 0.8,      // Высота панели переднего и заднего плана
    widthForeground: 0.7,  // Ширина  панели переднего плана
    widthBackground: 0.5,  // Ширина панели заднего плана
    alpha: "0.518rad",      // Наклон боковых панелей переднего плана
    betta: "0.33rad"        // Наклон боковых панелей заднего плана
}


//panels[0] = document.querySelector(".foreground.left." + str);
//panels[1] = document.querySelector(".foreground");
//panels[2] = document.querySelector(".foreground.right." + str);
//panels[3] = document.querySelector(".background.right." + str);
//panels[4] = document.querySelector(".background");
//panels[5] = document.querySelector(".background.left." + str);


window.onload = function (eventObj) {
    // Вращение блоков
    var rotateBlocks = function (directionRotate, blockRotate) {

        // Массив с панелями для вращения
        var panels = [];
        // Количество циклов для обеспечения поворота
        var cycles = 30;
        
        //// Коэффициенты и процентные соотношения
        //var blockWidth = blockRotate.clientWidth;
        //var blockHeight = blockRotate.clientWidth;

        //var alpha = Math.atan((blockHeight * 0.9) / (blockWidth * 0.85));
        //var betta = Math.atan((blockHeight * 0.9) / (blockWidth * 0.75));


        //Парсим класс, в котором содержатся панели для вращения
        var str = blockRotate.getAttribute('class').toString().split(" ");
        str = str[str.length - 1];

        document.querySelector(".foreground." + str).style.background = "black";

        panels[0] = document.querySelector(".foreground.right.");
        panels[1] = document.querySelector(".foreground");
        panels[2] = document.querySelector(".foreground.right." + str);
        panels[3] = document.querySelector(".background.right." + str);
        panels[4] = document.querySelector(".background");
        panels[5] = document.querySelector(".background.left." + str);

        try {

            // Производим трансформации с панелями
            while (cycles) {
                //for (a in panels) {

                //}
                //alert(cycles);
                panels[1].style.transform = "rotate(" + (alpha / cycles).toString() + "deg)";
                cycles--;
                
            }

            // Сдвигаем элементы в массиве, в зависимости от "directionRotate"
            // Временный буфер
            //if (directionRotate == "right") {
            //    var tmp = 0;
            //    for (var i = 0; i < panels.length; i++) {
            //        if (i == 0) {
            //            tmp = panels[panels.length - 1];
            //        }
            //        panels[panels.length - 1 - i] = panels[panels.length - 2 - i];
            //        if (i == panels.length - 1) {
            //            pan[0] = tmp;
            //        }
            //    }
            //} else {
            //    var tmp = 0;
            //    for (var i = 0; i < panels.length; i++) {
            //        if (i == 0) {
            //            tmp = panels[i];
            //        }
            //        panels[i] = panels[i + 1];
            //        if (i == panels.length - 1) {
            //            pan[i] = tmp;
            //        }
            //    }
            //}
        } catch (e) {

        }
        

    }

    // Переключение влево-вправо
    var doSwitch = function (eventObj) {
        // Направление поворота
        var turnSide = "";
        // Блок, содержищий вращяющиеся элементы
        var blockRoot = null;

        var trg = eventObj.target.parentNode;

        // Определяем направление поворота
        if (trg.getAttribute("class") == "switch left") {
            turnSide = "left";
        }
            
        else
            turnSide = "right";

        // Определяем блок, в котором происходит вращение
        blockRoot = trg.parentNode.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling;

        // Вращаем блоки
        rotateBlocks(turnSide, blockRoot);
    }

    //===========================================Элементы, вращающие барабан=======================================//
    document.getElementById('skills').getElementsByClassName("switch left")[0].onclick = doSwitch;
    document.getElementById("skills").getElementsByClassName('switch right')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch left')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch right')[0].onclick = doSwitch;

}

