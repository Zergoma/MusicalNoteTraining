using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicalNoteTraining.MVVM.Models;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MusicalNoteTraining.MVVM.ViewModels
{
    public partial class PlayViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<MusicalNote> allNotes;

        public PlayViewModel()
        {
            allNotes = new()
            {
                new ()
                {
                    MyNote = Notes.do1,
                    path = "Do1.wav",
                    color = "#CE313A",
                },
                new ()
                {
                    MyNote = Notes.re,
                    path = "Re.wav",
                    color = "#F18B4D",
                },
                new ()
                {
                    MyNote = Notes.mi,
                    path = "Mi.wav",
                    color = "#DBC21D",
                },
                new ()
                {
                    MyNote = Notes.fa,
                    path = "Fa.wav",
                    color = "#0C8F4D",
                },
                new ()
                {
                    MyNote = Notes.sol,
                    path = "Sol.wav",
                    color = "#2497C3",
                },
                new ()
                {
                    MyNote = Notes.la,
                    path = "La.wav",
                    color = "#33659A",
                },
                new ()
                {
                    MyNote = Notes.si,
                    path = "Si.wav",
                    color = "#725C9A",
                },
                new ()
                {
                    MyNote = Notes.do2,
                    path = "Do2.wav",
                    color = "#DF707C",
                },
            };
        }

        [RelayCommand]
        public async Task Play(MusicalNote sender)
        {
            var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sender.path));
            audioPlayer?.Play();
        }
    }
}
