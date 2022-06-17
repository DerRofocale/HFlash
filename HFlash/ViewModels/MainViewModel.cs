using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HFlash.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        #region Ink
        private bool _Ink;
        public bool Ink
        {
            get => _Ink;
            set
            {
                _Ink = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command GetUpdates
        private RelayCommand _getUpdates;
        public RelayCommand GetUpdates
        {
            get
            {
                return _getUpdates ??
                (_getUpdates = new RelayCommand(obj =>
                {
                    Task.Factory.StartNew(() =>
                    { });
                }));
            }
        }
        #endregion

        public MainViewModel()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    
                }
            });

            Task.Factory.StartNew(() =>
            {

                //while (true)
                //{
                //    try
                //    {
                //        using (HttpClient http = new HttpClient())
                //        {
                //            var a = http.GetAsync("https://pastebin.com/raw/192bCJ4t").Result.Content.ReadAsStringAsync().Result;
                //            if (a == Properties.Settings.Default.LastUpdate)
                //            {
                //                LatestVersion = "Установлена последняя версия - " + a; // 
                //                IsLastVersion = Visibility.Visible; // 
                //            }
                //            else
                //            {
                //                LatestVersion = "Устаревшая версия: " + Properties.Settings.Default.LastUpdate + "\nНовая версия: " + a; // 
                //                IsLastVersion = Visibility.Collapsed; // 
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //    }
                //    Task.Delay(1000).Wait();
                //}
            });
        }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
