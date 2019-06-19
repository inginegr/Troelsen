

window.onload = function (eventObj) {

    // Вращение блоков
    var rotateBlocks = function (directionRotate, blockRotate) {
        var setse = blockRotate.getElementsByTagName("div");
        //alert(document.querySelector('.background.left.photo'));
        try {
            document.querySelector(".foreground.left.photo").setAttribute('class', 'foreground right photo');
        } catch{
            alert("SDfsdfsdf");
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

