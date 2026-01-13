using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicalNoteTraining.Abstraction;
using MusicalNoteTraining.MVVM.Models;
using MusicalNoteTraining.Services;
using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AudioManager = Plugin.Maui.Audio.AudioManager;

namespace MusicalNoteTraining.MVVM.ViewModels
{
    public partial class PlayViewModel : ObservableObject, INeedInitilization
    {
        private readonly IMusicalNotesProducer notesProducer;

        [ObservableProperty]
        public ObservableCollection<MusicalNote> allNotes = new();

        public PlayViewModel(IMusicalNotesProducer notesProducer)
        {
            this.notesProducer = notesProducer;
        }

        [RelayCommand]
        static public async Task Play(MusicalNote sender)
        {
            var audioPlayer = AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(sender.path));
            audioPlayer?.Play();
        }

        public async void Initialize()
        {
            var listdata = await notesProducer.GetMusicalNote();

            AllNotes.Clear();
            listdata.ForEach(AllNotes.Add);
        }
    }
}
