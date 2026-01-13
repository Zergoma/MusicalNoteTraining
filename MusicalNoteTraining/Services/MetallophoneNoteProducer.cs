using MusicalNoteTraining.MVVM.Models;
using MusicalNoteTraining.Utilities;

namespace MusicalNoteTraining.Services
{
    public class MetallophoneNoteProducer : IMusicalNotesProducer
    {
        public async Task<List<MusicalNote>> GetMusicalNote()
        {
            List<MusicalNote> allNotes = new()
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

            return allNotes;
        }
    }
}
