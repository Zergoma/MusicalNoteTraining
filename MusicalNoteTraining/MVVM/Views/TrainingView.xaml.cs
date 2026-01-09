using MusicalNoteTraining.MVVM.ViewModels;
namespace MusicalNoteTraining.MVVM.Views;

public partial class TrainingView : ContentPage
{
    private CancellationTokenSource? _labelCts;

    public TrainingView(TrainingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.ShowInfoRequested += async () =>
        {
            await ShowLabelAsync();
        };
    }

    private async Task ShowLabelAsync()
    {
        await InfoLabel.FadeToAsync(1, 150, Easing.CubicIn);
        await InfoLabel.FadeToAsync(0, 1300, Easing.CubicOut);
    }
}