function fkeydown()
{
	if(event.keyCode==9 || event.keyCode==13 || event.button>0){
		if(((event.srcElement.tagName=="INPUT"&&(event.srcElement.type=="text"||event.srcElement.type=="radio"))||event.srcElement.tagName=="SELECT")&&event.keyCode==13){
			event.keyCode=9;
		}
	}
}
document.onkeydown=fkeydown;
