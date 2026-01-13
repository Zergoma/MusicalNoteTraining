using Microsoft.Extensions.Logging;
using MusicalNoteTraining.MVVM.ViewModels;
using MusicalNoteTraining.MVVM.Views;
using MusicalNoteTraining.Services;
using Plugin.Maui.Audio;

namespace MusicalNoteTraining
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<TrainingViewModel>();
            builder.Services.AddTransient<TrainingView>();

            builder.Services.AddTransient<PlayView>();
            builder.Services.AddTransient<PlayViewModel>();


            builder.Services.AddTransient<IMusicalNotesProducer, MetallophoneNoteProducer>();

            builder.AddAudio();

            return builder.Build();
        }
    }
}
