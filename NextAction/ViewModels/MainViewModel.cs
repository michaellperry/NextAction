using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NextAction.Models;

namespace NextAction.ViewModels
{
    public class MainViewModel
    {
        private readonly Document _document;
        private readonly ProjectSelection _projectSelection;

        public MainViewModel(Document document, ProjectSelection projectSelection)
        {
            _document = document;
            _projectSelection = projectSelection;
        }

        public IEnumerable<ProjectHeader> Projects
        {
            get
            {
                return
                    from project in _document.Projects
                    orderby project.Name
                    select new ProjectHeader(project);
            }
        }

        public ProjectHeader SelectedProject
        {
            get
            {
                return _projectSelection.SelectedProject == null
                    ? null
                    : new ProjectHeader(_projectSelection.SelectedProject);
            }
            set
            {
                if (value != null)
                    _projectSelection.SelectedProject = value.Project;
            }
        }

        public ProjectViewModel ProjectDetail
        {
            get
            {
                return _projectSelection.SelectedProject == null
                    ? null
                    : new ProjectViewModel(_projectSelection.SelectedProject, _projectSelection);
            }
        }
    }
}
