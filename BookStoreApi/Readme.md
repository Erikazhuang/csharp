Web API with mongodb backend

https://localhost:7216/API/Books


https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-6.0&tabs=visual-studio-code


Redefine tag names in Json response:

property names in the web API's serialized JSON response match their corresponding property names in the CLR object type. For example, the Book class's Author property serializes as Author instead of author.
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);



In Models/Book.cs, annotate the BookName property with the [JsonPropertyName] attribute. The [JsonPropertyName] attribute's value of Name represents the property name in the web API's serialized JSON response.

[BsonElement("Name")]
[JsonPropertyName("Name")]
public string BookName { get; set; } = null!;


deploy to Azure
https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vscode?view=aspnetcore-6.0