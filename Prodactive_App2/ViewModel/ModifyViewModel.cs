using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prodactive_App2.Models;
using Prodactive_App2.Services;
using Prodactive_App2.View;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Maui.Alerts;

using Prodactive_App2.Messages;
using CommunityToolkit.Maui.Core;

namespace Prodactive_App2.ViewModel
{
    [QueryProperty("Text", "Text")]
    public partial class ModifyViewModel : BaseViewModel
    {
        [ObservableProperty]
        List<AddNewTab> toDolist;

        [ObservableProperty]
        AddNewTab todo;

        [ObservableProperty]
        AddNewTab toSaveOnDB;

        private readonly Services.DbConnection _dbConnection;

        /* public AddViewModel(Services.DbConnection dbConnection)
         {
             _dbConnection = dbConnection;
             toDolist = new List<ToDoModel>();
             toSaveOnDB = new ToDoModel();
             GetInitalDataCommand.Execute(null);
         }*/
        public ModifyViewModel(AddNewTab todo)
        {
            ToSaveOnDB = todo;
            Value = todo.Id;
        }

        [RelayCommand]
        private async void GetInitalData()
        {
            ToDolist = await _dbConnection.GetItemsAsync();
        }
        [ObservableProperty]
        ObservableCollection<string> items;
        [ObservableProperty]
        string text;

        [RelayCommand]

        private async void GoToBasicNavigation()
        {
            await Shell.Current.GoToAsync(nameof(ModifyItem));
        }

        bool IsDigitsOnly(string value)
        {
            foreach (char c in value)
            {
                if (c < '0' || c > '9')
                    return false;

            }

            return true;

        }
        
        [RelayCommand]
        private async Task SaveOnDb()
        {
            await _dbConnection.SaveItemAsync(ToSaveOnDB);
            if (ToSaveOnDB.Minute != null && IsDigitsOnly(ToSaveOnDB.Minute)==true)
            {

                ToDolist = await _dbConnection.GetItemsAsync();
                await Shell.Current.GoToAsync("..");
            }
            if (IsDigitsOnly(ToSaveOnDB.Minute) == true)
            {
                var snackbar = Toast.Make("Only numbers allowed", ToastDuration.Short);
                await snackbar.Show();
            }
        }

        [RelayCommand]
        private async void MoveToANewTab1()
        {
            await Shell.Current.GoToAsync(nameof(ModifyItem));
        }

        [RelayCommand]
        async Task Back()
        {
            await Shell.Current.GoToAsync("..");

        }
    }
}
