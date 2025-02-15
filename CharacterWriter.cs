using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace CharacterConsole
{
    internal class CharacterWriter
    {
        public static void WriteCSV(string filePath, List<Character> characters)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(characters);
            }
        }

        public static void AddCharacter(string filePath, Character newCharacter)
        {
            var characters = CharacterReader.ReadCSV(filePath);
            characters.Add(newCharacter);

            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(characters);
            }
        }
    }
}
