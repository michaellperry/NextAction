using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UpdateControls.Collections;
using UpdateControls.Fields;

namespace NextAction.Models
{
    public class Project
    {
        private Independent<string> _name = new Independent<string>();
        private IndependentList<ProjectAction> _actions = new IndependentList<ProjectAction>();

        public string Name
        {
            get { return _name; }
            set { _name.Value = value; }
        }

        public IEnumerable<ProjectAction> Actions
        {
            get { return _actions; }
        }

        public ProjectAction NextAction
        {
            get
            {
                return
                    (from action in _actions
                     where !action.IsComplete
                     orderby action.Order
                     select action)
                    .FirstOrDefault();
            }
        }

        public ProjectAction NewAction()
        {
            ProjectAction action = new ProjectAction();
            _actions.Add(action);
            return action;
        }

        public void DeleteAction(ProjectAction action)
        {
            _actions.Remove(action);
        }

        public bool CanMoveDown(ProjectAction action)
        {
            return _actions.IndexOf(action) < _actions.Count - 1;
        }

        public void MoveDown(ProjectAction action)
        {
            int index = _actions.IndexOf(action);
            _actions.RemoveAt(index);
            _actions.Insert(index + 1, action);
        }

        public bool CanMoveUp(ProjectAction action)
        {
            return _actions.IndexOf(action) > 0;
        }

        public void MoveUp(ProjectAction action)
        {
            int index = _actions.IndexOf(action);
            _actions.RemoveAt(index);
            _actions.Insert(index - 1, action);
        }
    }
}
