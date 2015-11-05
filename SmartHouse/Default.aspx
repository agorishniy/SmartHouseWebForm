<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHouse.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartHouse</title>
	<link rel="stylesheet" type="text/css" href="Content/reset.css" />
	<link rel="stylesheet" type="text/css" href="Content/style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Wrapper" CssClass="wrapper" runat="server">
            <asp:Panel ID="TopHeader" CssClass="header" runat="server">
            </asp:Panel>
            
            <asp:Panel ID="Main" CssClass="main" runat="server">
                <asp:Panel ID="LeftCol" CssClass="left-col" runat="server">
                    <h1>
                        Add device
                    </h1>
                    <h2>
                        1. Input name of new device:
                    </h2>
                    <asp:TextBox ID="NameOfNewDevice" CssClass="name-of-new-device" runat="server"></asp:TextBox>
                    <h2>
                        2. Choose type of new device:
                    </h2>
                    <asp:LinkButton ID="BtnAddLamp" CssClass="btn-add" runat="server" OnClick="BtnAdd_Click">
                        <asp:Panel ID="AddLamp" CssClass="add-device" runat="server">
                            <h3>
                                LAMP
                            </h3>
                            <asp:Image ID="IconLamp" CssClass="add-icon" ImageUrl="Content/images/lamp_3.png" runat="server" />
                        </asp:Panel>
                    </asp:LinkButton>

                    <asp:LinkButton ID="BtnAddFan" CssClass="btn-add" runat="server" OnClick="BtnAdd_Click">
                        <asp:Panel ID="AddFan" CssClass="add-device" runat="server">
                            <h3>
                                FAN
                            </h3>
                            <asp:Image ID="IconFan" CssClass="add-icon" ImageUrl="Content/images/fan_3_1.png" runat="server" />
                        </asp:Panel>
                    </asp:LinkButton>

                    <asp:LinkButton ID="BtnAddLouvers" CssClass="btn-add" runat="server" OnClick="BtnAdd_Click">
                        <asp:Panel ID="AddLouvers"  CssClass="add-device" runat="server">
                            <h3>
                                LOUVERS
                            </h3>
                            <asp:Image ID="IconLouvers" CssClass="add-icon" ImageUrl="Content/images/louvers_3.png" runat="server" />
                        </asp:Panel>
                    </asp:LinkButton>

                    <asp:LinkButton ID="BtnAddTv" CssClass="btn-add" runat="server" OnClick="BtnAdd_Click">
                        <asp:Panel ID="AddTv" CssClass="add-device" runat="server">
                            <h3>
                                TV
                            </h3>
                            <asp:Image ID="IconTv" CssClass="add-icon" ImageUrl="Content/images/tv_3.png" runat="server" />
                        </asp:Panel>
                    </asp:LinkButton>


                </asp:Panel>
                
                <asp:Panel ID="RightCol" CssClass="right-col" runat="server">

                </asp:Panel>
            </asp:Panel>

            <asp:Panel ID="Footer" CssClass="footer" runat="server">

            </asp:Panel>

        </asp:Panel>

    </form>
	<script type="text/javascript">
	    window.onload = sameHeight;
	    function sameHeight() {
	       document.getElementById('LeftCol').style.height = parseInt(document.getElementById('RightCol').offsetHeight) - 6 + "px";
        };
	</script>
</body>
</html>
