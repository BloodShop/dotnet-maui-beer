using System.Net.Http.Json;

namespace SheetaBeer.Services;

public class BeerService /*: IBeerService*/
{
    HttpClient _httpClient;

    List<Beer> _beerList = new();

    public BeerService()
    {
        _httpClient = new HttpClient();
    }


    public async Task<List<Beer>> GetBeersAsync()
    {
        if (_beerList?.Count > 0)
            return _beerList;

        //var url = "https://raw.githubusercontent.com/BloodShop/dotnet-maui-beer/main/Raw/beerdata.json";

        //var response = await _httpClient.GetAsync(url);

        //if (response != null)
        //    _beerList = await response.Content.ReadFromJsonAsync<List<Beer>>();

        using var stream = await FileSystem.OpenAppPackageFileAsync("beerdata.json");
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();
        _beerList = JsonSerializer.Deserialize<List<Beer>>(contents);

        return _beerList;
    }
}
