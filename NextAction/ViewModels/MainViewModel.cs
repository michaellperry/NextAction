using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NextAction.Models;
using UpdateControls.XAML;

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

        public ICommand AddProject
        {
            get
            {
                return MakeCommand
                    .Do(delegate
                    {
                        _projectSelection.SelectedProject = _document.NewProject();
                        if (ProjectAdded != null)
                            ProjectAdded(_projectSelection.SelectedProject);
                    });
            }
        }

        public ICommand DeleteProject
        {
            get
            {
                return MakeCommand
                    .When(() => _projectSelection.SelectedProject != null)
                    .Do(async delegate
                    {
                        if (CanDeleteProject == null || await CanDeleteProject(_projectSelection.SelectedProject))
                        {
                            _document.DeleteProject(_projectSelection.SelectedProject);
                            _projectSelection.SelectedProject = null;
                        }
                    });
            }
        }

        public ICommand MoveProjectDown
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _projectSelection.SelectedProject != null &&
                        _document.CanMoveDown(_projectSelection.SelectedProject))
                    .Do(delegate
                    {
                        _document.MoveDown(_projectSelection.SelectedProject);
                    });
            }
        }

        public ICommand MoveProjectUp
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _projectSelection.SelectedProject != null &&
                        _document.CanMoveUp(_projectSelection.SelectedProject))
                    .Do(delegate
                    {
                        _document.MoveUp(_projectSelection.SelectedProject);
                    });
            }
        }

        public ICommand AddAction
        {
            get
            {
                return MakeCommand
                    .When(() => _projectSelection.SelectedProject != null)
                    .Do(delegate
                    {
                        _projectSelection.SelectedAction = _projectSelection.SelectedProject.NewAction();
                        if (ActionAdded != null)
                            ActionAdded(_projectSelection.SelectedAction);
                    });
            }
        }

        public ICommand DeleteAction
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _projectSelection.SelectedProject != null &&
                        _projectSelection.SelectedAction != null)
                    .Do(async delegate
                    {
                        if (CanDeleteAction == null || await CanDeleteAction(_projectSelection.SelectedAction))
                        {
                            _projectSelection.SelectedProject.DeleteAction(_projectSelection.SelectedAction);
                            _projectSelection.SelectedAction = null;
                        }
                    });
            }
        }

        public ICommand MoveActionDown
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _projectSelection.SelectedProject != null &&
                        _projectSelection.SelectedAction != null &&
                        _projectSelection.SelectedProject.CanMoveDown(_projectSelection.SelectedAction))
                    .Do(delegate
                    {
                        _projectSelection.SelectedProject.MoveDown(_projectSelection.SelectedAction);
                    });
            }
        }

        public ICommand MoveActionUp
        {
            get
            {
                return MakeCommand
                    .When(() =>
                        _projectSelection.SelectedProject != null &&
                        _projectSelection.SelectedAction != null &&
                        _projectSelection.SelectedProject.CanMoveUp(_projectSelection.SelectedAction))
                    .Do(delegate
                    {
                        _projectSelection.SelectedProject.MoveUp(_projectSelection.SelectedAction);
                    });
            }
        }

        public event Action<Project> ProjectAdded;
        public event Func<Project, Task<bool>> CanDeleteProject;
        public event Action<ProjectAction> ActionAdded;
        public event Func<ProjectAction, Task<bool>> CanDeleteAction;
    }
}
