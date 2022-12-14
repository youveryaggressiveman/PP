using SumoProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumoProject.ViewModel
{
    public class HistoryPageViewModel : BaseViewModel
    {
        private readonly FileManager _fileManager;

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public HistoryPageViewModel()
        {
            _fileManager = new FileManager();
            LoadInfo();
        }

        private async void LoadInfo()
        {
            Text = await _fileManager.ReadFile("History");
        }
    }
}
