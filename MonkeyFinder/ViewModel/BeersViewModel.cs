using SheetaBeer.Services;

namespace SheetaBeer.ViewModel;

public partial class BeersViewModel : BaseViewModel
{
    private readonly BeerService _beerService;
    public ObservableCollection<Beer> Beers { get; } = new();

    IConnectivity _connectivity;
    IGeolocation _geolocation;
    IMap _map;

    //public Command GetBeersCommand { get; }

    [ObservableProperty]
    bool isRefreshing;

    public BeersViewModel(BeerService beerService,
        IConnectivity connectivity,
        IGeolocation geolocation,
        IMap map)
    {
        Title = "Sheeta Beer";
        this._beerService = beerService;
        this._connectivity = connectivity;
        this._geolocation = geolocation;
        this._map = map;
    }

    [RelayCommand]
    async Task OpenMapAsync()
    {
        try
        {
            await _map.OpenAsync(BeerGarden.Location,
                new MapLaunchOptions
                {
                    Name = nameof(BeerGarden),
                    NavigationMode = NavigationMode.None
                });
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Internet Issue!",
                    $"Unable to open map: {ex.Message}", "OK");
            return;
        }
    }

    [RelayCommand]
    async Task GoToDetailsAsync(Beer beer)
    {
        if (beer == null) return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                { "Beer", beer }
            });
    }

    [RelayCommand]
    private async Task LoadBeersAsync()
    {
        if (IsBusy) return;

        try
        {
            if (_connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Shell.Current.DisplayAlert("Internet Issue!",
                    "Check your Internet and try again!", "OK");
                return;
            }

            IsBusy = true;
            var beers = await _beerService.GetBeersAsync();

            if (Beers?.Count != 0)
                Beers.Clear();

            foreach (var beer in beers)
                Beers.Add(beer);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get beer collection: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }
}