var blnIsDown = false;
var intBeginWinPositionX;// = 100;
var intBeginWinPositionY;// = 20;
var intBeginPositionX;
var intBeginPositionY;
var intAddPositionX;
var intAddPositionY;
var blnIsValidClick;
blnIsValidClick = false;
function iniWindow(){
	intBeginWinPositionX = parent.spanPreViewMain.offsetLeft;
	intBeginWinPositionY = parent.spanPreViewMain.offsetTop;
	//maintitle.innerText = intBeginWinPositionX+":"+intBeginWinPositionY;
	document.onclick = handleClick;
	document.onmouseover = handleMouseOver;
	document.onmouseout = handleMouseOut;
	document.onmousedown = handleMouseDown;
	document.onmouseup = handleMouseUp;
	document.onmousemove = handleMouseMove;
}

function handleMouseMove(){
	if(blnIsDown){
		if(event.button==1){
			intAddPositionX = event.screenX - intBeginPositionX;
			intAddPositionY = event.screenY - intBeginPositionY;
			intBeginWinPositionX = intBeginWinPositionX + intAddPositionX;
			intBeginWinPositionY = intBeginWinPositionY + intAddPositionY;
			//window.moveTo(intBeginWinPositionX,intBeginWinPositionY);
			parent.spanPreViewMain.style.left = intBeginWinPositionX + "px";
			parent.spanPreViewMain.style.top = intBeginWinPositionY + "px";
			intBeginPositionX = event.screenX;
			intBeginPositionY = event.screenY;
		}else{
			handleMouseUp();
		}
	}
}

function handleMouseUp(){
	//objTmp.style.backgroundColor = null;
	blnIsDown = false;
	intAddPositionX = 0;
	intAddPositionY = 0;
	//window.focus();
}

function handleMouseDown(){
	objTmp = getElement(window.event.srcElement, "tagName", "DIV");
	if(objTmp.id=="maintitle" && event.button==1){
		//objTmp.style.backgroundColor = "#FFFFFF";
		blnIsDown = true;
		intBeginPositionX = event.screenX;
		intBeginPositionY = event.screenY;
	}else{
		blnIsDown = false;
		intAddPositionX = 0;
		intAddPositionY = 0;
		}
}

function handleClick() {
	objTmp = getElement(window.event.srcElement, "tagName", "DIV");
	if (blnIsValidClick && objTmp.id.substr(objTmp.id.length-3,3)!="Sub" && objTmp.id!="maintitle" && objTmp.id!="mainfirst" && objTmp.id!="mainsecond" && objTmp.id!="mainzero") {
		if ((objTmp.className == "topFolder")) {
			objTmp.sub = eval(objTmp.id + "Sub");
			if (objTmp.sub.style.display == null) {
				objTmp.sub.style.display = "none";
			}
			var reIsOpen = new RegExp("floor.gif", "g");
			if (objTmp.sub.style.display != "block" && objTmp.innerHTML.search(reIsOpen) > -1) { //hidden
				wf_ChangeIcon(objTmp);
				if (objTmp.parentElement.openedSub != null) {
					var opener = eval(objTmp.parentElement.openedSub + ".opener");
					if (opener != undefined){
						if (opener.className == "topFolder")
							outTopItem(opener);
					}
				}
				objTmp.sub.style.display = "block";
				objTmp.sub.parentElement.openedSub = objTmp.sub.id;
				objTmp.sub.opener = objTmp;
			}
			else {
				var re2 = /floor-.gif/gi;
				objTmp.innerHTML = objTmp.innerHTML.replace(re2, "floor.gif");
				re2 = /zk/gi;
				objTmp.innerHTML = objTmp.innerHTML.replace(re2, "gb");
				hideDiv(objTmp.sub.id);
			}
		}
		var tmp  = getElement(objTmp, "className", "treeMenu");
	}
	blnIsValidClick = false;
}

function handleMouseOver() {
	var fromEl = getElement(window.event.fromElement, "tagName", "DIV");
	var toEl = getElement(window.event.toElement, "tagName", "DIV");
	if (fromEl == toEl) return;
	
	objTmp = toEl;
	
	if ((objTmp.className == "topFolder")) overTopItem(objTmp);
}

function handleMouseOut() {
	var fromEl = getElement(window.event.fromElement, "tagName", "DIV");
	var toEl = getElement(window.event.toElement, "tagName", "DIV");
	if (fromEl == toEl) return;
	
	objTmp = fromEl;

	if ((objTmp.className == "topFolder")) outTopItem(objTmp);
	if (objTmp.className == "scrollButton") outTopItem(objTmp);
}

function hideDiv(objTmpID) {
	var objTmp = eval(objTmpID);
	objTmp.style.display = "none";
	objTmp.parentElement.openedSub = null;
}

function overTopItem(objTmp) {
	objTmp.style.textDecoration = "underline";
}

function outTopItem(objTmp) {
	objTmp.style.textDecoration = "none";
}

function getElement(objTmp, type, value) {
	temp = objTmp;
	while ((temp != null) && (temp.tagName != "BODY")) {
		if (eval("temp." + type) == value) {
			objTmp = temp;
			return objTmp;
		}
		temp = temp.parentElement;
	}
	return objTmp;
}

function wf_ChangeIcon(objTmp) {
	var re1 = /floor.gif/gi;
	objTmp.innerHTML = objTmp.innerHTML.replace(re1, "floor-.gif");
	re1 = /gb/gi;
	objTmp.innerHTML = objTmp.innerHTML.replace(re1, "zk");
}