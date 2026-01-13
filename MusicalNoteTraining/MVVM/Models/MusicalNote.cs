using System;
using System.Collections.Generic;
using System.Text;

namespace MusicalNoteTraining.MVVM.Models
{
    public enum Notes { do1, re, mi, fa, sol, la, si, do2 };

    public class MusicalNote
    {
        public required Notes MyNote{ get; init; }
        public required string path { get; init; }
        public required string color { get; init; }
    }
}
