using System.Linq;
using UpdateControls.Fields;

namespace NextAction.Models
{
    public class ProjectSelection
    {
        private Independent<Project> _selectedProject = new Independent<Project>();
        private Independent<ProjectAction> _selectedAction = new Independent<ProjectAction>();

        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                _selectedProject.Value = value;
                _selectedAction.Value = value == null
                    ? null
                    : value.NextAction;
            }
        }

        public ProjectAction SelectedAction
        {
            get { return _selectedAction; }
            set { _selectedAction.Value = value; }
        }
    }
}
