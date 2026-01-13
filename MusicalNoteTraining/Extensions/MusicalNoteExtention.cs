using MusicalNoteTraining.MVVM.Models;
using MusicalNoteTraining.Utilities;

namespace MusicalNoteTraining.Extensions
{
    public static class MusicalNoteExtention
    {
        extension (MusicalNote musicalNote)
        {
            public string Boom()
            {
                return musicalNote.MyNote switch
                {
                    Notes.do1 => "do1",
                    Notes.do2 => "do2",
                    Notes.re => "ré",
                    Notes.mi => "mi",
                    Notes.fa => "fa",
                    Notes.sol => "sol",
                    Notes.la => "la",
                    Notes.si => "si",
                    _ => "---",
                };
            }
        }
    }
}
