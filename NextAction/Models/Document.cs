using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateControls.Collections;

namespace NextAction.Models
{
    public class Document
    {
        private IndependentList<Project> _projects = new IndependentList<Project>();

        public IEnumerable<Project> Projects
        {
            get { return _projects; }
        }

        public Project NewProject()
        {
            Project project = new Project();
            _projects.Add(project);
            return project;
        }

        public void DeleteProject(Project project)
        {
            _projects.Remove(project);
        }
    }
}
