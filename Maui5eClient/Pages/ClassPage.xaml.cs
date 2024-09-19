using System.Diagnostics;
using GraphQL;
using GraphQL.Client.Abstractions;
using Maui5eClient.Models;

namespace Maui5eClient.Pages;

public partial class ClassPage : ContentPage
{
    private readonly IGraphQLClient _graphQlClient;
    
    public ClassPage(IGraphQLClient graphQlClient)
    {
        InitializeComponent();
        _graphQlClient = graphQlClient; 
    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var classes = await GetAllClassesAsync();
        CollectionView.ItemsSource = classes;
    }

    private async Task<List<Class>> GetAllClassesAsync()
    {
        var classRequest = new GraphQLRequest {
            Query = """
                       query Classes {
                        classes(order: { by: NAME }) {
                            name
                            index
                            subclasses {
                                name 
                                desc
                            }
                        }
                    }
                    """
        };
        
        var graphQlResponse = await _graphQlClient
            .SendQueryAsync<Data>(classRequest);
        return graphQlResponse.Data.Classes;
    }
}