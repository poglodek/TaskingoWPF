﻿using System.ComponentModel;
using System.Windows.Input;
using TaskingoApp.Commands;
using TaskingoApp.View;

namespace TaskingoApp.ViewModel.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected object view;

        public object View
        {
            get => view;
            set
            {
                view = value;
                OnPropertyChanged(nameof(view));
            }
        }

        protected void OnPropertyChanged(params string[] nameProperty)
        {
            foreach (var property in nameProperty)
                if (property != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));


        }
        private ICommand setView;

        public ICommand SetView
        {
            get
            {
                if (setView == null)
                    setView = new RelayCommand(x =>
                    {
                        ChangeView(x as string);
                    });
                return setView;
            }
        }

        public void ChangeView(string viewName)
        {
            TaskingoApp.Properties.Settings.Default.ActualView = viewName;
            View = new ContentView();
        }
    }
}
