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

        public bool CanMoveDown(Project project)
        {
            return _projects.IndexOf(project) < _projects.Count - 1;
        }

        public bool CanMoveUp(Project project)
        {
            return _projects.IndexOf(project) > 0;
        }

        public void MoveDown(Project project)
        {
            int index = _projects.IndexOf(project);
            _projects.RemoveAt(index);
            _projects.Insert(index + 1, project);
        }

        public void MoveUp(Project project)
        {
            int index = _projects.IndexOf(project);
            _projects.RemoveAt(index);
            _projects.Insert(index - 1, project);
        }
    }
}
