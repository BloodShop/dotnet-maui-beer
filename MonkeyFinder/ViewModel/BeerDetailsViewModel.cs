namespace SheetaBeer.ViewModel;

[QueryProperty("Beer", "Beer")]
public partial class BeerDetailsViewModel : BaseViewModel
{

    public BeerDetailsViewModel()
    {
    }

    [ObservableProperty]
    Beer _beer;

    //[RelayCommand]
    //async Task GoBackAsync()
    //{
    //    await Shell.Current.GoToAsync("../DetailsPage");
    //}
}
