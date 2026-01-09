using MusicalNoteTraining.MVVM.ViewModels;

namespace MusicalNoteTraining.MVVM.Views;

public partial class PlayView : ContentPage
{
	public PlayView(PlayViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}