using MusicalNoteTraining.Extensions;
using MusicalNoteTraining.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MusicalNoteTraining.Converter
{
    public class NoteConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is MusicalNote mn)
            {
                return mn.Boom();
            }
            return "---";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
