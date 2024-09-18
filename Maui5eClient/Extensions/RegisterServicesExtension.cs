using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Maui5eClient.Pages;

namespace Maui5eClient.Extensions;

public static class RegisterServicesExtension
{
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        // Add your services here...
        // Default method
        //builder.Services.Add();
        // Scoped objects are the same within a request, but different across different requests.
        //builder.Services.AddScoped();     
        // Singleton objects are created as a single instance throughout the application. It creates the instance for the first time and reuses the same object in the all calls.
        builder.Services.AddHttpClient("GraphQLClient", client =>
            {
                client.BaseAddress = new Uri("https://www.dnd5eapi.co/graphql");
            })
            .AddTypedClient<IGraphQLClient>(httpClient => 
                new GraphQLHttpClient(httpClient.BaseAddress, new SystemTextJsonSerializer()));

        builder.Services.AddSingleton<ClassPage>();
        // Transient objects lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services.
        //builder.Services.AddTransient();  
        return builder;
    }
}