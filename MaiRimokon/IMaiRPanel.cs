using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaiRimokon
{
    public interface IMaiRPanel
    {
        MaiRControlValue.PanelType Type
        {
            get;
//            internal set;
        }

        List<IMaiRButton> ButtonItems
        {
            get;
            set;
        }
        string Title
        {
            get;
            set;
        }
        bool Selected
        {
            get;
            set;
        }
        event MaiRControlValue.ValueChangedHandler ValueChanged;
        event MaiRControlValue.SelectChangedHandler SelectChanged;
        void ViewSelect(bool value);
    }
}
