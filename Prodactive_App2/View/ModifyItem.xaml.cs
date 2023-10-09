namespace Prodactive_App2.View;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Prodactive_App2.Models;
using Prodactive_App2.Services;
using Prodactive_App2.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

public partial class ModifyItem : Popup, IQueryAttributable
{

    public bool Element5 { get; set; }
    private AddNewTab vm;
    //private readonly DbConnection _dbConnection;
    private AddNewTab _tabs;
    private AddNewTab tabs;
    public AddNewTab Tabs
    {
        get
        {
            return tabs;
        }
        set
        {
            tabs = value;
        }
    }
    private ObservableCollection<string> items;

    public ObservableCollection<string> Items
    {
        get
        {
            return items;
        }
        set
        {
            items = value;
        }
    }
    // public List<string> Items { get; set; }
    public ModifyItem(AddNewTab tab)
    {
        InitializeComponent();

        _tabs = tab;
        //myTodo.Text = _todo.Name;
        Tabs = new AddNewTab();
        Items = new ObservableCollection<string>();
        Console.WriteLine(tab.Minute + "???");
        BindingContext = new ModifyViewModel(tab);
        Element5 = false;

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Tabs = query["tab"] as AddNewTab;
        Tabs.Ok = 0;
    }
    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine(sender);

        Close();
    }
    bool IsDigitsOnly(string value)
    {
        Console.WriteLine(value + "FFF");
        foreach (char c in value)
        {
            if (c < '0' || c > '9')
                return false;

        }

        return true;

    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {

        /*OccasionModel occasion = new OccasionModel
        {
            Date = OccasionDate.Date,
            Occasion = OccasionType.SelectedItem.ToString(),
            Notes = OccasionNotes.Text
        };
        
        Close(occasion);*/
        bool element6 = IsDigitsOnly(_tabs.Minute);
        if (element6 == false)
        {
            Error.IsVisible = !Error.IsVisible;
        }
        if (_tabs != null && element6 == true)
        {
            Close((BindingContext as ModifyViewModel).ToSaveOnDB);

        }
        

        

    }

}