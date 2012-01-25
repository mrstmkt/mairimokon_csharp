using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace MaiRimokon
{
    class XmlConvert
    {
        public bool Valid
        {
            get;
            internal set;
        }
        private XmlDocument doc;

        public XmlConvert(MaiRimoconData data)
        {
            this.doc = ConvertDataToXml(data);
            if (this.doc == null)
            {
                this.Valid = false;
            }
            else
            {
                this.Valid = true;
            }
        }

        public XmlConvert(string fileName)
        {
            doc = ConvertFileToXml(fileName);
            if (this.doc == null)
            {
                this.Valid = false;
            }
            else
            {
                this.Valid = true;
            }
        }


        private XmlDocument ConvertDataToXml(MaiRimoconData data)
        {
            if (data != null)
            {
                XmlDocument doc = new XmlDocument();
                XmlDeclaration dec =  doc.CreateXmlDeclaration("1.0", "utf-8", "yes");
                doc.AppendChild(dec);

                XmlElement baseEle = doc.CreateElement("rimokoninfo");
                doc.AppendChild(baseEle);

                XmlElement ele = doc.CreateElement("title");
                XmlText text = doc.CreateTextNode(data.Title);
                ele.AppendChild(text);
                baseEle.AppendChild(ele);

                ele = doc.CreateElement("description");
                text = doc.CreateTextNode(data.Description);
                ele.AppendChild(text);
                baseEle.AppendChild(ele);

                int panelNo = 0;
                foreach (IMaiRPanel panel in data.PanelItems)
                {
                    XmlElement panelEle = doc.CreateElement("panelinfo");
                    baseEle.AppendChild(panelEle);

                    ele = doc.CreateElement("no");
                    text = doc.CreateTextNode(Convert.ToString(panelNo));
                    ele.AppendChild(text);
                    panelEle.AppendChild(ele);

                    ele = doc.CreateElement("title");
                    text = doc.CreateTextNode(panel.Title);
                    ele.AppendChild(text);
                    panelEle.AppendChild(ele);

                    ele = doc.CreateElement("type");
                    text = doc.CreateTextNode(Convert.ToString((int)panel.Type));
                    ele.AppendChild(text);
                    panelEle.AppendChild(ele);

                    int buttonNo = 0;
                    foreach (IMaiRButton button in panel.ButtonItems)
                    {
                        XmlElement buttonEle = doc.CreateElement("buttoninfo");
                        panelEle.AppendChild(buttonEle);

                        ele = doc.CreateElement("no");
                        text = doc.CreateTextNode(Convert.ToString(buttonNo));
                        ele.AppendChild(text);
                        buttonEle.AppendChild(ele);

                        ele = doc.CreateElement("type");
                        text = doc.CreateTextNode(Convert.ToString((int)button.Type));
                        ele.AppendChild(text);
                        buttonEle.AppendChild(ele);

                        ele = doc.CreateElement("upperlabel");
                        text = doc.CreateTextNode(button.UpperLabel);
                        ele.AppendChild(text);
                        buttonEle.AppendChild(ele);

                        ele = doc.CreateElement("innerlabel");
                        text = doc.CreateTextNode(button.InnerLabel);
                        ele.AppendChild(text);
                        buttonEle.AppendChild(ele);

                        ele = doc.CreateElement("color");
                        text = doc.CreateTextNode(Convert.ToString((int)button.Color));
                        ele.AppendChild(text);
                        buttonEle.AppendChild(ele);

                        ele = doc.CreateElement("longpush");
                        text = doc.CreateTextNode(Convert.ToString(button.LongPush));
                        ele.AppendChild(text);
                        buttonEle.AppendChild(ele);

                        ele = doc.CreateElement("disable");
                        text = doc.CreateTextNode(Convert.ToString(button.Disable));
                        ele.AppendChild(text);
                        buttonEle.AppendChild(ele);

                        int frameNo = 0;
                        if (button.Frames != null)
                        {
                            foreach (IRFrame frame in button.Frames)
                            {
                                XmlElement irEle = doc.CreateElement("irinfo");
                                buttonEle.AppendChild(irEle);

                                ele = doc.CreateElement("no");
                                text = doc.CreateTextNode(Convert.ToString(frameNo));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("format");
                                text = doc.CreateTextNode(Convert.ToString(button.Format));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("carrierhigh");
                                text = doc.CreateTextNode(Convert.ToString(frame.CarrierHigh));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("leaderhigh");
                                text = doc.CreateTextNode(Convert.ToString(frame.LeaderHigh));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("leaderlow");
                                text = doc.CreateTextNode(Convert.ToString(frame.LeaderLow));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("carrierlow");
                                text = doc.CreateTextNode(Convert.ToString(frame.CarrierLow));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("pulse0modulation");
                                text = doc.CreateTextNode(Convert.ToString(frame.Pulse0Modulation));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("pulse0high");
                                text = doc.CreateTextNode(Convert.ToString(frame.Pulse0High));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("pulse0low");
                                text = doc.CreateTextNode(Convert.ToString(frame.Pulse0Low));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("pulse1modulation");
                                text = doc.CreateTextNode(Convert.ToString(frame.Pulse1Modulation));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("pulse1high");
                                text = doc.CreateTextNode(Convert.ToString(frame.Pulse1High));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("pulse1low");
                                text = doc.CreateTextNode(Convert.ToString(frame.Pulse1Low));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("stophigh");
                                text = doc.CreateTextNode(Convert.ToString(frame.StopHigh));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("stoplow");
                                text = doc.CreateTextNode(Convert.ToString(frame.StopLow));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("frameinterval");
                                text = doc.CreateTextNode(Convert.ToString(frame.FrameInterval));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("repeathigh");
                                text = doc.CreateTextNode(Convert.ToString(frame.RepeatHigh));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                ele = doc.CreateElement("repeatlow");
                                text = doc.CreateTextNode(Convert.ToString(frame.RepeatLow));
                                ele.AppendChild(text);
                                irEle.AppendChild(ele);

                                if (frame.ValueValid == true)
                                {
                                    ele = doc.CreateElement("data");
                                    StringBuilder sb = new StringBuilder();
                                    foreach (byte b in frame.Value.ValueList)
                                    {
                                        String hex = Convert.ToString(b, 16);
                                        if (hex.Length == 1)
                                        {
                                            hex = "0" + hex;
                                        }
                                        sb.Append(hex);
                                    }
                                    text = doc.CreateTextNode(sb.ToString());
                                    ele.AppendChild(text);
                                    irEle.AppendChild(ele);

                                    ele = doc.CreateElement("len");
                                    text = doc.CreateTextNode(Convert.ToString(frame.Value.ValueLength));
                                    ele.AppendChild(text);
                                    irEle.AppendChild(ele);
                                }

                                frameNo++;
                            }
                        }
                        buttonNo++;
                    }
                    panelNo++;
                }
                return doc;
            }
            else
            {
                return null;
            }
        }

        private XmlDocument ConvertFileToXml(string fileName)
        {
            if (fileName != null && fileName.Length > 0)
            {
                if (File.Exists(fileName) == true)
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fileName);
                        return doc;
                    }
                    catch
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool SaveXml(string fileName)
        {
            bool ret = false;
            if (this.Valid == true)
            {
                this.doc.Save(fileName);
                ret = true;
            }
            return ret;
        }

        public MaiRimoconData ConvertXmlToData(MainForm mainForm, MaiRControlValue.ValueChangedHandler handler)
        {
            MaiRimoconData data = new MaiRimoconData();
            if (this.Valid == true)
            {
                XmlNode node = doc.SelectSingleNode("/rimokoninfo/title");
                if (node != null)
                {
                    data.Title = node.InnerText;
                }

                node = doc.SelectSingleNode("/rimokoninfo/description");
                if (node != null)
                {
                    data.Description = node.InnerText;
                }

                XmlNodeList panelNodeList= doc.SelectNodes("/rimokoninfo/panelinfo");
                if(panelNodeList != null)
                {
                    List<IMaiRPanel> panelList = new List<IMaiRPanel>();
                    for (int i = 0; i < panelNodeList.Count; i++)
                    {
                        try
                        {
                            XmlNodeList buttonNodeList = panelNodeList.Item(i).SelectNodes("buttoninfo");
                            List<IMaiRButton> buttonList = new List<IMaiRButton>();
                            if (buttonNodeList != null)
                            {
                                for (int j = 0; j < buttonNodeList.Count; j++)
                                {
                                    int format = IRFrame.FORMAT_DENKYO;
                                    List<IRFrame> frameList = new List<IRFrame>();
                                    try
                                    {
                                        XmlNodeList frameNodeList = buttonNodeList.Item(j).SelectNodes("irinfo");
                                        if (frameNodeList != null)
                                        {
                                            for (int k = 0; k < frameNodeList.Count; k++)
                                            {
                                                node = frameNodeList.Item(k).SelectSingleNode("format");
                                                if (k == 0)
                                                {
                                                    format = Convert.ToInt32(node.InnerText);
                                                }
                                                int format2 = Convert.ToInt32(node.InnerText);
                                                node = frameNodeList.Item(k).SelectSingleNode("carrierhigh");
                                                int carrierHigh = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("carrierlow");
                                                int carrierLow = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("leaderhigh");
                                                int leaderHigh = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("leaderlow");
                                                int leaderLow = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("pulse0modulation");
                                                int pulse0Modulation = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("pulse0high");
                                                int pulse0High = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("pulse0low");
                                                int pulse0Low = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("pulse1modulation");
                                                int pulse1Modulation = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("pulse1high");
                                                int pulse1High = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("pulse1low");
                                                int pulse1Low = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("stophigh");
                                                int stopHigh = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("stoplow");
                                                int stopLow = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("frameinterval");
                                                int frameInterval = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("repeathigh");
                                                int repeatHigh = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("repeatlow");
                                                int repeatLow = Convert.ToInt32(node.InnerText);

                                                node = frameNodeList.Item(k).SelectSingleNode("data");
                                                List<byte> dataList = new List<byte>();
                                                for (int l = 0; l < node.InnerText.Length; l = l + 2)
                                                {
                                                    byte b = Convert.ToByte(node.InnerText.Substring(l, 2), 16);
                                                    dataList.Add(b);
                                                }

                                                node = frameNodeList.Item(k).SelectSingleNode("len");
                                                int len = Convert.ToInt32(node.InnerText);

                                                if (dataList.Count > 0 && len > 0)
                                                {
                                                    IRFrameParam param = new IRFrameParam(carrierHigh, carrierLow,
                                                                                        leaderHigh, leaderLow,
                                                                                        pulse0Modulation, pulse0High, pulse0Low,
                                                                                        pulse1Modulation, pulse1High, pulse1Low,
                                                                                        stopHigh, stopLow,
                                                                                        frameInterval,
                                                                                        repeatHigh, repeatLow);
                                                    IRFrameValue value = new IRFrameValue();
                                                    value.ValueList = dataList;
                                                    value.ValueLength = len;
                                                    IRFrame frame = new IRFrame(format2, param, value);
                                                    frameList.Add(frame);
                                                }
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                    node = buttonNodeList.Item(j).SelectSingleNode("type");
                                    int buttontype = Convert.ToInt32(node.InnerText);

                                    node = buttonNodeList.Item(j).SelectSingleNode("upperlabel");
                                    String upperlabel = node.InnerText;

                                    node = buttonNodeList.Item(j).SelectSingleNode("innerlabel");
                                    String innerlabel = node.InnerText;

                                    node = buttonNodeList.Item(j).SelectSingleNode("color");
                                    int color = Convert.ToInt32(node.InnerText);

                                    node = buttonNodeList.Item(j).SelectSingleNode("longpush");
                                    bool longpush = Convert.ToBoolean(node.InnerText);

                                    node = buttonNodeList.Item(j).SelectSingleNode("disable");
                                    bool disable = Convert.ToBoolean(node.InnerText);

                                    MaiRButtonView buttonView = new MaiRButtonView();
                                    switch(buttontype)
                                    {
                                        case (int)MaiRControlValue.ButtonType.Type1:
                                            buttonView.Type = MaiRControlValue.ButtonType.Type1;
                                            break;
                                        case (int)MaiRControlValue.ButtonType.Type2:
                                            buttonView.Type = MaiRControlValue.ButtonType.Type2;
                                            break;
                                        case (int)MaiRControlValue.ButtonType.Type3:
                                            buttonView.Type = MaiRControlValue.ButtonType.Type3;
                                            break;
                                    }
                                    buttonView.UpperLabel = upperlabel;
                                    buttonView.InnerLabel = innerlabel;
                                    switch (color)
                                    {
                                        case (int)MaiRControlValue.ButtonColor.Default:
                                            buttonView.Color = MaiRControlValue.ButtonColor.Default;
                                            break;
                                        case (int)MaiRControlValue.ButtonColor.Blue:
                                            buttonView.Color = MaiRControlValue.ButtonColor.Blue;
                                            break;
                                        case (int)MaiRControlValue.ButtonColor.Red:
                                            buttonView.Color = MaiRControlValue.ButtonColor.Red;
                                            break;
                                        case (int)MaiRControlValue.ButtonColor.Green:
                                            buttonView.Color = MaiRControlValue.ButtonColor.Green;
                                            break;
                                        case (int)MaiRControlValue.ButtonColor.Yellow:
                                            buttonView.Color = MaiRControlValue.ButtonColor.Yellow;
                                            break;
                                    }
                                    buttonView.LongPush = longpush;
                                    buttonView.Disable = disable;
                                    buttonView.Frames = frameList;

                                    buttonList.Add(buttonView);
                                }
                            }
                            node = panelNodeList.Item(i).SelectSingleNode("title");
                            String title = node.InnerText;
                            node = panelNodeList.Item(i).SelectSingleNode("type");
                            int paneltype = Convert.ToInt32(node.InnerText);
                            switch (paneltype)
                            {
                                case (int)MaiRControlValue.PanelType.Type1:
                                    MaiRPanel1View panel1view = new MaiRPanel1View(mainForm);
                                    panel1view.Title = title;
                                    panel1view.ButtonItems = buttonList;
                                    panel1view.ValueChanged += handler;
                                    panelList.Add(panel1view);
                                    break;
                                case (int)MaiRControlValue.PanelType.Type2:
                                    MaiRPanel2View panel2view = new MaiRPanel2View(mainForm);
                                    panel2view.Title = title;
                                    panel2view.ButtonItems = buttonList;
                                    panel2view.ValueChanged += handler;
                                    panelList.Add(panel2view);
                                    break;
                                case (int)MaiRControlValue.PanelType.Type3:
                                    MaiRPanel3View panel3view = new MaiRPanel3View(mainForm);
                                    panel3view.Title = title;
                                    panel3view.ButtonItems = buttonList;
                                    panel3view.ValueChanged += handler;
                                    panelList.Add(panel3view);
                                    break;
                                case (int)MaiRControlValue.PanelType.Type4:
                                    MaiRPanel4View panel4view = new MaiRPanel4View(mainForm);
                                    panel4view.Title = title;
                                    panel4view.ButtonItems = buttonList;
                                    panel4view.ValueChanged += handler;
                                    panelList.Add(panel4view);
                                    break;
                            }
                        }
                        catch
                        {
                        }

                    }
                    data.PanelItems = panelList;
                }

            }
            return data;
        }
    }
}
