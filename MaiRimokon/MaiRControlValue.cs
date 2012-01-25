using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaiRimokon
{
    public static class MaiRControlValue
    {
        public enum ButtonType 
        {
            Type1 = 0,
            Type2,
            Type3
        };
        public enum ButtonColor
        {
            Default = 0,
            Blue,
            Red,
            Green,
            Yellow
        };
        public enum PanelType
        {
            Type1 = 0,
            Type2,
            Type3,
            Type4
        };
        public delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
        public delegate void SelectChangedHandler(object sender);

    }
}
