using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpdateControls.Fields;

namespace NextAction.Models
{
    public class ProjectAction
    {
        private Independent<string> _name = new Independent<string>();
        private Independent<string> _description = new Independent<string>();
        private Independent<int> _order = new Independent<int>();
        private Independent<bool> _isComplete = new Independent<bool>();

        public string Name
        {
            get { return _name; }
            set { _name.Value = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description.Value = value; }
        }

        public int Order
        {
            get { return _order; }
            set { _order.Value = value; }
        }

        public bool IsComplete
        {
            get { return _isComplete; }
            set { _isComplete.Value = value; }
        }
    }
}
