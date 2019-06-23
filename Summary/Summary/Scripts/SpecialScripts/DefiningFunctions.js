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
        this.alphaForeground = Math.atan((heightParam - panels[4].clientHeight) / (2 * panels[4].clientWidth));
        this.tgAlpha = (heightParam - panels[4].clientHeight) / (widthParam - panels[4].clientWidth);
        this.tgBetta = (heightParam - panels[1].clientHeight) / (widthParam - panels[1].clientWidth);
        //this.cosAlpha = 1 / (Math.sqrt(1 + Math.pow(this.tgAlpha, 2)));
        //this.cosBetta = 1 / (Math.sqrt(1 + Math.pow(this.tgBetta, 2)));
        this.angleAlpha = Math.atan(this.tgAlpha);
        this.angleBetta = Math.atan(this.tgBetta);

        this.bettaBackground = Math.atan((heightParam - panels[1].clientHeight) / (2 * panels[1].clientWidth));
        this.shortH = (heightParam - panels[4].clientHeight);  
        this.shortWidthTop = (widthParam - panels[1].clientWidth) / 2;
        this.shortWidthBottom = (widthParam - panels[4].clientWidth) / 2;
        this.heightScale = Math.abs(((this.shortH - this.shortWidthTop * this.tgAlpha - this.shortWidthBottom * this.tgBetta) * (this.tgAlpha + this.tgBetta)) / (2 * this.tgAlpha));
        this.scaleStepX = (1 + this.shortWidthTop / this.shortWidthBottom) / divis;
        this.scaleStepXBack = (1 + this.shortWidthBottom / this.shortWidthTop) / divis;
        this.scaleLeftTransition = Math.trunc(1 / this.scaleStepX);
        this.scaleDownStepY = this.heightScale * 2 / (this.shortH * this.scaleLeftTransition);
        this.scaleUpStepY = this.shortH / (2 * (1 - this.heightScale * 2 / this.shortH) * (divis - this.scaleLeftTransition));
        

        //============================================Left foreground panel====================================================================//
        this.leftForScaleX = 1;                                            // Относительные величины, в долях, занимаемые панелями в родительском окне
        this.kfLeftForScaleX = (directionParam == "left") ? this.scaleStepX : (panels[4].clientWidth / panels[3].clientWidth - 1) / divis;
        this.leftForScew = this.angleAlpha;
        this.kfLeftForSkew = (directionParam == "left") ? 0 : (this.angleAlpha / divis);
        this.leftForTranslateX = 0;
        this.kfLeftForTranslateX = panels[3].clientWidth / divis;
        this.leftForTranslateY = (directionParam == "left") ? 0 : - this.shortH / 2;
        this.kfLeftForTranslateY = this.shortH / (2 * divis);

        //============================================Center foreground panel====================================================================//
        this.centerForScale = 1;
        this.kfCenterForScale = (this.centerForScale - (panels[5].clientWidth / (widthParam * procentFactors.widthForeground))) / cycles;
        this.centerForSkew = 0;
        this.kfCenterForSkew = this.alphaForeground / divis;
        this.centerForTranslateX = 0;
        this.kfCenterForTranslateX = panels[4].clientWidth / divis;

        //============================================Right foreground panel====================================================================//
        this.rightForScaleX = 1;                                            // Относительные величины, в долях, занимаемые панелями в родительском окне
        this.kfRightForScaleX = (directionParam == "right") ? this.scaleStepX : (panels[4].clientWidth / panels[5].clientWidth - 1) / divis;
        this.rightForScew = -this.angleAlpha;
        this.kfRightForSkew = (directionParam == "right") ? 0 : (this.angleAlpha / divis);
        this.rightForTranslateX = 0;
        this.kfRightForTranslateX = panels[5].clientWidth / divis;
        this.rightForTranslateY = (directionParam == "right") ? 0 : - this.shortH / 2;
        this.kfRightForTranslateY = this.shortH / (2 * divis);

        //============================================Left background panel====================================================================//
        this.leftForScaleXBack = 1;                                            
        this.kfLeftForScaleXBack = (directionParam == "right") ? this.scaleStepXBack : (panels[1].clientWidth / panels[0].clientWidth - 1) / divis;
        this.leftForScewBack = -this.angleBetta;
        this.kfLeftForSkewBack = (directionParam == "right") ? 0 : (this.angleBetta / divis);
        this.leftForTranslateXBack = 0;
        this.kfLeftForTranslateXBack = panels[0].clientWidth / divis;
        this.leftForTranslateYBack = (directionParam == "right") ? 0 : this.shortH / 2;
        this.kfLeftForTranslateYBack = this.shortH / (2 * divis);

        //============================================Center background panel====================================================================//
        this.centerForScaleBack = 1;
        this.kfCenterForScaleBack = (this.centerForScaleBack - (panels[0].clientWidth / (widthParam * procentFactors.widthBackground))) / cycles;
        this.centerForSkewBack = 0;
        this.kfCenterForSkewBack = this.bettaBackground / divis;
        this.centerForTranslateXBack = 0;
        this.kfCenterForTranslateXBack = panels[1].clientWidth / divis;

        //============================================Right background panel====================================================================//
        this.rightForScaleXBack = 1;
        this.kfRightForScaleXBack = (directionParam == "left") ? this.scaleStepXBack : (panels[1].clientWidth / panels[2].clientWidth - 1) / divis;
        this.rightForScewBack = -this.angleBetta;
        this.kfRightForSkewBack = (directionParam == "right") ? 0 : (this.angleBetta / divis);
        this.rightForTranslateXBack = 0;
        this.kfRightForTranslateXBack = panels[0].clientWidth / divis;
        this.rightForTranslateYBack = (directionParam == "right") ? 0 : this.shortH / 2;
        this.kfRightForTranslateYBack = this.shortH / (2 * divis);


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
                // For panel[3]
                panels[3].style.transformOrigin = "left bottom";
                panels[5].style.transformOrigin = "left bottom";
                panels[1].style.transformOrigin = "right bottom";
                panels[0].style.transformOrigin = "right bottom";
                if (curSt.leftForScaleXBack < 0) panels[0].style.zIndex = "2";
                panels[2].style.transformOrigin = "right bottom";
            } else {
                i = 1;
                panels[4].style.transformOrigin = "right bottom";
                // For panel[3]
                panels[3].style.transformOrigin = "right bottom";                
                panels[5].style.transformOrigin = "right bottom";
                panels[5].style.zIndex = "2";
                panels[1].style.transformOrigin = "left bottom";
                panels[0].style.transformOrigin = "left bottom";
                panels[2].style.transformOrigin = "left bottom";
            }

            // Работаем с центральной панелью переднего плана
            curSt.centerForScale -= curSt.kfCenterForScale;
            curSt.centerForSkew += i * curSt.kfCenterForSkew;
            curSt.centerForTranslateX -=  i * curSt.kfCenterForTranslateX;            
            panels[4].style.transform = "matrix(" + curSt.centerForScale + "," + curSt.centerForSkew + ", 0, 1," + curSt.centerForTranslateX + ", 0)";

            // Левая панель переднего плана
            curSt.leftForTranslateX -= (i) * curSt.kfLeftForTranslateX;
            curSt.leftForTranslateY -= (i) * curSt.kfLeftForTranslateY;
            curSt.leftForScaleX -= (i) * curSt.kfLeftForScaleX;
            curSt.leftForScew += (i) * curSt.kfLeftForSkew;
            panels[3].style.transform = "matrix(" + curSt.leftForScaleX + "," + curSt.leftForScew + ", 0, 1," + curSt.leftForTranslateX + "," + curSt.leftForTranslateY + ")";

            // Правая панель переднего плана
            curSt.rightForTranslateX -= (i) * curSt.kfRightForTranslateX;
            curSt.rightForTranslateY += (i) * curSt.kfRightForTranslateY;
            curSt.rightForScaleX += (i) * curSt.kfRightForScaleX;
            curSt.rightForScew += (i) * curSt.kfRightForSkew;
            panels[5].style.transform = "matrix(" + curSt.rightForScaleX + "," + curSt.rightForScew + ", 0, 1," + curSt.rightForTranslateX + "," + curSt.rightForTranslateY + ")";

            // Работаем с центральной панелью заднего плана
            curSt.centerForScaleBack -= curSt.kfCenterForScaleBack;
            curSt.centerForSkewBack += i * curSt.kfCenterForSkewBack;
            curSt.centerForTranslateXBack += i * curSt.kfCenterForTranslateXBack;
            panels[1].style.transform = "matrix(" + curSt.centerForScaleBack + "," + curSt.centerForSkewBack + ", 0, 1," + curSt.centerForTranslateXBack + ", 0)";

            // Левая панель заднего плана
            curSt.leftForTranslateXBack += (i) * curSt.kfLeftForTranslateXBack;
            curSt.leftForTranslateYBack -= (i) * curSt.kfLeftForTranslateYBack;
            curSt.leftForScaleXBack += (i) * curSt.kfLeftForScaleXBack;
            curSt.leftForScewBack += (i) * curSt.kfLeftForSkewBack;            
            panels[0].style.transform = "matrix(" + curSt.leftForScaleXBack + "," + curSt.leftForScewBack + ", 0, 1," + curSt.leftForTranslateXBack + "," + curSt.leftForTranslateYBack + ")";

            // Ghfdfz панель заднего плана
            curSt.leftForTranslateXBack += (i) * curSt.kfLeftForTranslateXBack;
            curSt.leftForTranslateYBack -= (i) * curSt.kfLeftForTranslateYBack;
            curSt.leftForScaleXBack += (i) * curSt.kfLeftForScaleXBack;
            curSt.leftForScewBack += (i) * curSt.kfLeftForSkewBack;
            panels[0].style.transform = "matrix(" + curSt.leftForScaleXBack + "," + curSt.leftForScewBack + ", 0, 1," + curSt.leftForTranslateXBack + "," + curSt.leftForTranslateYBack + ")";




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
        // Обнуляем коэффициент 
        factorSide = 0;

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
        }, 10);
    }

    //===========================================Элементы, вращающие барабан=======================================//
    document.getElementById('skills').getElementsByClassName("switch left")[0].onclick = doSwitch;
    document.getElementById("skills").getElementsByClassName('switch right')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch left')[0].onclick = doSwitch;
    document.getElementById("photo").getElementsByClassName('switch right')[0].onclick = doSwitch;

}

