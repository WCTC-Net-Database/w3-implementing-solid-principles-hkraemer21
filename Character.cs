using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterConsole
{
    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public string Equipment { get; set; }

        public Character()
        {
            Name = "";
            Class = "";
            Level = 0;
            HP = 0;
            Equipment = "";
        }

        public Character(string name, string charClass, int level, int hp, string equipment)
        {
            Name = name;
            Class = charClass;
            Level = level;
            HP = hp;
            Equipment = equipment;
        }


    }


}
