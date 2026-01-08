using MusicalNoteTraining.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicalNoteTraining.Extentions
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
