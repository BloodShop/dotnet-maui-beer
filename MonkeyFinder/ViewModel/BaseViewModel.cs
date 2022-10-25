namespace SheetaBeer.ViewModel;

//[NotifyPropertyChanged]
public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel()
    {

    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))] // --> changed from [AlsoNotifyChangeFor]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool IsNotBusy => !IsBusy;
    //{
    //    get => !IsBusy;
    //    set => base.OnPropertyChanged(nameof(IsNotBusy));
    //}
}
