using System;
using System.Linq;
using NextAction.Models;

namespace NextAction.ViewModels
{
    public class ProjectHeader
    {
        private readonly Project _project;

        public ProjectHeader(Project project)
        {
            _project = project;
        }

        public Project Project
        {
            get { return _project; }
        }

        public string Name
        {
            get { return _project.Name; }
        }

        public string NextAction
        {
            get
            {
                return
                    (from action in _project.Actions
                     where !action.IsComplete
                     orderby action.Order
                     select action.Name)
                    .FirstOrDefault();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            ProjectHeader that = obj as ProjectHeader;
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
