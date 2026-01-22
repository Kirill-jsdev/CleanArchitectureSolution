namespace Infrastructure;

public class JsonPlaceholderService
{
    private readonly HttpClient _httpClient;

    public JsonPlaceholderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetData()
    {
        return await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts/1");
    }
}