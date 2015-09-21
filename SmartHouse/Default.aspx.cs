using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SmartHouse.Models;

namespace SmartHouse
{
    public partial class Default : System.Web.UI.Page
    {

        List<IDevice> listDevices;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["listDevices"] == null)
            {
                listDevices = new List<IDevice>();
                listDevices.Add(new Lamp("Living room", false));
                listDevices.Add(new Lamp("Kitchen", true));
                listDevices.Add(new Lamp("Outdoors", false));

                listDevices.Add(new Fan("First floor", false, 1));
                listDevices.Add(new Fan("Kitchen", false, 2));

                listDevices.Add(new Tv("Kitchen", true, Channels.football, 1, 4));
                listDevices.Add(new Tv("Living room", false, Channels.m1, 2, 3));

                listDevices.Add(new Louvers("Room 1", true, 1));
                listDevices.Add(new Louvers("Room 2", false, 1));

                Session["listDevices"] = listDevices;
                DisplayDevices();
            }
            else
            {
                listDevices = (List<IDevice>)Session["listDevices"];
                DisplayDevices();
            }

        }

        protected void DisplayDevices()
        {
            int i = 1;

            RightCol.Controls.Clear();

            foreach (IDevice dev in listDevices)
            {
                Panel divWrapper = new Panel();

                divWrapper.Attributes["name"] = "divWrapper" + String.Format("{0:00}", i);
                divWrapper.CssClass = "device-status";

                AddHeader(divWrapper, dev, i);


                AddState(divWrapper, dev, i);
                
                if (listDevices[i - 1].State)
                {
                    if (dev is IDevSpeed)
                        AddParam(divWrapper, dev, i, "Speed", ((Fan)listDevices[i - 1]).Speed.Value);

                    if (dev is IDevVolume)
                        AddParam(divWrapper, dev, i, "Volume", ((Tv)listDevices[i - 1]).Volume.Value);

                    if (dev is IDevBright)
                        AddParam(divWrapper, dev, i, "Bright", ((Tv)listDevices[i - 1]).Bright.Value);

                    if (dev is IDevOpen)
                        AddOpen(divWrapper, dev, i);

                    if (dev is Tv)
                        AddProgram(divWrapper, dev, i);
                }

                AddOnOff(divWrapper, dev, i);

                
                RightCol.Controls.Add(divWrapper);

                i++;
            }
        }

        protected void AddHeader(Panel div, IDevice dev, int iNum)
        {
            string sNum = String.Format("{0:00}", iNum);

            Panel divHeader = new Panel();
            Image imgIcon = new Image();
            Label devName = new Label();

            LinkButton btnDelete = new LinkButton();
            Image imgDelete = new Image();

            divHeader.Attributes["name"] = "divHeader" + sNum;
            divHeader.CssClass = "device-status-header";

            imgIcon.Attributes["name"] = "imgIcon" + sNum;
            imgIcon.ImageUrl = "App_Themes/images/" + dev.Type + "_3.png";
            imgIcon.CssClass = "device-status-icon";

            devName.Attributes["name"] = "devName" + sNum;
            devName.CssClass = "device-status-name";
            devName.Text = dev.Name;

            btnDelete.Attributes["name"] = "btnDelete" + sNum;
            btnDelete.Click += new EventHandler(this.BtnDel_Click);
            btnDelete.CssClass = "device-status-btn-del";

            imgDelete.Attributes["name"] = "imgDelete" + sNum;
            imgDelete.ImageUrl = "App_Themes/images/del_green_2.png";
            imgDelete.CssClass = "device-status-img-del";

            btnDelete.Controls.Add(imgDelete);

            divHeader.Controls.Add(imgIcon);
            divHeader.Controls.Add(devName);
            divHeader.Controls.Add(btnDelete);

            div.Controls.Add(divHeader);
        }

        protected void AddOnOff(Panel div, IDevice dev, int iNum)
        {
            string sNum = String.Format("{0:00}", iNum);

            Panel divBase = new Panel();
            Panel divLeft = new Panel();
            Panel divRight = new Panel();

            Label cmdName = new Label();

            LinkButton cmdBtn = new LinkButton();
            Image imgBtn = new Image();

            divBase.Attributes["name"] = "divBase" + sNum;
            divBase.CssClass = "device-div-on-off";

            divLeft.Attributes["name"] = "divLeft" + sNum;
            divLeft.CssClass = "device-div-on-off-left";

            divRight.Attributes["name"] = "divRight" + sNum;
            divRight.CssClass = "device-div-on-off-right";

            cmdName.Attributes["name"] = "cmdName" + sNum;
            cmdName.CssClass = "device-status-name";
            cmdName.Text = "Turn on/off";

            cmdBtn.Attributes["name"] = "cmdBtn" + sNum;
            cmdBtn.Click += new EventHandler(this.BtnOnOff_Click);
            cmdBtn.CssClass = "device-div-on-off-cmd-btn";

            imgBtn.Attributes["name"] = "imgBtn" + sNum;
            if (listDevices[iNum - 1].State) 
                imgBtn.ImageUrl = "App_Themes/images/btn_on.png";
            else
                imgBtn.ImageUrl = "App_Themes/images/btn_off.png";

            imgBtn.CssClass = "device-div-on-off-cmd-img";

            divLeft.Controls.Add(cmdName);

            cmdBtn.Controls.Add(imgBtn);
            divRight.Controls.Add(cmdBtn);


            divBase.Controls.Add(divLeft);
            divBase.Controls.Add(divRight);

            div.Controls.Add(divBase);
        }

        protected void AddParam(Panel div, IDevice dev, int iNum, string sText, byte iState)
        {
            string sNum = String.Format("{0:00}", iNum);

            Panel divBase = new Panel();
            Panel divLeft = new Panel();
            Panel divRight = new Panel();

            Label cmdName = new Label();

            LinkButton cmdBtnDown = new LinkButton();
            Image imgBtnDown = new Image();

            LinkButton cmdBtnUp = new LinkButton();
            Image imgBtnUp = new Image();

            Image imgState = new Image();


            divBase.Attributes["name"] = "divBase" + sNum;
            divBase.CssClass = "device-div-on-off";

            divLeft.Attributes["name"] = "divLeft" + sNum;
            divLeft.CssClass = "device-div-speed-left";

            divRight.Attributes["name"] = "divRight" + sNum;
            divRight.CssClass = "device-div-speed-right";

            cmdName.Attributes["name"] = "cmdName" + sNum;
            cmdName.CssClass = "device-status-name";
            cmdName.Text = sText;

            cmdBtnDown.Attributes["name"] = sText + sNum;
            cmdBtnDown.Click += new EventHandler(this.BtnDown_Click);

            imgBtnDown.Attributes["name"] = "imgBtnDown" + sNum;
            imgBtnDown.ImageUrl = "App_Themes/images/btn_down.png";
            imgBtnDown.CssClass = "device-div-speed-img";

            imgState.Attributes["name"] = "imgState" + sNum;
            
            imgState.ImageUrl = "App_Themes/images/val_" + iState.ToString() + ".png";
            imgState.CssClass = "device-div-speed-state";


            cmdBtnUp.Attributes["name"] = sText + sNum;
            cmdBtnUp.Click += new EventHandler(this.BtnUp_Click);

            imgBtnUp.Attributes["name"] = "imgBtnUp" + sNum;
            imgBtnUp.ImageUrl = "App_Themes/images/btn_up.png";
            imgBtnUp.CssClass = "device-div-speed-img";


            divLeft.Controls.Add(cmdName);

            cmdBtnDown.Controls.Add(imgBtnDown);
            cmdBtnUp.Controls.Add(imgBtnUp);

            if (listDevices[iNum - 1].State)
                divRight.Controls.Add(cmdBtnDown);
            
            divRight.Controls.Add(imgState);
            
            if (listDevices[iNum - 1].State)
                divRight.Controls.Add(cmdBtnUp);


            divBase.Controls.Add(divLeft);
            divBase.Controls.Add(divRight);

            div.Controls.Add(divBase);
        }

        protected void AddOpen(Panel div, IDevice dev, int iNum)
        {
            string sNum = String.Format("{0:00}", iNum);

            Panel divBase = new Panel();
            Panel divLeft = new Panel();
            Panel divRight = new Panel();

            Label cmdName = new Label();

            LinkButton cmdBtnDown = new LinkButton();
            Image imgBtnDown = new Image();

            LinkButton cmdBtnUp = new LinkButton();
            Image imgBtnUp = new Image();

            Image imgState = new Image();


            divBase.Attributes["name"] = "divBase" + sNum;
            divBase.CssClass = "device-div-on-off";

            divLeft.Attributes["name"] = "divLeft" + sNum;
            divLeft.CssClass = "device-div-open-left";

            divRight.Attributes["name"] = "divRight" + sNum;
            divRight.CssClass = "device-div-open-right";

            cmdName.Attributes["name"] = "cmdName" + sNum;
            cmdName.CssClass = "device-status-name";
            cmdName.Text = "Open: " + (50*((Louvers)listDevices[iNum - 1]).Open.Value).ToString() + "%";

            cmdBtnDown.Attributes["name"] = "cmdBtnDown" + sNum;
            cmdBtnDown.Click += new EventHandler(this.BtnDown_Click);

            imgBtnDown.Attributes["name"] = "imgBtnDown" + sNum;
            imgBtnDown.ImageUrl = "App_Themes/images/btn_down.png";
            imgBtnDown.CssClass = "device-div-speed-img";


            cmdBtnUp.Attributes["name"] = "cmdBtnUp" + sNum;
            cmdBtnUp.Click += new EventHandler(this.BtnUp_Click);

            imgBtnUp.Attributes["name"] = "imgBtnUp" + sNum;
            imgBtnUp.ImageUrl = "App_Themes/images/btn_up.png";
            imgBtnUp.CssClass = "device-div-speed-img";


            divLeft.Controls.Add(cmdName);

            cmdBtnDown.Controls.Add(imgBtnDown);
            cmdBtnUp.Controls.Add(imgBtnUp);

            if (listDevices[iNum - 1].State)
                divRight.Controls.Add(cmdBtnDown);

            if (listDevices[iNum - 1].State)
                divRight.Controls.Add(cmdBtnUp);


            divBase.Controls.Add(divLeft);
            divBase.Controls.Add(divRight);

            div.Controls.Add(divBase);
        }

        protected void AddProgram(Panel div, IDevice dev, int iNum)
        {
            string sNum = String.Format("{0:00}", iNum);

            Panel divBase = new Panel();
            Panel divLeft = new Panel();
            Panel divRight = new Panel();

            Label cmdName = new Label();

            LinkButton cmdBtnDown = new LinkButton();
            Image imgBtnDown = new Image();

            LinkButton cmdBtnUp = new LinkButton();
            Image imgBtnUp = new Image();

            Image imgState = new Image();


            divBase.Attributes["name"] = "divBase" + sNum;
            divBase.CssClass = "device-div-on-off";

            divLeft.Attributes["name"] = "divLeft" + sNum;
            divLeft.CssClass = "device-div-speed-left";

            divRight.Attributes["name"] = "divRight" + sNum;
            divRight.CssClass = "device-div-speed-right";

            cmdName.Attributes["name"] = "cmdName" + sNum;
            cmdName.CssClass = "device-status-name";
            cmdName.Text = "Program";

            cmdBtnDown.Attributes["name"] = "Program" + sNum;
            cmdBtnDown.Click += new EventHandler(this.BtnDown_Click);
            //            cmdBtnDown.CssClass = "device-div-on-off-cmd-btn";

            imgBtnDown.Attributes["name"] = "imgBtnDown" + sNum;
            imgBtnDown.ImageUrl = "App_Themes/images/btn_down.png";
            imgBtnDown.CssClass = "device-div-speed-img";

            imgState.Attributes["name"] = "imgState" + sNum;

            imgState.ImageUrl = "App_Themes/images/icon_" + ((Tv)listDevices[iNum - 1]).Channel.ToString() + ".png";
            imgState.CssClass = "device-div-prog-state";


            cmdBtnUp.Attributes["name"] = "Program" + sNum;
            cmdBtnUp.Click += new EventHandler(this.BtnUp_Click);

            imgBtnUp.Attributes["name"] = "imgBtnUp" + sNum;
            imgBtnUp.ImageUrl = "App_Themes/images/btn_up.png";
            imgBtnUp.CssClass = "device-div-speed-img";


            divLeft.Controls.Add(cmdName);
            divLeft.Controls.Add(imgState);

            cmdBtnDown.Controls.Add(imgBtnDown);
            cmdBtnUp.Controls.Add(imgBtnUp);

            if (listDevices[iNum - 1].State)
                divRight.Controls.Add(cmdBtnDown);


            if (listDevices[iNum - 1].State)
                divRight.Controls.Add(cmdBtnUp);


            divBase.Controls.Add(divLeft);
            divBase.Controls.Add(divRight);

            div.Controls.Add(divBase);
        }


        protected void AddState(Panel div, IDevice dev, int iNum)
        {
            string sNum = String.Format("{0:00}", iNum);
            string sImgFile = "";

            Panel divBase = new Panel();
            Label cmdName = new Label();

            Image imgState = new Image();

            divBase.Attributes["name"] = "divBase" + sNum;
            divBase.CssClass = "device-div-on-off";

            cmdName.Attributes["name"] = "cmdName" + sNum;
            cmdName.CssClass = "device-state";
            if (listDevices[iNum - 1].State)
                cmdName.Text = "State: ON";
            else
                cmdName.Text = "State: OFF";

            imgState.Attributes["name"] = "imgState" + sNum;
            imgState.CssClass = "device-image";

            switch (listDevices[iNum - 1].Type)
            {
                case "lamp":
                    if (listDevices[iNum - 1].State)
                        sImgFile = "lamp_on.png";
                    else
                        sImgFile = "lamp_off.png";
                    break;
                case "fan":
                    if (listDevices[iNum - 1].State)
                        sImgFile = "fan_" + ((Fan)listDevices[iNum - 1]).Speed.Value.ToString() + ".gif";
                    else
                        sImgFile = "fan_stop.png";
                    break;
                case "louvers":
                    if (listDevices[iNum - 1].State)
                        sImgFile = "louvers_" + ((Louvers)listDevices[iNum - 1]).Open.Value.ToString() + ".png";
                    else
                        sImgFile = "louvers_stop.png";
                    break;
                case "tv":
                    if (listDevices[iNum - 1].State)
                        sImgFile = "tv_" + ((Tv)listDevices[iNum - 1]).Channel.ToString() + ".png";
                    else
                        sImgFile = "tv_stop.png";
                    break;
            }

            imgState.ImageUrl = "App_Themes/images/" + sImgFile;

            divBase.Controls.Add(cmdName);
            divBase.Controls.Add(imgState);

            div.Controls.Add(divBase);
        }

        protected IDevice GetNewDevice(string sType)
        {
            switch (sType)
            {
                case "lamp":
                    return new Lamp(NameOfNewDevice.Text, false);
                case "fan":
                    return new Fan(NameOfNewDevice.Text, false, 1);
                case "louvers":
                    return new Louvers(NameOfNewDevice.Text, false, 1);
                case "tv":
                    return new Tv(NameOfNewDevice.Text, false, Channels.football, 2, 5);
            }

            return null;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string sID = ((LinkButton)sender).ID;
            string sType = (sID.Substring(6, sID.Length - 6)).ToLower();

            if (NameOfNewDevice.Text != "")
                if (!listDevices.Exists(i => ((i.Name == NameOfNewDevice.Text) && (i.Type == sType))))
                {
                    listDevices.Add(GetNewDevice(sType));
                    Session["listDevices"] = listDevices;
                    Response.Redirect("~/Default.aspx");
                }
        }

        protected void BtnOnOff_Click(object sender, EventArgs e)
        {
            string sName = ((LinkButton)sender).Attributes["name"];
            int numOfElement = Convert.ToInt32(sName.Substring(sName.Length - 2, 2)) - 1;

            listDevices[numOfElement].OnOff();
            Session["listDevices"] = listDevices;
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnDown_Click(object sender, EventArgs e)
        {
            string sName = ((LinkButton)sender).Attributes["name"];
            string sType = sName.Substring(0, sName.Length - 2);
            int numOfElement = Convert.ToInt32(sName.Substring(sName.Length - 2, 2)) - 1;

            switch (listDevices[numOfElement].Type)
            {
                case "fan":
                    ((Fan)listDevices[numOfElement]).Speed.Down();
                    break;
                case "louvers":
                    ((Louvers)listDevices[numOfElement]).Open.Down();
                    break;
                case "tv":
                    if (sType == "Program")
                        ((Tv)listDevices[numOfElement]).PreviousChannel();
                    if (sType == "Volume")
                        ((Tv)listDevices[numOfElement]).Volume.Down();
                    if (sType == "Bright")
                        ((Tv)listDevices[numOfElement]).Bright.Down();
                    break;
            }

            Session["listDevices"] = listDevices;
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnUp_Click(object sender, EventArgs e)
        {
            string sName = ((LinkButton)sender).Attributes["name"];
            string sType = sName.Substring(0, sName.Length - 2);
            int numOfElement = Convert.ToInt32(sName.Substring(sName.Length - 2, 2)) - 1;

            switch (listDevices[numOfElement].Type)
            {
                case "fan":
                    ((Fan)listDevices[numOfElement]).Speed.Up();
                    break;
                case "louvers":
                    ((Louvers)listDevices[numOfElement]).Open.Up();
                    break;
                case "tv":
                    if (sType == "Program")
                        ((Tv)listDevices[numOfElement]).NextChannel();
                    if (sType == "Volume")
                        ((Tv)listDevices[numOfElement]).Volume.Up();
                    if (sType == "Bright")
                        ((Tv)listDevices[numOfElement]).Bright.Up();
                    break;
            }
            Session["listDevices"] = listDevices;
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnDel_Click(object sender, EventArgs e)
        {
            string sName = ((LinkButton)sender).Attributes["name"];
            int numOfElement = Convert.ToInt32(sName.Substring(sName.Length - 2, 2)) - 1;
            
            listDevices.RemoveAt(numOfElement);
            Session["listDevices"] = listDevices;
            Response.Redirect("~/Default.aspx");
        }
    }
}