//Процентные соотношения для панелей
var procentFactors = {
    heightPanel: 0.8,      // Высота панели переднего и заднего плана
    widthForeground: 0.7,  // Ширина  панели переднего плана
    widthBackground: 0.5,  // Ширина панели заднего плана
    alpha: 0.455,          // Наклон боковых панелей переднего плана
    betta: 0.33            // Наклон боковых панелей заднего плана
}


//panels[0] = document.querySelector(".foreground.left." + str);
//panels[1] = document.querySelector(".foreground");
//panels[2] = document.querySelector(".foreground.right." + str);
//panels[3] = document.querySelector(".background.right." + str);
//panels[4] = document.querySelector(".background");
//panels[5] = document.querySelector(".background.left." + str);


window.onload = function (eventObj) {
    // Количество циклов изменений
    var cycles = divis = 30;
    // Коэффициент для поворота. 1 - влево, -1 - вправо
    var i = 1;

    // Флаг, показывающий, что в данный момент происходит вращение
    var flagRotate = false;

    // Теущие состояния, управляющие вращением
    function currentStates(procentFactors, widthParam, heightParam, panels, directionParam) {
        //-----------------------------------------Общие свойства--------------------------------------------------------//
        alphaForeground = Math.atan((heightParam - panels[4].clientHeight) / (2 * panels[4].clientWidth));

        //============================================Left foreground panel====================================================================//
        this.leftForScale = 1;                                            // Относительные величины, в долях, занимаемые панелями в родительском окне
        this.kfLeftForScale = (directionParam == "left") ? (1 / divis) : (panels[4].clientWidth / (divis * panels[5].clientWidth));
        this.leftForScew = alphaForeground;
        this.kfLeftForSkew = (directionParam == "left") ? (Math.PI / 2 - alphaForeground) : (alphaForeground / divis);
        this.leftForTranslateX = 0;
        this.kfLeftForTranslateX = (directionParam == "left") ? (panels[5] / divis) : (panels[5].clientWidth / divis);
        this.leftForTranslateY = 0;
        this.kfLeftForTranslateY = 

        //============================================Center foreground panel====================================================================//
        this.centerForScale = 1;
        this.kfCenterForScale = (this.centerForScale - (panels[5].clientWidth / (widthParam * procentFactors.widthForeground))) / cycles;
        this.centerForSkew = 0;
        this.kfCenterForSkew = alphaForeground / divis;
        this.centerForTranslateX = 0;
        this.kfCenterForTranslateX = panels[4].clientWidth / divis;
        //this.centerForTranslateY = 0;
        //this.kfCenterForTranslateY = (heightParam - panels[4].clientHeight) / (2 * divis);
        //=======================================================================================================================================//
         
        // Доделать
        this.kfRightFor = 0;
        
    }

    // Объект с текущими состояниями
    var curSt = null;

    // Вращающиеся панели
    var panels = null;

    // Таймеры
    var timeRotate = null;

    

    // Вращение блоков
    var rotateBlocks = function (directionRotate) {

        try {          
            if (directionRotate == "right") {
                i = -1;
                panels[4].style.transformOrigin = "left bottom";
            } else {
                i = 1;
                panels[4].style.transformOrigin = "right bottom";
            }

            // Работаем с центральной панелью переднего плана
            curSt.centerForScale -= curSt.kfCenterForScale;
            curSt.centerForSkew += i * curSt.kfCenterForSkew;
            curSt.centerForTranslateX -=  i * curSt.kfCenterForTranslateX;            
            panels[4].style.transform = "matrix(" + curSt.centerForScale + "," + curSt.centerForSkew + ", 0, 1," + curSt.centerForTranslateX + ", 0)";

            // Левая панель переднего плана

            cycles--;

            if (cycles < 1) {
                clearInterval(timeRotate);
                flagRotate = false;
            }
        } catch (e) {

        }
        

    }
    
    // Переключение влево-вправо
    var doSwitch = function (eventObj) {
        // Проверяем, запущено ли измерение в текущий момент
        if (flagRotate)
            return;
        else
            flagRotate = true;
        // Установить счетчик
        cycles = divis;
        // Направление поворота
        var turnSide = "";
        // Блок, содержищий вращяющиеся элементы
        var blockRoot = null;
        // Родительский блок
        var trg = eventObj.target.parentNode;

        // Определяем направление поворота
        if (trg.getAttribute("class") == "switch left") {
            turnSide = "left";
        }else
            turnSide = "right";

        // Определяем блок, в котором происходит вращение
        blockRoot = trg.parentNode.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling;
                
        panels = blockRoot.querySelectorAll("div");

        curSt = new currentStates(procentFactors, blockRoot.clientWidth, blockRoot.clientHeight, panels, turnSide);

        // Вращаем блоки
        timeRotate = setInterval(function () {
            rotateBlocks(turnSide);
        }, 100);
    }

    //===========================================Элементы, вращающие барабан=======================================//
    document.getElementById('skills').getElementsByClassName("switch left")[0].onclick = doSwitch;
    document.getElementById("skills").getElementsByClassName('switch right')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch left')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch right')[0].onclick = doSwitch;

}

