using Prodactive_App2.ViewModel;

namespace Prodactive_App2.View;

public partial class AddItem: ContentPage
{
   
    public AddItem(AddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}