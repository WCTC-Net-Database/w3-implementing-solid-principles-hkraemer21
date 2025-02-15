using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace CharacterConsole
{
    internal class CharacterReader
    {
        
        public static List<Character> ReadCSV(string filePath)
        {
            List<Character> characters = new List<Character>();
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                characters = csv.GetRecords<Character>().ToList();
            }
            return characters;
        }
    }
}
