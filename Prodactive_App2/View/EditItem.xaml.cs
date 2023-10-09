using Prodactive_App2.ViewModel;
namespace Prodactive_App2.View;

public partial class EditItem : ContentPage
{
 
    public EditItem(EditViewModel vm)
    {
        
        InitializeComponent();
        BindingContext = vm;
    }
   
}