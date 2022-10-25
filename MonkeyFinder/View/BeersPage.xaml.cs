namespace SheetaBeer.View;

public partial class BeersPage : ContentPage
{
    public BeersPage(BeersViewModel ViewModel)
    {
        InitializeComponent();
        BindingContext = ViewModel;
    }
}