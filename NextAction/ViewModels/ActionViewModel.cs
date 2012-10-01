using System;
using NextAction.Models;

namespace NextAction.ViewModels
{
    public class ActionViewModel
    {
        private readonly ProjectAction _action;

        public ActionViewModel(ProjectAction action)
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

        public bool IsComplete
        {
            get { return _action.IsComplete; }
            set { _action.IsComplete = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            ActionViewModel that = obj as ActionViewModel;
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
