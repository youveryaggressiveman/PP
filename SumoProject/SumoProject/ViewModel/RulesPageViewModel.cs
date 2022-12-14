using SumoProject.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SumoProject.ViewModel
{
    public class RulesPageViewModel : BaseViewModel
    {
        private readonly FileManager _fileManager;

        private ObservableCollection<string> _ruleList;

        private string _selectedRule;
        private BitmapImage _image;
        private string _name;
        private string _text;

        public ObservableCollection<string> RuleList
        {
            get => _ruleList;
            set
            {
                _ruleList = value;
                OnPropertyChanged(nameof(RuleList));
            }
        }

        public string SelectedRule
        {
            get => _selectedRule;
            set
            {
                _selectedRule = value;
                OnPropertyChanged(nameof(SelectedRule));

                LoadInfo();
            }
        }

        public BitmapImage Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public RulesPageViewModel()
        {
            _fileManager = new FileManager();

            RuleList = new ObservableCollection<string>()
            {
                "Основные правила",
                "Форма участника",
                "Состав судейской коллегии",
                "Инвентарь соревнований"
            };
        }

        private async void LoadInfo()
        {
            var image = _fileManager.FindUri(SelectedRule);

            if(image == null)
            {
                return;
            }

            Name = SelectedRule;
            Image = new BitmapImage(image);
            Text = await _fileManager.ReadFile(SelectedRule);
        }
    }
}
