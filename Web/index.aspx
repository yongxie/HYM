<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.index" codepage="936" %>

<HTML>
	<HEAD>
		<TITLE>爱之家会员管理系统</TITLE>
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
	</HEAD>
	<frameset rows="68,*" cols="*" framespacing="0" frameborder="no" border="0">
		<frame src="include/top.aspx" scrolling="no" noresize>
		<frameset rows="*" cols="168,*">
			<frame name="left" src="include/left_index.aspx" scrolling="no" noresize>
			<frameset rows="*,24" cols="*">
				<frame name="main" src="include/main.aspx" scrolling="auto" noresize>
				<frame name="bottom" src="include/bottom.htm" scrolling="no" noresize>
			</frameset>
		</frameset>
	</frameset>
</HTML>
