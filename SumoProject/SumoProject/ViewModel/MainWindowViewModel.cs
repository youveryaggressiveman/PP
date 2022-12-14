using SumoProject.Command;
using SumoProject.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SumoProject.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand History { get; }
        public ICommand Rules { get; }
        public ICommand AboutProgram { get; }

        public MainWindowViewModel()
        {
            History = new DelegateCommand(HistoryCommand);
            Rules = new DelegateCommand(RulesCommand);
            AboutProgram = new DelegateCommand(AboutProgramCommand);
        }

        private void AboutProgramCommand(object obj)
        {
            FrameManager.SetSource(new AboutProgramPage());
        }

        private void RulesCommand(object obj)
        {
            FrameManager.SetSource(new RulesPage());
        }

        private void HistoryCommand(object obj)
        {
            FrameManager.SetSource(new HistoryPage());
        }
    }
}
