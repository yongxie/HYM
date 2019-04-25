<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left_index.aspx.cs" Inherits="Web.include.left_index"
    CodePage="936" %>

<html>
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/normal.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="../js/outlook-wygl.js"></script>
    <script language="JavaScript1.2">
        function high(which2){
            theobject=which2
            highlighting=setInterval("highlightit(theobject)",30)
        }
        function low(which2){
            clearInterval(highlighting)
            theobject=which2
            lowlighting=setInterval("lowlightit(theobject)",30)
        }

        function lowlightit(cur2){
            if(cur2.filters.alpha.opacity>0)
            cur2.filters.alpha.opacity-=10
            else if (window.lowlighting)
            clearInterval(lowlighting)
        }

        function highlightit(cur2){
            if (cur2.filters.alpha.opacity<100)
            cur2.filters.alpha.opacity+=10
            else if (window.highlighting)
            clearInterval(highlighting)
        }
    </script>
    <script language="JavaScript" type="text/JavaScript">
<!--
        function MM_swapImgRestore() { //v3.0
            var i, x, a = document.MM_sr; for (i = 0; a && i < a.length && (x = a[i]) && x.oSrc; i++) x.src = x.oSrc;
        }

        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }

        function MM_findObj(n, d) { //v4.01
            var p, i, x; if (!d) d = document; if ((p = n.indexOf("?")) > 0 && parent.frames.length) {
                d = parent.frames[n.substring(p + 1)].document; n = n.substring(0, p);
            }
            if (!(x = d[n]) && d.all) x = d.all[n]; for (i = 0; !x && i < d.forms.length; i++) x = d.forms[i][n];
            for (i = 0; !x && d.layers && i < d.layers.length; i++) x = MM_findObj(n, d.layers[i].document);
            if (!x && d.getElementById) x = d.getElementById(n); return x;
        }

        function MM_swapImage() { //v3.0
            var i, j = 0, x, a = MM_swapImage.arguments; document.MM_sr = new Array; for (i = 0; i < (a.length - 2); i += 3)
                if ((x = MM_findObj(a[i])) != null) { document.MM_sr[j++] = x; if (!x.oSrc) x.oSrc = x.src; x.src = a[i + 2]; }
        }
//-->
    </script>
</head>
<body onload="MM_preloadImages('../images/menu/left_dot2.gif')" style="background-color:#F0F0F0">
    <table height="100%" cellspacing="0" style="background-color:#F0F0F0" cellpadding="0" border="0" align="center" width="175">
        <tr>
            <td style="width:8px;">&nbsp;</td>
            <td style="width:155px;">
                <table height="100%" cellspacing="0" cellpadding="0" border="0" align="center" width="155">
        <script type="text/javascript">
            outlookbar.otherclass = "border=0 cellspacing='0' cellpadding='0' style='height:100%;width:100%;border-bottom:2pt solid #ebf5d6;'valign=middle align=center ";

            function setCount(x) {
                if (document.all == null) return;
                document.all("oCount").innerText = x
            }
            function load(form) {
                var url = form.list.options[form.list.selectedIndex].value;
                if (url != "") open(url, "_blank");
                return false;
            }
        </script>
        <tr>
            <td height="59" valign="top">
                <img src="../images/images/control.gif" border="0" height="58" width="150">
            </td>
        </tr>
        <tr>
            <td id="outLookBarShow" valign="top" align="left" name="outLookBarShow">
                <div id="outLookBarDiv" style="width: 100%; height: 100%" name="outLookBarDiv">
                    <table width="151" height="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="151" valign="top">
                                <%=addcontent %>
                            </td>
                        </tr>
                    </table>
                </div>
                <script>
                    //outlookbar.show()
                    switchoutlookBar(0);
                </script>
            </td>
        </tr>
        <tr>
            <!--<td height="40"><img src="../images/index/menu_bot.gif" width="168" height="40"></td>-->
            <td style="background: url(../images/images/di_1.gif) no-repeat;
                height: 9px; width: 151px; text-align: center;">
                <br />
                操作员：<%=Session["UserID"].ToString() %>
            </td>
        </tr>
    </table>
            </td>
            <td style="width:12px;">&nbsp;</td>
        </tr>
    </table>
    
</body>
</html>
