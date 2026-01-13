using MusicalNoteTraining.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicalNoteTraining.Services
{
    public interface IMusicalNotesProducer
    {
        public Task<List<MusicalNote>> GetMusicalNote();
    }
}
