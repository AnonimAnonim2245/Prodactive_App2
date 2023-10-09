using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prodactive_App2.Helpers;
using Prodactive_App2.Models;
using Prodactive_App2.Services;
using Prodactive_App2.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Prodactive_App2.ViewModel
{
    //[QueryProperty("Text", "Text")]

    public partial class EditViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        List<AddNewTab> tablist;

        [ObservableProperty]
        ObservableCollection<AddNewTab> element3;


        [ObservableProperty]
        ObservableCollection<string> options;

        [ObservableProperty]
        ObservableCollection<string> options2;

        [ObservableProperty]
        ObservableCollection<string> times;

        [ObservableProperty]
        AddNewTab tab;

        [ObservableProperty]
        string selectedoptions;

        [ObservableProperty]
        AddNewTab toSaveOnDB;

        [ObservableProperty]
        string text;
        public ObservableCollection<TitleValue> Items { get; set; } = new ObservableCollection<TitleValue>();



        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        int index;

        [ObservableProperty]
        ObservableCollection<int> index2;

        [ObservableProperty]
        private TitleValue _currentItem;


        [ObservableProperty]
        private bool _isDisplayPicker;
        private int initialSelectedIndex;

        [ObservableProperty]
        private TitleValue _currentItem1;

        [ObservableProperty]
        private bool _isLoading1;


        [ObservableProperty]
        private bool _isDisplayPicker1;

        private readonly DbConnection _dbConnection;


        public EditViewModel(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            tablist = new List<AddNewTab>();
            toSaveOnDB = new AddNewTab();
            //toDeleteOnDB = new ToDoModel();
            tab = new AddNewTab();            
            GetInitalDataCommand.Execute(null);
   
        }

        [RelayCommand]
        private async void GetInitalData()
        {
            Tablist = await _dbConnection.GetItemsAsync();
        }



        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Tab = query["tab"] as AddNewTab;
            Tab.Ok = 0;
            Timp();
            Console.WriteLine(Element3[0].Minute);
        }
        

       
      
       

        void Timp()
        {

            if (Tab.Name == "Learn with pomodoro")
            {



                // Preselect an option
                Options = new ObservableCollection<string>();

                for (int i = 1; i <= 60; i++)
                {
                    Options.Add(i.ToString());
                }



                Options2 = new ObservableCollection<string>
                {
                    "25 min","5 min"
                };
                Selectedoptions = Options[24];

                Element3 = new ObservableCollection<AddNewTab>
                {
                new AddNewTab
                {
                    Minute=Options[24],
                    Name = "Focus",


                }, new AddNewTab
                {
                    Minute=Options[4],
                    Name="Relax"

                }
                , new AddNewTab
                {
                    Minute=Options[24],
                    Name = "Focus"


                }, new AddNewTab
                {
                  Minute=Options[4],
                    Name = "Relax"

                }
                ,new AddNewTab
                {
                    Minute=Options[24],
                    Name = "Focus"

                }, new AddNewTab
                {
                    Minute=Options[4],

                    Name="Relax"
                }
                , new AddNewTab
                {
                    Minute=Options[24],

                    Name = "Focus"
                }
            };

                Console.WriteLine(Element3[0].Minute + "!!!");


            }


        }
        [RelayCommand]
        private async void GoToModifyItem(AddNewTab item)
        {
            var index = Element3.IndexOf(item);
            Console.WriteLine(index + "!!");
            var navigationParameter = new Dictionary<string, object>
                {
            { "tab", Element3[index] }
                };
            //ToSaveOnDB.Name = null;
            var popup = new ModifyItem(Element3[index]);

            var element = await Shell.Current.ShowPopupAsync(popup);
            if (element is AddNewTab res2)
            {
                if (res2 == null)
                    return;
                Console.WriteLine(res2.Minute+"$##");
                Console.WriteLine(index+"!!!2");
                Element3[index]= res2;

                Tablist[index] = res2;

                ToSaveOnDB = res2;
                

            }
            Console.WriteLine(Element3[0].Minute);

        }

        [RelayCommand]
        private async void SaveOnDb()
        {

            if (Tab.Name == null)
                return;
            await _dbConnection.SaveItemAsync(Tab);
            Tab.Ok = 1;

            Console.WriteLine("##!#!" + Tab.Color_name + Tab.Name + Tab.Ok);
            BackCommand.Execute(null);


        }
        [RelayCommand]

        private async Task Back()
        {
            //var query = new Dictionary<string, object>();
            if (Tab.Ok == 1)
            {
                Tab.Ok = -5;
                Console.WriteLine("3");
                var parameters = new Dictionary<string, object>()
                {             
                 {"NameUser",Tab }
                    //{"NameUser2",Todo.Id}
                };
                await Shell.Current.GoToAsync("../../../..", parameters);

             }
            else
            {
                var parameters = new Dictionary<string, object>()
                {
                     {"NameUser",null }
                     //{"NameUser2",Todo.Id}
                };
                await Shell.Current.GoToAsync("..", parameters);


            }





        }

      

    }


}