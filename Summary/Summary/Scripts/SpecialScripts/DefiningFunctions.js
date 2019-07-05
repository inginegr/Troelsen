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


// Массив с цветом панелей
var panelsColor = ["linear-gradient(to right, #d6d6d6, #aaaaaa)", "#b3b3b3", "linear-gradient(to left, #d6d6d6, #aaaaaa)", "linear-gradient(to left, #1187ff, #56aaff)",
    "linear-gradient(to right, #1287ff, #007af6, #1287ff)", "linear-gradient(to right, #1187ff, #56aaff)"];


// Massive with photo
var containerPhoto = [];

// Massive with skills data
var containerSkills = [];

// Количество циклов изменений
var cycles = divis = 10;

// Time between panels rotating
var timerInterval = 20;

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

// Change backgrounds of panels, if the panel is reversed
// position - initialStates structure
// panel - current panel
var changeBackgrounds = (panel) => {

    // Define classes of panel
    var className = panel.className.split(" ");

    // Change backgrounds
    if (className.includes("background")) {
        if (className.includes("left")) {
            panel.style.background = panelsColor[3];//"linear-gradient(to left, #1187ff, #56aaff)";// panelsColor[0];
            panel.style.zIndex = "2";
        }            
        else
            panel.style.background = panelsColor[5];
    } else
            panel.style.background = panelsColor[0];
        
}

// Переместить панель в указанное положение
// currentPanel - панель, которую перемещаем
// moves - структура panelStruct
var transformPanel = (currentPanel, moves, turnSide) => {
    // Dafault parameters
    currentPanel.style.transformOrigin = "left top";
    currentPanel.style.left = "0%";

    // Set x-Index' es
    var names = currentPanel.className.split(" ");
    if ((names.length == 2) && (names.includes("foreground"))) {
        currentPanel.style.zIndex = "2";        
    }
    if (turnSide == "right" && names.includes("left") && names.includes("foreground"))
        currentPanel.style.zIndex = "2";
       
    // Move panel
    currentPanel.style.transform = "matrix(" + moves.xScale + "," + moves.ySkew + "," + moves.xSkew + "," + moves.yScale + "," + moves.xTranslate + "," + moves.yTranslate + ")";

    // If reverse event is occur, coontrol background colors and z indexes
    if (moves.xScale < 0)
        changeBackgrounds(currentPanel);
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
        panels[i].style.zIndex = "1";
        panels[i].style.background = panelsColor[i];
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

    var angleBackground = Math.atan((a * (1 - g) / 2) / b);
    var angleForeground = Math.atan((a * (1 - g) / 2) / b);
    
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
        kfXScale: dir ? (c - e) / totalCycles : -(e + f) / totalCycles,
        kfYSkew: dir ? (angleBackground) / totalCycles : 0,
        kfXTranslate: dir ? b * e / totalCycles : b * f / totalCycles,
        kfYTranslate: dir ? -a * (1 - g) / (2 * totalCycles) : a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Center background panel
    coefs = {
        kfXScale: (e - c) / totalCycles,
        kfYSkew: dir ? angleBackground / totalCycles : -angleBackground / totalCycles,
        kfXTranslate: dir ? b * c / totalCycles : -b * e / totalCycles,
        kfYTranslate: dir ? 0 : a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Right background panel
    coefs = {
        kfXScale: dir ? -(e + f) / totalCycles : (c - e) / totalCycles,
        kfYSkew: dir ? 0 : -angleBackground / totalCycles,
        kfXTranslate: dir ? b * e / totalCycles : -b * c / totalCycles,
        kfYTranslate: dir ? a * (1 - g) / (2 * totalCycles) : 0,
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Left foreground panel
    coefs = {
        kfXScale: dir ? -(e + f) / totalCycles : (d - f) / totalCycles,
        kfYSkew: dir ? 0 : -angleForeground / totalCycles,
        kfXTranslate: dir ? b * e / totalCycles : b * f / totalCycles,
        kfYTranslate: dir ? -a * (1 - g) / (2 * totalCycles) : a * (1 - g) / (2 * totalCycles),
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Center foreground panel
    coefs = {
        kfXScale: (f - d) / totalCycles,
        kfYSkew: dir ? angleForeground / totalCycles : -angleForeground / totalCycles,
        kfXTranslate: dir ? -b * f / totalCycles : b * d / totalCycles,
        kfYTranslate: dir ? -a * (1 - g) / (2 * totalCycles) : 0,
        kfYScale: 0,
        kfXSkew: 0
    }

    retMas.push(coefs);

    // Right foreground panel
    coefs = {
        kfXScale: dir ? (d - f) / totalCycles : - (e + f) / totalCycles,
        kfYSkew: dir ? angleForeground / totalCycles : 0,
        kfXTranslate: dir ? -d * b / totalCycles : b * f / totalCycles,
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
        positions[i].yScale += 0;
        positions[i].xSkew += 0;
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
        transformPanel(panels[i], currentPositions[i], turnSide);
    }
    
    cycles--;

    if (cycles == 0) {
        flagRotate = false;
        clearInterval(timeRotate);
        restorePanels(rootPanel, factors);        
    }
}

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
    }, timerInterval);
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

    restoreAllPanels(procentFactors);
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

//===============================================================Ajax requests===================================================================//






// Get remained data async, and load them to massives

var GetRemainedDataAsync = () => {
    var req = new XMLHttpRequest();

    req.open("POST", "MainPage/SendRemainedAsync", true);

    req.setRequestHeader('Content-Type', 'text/xml');

    req.onreadystatechange = () => {

        if (req.readyState != 4) return;

        var v = req.responseXML.getElementById('s2');

        if (req.status >= 200 && req.status < 400) {
            alert(v);
        } else {
            alert('We encountered an error!');
        }
    }

    req.send();
}









//===============================================================================================================================================//
