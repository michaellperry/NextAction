using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextAction.Models;
using UpdateControls.XAML;

namespace NextAction.ViewModels
{
    public class ViewModelLocator
    {
        private MainViewModel _main;

        public ViewModelLocator()
        {
            Document document = new Document();
            CreateSampleData(document);
            ProjectSelection projectSelection = new ProjectSelection();
            _main = new MainViewModel(document, projectSelection);
        }

        public object Main
        {
            get { return ForView.Wrap(_main); }
        }

        private static void CreateSampleData(Document document)
        {
            CreateSampleProject(document, "Project A");
            CreateSampleProject(document, "Project B");
            CreateSampleProject(document, "Project C");
        }

        private static void CreateSampleProject(Document document, string name)
        {
            Project project = document.NewProject();
            project.Name = name;
            CreateSampleAction(project, "Action 1");
            CreateSampleAction(project, "Action 2");
            CreateSampleAction(project, "Action 3");
        }

        private static void CreateSampleAction(Project project, string name)
        {
            ProjectAction action = project.NewAction();
            action.Name = name;
            action.Description = String.Format("Description of {0} {1}", project.Name, name);
        }
    }
}
