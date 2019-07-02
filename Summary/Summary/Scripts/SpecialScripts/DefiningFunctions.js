//===========================================================================Данные=====================================//

//Процентные соотношения для панелей
var procentFactors = {
    heightPanel: 0.8,                                // Высота панели переднего и заднего плана
    widthForeground: 0.7,                            // Ширина  панели переднего плана
    widthBackground: 0.5,                            // Ширина панели заднего плана
    widthSideBackground: 0.25,                       // Ширина боковых панелей заднего плана
    widthSideForeground: 0.15,                       // Ширина боковых панелей переднего плана
    alpha: 0.455,                                    // Наклон боковых панелей переднего плана
    betta: 0.33                                      // Наклон боковых панелей заднего плана
}

// Представляет структуру панели, с необходимыми данными для вращения
var panelStruct = {
    xScale: null,          // Текущий масштаб по оси Х
    kfXScale: null,        // Коэфициент приращения по оси Х
    yScale: null,          // Масштаб по оси У
    kfYScale: null,        // Коэффициент приращения по оси У
    xSkew: null,           // Угол поворота по горизонтали
    kfXSkew: null,         // Коэфициент приращения для  угла наклона по горизонтали
    ySkew: null,           // Угол поворота по вертикали
    kfYSkew: null,         // Коэфициент приращения для  угла наклона по вертикали
    xTranslate: null,      // Перемещение по оси Х
    kfXTranslate: null,    // Коэфициент приращения для перемещения по оси Х
    yTranslate: null,      // Перемещение по оси У
    kfYTranslateY: null     // Коэфициент приращения по оси У
}

// Структура с цветами панелей
var panelsColor = {
    leftBackground: "linear-gradient(to right, #d6d6d6, #aaaaaa)",
    centerBackground: "#b3b3b3",
    rightBackground: "linear - gradient(to left, #d6d6d6, #aaaaaa)",
    leftForeground: "linear-gradient(to left, #1187ff, #56aaff)",
    centerForeground: "linear-gradient(to right, #1287ff, #007af6, #1287ff)",
    rightForeground: "linear-gradient(to right, #1187ff, #56aaff)"
}

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

// Количество циклов изменений
var cycles = divis = 60;
// Коэффициент для поворота. 1 - влево, -1 - вправо    
var i = 1;

// Флаг, показывающий, что в данный момент происходит вращение
var flagRotate = false;

// Флаг переключения цвета
var flagColor1 = false;
var flagColor2 = false;

// Объект с текущими состояниями
var curSt = null;

// Вращающиеся панели
var panels = null;

// Классы панелей
var panelsClass = null;

// Таймеры
var timeRotate = null;

// Массив с данными для панелей со скилами
var skillsContent = [];

// Кодировка скрытых данных
var hideEmail = [11.2, 9.7, 11.5, 10.7, 9.7, 10.8, 10.4, 10.1, 10.8, 11.2, 6.4, 11, 9.7, 11.4, 11.1, 10, 4.6, 11.4, 11.7];
var hidePhone = [5.6, 5.7, 5, 5.1, 5.4, 5.6, 4.8, 5, 5, 5.6, 5.3];


//===========================================================================Функции=====================================//


// Нахождение вращающихся панелей
var findPanels = (rootContainer) => {
    // Определяем блок, в котором происходит вращение
    var tmp = rootContainer.childNodes;
    var ret = [];
    for (var i = 0; i < tmp.length; i++) {
        if (tmp[i].nodeType == 1)
            ret.push(tmp[i]);
    }
    return ret;
}

// Нахождение всех контейнеров, которыекоторые содержат вращающиеся панели
var findContainers = (className) => {
    var str = (typeof className == "undefined") || (typeof className == "null") || (className == "") ? "" : " " + className;
    return document.getElementsByClassName("rotate" + str);
}

// Переместить панель в указанное положение
// currentPanel - панель, которую перемещаем
// moves - структура panelStruct
var transformPanel = (currentPanel, moves) => {
    // Dafault parameters
    currentPanel.style.transformOrigin = "left top";
    currentPanel.style.zIndex = 1;
    currentPanel.style.left = "0%";
    
    // Move panel
    currentPanel.style.transform = "matrix(" + moves.xScale + "," + moves.ySkew + "," + moves.yScale + "," + moves.xSkew + "," + moves.xTranslate + "," + moves.yTranslate + ")";
}

// Evaluate coefficients
// mainPanel - panel, that includes rotating panels
// directionRotate - direction where rotate the panels: "left", "right"
// pos - indicates, that side panels are reversed: "true", "false"
// factors - the procentFactors structure
var evaluateCoefficients = (mainPanel, totalCycles, directionRotate, pos, factors) => {
    // Massive with coefficient for each panel
    var retMas = [];

    // Short variables
    var a = mainPanel.clientHeight;
    var b = mainPanel.clientWidth;
    var c = factors.widthBackground;
    var d = factors.widthForeground;
    var e = factors.widthSideBackground;
    var f = factors.widthSideForeground;
    var g = factors.heightPanel;
    var angleBackground = Math.atan(a * (1- g) / (b * e));
    var angleForeground = Math.atan(a * (1- g) / (b * f));

    // Object with coefficients
    var coefs = {

        kfXScale: null,        // Коэфициент приращения по оси Х

        kfYScale: null,        // Коэффициент приращения по оси У

        kfXSkew: null,         // Коэфициент приращения для  угла наклона по горизонтали

        kfYSkew: null,         // Коэфициент приращения для  угла наклона по вертикали

        kfXTranslate: null,    // Коэфициент приращения для перемещения по оси Х

        kfYTranslate: null    // Коэфициент приращения по оси У
    }

    var dir = directionRotate == "left";
    // Left background panel
    coefs = {
        kfXScale: dir ? b * ((c - e) / 2) / totalCycles : (1 + f / e) / totalCycles,
        kfYScale: 0,
        kfXSkew: 1,
        kfYSkew: dir ? -angleBackground / totalCycles : 0,
        kfXTranslate: dir ? b * e / totalCycles : 0,
        kfYTranslate: dir ? a * (1 - g) / (2 * totalCycles) : -a * (1 - g) / (2 * totalCycles)
    }

    retMas.push(coefs);

    // Center background panel
    coefs = {
        kfXScale: dir ? b * ((c - e) / 2) / totalCycles : (1 + f / e) / totalCycles,
        kfYScale: 0,
        kfXSkew: 1,
        kfYSkew: dir ? -angleBackground / totalCycles : 0,
        kfXTranslate: dir ? b * e / totalCycles : 0,
        kfYTranslate: dir ? a * (1 - g) / (2 * totalCycles) : -a * (1 - g) / (2 * totalCycles)
    }

    return retMas;
}



// Вычисление координат, для перемещения панелей
// direction - the direction, that indicates where to turn
// positions - the currentStates object
// division - the number of cycles
var evaluatePosition = (direction, positions, division, panels) => {

    // Define offsets and coefficients

    // Container for coordinates
    var pos = null;

    // Return massive
    var returnCoordinates = [];

    // Left background panel
    var lb = {
        xScale: null,          // Текущий масштаб по оси Х
        kfXScale: null,        // Коэфициент приращения по оси Х
        yScale: null,          // Масштаб по оси У
        kfYScale: null,        // Коэффициент приращения по оси У
        xSkew: null,           // Угол поворота по горизонтали
        kfXSkew: null,         // Коэфициент приращения для  угла наклона по горизонтали
        ySkew: null,           // Угол поворота по вертикали
        kfYSkew: null,         // Коэфициент приращения для  угла наклона по вертикали
        xTranslate: null,      // Перемещение по оси Х
        kfXTranslate: null,    // Коэфициент приращения для перемещения по оси Х
        yTranslate: null,      // Перемещение по оси У
        kfYTranslateY: null     // Коэфициент приращения по оси У
    }
    

    return 
}

// Установить  панели в заданное положение
// factors - процентные соотношения 
// classContainer - контейнер, содержищий панели
// states - структура currentStates
var transformPanels = (factors, classContainer, states) => {
    //Определяем панели, которые необходимо вращать
    var containers = findContainers(classContainer);

    // Коэффициенты для матрицы преобразований
    //matrix(scaleX, skewY, scaleY, skewX, moveX, moveY)
    var scaleX = 0;
    var scaleY = 0;
    var skewX = 0;
    var skewY = 0;
    var moveX = 0;
    var moveY = 0;

    // Устанавливаем положение панелей, в каждом контейнере containers
    for (i = 0; i < containers.length; i++) {
        // Контейнеры
        var p = containers[i];
        //// Угол наглона для задних панелей
        //alphaBackground = Math.atan((p.clientHeight * (1 - factors.heightPanel) / 2) / ((p.clientWidth * (1 - factors.widthBackground) / 2)));

        //// Deviation panel Y
        //var devY = p.clientHeight * (1 - factors.heightPanel) / 2;

        //// Угол наклона для передних панелей
        //alphaForeground = Math.atan((p.clientHeight * (1 - factors.heightPanel) / 2) / ((p.clientWidth /** (1 - factors.widthForeground) / 2*/)));

        //// Ширина задних боковых
        //var widthBackground = p.clientWidth * ((1 - factors.widthBackground) / 2);

        //// Ширина передних боковых
        //var widthForeground = p.clientWidth * ((1 - factors.widthForeground) / 2);
        var pnls = findPanels(p);
        for (j = 0; j < pnls.length; j++) {
            // Панели
            a = pnls[j];
            // Сбрасываем z-индексы
            a.style.zIndex = "1";
            // Устанавливаем начало отсчета для панелей
            a.style.transformOrigin = "right bottom";
            // Высота всех панелей
            a.clientHeight = factors.heightPanel;

            // Определяем класс текущей панели
            var buf = a.getAttribute("class").split(" ");
            var str = buf[0] + " " + buf[1];

            // Задние панели
            if (str == "background left") {
                a.clientWidth = widthBackground;
                a.style.left = "0%";
                a.style.transform = "skewY(" + "-" + alphaBackground + "rad)";
                //a.style.transform = "matrix(1," + "-" + alphaBackground + ",0,1,0,0)";
                a.style.background = panelsColor.leftBackground;
            } else if (str == "background right") {
                a.style.transformOrigin = "left bottom";
                a.style.left = 100 * (factors.widthSideBackground + factors.widthBackground) + "%";
                a.clientWidth = widthBackground;
                a.style.background = "";
                a.style.background = /*"linear-gradient(to left, #d6d6d6, #aaaaaa)";*/ panelsColor.rightBackground;
                a.style.transform = "skewY(" + alphaBackground + "rad)";
                //a.style.transform = "matrix(1," + alphaBackground + ",0,1,0,0)";
            } else if (buf[0] == "background") {
                a.style.left = factors.widthSideBackground * 100 + "%";
                a.clientWidth = p.clientWidth * factors.widthBackground;
                a.style.transform = "";
                a.style.background = panelsColor.centerBackground;
            }

            if (str == "foreground left") {
                a.clientWidth = widthForeground;
                //a.style.left = "0%";
                a.style.transformOrigin = "right bottom";
                //a.style.transform = "scaleX(" + factors.widthSideForeground + ") " + "translateY(-" + devY + "px)" + " skewY(" + alphaForeground + "rad)";
                //a.style.transform = "matrix(" + factors.widthSideForeground + "," + alphaForeground + ", 0, 1, 0, 0)";
                scaleX = factors.widthSideForeground;
                skewY = alphaForeground;
                skewX = 0;
                scaleY = 1;
                moveX = -p.clientWidth * (factors.widthSideForeground + factors.widthForeground);
                moveY = 0;
                
                a.style.background = panelsColor.leftForeground;
            } else if (str == "foreground right") {
                a.style.transformOrigin = "left bottom";
                a.clientWidth = widthForeground;
                a.style.left = 0 + "%";
                a.style.transform = "translate(" + p.clientWidth * (1 - factors.widthSideForeground) + "px, -" + (2 * p.clientHeight * factors.heightPanel) + "px) " +
                    "scaleX(" + factors.widthSideForeground + ") skewY(-" + alphaForeground + "rad)";                    
                a.style.background = panelsColor.rightForeground;
            } else if (buf[0] == "foreground") {
                a.style.left = 0 * 100 + "%";
                a.clientWidth = p.clientWidth * factors.widthForeground;
                a.style.transform = "translate(" + (p.clientWidth * factors.widthSideForeground) + "px, -" + p.clientHeight * factors.heightPanel + "px)";
                a.style.background = panelsColor.centerForeground;
            }
            transformPanel(a, panelStruct);
        }
    }
}

//// Управление стилями вращающихся блоков
//var managePanelsBehaviour = (currents, rotatePanels, directionRotate) => {
//    // Если перешли за середину, то меняем цвета
//    if ((currents.panelStruct[0].xScale < 0 || currents.panelStruct[3].xScale < 0) && !flagColor1) {
//        rotatePanels[0].style.background = directionRotate == "left" ? panelsColor.centerBackground : panelsColor.leftForeground;
//        rotatePanels[0].style.zIndex = directionRotate == "right" ? "2" : "1";
//        rotatePanels[1].style.background = panelsColor.leftBackground;
//        rotatePanels[3].style.background = directionRotate == "right" ? panelsColor.centerForeground : panelsColor.leftBackground;
//        flagColor1 = true;
//    }
//    if ((currents.panelStruct[2].xScale < 0 || currents.panelStruct[5].xScale < 0) && !flagColor2) {
//        rotatePanels[1].style.background = panelsColor.leftBackground;
//        rotatePanels[2].style.background = directionRotate == "left" ? panelsColor.rightForeground : panelsColor.centerBackground;
//        rotatePanels[2].style.zIndex = directionRotate == "right" ? "1" : "2";
//        rotatePanels[5].style.background = "";
//        rotatePanels[5].style.background = directionRotate == "left" ? panelsColor.centerForeground : "linear-gradient(to left, #d6d6d6, #aaaaaa)";
//        rotatePanels[5].style.zIndex = directionRotate == "right" ? "0" : "1";
//        flagColor2 = true;
//    }

//    // Если дошли до конца, то возвращаем панели в исходное состояние
//    var className = rotatePanels[0].parentElement.getAttribute("class").split(" ");
//    if (cycles == 0) {
//        restorePanels(procentFactors, className[1]);
//    }

//}

//// Вращение блоков
//var rotateBlocks = function (directionRotate) {
//    try {
//        // Начало отсчета
//        var coord1 = "right bottom";
//        var coord2 = "left bottom";

//        // Устанавливаем начало координат в зваисимости от направления вращения
//        for (var a = 0; a < curSt.panelStruct.length; a++) {
//            if (directionRotate == "right") {
//                i = -1;
//                if (a < 3)
//                    panels[a].style.transformOrigin = coord1;
//                else
//                    panels[a].style.transformOrigin = coord2;
//            } else {
//                i = 1;
//                if (a < 3)
//                    panels[a].style.transformOrigin = coord2;
//                else
//                    panels[a].style.transformOrigin = coord1;
//            }
//        }

//        // Вращаем панели
//        for (var b = 0; b < curSt.panelStruct.length; b++) {
//            if (b < 3) {
//                curSt.panelStruct[b].translateX -= (i) * curSt.panelStruct[b].kfTranslateX;
//                curSt.panelStruct[b].translateY -= (i) * curSt.panelStruct[b].kftranslateY;
//                curSt.panelStruct[b].xScale -= (b == 1 || b == 4) ? curSt.panelStruct[b].kfXScale : (i) * curSt.panelStruct[b].kfXScale;
//                curSt.panelStruct[b].skew += (i) * curSt.panelStruct[b].kfSkew;
//                panels[b].style.transform = "matrix(" + curSt.panelStruct[b].xScale + "," + curSt.panelStruct[b].skew + ", 0, 1," + curSt.panelStruct[b].translateX + "," + curSt.panelStruct[b].translateY + ")";
//            } else {

//            }
//        }

//        cycles--;

//        managePanelsBehaviour(curSt, panels, directionRotate);

//        if (cycles < 1) {
//            clearInterval(timeRotate);
//            flagRotate = false;
//        }
//    } catch (e) {

//    }
//}

// Переключение влево-вправо
var doSwitch = function (eventObj) {
    // Проверяем, запущено ли измерение в текущий момент
    if (flagRotate)
        return;
    else
        flagRotate = true;

    flagColor1 = false;
    flagColor2 = false;

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
    } else
        turnSide = "right";

    // Определяем контейнер с панелями
    var blockRoot = trg.parentNode.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling;

    panels = findPanels(blockRoot);

    curSt = new currentStates(procentFactors, blockRoot.clientWidth, blockRoot.clientHeight, panels, turnSide);

    // Вращаем блоки
    timeRotate = setInterval(function () {
        rotateBlocks(turnSide);
    }, 5);
}

// Заполнение панелей со скилами
var fillSkills = (containerSkills) => {
    var panels = findPanels(findContainers("skills")[0]);

    // Заполняем передние панели данными
    for (var i = 3; i < panels.length; i++)
        panels[i].innerHTML = containerSkills[i - 3];
}

// Заполнение панелей со скилами при старте страницы
var fillSkillsOnStartUp = () => {
    var skillsMassiv = [];

    // Формируем массив со скилами
    for (var i = 0; i < 3; i++) {
        var sTmp = "s" + i;
        skillsMassiv[i] = document.getElementById(sTmp).innerHTML;
    }

    // Заполняем панели
    fillSkills(skillsMassiv);

    rotatePanels(procentFactors);
}

// Показать скрытые данные
var showHiddenData = (eventObj) => {

    // Источник сообщения
    var eventSource = eventObj.target;
    var parsData = eventSource.id == "phoneId" ? hidePhone : hideEmail;

    // Получаем кодировку символов
    var codedSymbols = "";

    for (var i = 0; i < parsData.length; i++)
        codedSymbols += "&#" + parsData[i] * 10 + ";";

    // Отображаем скрытые данные
    eventSource.innerHTML = codedSymbols;
}


//===========================================================================Первоначальная информация для блоков Skills=====================================//





//===========================================================================/Первоначальная информация для блоков Skills=====================================//