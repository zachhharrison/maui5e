using Maui5eClient.ViewModels;

namespace Maui5eClient.Pages;

public partial class ClassPage : ContentPage
{
    private readonly DataViewModel _dataViewModel;
    
    public ClassPage(DataViewModel dataViewModel)
    {
        InitializeComponent();
        BindingContext = dataViewModel;
        _dataViewModel = dataViewModel;
        var p = "potato";
    }
}