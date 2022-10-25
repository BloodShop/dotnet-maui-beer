namespace SheetaBeer;


public partial class DetailsPage : ContentPage
{
	//public Beer Beer { get; set; }
	public DetailsPage(BeerDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args) => base.OnNavigatedTo(args);
}