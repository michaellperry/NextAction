using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NextAction.ViewModels;
using UpdateControls.XAML;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NextAction.Models;
using Windows.UI.Popups;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NextAction
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var viewModel = ForView.Unwrap<MainViewModel>(DataContext);
            if (viewModel != null)
            {
                viewModel.ProjectAdded += ProjectAdded;
                viewModel.CanDeleteProject += CanDeleteProject;
                viewModel.ActionAdded += ActionAdded;
                viewModel.CanDeleteAction += viewModel_CanDeleteAction;
            }
        }

        void ProjectAdded(Project project)
        {
            ProjectNameTextBox.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        async Task<bool> CanDeleteProject(Project project)
        {
            string prompt = String.Format("Delete project {0}?", project.Name);

            var messageDialog = new MessageDialog(prompt);

            UICommand yesCommand = new UICommand("Yes");
            messageDialog.Commands.Add(yesCommand);
            messageDialog.Commands.Add(new UICommand("No"));

            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            var result = await messageDialog.ShowAsync();

            return result == yesCommand;
        }

        void ActionAdded(ProjectAction obj)
        {
            ActionNameTextBox.Focus(Windows.UI.Xaml.FocusState.Keyboard);
        }

        async Task<bool> viewModel_CanDeleteAction(ProjectAction action)
        {
            string prompt = String.Format("Delete task {0}?", action.Name);

            var messageDialog = new MessageDialog(prompt);

            UICommand yesCommand = new UICommand("Yes");
            messageDialog.Commands.Add(yesCommand);
            messageDialog.Commands.Add(new UICommand("No"));

            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            var result = await messageDialog.ShowAsync();

            return result == yesCommand;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
