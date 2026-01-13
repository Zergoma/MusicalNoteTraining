using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicalNoteTraining.Abstraction;
using MusicalNoteTraining.Extensions;
using MusicalNoteTraining.MVVM.Models;
using MusicalNoteTraining.Services;
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
    public partial class TrainingViewModel : ObservableObject, INeedInitilization
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

        List<MusicalNote> allNotes = [];

        Random rdn;
        private readonly IMusicalNotesProducer producerService;

        public TrainingViewModel(IMusicalNotesProducer producer)
        {
            producerService = producer;
            rdn = Random.Shared;
        }

        public async void Initialize()
        {
            allNotes = await producerService.GetMusicalNote();

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
