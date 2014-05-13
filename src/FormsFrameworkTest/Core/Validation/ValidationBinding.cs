using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Core.Validation
{
    public class ValidationBinding : Binding
    {
        public ValidationBinding()
            : base()
        {
            this.ValidatesOnDataErrors = true;
            this.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        }

        public ValidationBinding(string path)
            : base(path)
        {
            this.ValidatesOnDataErrors = true;
            this.UpdateSourceTrigger = UpdateSourceTrigger.LostFocus;
        }
    }
}
