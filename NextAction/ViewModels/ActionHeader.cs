using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NextAction.Models;

namespace NextAction.ViewModels
{
    public class ActionHeader
    {
        private readonly ProjectAction _action;

        public ActionHeader(ProjectAction action)
        {
            _action = action;
        }

        public string Name
        {
            get { return _action.Name; }
            set { _action.Name = value; }
        }

        public string Description
        {
            get { return _action.Description; }
            set { _action.Description = value; }
        }

        public ProjectAction Action
        {
            get { return _action; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            ActionHeader that = obj as ActionHeader;
            if (that == null)
                return false;
            return Object.Equals(this._action, that._action);
        }

        public override int GetHashCode()
        {
            return _action.GetHashCode();
        }
    }
}
