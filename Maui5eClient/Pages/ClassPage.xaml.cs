using GraphQL;
using GraphQL.Client.Abstractions;
using Maui5eClient.Models;
using Maui5eClient.ViewModels;

namespace Maui5eClient.Pages;

public partial class ClassPage : ContentPage
{
    private readonly ClassViewModel _viewModel;

    public ClassPage(IGraphQLClient graphQlClient)
    {
        InitializeComponent();

        // Initialize the ViewModel and set it as the BindingContext
        _viewModel = new ClassViewModel(graphQlClient);
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Optionally load data here if needed
        _viewModel.LoadClassesAsync();
    }
}