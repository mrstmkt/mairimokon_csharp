using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaiRimokon
{
    public interface IMaiRButton
    {
        MaiRControlValue.ButtonType Type
        {
            get;
            set;
        }

        MaiRControlValue.ButtonColor Color
        {
            get;
            set;
        }

        int Format
        {
            get;
            set;
        }
        //IRFrame Frame
        //{
        //    get;
        //    set;
        //}
        List<IRFrame> Frames
        {
            get;
            set;
        }
        string UpperLabel
        {
            get;
            set;
        }
        string InnerLabel
        {
            get;
            set;
        }
        bool LongPush
        {
            get;
            set;
        }
        bool Disable
        {
            get;
            set;
        }
        bool Selected
        {
            get;
            set;
        }
//        delegate void ValueChangedHandler(object sender, ValueChangedEventArgs e);
        event MaiRControlValue.ValueChangedHandler ValueChanged;
        event MaiRControlValue.SelectChangedHandler SelectChanged;
        void ViewSelect(bool value); 
    }
}
