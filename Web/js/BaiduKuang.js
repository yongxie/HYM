//仿百度搜索智能提示(纯JS实现)
var arrList = new Array();//要搜索的数据
var objouter, objInput, objInputId = '<%=CsharpVoid("' + v + '") %>'; ; //控件ID
    var selectedIndex = -1, intTmp;
    //初始化
    function smanPromptList() {
        this.style = "overflow:hidden;width:393px;height:auto;background:#FFFFFF;border:1px solid #000000;font-size:14px;cursor:default;"
        if (arrList.constructor != Array) {
            alert('smanPromptList初始化失败:第一个参数非数组!');
            return;
        }
        document.write("<div id='__smanDisp' style='position:absolute;display:none;" + this.style + "' onblur></div>");
        document.write("<style type=\"text/css\">.sman_selectedStyle{background-Color:#3366CC;color:#FFFFFF}</style>");

        arrList.sort(function(a, b) {
            if (a.length > b.length) return 1;
            else if (a.length == b.length) return a.localeCompare(b);
            else return -1;
        });
        objouter = document.getElementById("__smanDisp") //显示的DIV对象 
        objInput = document.getElementById(objInputId);  //文本框对象
        if (objInput == null) {
            alert('smanPromptList初始化失败:没有找到"' + objInputId + '"文本框');
            return;
        }
        objInput.onblur = function() { objouter.style.display = 'none'; }
        objInput.onkeyup = checkKeyCode;
        objInput.onfocus = checkAndShow;
    }

    function getAbsoluteHeight(ob) {
        return ob.offsetHeight;
    }
    function getAbsoluteWidth(ob) {
        return ob.offsetWidth;
    }
    function getAbsoluteLeft(ob) {
        var s_el = 0, el = ob;
        while (el) {
            s_el = s_el + el.offsetLeft;
            el = el.offsetParent;
        };
        return s_el;
    }
    function getAbsoluteTop(ob) {
        var s_el = 0, el = ob;
        while (el) {
            s_el = s_el + el.offsetTop;
            el = el.offsetParent;
        };
        return s_el;
    }
    function outSelection(Index) {
        objInput.value = objouter.children[Index].innerText.Trim();
        objouter.style.display = 'none';
    }
    function divPosition() {
        objouter.style.top = getAbsoluteHeight(objInput) + getAbsoluteTop(objInput);
        objouter.style.left = getAbsoluteLeft(objInput);
        objouter.style.width = getAbsoluteWidth(objInput);
    }
    function chageSelection(isUp) {
        if (objouter.style.display == 'none') {
            objouter.style.display = '';
        }
        else {
            if (isUp)
                selectedIndex++;
            else
                selectedIndex--;
        }
        var maxIndex = objouter.children.length - 1;
        if (selectedIndex < 0) { selectedIndex = 0; }
        if (selectedIndex > maxIndex) { selectedIndex = maxIndex; }
        if (selectedIndex == maxIndex) { selectedIndex = -1; }

        for (intTmp = 0; intTmp <= maxIndex; intTmp++) {
            if (intTmp == selectedIndex) {
                objouter.children[intTmp].className = "sman_selectedStyle";
                objInput.value = objouter.children[selectedIndex].innerText.Trim();
            }
            else {
                objouter.children[intTmp].className = "";
            }
        }
    }
    function checkKeyCode() {
        var ie = (document.all) ? true : false
        if (ie) {
            var keyCode = event.keyCode
            if (keyCode == 40 || keyCode == 38) {
                var isUp = false
                if (keyCode == 40)
                    isUp = true;
                chageSelection(isUp)
            }
            else if (keyCode == 13) {
                outSelection(selectedIndex);
            }
            else {
                checkAndShow();
            }
        }
        else {
            checkAndShow();
        }
        divPosition();
    }

    function checkAndShow() {
        var strInput = objInput.value.Trim();
        if (strInput != "") {
            divPosition();
            selectedIndex = -1;
            arrList.length = 0;
            objouter.innerHTML = "";
            //=======================这里修改数据================================
            var result = Web.main_paymanager.program.GetArray(strInput).value;
            //===================================================================
            var data = eval('(' + result + ')');
            for (var j = 0; j < data.length; j++) {

                arrList[j] = data[j];
            }

            for (intTmp = 0; intTmp < arrList.length; intTmp++) {
                for (i = 0; i < arrList[intTmp].length; i++) {
                    if (arrList[intTmp].substr(i, strInput.length).toUpperCase() == strInput.toUpperCase()) {
                        addOption(arrList[intTmp], strInput);
                    }
                    if (objouter.childNodes.length >= 10) {
                        break;
                    }
                }
            }
            if (objouter.childNodes.length > 0) {
                objouter.innerHTML += "<div style=\"width:395px;height:22px;text-align:right;color:Blue;text-decoration:underline;cursor:pointer;\">关闭</div>";
            }
            objouter.style.display = '';
        }
        else {
            objouter.style.display = 'none';
        }
    }
    //显示搜索的数据并关键字涂色
    function addOption(value, keyw) {
        var v = value.replace(keyw, "<b><font color=\"red\">" + keyw + "</font></b>");
        objouter.innerHTML += "<div style=\"width:395px;height:22px\" onmouseover=\"this.className='sman_selectedStyle'\" onmouseout=\"this.className=''\" onmousedown=\"document.getElementById('" + objInputId + "').value='" + value + "'\">" + v + "</div>"
    }
    String.prototype.Trim = function() {
        return this.replace(/(^\s*)|(\s*$)/g, "");
    }
    smanPromptList();


