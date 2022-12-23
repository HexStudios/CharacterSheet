using CharacterSheet.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterSheet.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand ExitButton { get; set; }

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand StatsViewCommand { get; set; }
        


        public HomeViewModel HomeVM { get; set; }
        public StatsViewModel StatsVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            StatsVM = new StatsViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            StatsViewCommand = new RelayCommand(o =>
            {
                CurrentView = StatsVM;
            });
            ExitButton = new RelayCommand(o =>
            {
                App.Current.Shutdown();
            });

        }
    }
}
