using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaiRimokon
{
    public class MaiRimoconData
    {
        public string Title
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public List<IMaiRPanel> PanelItems
        {
            get;
            set;
        }
        public MaiRimoconData():this("","")
        {
        }
        public MaiRimoconData(string title)
            : this(title, "")
        {
        }
        public MaiRimoconData(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this.PanelItems = new List<IMaiRPanel>();
        }
    }
}
