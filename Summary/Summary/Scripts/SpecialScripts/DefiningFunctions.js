//Процентные соотношения для панелей
var procentFactors = {
    heightPanel: 0.8,      // Высота панели переднего и заднего плана
    widthForeground: 0.7,  // Ширина  панели переднего плана
    widthBackground: 0.5,  // Ширина панели заднего плана
    alpha: 0.455,          // Наклон боковых панелей переднего плана
    betta: 0.33            // Наклон боковых панелей заднего плана
}

// Представляет структуру панели, с необходимыми данными для вращения
var panelStruct = {
    xScale: null,          // Текущий масштаб по оси Х
    kfXScale: null,        // Коэфициент приращения по оси Х
    skew: null,            // Наклон панели (для центральных передней и задней панели)
    kfSkew: null,          // Коэфициент приращения для наклона
    translateX: null,      // Перемещение по оси Х
    kfTranslateX: null,    // Коэфициент приращения для перемещения по оси Х
    translateY: null,      // Перемещение по оси У
    kftranslateY: null     // Коэфициент приращения по оси У
}



window.onload = function (eventObj) {
    
    // Количество циклов изменений
    var cycles = divis = 30;

    // Коэффициент для поворота. 1 - влево, -1 - вправо    
    var i = 1;

    // Флаг, показывающий, что в данный момент происходит вращение
    var flagRotate = false;

    // Объект с текущими состояниями
    var curSt = null;

    // Вращающиеся панели
    var panels = null;

    // Таймеры
    var timeRotate = null;

    // Теущие состояния, управляющие вращением
    function currentStates(procentFactors, widthParam, heightParam, panels, directionParam) {
        // Массив панелей для вращения
        this.panelStruct = [];

        //-----------------------------------------Общие свойства--------------------------------------------------------//
        this.alphaForeground = Math.atan((heightParam - panels[4].clientHeight) / (2 * panels[4].clientWidth));
        this.tgAlpha = (heightParam - panels[4].clientHeight) / (widthParam - panels[4].clientWidth);
        this.tgBetta = (heightParam - panels[1].clientHeight) / (widthParam - panels[1].clientWidth);
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
        this.panelStruct[3] = {

            // Текущий масштаб по оси Х
            xScale: 1,          

            // Коэфициент приращения по оси Х
            kfXScale: (directionParam == "left") ? this.scaleStepX : (panels[4].clientWidth / panels[3].clientWidth - 1) / divis,  

            // Наклон панели (для центральных передней и задней панели)
            skew: this.angleAlpha,            

            // Коэфициент приращения для наклона
            kfSkew: (directionParam == "left") ? 0 : (this.angleAlpha / divis),          

            // Перемещение по оси Х
            translateX: 0,      

            // Коэфициент приращения для перемещения по оси Х
            kfTranslateX: panels[3].clientWidth / divis,    

            // Перемещение по оси У
            translateY: (directionParam == "left") ? 0 : - this.shortH / 2,      

            // Коэфициент приращения по оси У
            kftranslateY: this.shortH / (2 * divis)
        }
             
        //============================================Center foreground panel====================================================================//
        this.panelStruct[4] = {

            // Текущий масштаб по оси Х
            xScale: 1,

            // Коэфициент приращения по оси Х
            kfXScale: (1 - (panels[5].clientWidth / (widthParam * procentFactors.widthForeground))) / cycles,

            // Наклон панели (для центральных передней и задней панели)
            skew: 0,

            // Коэфициент приращения для наклона
            kfSkew: this.alphaForeground / divis,

            // Перемещение по оси Х
            translateX: 0,

            // Коэфициент приращения для перемещения по оси Х
            kfTranslateX: panels[4].clientWidth / divis,

            // Перемещение по оси У
            translateY: 0,

            // Коэфициент приращения по оси У
            kftranslateY: 0
        }


        //============================================Right foreground panel====================================================================//
        this.panelStruct[5] = {

            // Текущий масштаб по оси Х
            xScale: 1,

            // Коэфициент приращения по оси Х
            kfXScale: (directionParam == "right") ? -this.scaleStepX : -(panels[4].clientWidth / panels[5].clientWidth - 1) / divis,

            // Наклон панели (для центральных передней и задней панели)
            skew: -this.angleAlpha,

            // Коэфициент приращения для наклона
            kfSkew: (directionParam == "right") ? 0 : (this.angleAlpha / divis),

            // Перемещение по оси Х
            translateX: 0,

            // Коэфициент приращения для перемещения по оси Х
            kfTranslateX: panels[5].clientWidth / divis,

            // Перемещение по оси У
            translateY: (directionParam == "right") ? 0 : - this.shortH / 2,

            // Коэфициент приращения по оси У
            kftranslateY: -this.shortH / (2 * divis)
        }

        //============================================Left background panel====================================================================//
        this.panelStruct[0] = {

            // Текущий масштаб по оси Х
            xScale: 1,

            // Коэфициент приращения по оси Х
            kfXScale: (directionParam == "right") ? -this.scaleStepXBack : -(panels[1].clientWidth / panels[0].clientWidth - 1) / divis,

            // Наклон панели (для центральных передней и задней панели)
            skew: -this.angleBetta,

            // Коэфициент приращения для наклона
            kfSkew: (directionParam == "right") ? 0 : (this.angleBetta / divis),

            // Перемещение по оси Х
            translateX: 0,

            // Коэфициент приращения для перемещения по оси Х
            kfTranslateX: -panels[0].clientWidth / divis,

            // Перемещение по оси У
            translateY: (directionParam == "right") ? 0 : this.shortH / 2,

            // Коэфициент приращения по оси У
            kftranslateY: this.shortH / (2 * divis)
        }

        //============================================Center background panel====================================================================//
        this.panelStruct[1] = {

            // Текущий масштаб по оси Х
            xScale: 1,

            // Коэфициент приращения по оси Х
            kfXScale: (1 - (panels[0].clientWidth / (widthParam * procentFactors.widthBackground))) / cycles,

            // Наклон панели (для центральных передней и задней панели)
            skew: 0,

            // Коэфициент приращения для наклона
            kfSkew: this.bettaBackground / divis,

            // Перемещение по оси Х
            translateX: 0,

            // Коэфициент приращения для перемещения по оси Х
            kfTranslateX: -panels[1].clientWidth / divis,

            // Перемещение по оси У
            translateY: 0,

            // Коэфициент приращения по оси У
            kftranslateY: 0
        }

        //============================================Right background panel====================================================================//
        this.panelStruct[2] = {

            // Текущий масштаб по оси Х
            xScale: 1,

            // Коэфициент приращения по оси Х
            kfXScale: (directionParam == "left") ? this.scaleStepXBack : (panels[1].clientWidth / panels[2].clientWidth - 1) / divis,

            // Наклон панели (для центральных передней и задней панели)
            skew: this.angleBetta,

            // Коэфициент приращения для наклона
            kfSkew: (directionParam == "left") ? 0 : (this.angleBetta / divis),

            // Перемещение по оси Х
            translateX: 0,

            // Коэфициент приращения для перемещения по оси Х
            kfTranslateX: -panels[0].clientWidth / divis,

            // Перемещение по оси У
            translateY: (directionParam == "left") ? 0 : this.shortH / 2,

            // Коэфициент приращения по оси У
            kftranslateY: -this.shortH / (2 * divis)
        }        
    }

    // Управление стилями вращающихся блоков
    var managePanelsBehaviour = (currents, rotatePanels, directionRotate) => {
        // Цвет, на который меняем
        var flagChangeColor = false;
        for (a in currents.panelStruct) {


        }

        if (currents.panelStruct[0].xScale < 0) {
            rotatePanels[0].style.background = directionRotate == "left" ? "linear - gradient(to right, #d6d6d6, #aaaaaa)" : "linear-gradient(to left, #1187ff, #56aaff)";
            rotatePanels[0].style.zIndex = "2";
            rotatePanels[1].style.background = "linear - gradient(to right, #d6d6d6, #aaaaaa)";
            rotatePanels[2].style.background = directionRotate == "left" ? "linear - gradient(to right, #d6d6d6, #aaaaaa)" : "linear-gradient(to left, #1187ff, #56aaff)";
        }
    }

    // Вращение блоков
    var rotateBlocks = function (directionRotate) {
        try {
            // Начало отсчета
            var coord1 = "right bottom";
            var coord2 = "left bottom";

            // Устанавливаем начало координат в зваисимости от направления вращения
            for (var a = 0; a < curSt.panelStruct.length; a++) {
                if (directionRotate == "right") {
                    i = -1;
                    if (a < 3)
                        panels[a].style.transformOrigin = coord1;
                    else
                        panels[a].style.transformOrigin = coord2;
                } else {
                    i = 1;
                    if (a < 3)
                        panels[a].style.transformOrigin = coord2;
                    else
                        panels[a].style.transformOrigin = coord1;
                }
            }

            // Вращаем панели
            for (var b = 0; b < curSt.panelStruct.length; b++) {
                curSt.panelStruct[b].translateX -= (i) * curSt.panelStruct[b].kfTranslateX;
                curSt.panelStruct[b].translateY -= (i) * curSt.panelStruct[b].kftranslateY;
                curSt.panelStruct[b].xScale -= (b == 1 || b == 4) ? curSt.panelStruct[b].kfXScale : (i) * curSt.panelStruct[b].kfXScale;
                curSt.panelStruct[b].skew += (i) * curSt.panelStruct[b].kfSkew;
                panels[b].style.transform = "matrix(" + curSt.panelStruct[b].xScale + "," + curSt.panelStruct[b].skew + ", 0, 1," + curSt.panelStruct[b].translateX + "," + curSt.panelStruct[b].translateY + ")";
            }

            managePanelsBehaviour(curSt, panels, directionRotate);

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

