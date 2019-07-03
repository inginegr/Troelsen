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
//var initialStates = {
//    xScale: null,          // Текущий масштаб по оси Х
//    yScale: null,          // Масштаб по оси У
//    xSkew: null,           // Угол поворота по горизонтали
//    ySkew: null,           // Угол поворота по вертикали
//    xTranslate: null,      // Перемещение по оси Х
//    yTranslate: null,      // Перемещение по оси У
//}

// Структура с цветами панелей
var panelsColor = {
    leftBackground: "linear-gradient(to right, #d6d6d6, #aaaaaa)",
    centerBackground: "#b3b3b3",
    rightBackground: "linear - gradient(to left, #d6d6d6, #aaaaaa)",
    leftForeground: "linear-gradient(to left, #1187ff, #56aaff)",
    centerForeground: "linear-gradient(to right, #1287ff, #007af6, #1287ff)",
    rightForeground: "linear-gradient(to right, #1187ff, #56aaff)"
}

// Текущие состояния, управляющие вращением
//function currentStates(procentFactors, widthParam, heightParam, panels, directionParam) {
//    // Массив панелей для вращения
//    this.panelStruct = [];

//    //-----------------------------------------Общие свойства--------------------------------------------------------//
//    this.alphaForeground = Math.atan((heightParam - panels[4].clientHeight) / (2 * panels[4].clientWidth));
//    this.tgAlpha = (heightParam - panels[4].clientHeight) / (widthParam - panels[4].clientWidth);
//    this.tgBetta = (heightParam - panels[1].clientHeight) / (widthParam - panels[1].clientWidth);
//    this.angleAlpha = Math.atan(this.tgAlpha);
//    this.angleBetta = Math.atan(this.tgBetta);

//    this.bettaBackground = Math.atan((heightParam - panels[1].clientHeight) / (2 * panels[1].clientWidth));
//    this.shortH = (heightParam - panels[4].clientHeight);
//    this.shortWidthTop = (widthParam - panels[1].clientWidth) / 2;
//    this.shortWidthBottom = (widthParam - panels[4].clientWidth) / 2;
//    this.heightScale = Math.abs(((this.shortH - this.shortWidthTop * this.tgAlpha - this.shortWidthBottom * this.tgBetta) * (this.tgAlpha + this.tgBetta)) / (2 * this.tgAlpha));
//    this.scaleStepX = (1 + this.shortWidthTop / this.shortWidthBottom) / divis;
//    this.scaleStepXBack = (1 + this.shortWidthBottom / this.shortWidthTop) / divis;
//    this.scaleLeftTransition = Math.trunc(1 / this.scaleStepX);
//    this.scaleDownStepY = this.heightScale * 2 / (this.shortH * this.scaleLeftTransition);
//    this.scaleUpStepY = this.shortH / (2 * (1 - this.heightScale * 2 / this.shortH) * (divis - this.scaleLeftTransition));
//}

// Количество циклов изменений
var cycles = divis = 60;


// Флаг, показывающий, что в данный момент происходит вращение
var flagRotate = false;

// Флаг переключения цвета
var flagSideChanged = false;
var flagSideChanged2 = false;

// Объект с текущим положением панелей
var currentPositions = null;

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


// Evaluate initial states of panels
// rootContainer - element, that includes panels
// factors - procentFactors object
var evaluateInitialStates = (rootContainer, factors) => {
    var retMas = [];

    // Correction coefficient
    var corCoef = 0.005;

    // Define child panels
    var ps = findPanels(rootContainer);

    // Short variables

    //Height of root panel
    var pHeight = rootContainer.clientHeight;

    //Width of root panel
    var pWidth = rootContainer.clientWidth;

    // Common variables
    var angleBackground = Math.atan((pHeight * (1 - factors.heightPanel) / 2) / pWidth);

    var angleForeground = Math.atan((pHeight * (1 - factors.heightPanel) / 2) / pWidth);

    // Position of single panel, used in matrix()
    var initialStates = {
        xScale: 1,          // Текущий масштаб по оси Х
        yScale: 0,          // Масштаб по оси У
        xSkew: 1,           // Угол поворота по горизонтали
        ySkew: 0,           // Угол поворота по вертикали
        xTranslate: 0,      // Перемещение по оси Х
        yTranslate: 0,      // Перемещение по оси У
    }


    // Left background panel
    initialStates = {
        xScale: factors.widthSideBackground,
        yScale: factors.heightPanel,
        xSkew: 0,
        ySkew: -angleBackground,
        xTranslate: 0,
        yTranslate: -ps[0].offsetTop + pHeight * (1 - factors.heightPanel)/2
    }

    retMas.push(initialStates);

    // Center background panel
    initialStates = {
        xScale: factors.widthBackground,
        yScale: factors.heightPanel,
        xSkew: 0,
        ySkew: 0,
        xTranslate: pWidth * factors.widthSideBackground,
        yTranslate: -ps[1].offsetTop
    }

    retMas.push(initialStates);

    // Right background panel
    initialStates = {
        xScale: factors.widthSideBackground,
        yScale: factors.heightPanel,
        xSkew: 0,
        ySkew: angleBackground,
        xTranslate: pWidth * (factors.widthSideBackground + factors.widthBackground),
        yTranslate: -ps[2].offsetTop
    }

    retMas.push(initialStates);

    // Left foreground panel
    initialStates = {
        xScale: factors.widthSideForeground,
        yScale: factors.heightPanel,
        xSkew: 0,
        ySkew: angleForeground,
        xTranslate: 0,
        yTranslate: -ps[3].offsetTop + pHeight * (1 - factors.heightPanel) / 2
    }

    retMas.push(initialStates);

    // Center foreground panel
    initialStates = {
        xScale: factors.widthForeground + corCoef,
        yScale: factors.heightPanel,
        xSkew: 0,
        ySkew: 0,
        xTranslate: pWidth * (factors.widthSideForeground - corCoef / 2),
        yTranslate: -ps[4].offsetTop + pHeight * (1 - factors.heightPanel)
    }

    retMas.push(initialStates);

    // Right foreground panel
    initialStates = {
        xScale: factors.widthSideForeground,
        yScale: factors.heightPanel,
        xSkew: 0,
        ySkew: -angleForeground,
        xTranslate: pWidth * (factors.widthSideForeground + factors.widthForeground),
        yTranslate: -ps[5].offsetTop + pHeight * (1 - factors.heightPanel)
    }

    retMas.push(initialStates);

    //for (var i = 0; i < retMas.length; i++) {
    //    retMas[i] = {xsc}
    //    if (i == 1 || i == 4) {
    //        retMas[i] = x
    //    }
    //}

    return retMas;
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
    currentPanel.style.transform = "matrix(" + moves.xScale + "," + moves.ySkew + "," + moves.xSkew + "," + moves.yScale + "," + moves.xTranslate + "," + moves.yTranslate + ")";
}

// Restore panels to default positions
// rootContainer - the element, that includes panels
// factors - the procentFactors object
var restorePanels = (rootContainer, factors) => {
    var panels = findPanels(rootContainer);

    // Massive with initial states of panels
    var panelPositions = evaluateInitialStates(rootContainer, factors);

    // Transform each panel to default position
    for (var i = 0; i < panels.length; i++) {
        transformPanel(panels[i], panelPositions[i]);
    }
}

// Restore all panells in the window
var restoreAllPanels = (factors) => {
    var contaners = findContainers();

    for (var i = 0; i < contaners.length; i++) {
        restorePanels(contaners[i], procentFactors);
    }    
} 

// Evaluate coefficients
// mainPanel - panel, that includes rotating panels
// directionRotate - direction where rotate the panels: "left", "right"
// factors - the procentFactors structure
var evaluateCoefficients = (rootPanel, totalCycles, directionRotate, factors) => {
    // Massive with coefficient for each panel
    var retMas = [];

    // Short variables
    var a = rootPanel.clientHeight;
    var b = rootPanel.clientWidth;
    var c = factors.widthBackground;
    var d = factors.widthForeground;
    var e = factors.widthSideBackground;
    var f = factors.widthSideForeground;
    var g = factors.heightPanel;
    var angleBackground = Math.atan(a * (1- g) / (b * e));
    var angleForeground = Math.atan(a * (1 - g) / (b * f));
    
    // Object with coefficients
    var coefs = {
        kfXScale: null,        // Коэфициент приращения по оси Х
        kfYScale: 0,        // Коэффициент приращения по оси У
        kfXSkew: 0,         // Коэфициент приращения для  угла наклона по горизонтали
        kfYSkew: null,         // Коэфициент приращения для  угла наклона по вертикали
        kfXTranslate: null,    // Коэфициент приращения для перемещения по оси Х
        kfYTranslate: null    // Коэфициент приращения по оси У
    }

    var dir = directionRotate == "left";
    // Left background panel
    coefs = {
        kfXScale: dir ? c / (e * totalCycles) : -(1 + f / e) / totalCycles,
        kfYSkew: dir ? -angleBackground / totalCycles : 0,
        kfXTranslate: dir ? b * e / totalCycles : 0,
        kfYTranslate: dir ? -a * (1 - g) / (2 * totalCycles) : a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Center background panel
    coefs = {
        kfXScale: e / (b * totalCycles),
        kfYSkew: dir ? angleBackground / totalCycles : -angleBackground / totalCycles,
        kfXTranslate: dir ? b * c / totalCycles : -b * c / totalCycles,
        kfYTranslate: dir ? 0 : a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Left background panel
    coefs = {
        kfXScale: dir ? -(1 + f / e) / totalCycles : c / (e * totalCycles),
        kfYSkew: dir ? angleBackground / totalCycles : 0,
        kfXTranslate: dir ? 0 : b * e / totalCycles,
        kfYTranslate: dir ? a * (1 - g) / (2 * totalCycles) : -a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Left foreground panel
    coefs = {
        kfXScale: dir ? -(1 + e / f) / totalCycles : d / (f * totalCycles),
        kfYSkew: dir ? 0 : -angleForeground / totalCycles,
        kfXTranslate: dir ? 0 : d / (f * totalCycles),
        kfYTranslate: dir ? -a * (1 - g) / (2 * totalCycles) : a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Center foreground panel
    coefs = {
        kfXScale: dir ? -f / (d * totalCycles) : -f / (d * totalCycles),
        kfYSkew: dir ? angleForeground / totalCycles : -angleForeground / totalCycles,
        kfXTranslate: dir ? -b * f / totalCycles : b * d / totalCycles,
        kfYTranslate: dir ? -a * (1 - g) / (2 * totalCycles) : 0,
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Right foreground panel
    coefs = {
        kfXScale: dir ? d / (f * totalCycles) : - (1 + e / f) / totalCycles,
        kfYSkew: dir ? angleForeground / totalCycles : 0,
        kfXTranslate: dir ? d / (f * totalCycles) : 0,
        kfYTranslate: dir ? 0 : -a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    return retMas;
}


// Вычисление координат, для перемещения панелей
// direction - the direction, that indicates where to turn
// positions - the currentStates object
// division - the number of cycles
var evaluatePosition = (direction, positions, division, rootPanel, factors) => {

    // Evaluated positions of panels
    var evaluatedPositions = {
        xScale: 1,          // Текущий масштаб по оси Х
        yScale: 0,          // Масштаб по оси У
        xSkew: 1,           // Угол поворота по горизонтали
        ySkew: 0,           // Угол поворота по вертикали
        xTranslate: 0,      // Перемещение по оси Х
        yTranslate: 0,      // Перемещение по оси У
    }

    var coefficients = evaluateCoefficients(rootPanel, division, direction, factors);

    // Evaluate new positions of panels using coefficients
    for (var i = 0; i < currentPositions.length; i++) {
        
        positions[i].xScale += coefficients[i].kfXScale;
        // Define flag
        flagSideChanged = positions[i].xScale < 0;
        positions[i].yScale += coefficients[i].kfYScale;
        positions[i].xSkew += coefficients[i].kfYSkew;
        positions[i].ySkew += coefficients[i].kfYSkew;
        positions[i].xTranslate += coefficients[i].kfXTranslate;
        positions[i].yTranslate += coefficients[i].kfYTranslate;
    }

    return positions;
}

// Установить  панели в заданное положение
// factors - процентные соотношения 
// classContainer - контейнер, содержищий панели
// states - структура currentStates
var transformPanels = (factors, rootPanel, turnSide, division) => {

    // Коэффициенты для матрицы преобразований
    //matrix(scaleX, skewY, scaleY, skewX, moveX, moveY)
    var scaleX = 0;
    var scaleY = 0;
    var skewX = 0;
    var skewY = 0;
    var moveX = 0;
    var moveY = 0;

    // Define new positions of panels
    currentPositions = evaluatePosition(turnSide, currentPositions, division, rootPanel, factors);

    // Define panels to rotate
    var panels = findPanels(rootPanel);

    // Transform all panels
    for (var i = 0; i < panels.length; i++) {
        transformPanel(panels[i], currentPositions);
    }
    
    cycles--;

    if (cycles == 0) {
        clearInterval(timeRotate);
        restorePanels(rootPanel, factors);
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
var doSwitch = (eventObj) => {
    // Проверяем, запущено ли измерение в текущий момент
    if (flagRotate)
        return;
    else
        flagRotate = true;

    flagSideChanged = false;

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

    currentPositions = evaluateInitialStates(blockRoot, procentFactors);

    // Вращаем блоки
    timeRotate = setInterval(function () {
        transformPanels(procentFactors, blockRoot, turnSide, divis);
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