using MusicalNoteTraining.Abstraction;
using MusicalNoteTraining.MVVM.ViewModels;
namespace MusicalNoteTraining.MVVM.Views;

public partial class TrainingView : ContentPage
{
    public TrainingView(TrainingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.ShowInfoRequested += async () =>
        {
            await ShowLabelAsync();
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is INeedInitilization viewModel)
        {
            viewModel.Initialize();
        }

    }

    private async Task ShowLabelAsync()
    {
        await InfoLabel.FadeToAsync(1, 150, Easing.CubicIn);
        await InfoLabel.FadeToAsync(0, 1300, Easing.CubicOut);
    }
}