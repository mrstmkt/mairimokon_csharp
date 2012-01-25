using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaiRimokon
{
    public class ValueChangedEventArgs:EventArgs
    {
        public string PropertyName
        {
            get;
            set;
        }
        public object Value
        {
            get;
            set;
        }
        public ValueChangedEventArgs(string propertyName, object value)
        {
            this.PropertyName = propertyName;
            this.Value = value;
        }
    }
}
