using CommunityToolkit.Maui.Markup;
using GraphQL;
using GraphQL.Client.Abstractions;
using Maui5eClient.Models;

namespace Maui5eClient.Pages;

public class ClassPage : ContentPage
{
    private readonly IGraphQLClient _graphQlClient;
    
    public ClassPage(IGraphQLClient graphQlClient)
    {
        _graphQlClient = graphQlClient; 
        
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
                        Text = "Get Subclasses",
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
        
        var graphQlResponse = await _graphQlClient
            .SendQueryAsync<Data>(classRequest);
        return graphQlResponse.Data
            .Class.Subclasses
            .FirstOrDefault()
            .Description
            .FirstOrDefault() ?? "No description";
    }
}