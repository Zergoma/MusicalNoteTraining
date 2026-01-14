using Microsoft.Extensions.DependencyInjection;
using MusicalNoteTraining.MVVM.ViewModels;
using MusicalNoteTraining.MVVM.Views;

namespace MusicalNoteTraining
{
    public partial class App : Application
    {
        private readonly IServiceProvider services;

        public App(IServiceProvider services)
        {
            InitializeComponent();
            this.services = services;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(services.GetRequiredService<AppShell>());
        }
    }
}