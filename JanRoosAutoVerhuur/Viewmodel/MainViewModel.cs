using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace JanRoosAutoVerhuur.Viewmodel
{
    public partial class MainViewModel : ObservableObject
    {

        public MainViewModel()
        {
            items = new ObservableCollection<string>();
        }


        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        string text;

        [RelayCommand]
        void Add() 
        {
        items.Add(Text);
            Text = "Hello World";
        }
    }
}
