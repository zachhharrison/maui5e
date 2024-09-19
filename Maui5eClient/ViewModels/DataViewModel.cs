using System.Collections.ObjectModel;
using System.ComponentModel;
using GraphQL;
using GraphQL.Client.Abstractions;
using Maui5eClient.Models;

namespace Maui5eClient.ViewModels;

public class DataViewModel :INotifyPropertyChanged
{
    private readonly IGraphQLClient _graphQlClient;
    public ObservableCollection<Class> Classes { get; set; }
    
    public DataViewModel(IGraphQLClient graphQlClient)
    {
        _graphQlClient = graphQlClient;
        Classes = new ObservableCollection<Class>();

        GetAllClassesAsync();
    }
    
    private async void GetAllClassesAsync()
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

        Classes.Clear();
        foreach (var c in graphQlResponse.Data.Classes)
        {
            Classes.Add(c);
        }
        OnPropertyChanged(nameof(Classes));    
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}