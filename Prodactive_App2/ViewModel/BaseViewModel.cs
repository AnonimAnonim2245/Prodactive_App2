using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
namespace Prodactive_App2.ViewModel;

public partial class BaseViewModel: ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;
    [ObservableProperty]
    int value;
    public bool IsNotBusy => !isBusy;

}
/*
public class BaseViewModel : INotifyPropertyChanged
{
    bool isBusy;
    string title;

    public bool IsBusy
    {

        get => isBusy;
        set
        {
            if(isBusy == value) 
                return; 
            isBusy = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsNotBusy));
        }
    }

    public string Title
    {

        get => title;
        set
        {
            if (title == value) 
                return;
            title = value;
            OnPropertyChanged();
        }
    }
    public bool IsNotBusy => !isBusy;
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string name = null) =>
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


}
*/

