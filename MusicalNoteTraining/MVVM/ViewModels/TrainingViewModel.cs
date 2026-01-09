using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicalNoteTraining.Extensions;
using MusicalNoteTraining.MVVM.Models;
using Plugin.Maui.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace MusicalNoteTraining.MVVM.ViewModels
{
    public partial class TrainingViewModel : ObservableObject
    {
        public event Action? ShowInfoRequested;

        [ObservableProperty]
        public MusicalNote currentNote;

        [ObservableProperty]
        public ObservableCollection<MusicalNote> responsesNotes = [];

        [ObservableProperty]
        public string message = string.Empty;

        [ObservableProperty]
        public int errorCounter;

        [ObservableProperty]
        public int successCounter;


        [ObservableProperty]
        public string messageColor = "Black";

        List<MusicalNote> allNotes;

        Random rdn;

        public TrainingViewModel()
        {
            allNotes = new()
            {
                new()
                {
                    MyNote = Notes.do1,
                    path = "Do1.wav",
                    color = "#CE313A",
                },
                new()
                {
                    MyNote = Notes.re,
                    path = "Re.wav",
                    color = "#F18B4D",
                },
                new()
                {
                    MyNote = Notes.mi,
                    path = "Mi.wav",
                    color = "#DBC21D",
                },
                new()
                {
                    MyNote = Notes.fa,
                    path = "Fa.wav",
                    color = "#0C8F4D",
                },
                new()
                {
                    MyNote = Notes.sol,
                    path = "Sol.wav",
                    color = "#2497C3",
                },
                new()
                {
                    MyNote = Notes.la,
                    path = "La.wav",
                    color = "#33659A",
                },
                new()
                {
                    MyNote = Notes.si,
                    path = "Si.wav",
                    color = "#725C9A",
                },
                new()
                {
                    MyNote = Notes.do2,
                    path = "Do2.wav",
                    color = "#DF707C",
                },
            };

            rdn = Random.Shared;

            CurrentNote = allNotes[rdn.Next(allNotes.Count)];
            Randomize();
        }

        [RelayCommand]
        public async Task Rando()
        {
            Randomize();
        }

        [RelayCommand]
        public async Task PlaySound()
        {
            var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(CurrentNote.path));
            audioPlayer?.Play();
        }

        [RelayCommand]
        public async Task Check(MusicalNote sender)
        {
            ShowInfoRequested?.Invoke();
            if (sender.MyNote == CurrentNote.MyNote)
            {
                Randomize();
                Message = "Good !";
                MessageColor = "Green";
                SuccessCounter++;
            }
            else
            {
                Message = $"No";
                MessageColor = "Red";
                ErrorCounter++;
            }

            var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sender.path));
            audioPlayer?.Play();
        }

        private void Randomize()
        {
            var oldNote = CurrentNote;

            var filtredNotes = allNotes
            .Where(n => n != oldNote)
            .ToList();

            CurrentNote = filtredNotes[rdn.Next(filtredNotes.Count)];

            filtredNotes.ShuffleIt();
            var otherResponses = filtredNotes
                .Where(n => n != CurrentNote)
                .Take(3)
                .ToList();
            otherResponses.Add(CurrentNote);

            otherResponses.ShuffleIt();

            ResponsesNotes.Clear();
            otherResponses.ForEach(ResponsesNotes.Add);
        }
    }
}
