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
        _labelCts?.Cancel();
        _labelCts = new CancellationTokenSource();
        var token = _labelCts.Token;


        try
        {
            InfoLabel.AbortAnimation(nameof(VisualElement.Opacity));


            InfoLabel.Opacity = 1;
            InfoLabel.IsVisible = true;

            await Task.Delay(TimeSpan.FromSeconds(2));

            await InfoLabel.FadeToAsync(0, 2000, Easing.CubicOut);

            if (!token.IsCancellationRequested)
            {
                InfoLabel.IsVisible = false;
            }
        }
        catch (TaskCanceledException)
        {
            // Annulation attendue : on repart de zéro
        }
    }
}