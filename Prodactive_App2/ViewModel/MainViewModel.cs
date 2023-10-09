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
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Views;
using Prodactive_App2.View;

namespace Prodactive_App2.ViewModel
{
    public partial class MainViewModel : BaseViewModel, IQueryAttributable, INotifyPropertyChanged
    {
        [ObservableProperty]
        ObservableCollection<DateItem> dates;

        [ObservableProperty]
        ObservableCollection<AddNewTab> tablist;

        [ObservableProperty]
        AddNewTab toSaveOnDB;
        [ObservableProperty]
        AddNewTab tab;

        [ObservableProperty]
        bool isBorderVisible;
        [ObservableProperty]
        bool isTextVisible;

        private readonly Services.DbConnection _dbConnection;
        private readonly ObservableCollection<AddNewTab> options;
        public MainViewModel(Services.DbConnection dbConnection)
        {
            // Initialize the ObservableCollection with date items (you can customize this)
            _dbConnection = dbConnection;
            tablist = new ObservableCollection<AddNewTab>();
            toSaveOnDB = new AddNewTab();
            tab = new AddNewTab();
            Dates = new ObservableCollection<DateItem>();
            
            DateTime today = DateTime.Today;

            for (int i = 0; i < 14; i++)
            {
                DateTime date = today.AddDays(i);
                string dayOfWeek = date.ToString("dddd");

                if (dayOfWeek.Equals("Sunday"))
                    dayOfWeek = "SU";
                if (dayOfWeek.Equals("Monday"))
                    dayOfWeek = "MO";
                if (dayOfWeek.Equals("Tuesday"))
                    dayOfWeek = "TU";
                if (dayOfWeek.Equals("Wednesday"))
                    dayOfWeek = "WE";
                if (dayOfWeek.Equals("Thursday"))
                    dayOfWeek = "TH";
                if (dayOfWeek.Equals("Friday"))
                    dayOfWeek = "FR";
                if (dayOfWeek.Equals("Saturday"))
                    dayOfWeek = "SA";

                Dates.Add(new DateItem { DayOfWeek = dayOfWeek, Date = date });

            }
            GetInitalDataCommand.Execute(null);

        }
        [RelayCommand]
        private async void GetInitalData()
        {
            var tabListBase = await _dbConnection.GetItemsAsync();
            Tablist = new ObservableCollection<AddNewTab>(tabListBase);
            if (Tablist.Count < 8)
            {
                IsBorderVisible = true;
                IsTextVisible = false;

                Console.Write("~~");
            }
            else
            {
                IsBorderVisible = false;
                IsTextVisible = true;

            }
            Tablist.CollectionChanged += (sender, e) =>
            {
                if (Tablist.Count < 8)
                {
                    IsBorderVisible = true;
                    IsTextVisible = false;

                    Console.Write("~~");
                }
                else
                {
                    IsBorderVisible = false;
                    IsTextVisible = true;

                }
                Console.WriteLine("no" + isBorderVisible);
            };
        }
      
        [RelayCommand]

        private async void GoToAddItem()
        {
            
            
                Tab.Id = -5;
                var navigationParameter = new Dictionary<string, object>
                {
                { "tab", Tab }
                };
                await Shell.Current.GoToAsync($"{nameof(AddItem)}", navigationParameter);
                //ToSaveOnDB.Name = null;
            

        }
        [RelayCommand]
        private async void SaveOnDb()
        {
            if (ToSaveOnDB.Name == null)
                return;
            Tablist.Add(ToSaveOnDB);
        }
            [RelayCommand]
        public async Task DeleteOnDb(AddNewTab tab)
        {
            Tablist.Remove(tab);
            await _dbConnection.DeleteItemAsync(tab);
        }
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Console.WriteLine("before query "+ Tab.Id);
            Console.WriteLine(query.ContainsKey("NameUser"));

            if (query.ContainsKey("IdUser") && Tab.Id == -3)
            {
                Console.WriteLine(Tab.Ok);
                var id = (int)query["IdUser"];
                var todoItem = Tablist.Where(x => x.Id == id).FirstOrDefault();
                Tablist.Remove(todoItem);
                Console.WriteLine("1");
                //el=Preferences.Default.Get("huh", 2);
                Console.WriteLine("Before " + query);
                //query = null;
                query = new Dictionary<string, object>();
                Console.WriteLine("After " + query);

            }
            if (query.ContainsKey("NameUser") && Tab.Id == -5)
            {

                Console.WriteLine(Tab.Ok + "!!");

                var element = (AddNewTab)query["NameUser"];
                Console.WriteLine(ToSaveOnDB.Name);

                if (element == null)
                    return;
                ToSaveOnDB = element;

                Console.WriteLine("2");
                Console.WriteLine("Before " + query);

                //SaveOnDbCommand.Execute(null);
                Tablist.Add(element);
                //query = null;
                query = new Dictionary<string, object>();
                Console.WriteLine("After " + query);
                Console.WriteLine(ToSaveOnDB.Name);

                //await _dbConnection.SaveItemAsync(element);

                //ToDolist.Add(element);
            }



        }
        /*  [RelayCommand]

          private async void GoToAddItem()
          {
              var navigationParameter = new Dictionary<string, object>
              {
              { "Tab", tab }
              };
              var popup = new AddItems();

              var element = await Shell.Current.ShowPopupAsync(popup);
              if (element is AddNewTab res2)
              {
                  if (res2 == null)
                      return;
                  ToSaveOnDB = res2;

                  Console.WriteLine("2");
                  //Console.WriteLine("Before " + query);

                  //SaveOnDbCommand.Execute(null);
                  Tablist.Add(res2);
                  await _dbConnection.SaveItemAsync(ToSaveOnDB);
                  //query = null;
                  //query = new Dictionary<string, object>();
                  //Console.WriteLine("After " + query);
                  Console.WriteLine("?dmf?");

              }

              //await Shell.Current.GoToAsync($"{nameof(AddItem)}", navigationParameter);
          }*/

    }
}
