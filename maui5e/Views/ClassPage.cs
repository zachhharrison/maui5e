using CommunityToolkit.Maui.Markup;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using maui5e.Models;

namespace maui5e.Views;

public class ClassPage : ContentPage
{
    public ClassPage()
    {
        var scrollView = new ScrollView();
        var verticalStackLayout = new VerticalStackLayout
        {
            Spacing = 25,
            Children =
            {
                new Label
                    {
                        Text = "Class Page!"
                    }
                    .Font(size: 32)
                    .CenterHorizontal(),
                
                new Label
                    {
                        Text = "", 
                    }
                    .Font(size: 18)
                    .CenterHorizontal()
                    .Assign(out Label dataLabel),
                
                new Button
                    {
                        Text = "Get Metadata",
                    }
                    .Font(bold:true)
                    .CenterHorizontal()
                    .Invoke(b => b.Clicked += async (_, _) =>
                    {
                        dataLabel.Text = await GetClassFromGraphQl("wizard");
                    })
            }
        };

        scrollView.Content = verticalStackLayout;
        Content = scrollView;
    }

    private async Task<string> GetClassFromGraphQl(string className)
    {
        const string uri = "https://www.dnd5eapi.co/graphql";
        using var graphQlClient = new GraphQLHttpClient(uri, new SystemTextJsonSerializer());
        
        var classRequest = new GraphQLRequest {
            Query = """
                    query Class($index: String){
                      class(index: $index) {
                        subclasses {
                          name
                          desc
                        }
                        name
                      }
                    }
                    """,
            OperationName = "Class",
            Variables = new { index = className },
        };
        
        var graphQlResponse = await graphQlClient
            .SendQueryAsync<Data>(classRequest);
        return graphQlResponse.Data
            .Class.Subclasses
            .FirstOrDefault()
            .Description
            .FirstOrDefault() ?? "No description";
    }
}