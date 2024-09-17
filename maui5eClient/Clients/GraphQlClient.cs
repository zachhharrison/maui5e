using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

namespace maui5eClient.Clients;

public class GraphQlClient
{
    private readonly GraphQLHttpClient _client;

    public GraphQlClient()
    {
        _client = new GraphQLHttpClient("https://api.github.com/graphql", new SystemTextJsonSerializer());
        _client.HttpClient.DefaultRequestHeaders.Add("Authorization", "Bearer YOUR_GITHUB_TOKEN");
    }

    public async Task<GraphQLResponse<dynamic>> FetchRepositoryAsync(string query)
    {
        var request = new GraphQLRequest
        {
            Query = query
        };

        try
        {
            var response = await _client.SendQueryAsync<dynamic>(request);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return null;
        }
    }
}