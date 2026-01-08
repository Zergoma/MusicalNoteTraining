using Microsoft.Extensions.DependencyInjection;
using MusicalNoteTraining.MVVM.ViewModels;
using MusicalNoteTraining.MVVM.Views;

namespace MusicalNoteTraining
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new TrainingView(new TrainingViewModel()));
        }
    }
}