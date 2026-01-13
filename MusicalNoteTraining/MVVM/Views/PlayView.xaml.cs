using MusicalNoteTraining.Abstraction;
using MusicalNoteTraining.MVVM.ViewModels;

namespace MusicalNoteTraining.MVVM.Views;

public partial class PlayView : ContentPage
{
	public PlayView(PlayViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		if(BindingContext is INeedInitilization vm)
		{
			vm.Initialize();
		}
    }
}