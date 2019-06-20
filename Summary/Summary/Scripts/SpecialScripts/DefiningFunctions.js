//Процентные соотношения для панелей
var procentFactors = {
    heightPanel: 0.8,      // Высота панели переднего и заднего плана
    widthForeground: 0.7,  // Ширина  панели переднего плана
    widthBackground: 0.5,  // Ширина панели заднего плана
    alpha: 0.518,          // Наклон боковых панелей переднего плана
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

    // Теущие состояния
    function currentStates(procentFactors, widthParam, heightParam) {
        this.leftFor = widthParam * (1 - procentFactors.widthForeground) / 2; // Относительные величины, в долях, занимаемые панелями в родительском окне
        this.kfLeftFor = procentFactors.alpha / cycles;
        this.centerFor = 1;
        this.kfCenterFor = (this.centerFor - (this.leftFor / (widthParam * procentFactors.widthForeground))) / cycles;
        this.rightFor = widthParam * (1 - procentFactors.widthForeground) / 2;
        this.alphaCenterFor = 0;
        this.kfAlphaCenterFor = procentFactors.alpha / (6 * cycles);
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
            // Производим трансформации с панелями
            if (directionRotate == "right") {
                curSt.centerFor -= curSt.kfCenterFor;
                curSt.alphaCenterFor -= curSt.kfAlphaCenterFor
                //alert(curSt.alphaCenterFor + " " + curSt.kfAlphaCenterFor);
                panels[4].style.transform = "scaleX(" + curSt.centerFor + ")" + " skewY(" + /*curSt.alphaCenterFor*/0.518 + "rad)";
                //alert("scaleX(" + curSt.centerFor + ")");
            }
            
            cycles--;

            if (cycles < 1) {
                clearInterval(timeRotate);
            }
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
        }else
            turnSide = "right";

        // Определяем блок, в котором происходит вращение
        blockRoot = trg.parentNode.firstChild.nextSibling.nextSibling.nextSibling.nextSibling.nextSibling;
        
        curSt = new currentStates(procentFactors, blockRoot.clientWidth, blockRoot.clientHeight);
        
        panels = blockRoot.querySelectorAll("div");
        
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

