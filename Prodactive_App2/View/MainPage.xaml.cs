namespace Prodactive_App2.View;

using Microsoft.Maui.Controls;
using Prodactive_App2.ViewModel;
using System;
public partial class MainPage : ContentPage
{
	int count = 0;
  
    public MainPage(MainViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
        

    }
   

}


