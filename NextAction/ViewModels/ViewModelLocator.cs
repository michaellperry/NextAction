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
            CreateSampleProject(document, "Get off of Tatooine",
                "Find the boy",
                "Bet on the pod races",
                "Buy hyperdrive",
                "Install hyperdrive");
            CreateSampleProject(document, "Fix the sink",
                "Buy parts at hardware store",
                "Install parts",
                "Go back to hardware store",
                "Smash finger with wrench",
                "Call plumber");
            CreateSampleProject(document, "Build Windows 8 app",
                "Download SDK",
                "Build app",
                "...",
                "Profit!");
        }

        private static void CreateSampleProject(Document document, string name, params string[] actions)
        {
            Project project = document.NewProject();
            project.Name = name;
            foreach (string action in actions)
                CreateSampleAction(project, action);
        }

        private static void CreateSampleAction(Project project, string name)
        {
            ProjectAction action = project.NewAction();
            action.Name = name;
            action.Description = String.Format("Description of {0} {1}", project.Name, name);
        }
    }
}
