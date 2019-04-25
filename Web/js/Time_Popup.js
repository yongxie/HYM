/*--------------弹出选择日历对话框-------------------*/
function fPopUpCalendarDlg(ctrlobj)
{
	if(ctrlobj.disabled=="")
	{
	showx = event.screenX - event.offsetX - 4 - 210 ; // + deltaX;
	showy = event.screenY - event.offsetY + 18; // + deltaY;
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog("../../js/time.htm", "", "dialogWidth:197px; dialogHeight:210px; dialogLeft:"+showx+"px; dialogTop:"+showy+"px; status:no; directories:yes;scrollbars:no;Resizable=no; "  );
	if( retval != null ){
		ctrlobj.value = retval;
	}else{
		//alert("canceled");
	}
	}
}

/*--------------弹出选择日历对话框-------------------*/
function fPopUpCalendarDlgAll(ctrlobj)
{
	showx = event.screenX - event.offsetX - 4 - 210 ; // + deltaX;
	showy = event.screenY - event.offsetY + 18; // + deltaY;
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog("../../js/time.htm", "", "dialogWidth:197px; dialogHeight:210px; dialogLeft:"+showx+"px; dialogTop:"+showy+"px; status:no; directories:yes;scrollbars:no;Resizable=no; "  );
	if( retval != null ){
			var coll = document.all.tags("input");
			if (coll!=null)
			{
				for (i=0; i<coll.length; i++)
				{	
					if (coll[i].name.indexOf(ctrlobj)>-1)
	  					coll[i].value = retval;	
				}
			}
	}
}

/*--------------弹出选择日历对话框-------------------*/
function fPopUpMeterManDlgAll(ctrlobj,strprecinct)
{
	showx = event.screenX - event.offsetX - 4 - 210 ; // + deltaX;
	showy = event.screenY - event.offsetY + 18; // + deltaY;
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog("../../js/popmeterman.aspx?PrecinctID=" + strprecinct, "", "dialogWidth:197px; dialogHeight:210px; dialogLeft:"+showx+"px; dialogTop:"+showy+"px; status:no; directories:yes;scrollbars:no;Resizable=no; "  );
	if( retval != null ){
			var coll = document.all.tags("select");
			if (coll!=null)
			{
				for (i=0; i<coll.length; i++)
				{	
					if (coll[i].name.indexOf(ctrlobj)>-1)
	  					coll[i].selectedIndex = retval;	
				}
			}
	}
}

/*--------------弹出选择更改密码对话框------------*/
function fPopUpPassWord(ctrlobj)
{
	if(ctrlobj.value!="")
	{
	showx = event.screenX - event.offsetX - 4 - 450 ; // + deltaX;
	showy = event.screenY - event.offsetY + 18; // + deltaY;
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog('System_UserPassWord_Ifram.aspx?UserID=' + ctrlobj.value ,'son','dialogwidth:280px;dialogheight:210px;dialogLeft:'+showx+'px; dialogTop:'+showy+'px;help:no;status:no;scroll:directories:yes;scrollbars:no;Resizable=no;')	
	if( retval != null ){
		
	}else{
		//alert("canceled");
	}
	}
}
/*------------------------------------------------*/

/*--------------弹出选择设备编号对话框-------------------*/
function fPopUpEquipment(ctrlobj,ctrlin)
{
	if(ctrlobj.disabled=="")
	{
	showx = event.screenX - event.offsetX - 4 - 450 ; // + deltaX;
	showy = event.screenY - event.offsetY + 18; // + deltaY;
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog('Equip_Ifram.aspx?PrecinctID=' + ctrlin.value ,'son','dialogwidth:460px;dialogheight:280px;dialogLeft:'+showx+'px; dialogTop:'+showy+'px;help:no;status:no;scroll:directories:yes;scrollbars:no;Resizable=no;')	
	if( retval != null ){
		ctrlobj.value = retval;
	}else{
		//alert("canceled");
	}
	}
}

/*--------------弹出选择物料编号对话框-------------------*/
function fPopUpDepot(ctrlobj,ctrlobj2,ctrlobj3,ctrlin)
{
	if(ctrlobj.disabled=="")
	{
	showx = event.screenX - event.offsetX - 4 - 450 ; // + deltaX;
	showy = event.screenY - event.offsetY + 18; // + deltaY;
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog('Depot_Ifram.aspx?PrecinctID=' + ctrlin.value ,'son','dialogwidth:460px;dialogheight:280px;dialogLeft:'+showx+'px; dialogTop:'+showy+'px;help:no;status:no;scroll:directories:yes;scrollbars:no;Resizable=no;')	
	if( retval != null ){
		var value = retval.split("#");
			ctrlobj.value = value[0];
			ctrlobj2.value = value[1];
			ctrlobj3.value = value[2];
	}else{
		//alert("canceled");
	}
	}
}

/*--------------弹出选择设备图纸编号对话框-------------------*/
function fPopUpBlueprint(ctrlobj,ctrlin)
{
	if(ctrlobj.disabled=="")
	{
	showx = event.screenX - event.offsetX - 4 - 450 ; // + deltaX;
	showy = event.screenY - event.offsetY + 18; // + deltaY;
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog('Equip_Ifram_Blueprint.aspx?PrecinctID=' + ctrlin.value ,'son','dialogwidth:460px;dialogheight:280px;dialogLeft:'+showx+'px; dialogTop:'+showy+'px;help:no;status:no;scroll:directories:yes;scrollbars:no;Resizable=no;')	
	if( retval != null ){
		ctrlobj.value = retval;
	}else{
		//alert("canceled");
	}
	}
}

/*--------------弹出选择员工编号对话框-------------------*/
function fPopUpEmployee(ctrlEobj,ctrlPobj)
{
	if(ctrlEobj.disabled=="")
	{
		showx = event.screenX - event.offsetX - 4-150 ;
		showy = event.screenY - event.offsetY + 18;
		newWINwidth = 210 + 4 + 18;
		retval = window.showModalDialog('System_UserAuthorization_ShowID.aspx?','son','dialogwidth:350px;dialogheight:230px;dialogLeft:'+showx+'px; dialogTop:'+showy+'px;help:no;status:no;scroll:directories:yes;scrollbars:no;Resizable=no;')
		if( retval != null )
		{
			var value = retval.split("#");
			ctrlEobj.value = value[0];
			ctrlPobj.value = value[1];
		}
		else
		{
			
		}
	}
}

/*--------------弹出选择小区对话框-------------------*/
function fPopUpUserPrecinct(ctrlobj,ctrlPobj)
{
	if(ctrlobj.disabled=="")
	{
		showx = event.screenX - event.offsetX - 4-260 ;
		showy = event.screenY - event.offsetY + 18;
		retval = window.showModalDialog('System_UserAuthorization_ShowPrecinct.aspx?','son','dialogwidth:380px;dialogheight:230px;dialogLeft:'+showx+'px; dialogTop:'+showy+'px;help:no;status:no;scroll:directories:yes;scrollbars:no;Resizable=no;')
		if( retval != null )
		{
			var value = retval.split("#");
			ctrlobj.value = value[0];
			ctrlPobj.value = value[1];
		}
		else
		{			
		}
	}
}
