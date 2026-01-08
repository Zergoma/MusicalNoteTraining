using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicalNoteTraining.Extentions;
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
                    path = "Do1.wav"
                },
                new()
                {
                    MyNote = Notes.re,
                    path = "Re.wav"
                },
                new()
                {
                    MyNote = Notes.mi,
                    path = "Mi.wav"
                },
                new()
                {
                    MyNote = Notes.fa,
                    path = "Fa.wav"
                },
                new()
                {
                    MyNote = Notes.sol,
                    path = "Sol.wav"
                },
                new()
                {
                    MyNote = Notes.la,
                    path = "La.wav"
                },
                new()
                {
                    MyNote = Notes.si,
                    path = "Si.wav"
                },
                new()
                {
                    MyNote = Notes.si,
                    path = "Si.wav"
                },
            };

            rdn = Random.Shared;

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
            }
            else
            {
                Message = $"No";
                MessageColor = "Red";
                var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sender.path));
                audioPlayer?.Play();
            }
        }

        private void Randomize()
        {

            var indexes = Enumerable.Range(0, allNotes.Count).ToArray();
            rdn.Shuffle(indexes);
            
            var _4first = indexes.Take(4);

            ResponsesNotes.Clear();
            
            foreach (var i in _4first)
            {
                ResponsesNotes.Add(allNotes[i]);
            }

            var arr = _4first.ToArray();
            rdn.Shuffle(arr);

            CurrentNote = allNotes[arr[0]];


        }
    }
}
