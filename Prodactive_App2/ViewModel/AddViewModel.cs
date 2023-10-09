using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prodactive_App2;
using Prodactive_App2.Models;
using Prodactive_App2.Services;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using Prodactive_App2.View;
using Prodactive_App2.Helpers;

namespace Prodactive_App2.ViewModel
{
    public partial class AddViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        ObservableCollection<DateItem> dates;

        [ObservableProperty]
        ObservableCollection<AddNewTab> tablist;

        [ObservableProperty]
        ObservableCollection<AddNewTab> element2;


        [ObservableProperty]
        AddNewTab toSaveOnDB;
        [ObservableProperty]
        AddNewTab tab;

        private readonly Services.DbConnection _dbConnection;
        private readonly ObservableCollection<AddNewTab> options;
        public AddViewModel(Services.DbConnection dbConnection)
        {
            // Initialize the ObservableCollection with date items (you can customize this)
            _dbConnection = dbConnection;
            tablist = new ObservableCollection<AddNewTab>();
            toSaveOnDB = new AddNewTab();
            //tab = new AddNewTab();

            GetInitalDataCommand.Execute(null);
            Function_element();

        }
        [RelayCommand]
        private async void GetInitalData()
        {
            var tabListBase = await _dbConnection.GetItemsAsync();
            Tablist = new ObservableCollection<AddNewTab>(tabListBase);
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tab = query["tab"] as AddNewTab;
            Tab.Ok = 0;
        }
        void Function_element()
        {
            Element2 = new ObservableCollection<AddNewTab>
            {
                new AddNewTab
                {
                    Name = "Learn with pomodoro",
                    Description = "A well proven technique which helps you getting stuff done",
                    Color_name = "#80FF0000",
                    Icon = IconFont.tomato
                }, new AddNewTab
                {
                    Name = "Meditate",
                    Description = "It improves your concentration and makes you more relaxed",
                    Color_name = "#801d1c17",
                    Icon = IconFont.ying_yang
                }
                , new AddNewTab
                {
                    Name = "Lecture",
                    Description = "Immerse yourself into a new world",
                    Color_name = "#80FFAE42",
                    Icon = IconFont.book
                }, new AddNewTab
                {
                    Name = "Nature",
                    Description = "Going outside whenether it is morning, afternoon or night, helps you with bringing you more energy.",
                    Color_name = "#704214",
                    Icon = IconFont.mountain
                }
            };


        }

        [RelayCommand]
        private async void GoToMoreInfo(AddNewTab tab)
        {
            tab.Id = -5;
            var navigationParameter = new Dictionary<string, object>
                {
            { "tab", tab }
                };

            //Console.WriteLine("###" + tab.Name);
            //Console.WriteLine("12###" + navigationParameter);


            await Shell.Current.GoToAsync($"{nameof(EditItem)}", navigationParameter);
            // ToSaveOnDB.Name = null;
        }
        [RelayCommand]

        private async Task Back2()
        {
            //var query = new Dictionary<string, object>();
            Tab.Id = 4;
            var navigationParameter = new Dictionary<string, object>
             {
                    { "tab", tab }
             };
            await Shell.Current.GoToAsync("../../../../../../..",navigationParameter);


        }
    }
}
