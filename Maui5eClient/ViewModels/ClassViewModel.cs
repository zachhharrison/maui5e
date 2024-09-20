using System.Collections.ObjectModel;
using System.ComponentModel;
using GraphQL;
using GraphQL.Client.Abstractions;
using Maui5eClient.Models;

namespace Maui5eClient.ViewModels;

public class ClassViewModel : INotifyPropertyChanged
{
    private readonly IGraphQLClient _graphQlClient;

    // ObservableCollection to bind to the CollectionView in the XAML
    public ObservableCollection<Class> Classes
    {
        get => _classes;
        set
        {
            if (Equals(value, _classes)) return;
            _classes = value;
            OnPropertyChanged(nameof(Classes));
        }
    }

    private bool _isLoading;
    private ObservableCollection<Class> _classes = [];

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
        }
    }

    public ClassViewModel(IGraphQLClient graphQlClient)
    {
        _graphQlClient = graphQlClient;
        _ = LoadClassesAsync();
    }

    public async Task LoadClassesAsync()
    {
        IsLoading = true;

        var classRequest = new GraphQLRequest
        {
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

        var graphQlResponse = await _graphQlClient.SendQueryAsync<Data>(classRequest);

        // Clear the existing collection and add the new data
        Classes.Clear();
        foreach (var dndClass in graphQlResponse.Data.Classes)
        {
            Classes.Add(dndClass);
        }

        IsLoading = false;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
