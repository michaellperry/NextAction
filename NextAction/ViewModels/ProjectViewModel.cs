using System;
using System.Collections.Generic;
using System.Linq;
using NextAction.Models;

namespace NextAction.ViewModels
{
    public class ProjectViewModel
    {
        private readonly Project _project;
        private readonly ProjectSelection _projectSelection;

        public ProjectViewModel(Project project, ProjectSelection projectSelection)
        {
            _project = project;
            _projectSelection = projectSelection;
        }

        public string Name
        {
            get { return _project.Name; }
            set { _project.Name = value; }
        }

        public IEnumerable<ActionHeader> Actions
        {
            get
            {
                return
                    from action in _project.Actions
                    orderby action.Order
                    select new ActionHeader(action);
            }
        }

        public ActionHeader SelectedAction
        {
            get
            {
                return _projectSelection.SelectedAction == null
                    ? null
                    : new ActionHeader(_projectSelection.SelectedAction);
            }
            set
            {
                _projectSelection.SelectedAction = value == null
                    ? null
                    : value.Action;
            }
        }

        public ActionViewModel ActionDetail
        {
            get
            {
                return _projectSelection.SelectedAction == null
                    ? null
                    : new ActionViewModel(_projectSelection.SelectedAction);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            ProjectViewModel that = obj as ProjectViewModel;
            if (that == null)
                return false;
            return Object.Equals(this._project, that._project);
        }

        public override int GetHashCode()
        {
            return _project.GetHashCode();
        }
    }
}
