namespace CharacterConsole;

public class CharacterManager
{
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly string _filePath = "input.csv";

    private string[] lines;

    public CharacterManager(IInput input, IOutput output)
    {
        _input = input;
        _output = output;
    }

    public void Run()
    {
        _output.WriteLine("Welcome to Character Management");

        lines = File.ReadAllLines(_filePath);

        while (true)
        {
            _output.WriteLine("Menu:");
            _output.WriteLine("1. Display Characters");
            _output.WriteLine("2. Find Character");
            _output.WriteLine("3. Add Character");
            _output.WriteLine("4. Level Up Character");
            _output.WriteLine("5. Exit");
            _output.Write("Enter your choice: ");
            var choice = _input.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayCharacters();
                    break;
                case "2":                    
                    FindCharacter();
                    break;
                case "3":
                    AddCharacter();
                    break;
                case "4":
                    LevelUpCharacter();
                    break;
                case "5":
                    return;
                default:
                    _output.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayCharacters()
    {
        // TODO: Implement displaying characters from the CSV file
        var characters = CharacterReader.ReadCSV(_filePath);
        foreach (var character in characters)
        {
            _output.WriteLine($"\nName: {character.Name}\nClass: {character.Class}\nLevel: " +
                $"{character.Level}\nHP: {character.HP}\nEquipment: {character.Equipment}\n");
        }
    }

    public void FindCharacter()
    {
        _output.Write("Enter character name to find: ");
        var name = _input.ReadLine();
        var characters = CharacterReader.ReadCSV(_filePath);
        var character = characters.FirstOrDefault(c => c.Name == name);

        if (character != null)
        {
            _output.WriteLine($"\nName: {character.Name}\nClass: {character.Class}\nLevel: " +
                $"{character.Level}\nHP: {character.HP}\nEquipment: {character.Equipment}\n");
        }
        else
        {
            _output.WriteLine("Character not found.");
        }
    }



    public void AddCharacter()
    {
        // TODO: Implement adding a new character and saving to the CSV file
        Character newCharacter = new Character();
        _output.Write("Enter character name: ");
        newCharacter.Name = _input.ReadLine();
        _output.Write("Enter character class: ");
        newCharacter.Class = _input.ReadLine();
        _output.Write("Enter character level: ");
        newCharacter.Level = int.Parse(_input.ReadLine());
        _output.Write("Enter character HP: ");
        newCharacter.HP = int.Parse(_input.ReadLine());
        _output.Write("Enter character's first equipment item: ");
        var equipment1 = _input.ReadLine();
        _output.Write("Enter character's second equipment item: ");
        var equipment2 = _input.ReadLine();
        _output.Write("Enter character's third equipment item: ");
        var equipment3 = _input.ReadLine();
        newCharacter.Equipment = $"{equipment1}|{equipment2}|{equipment3}";

        CharacterWriter.AddCharacter(_filePath, newCharacter);

        _output.WriteLine("Character added successfully!");


    }

    public void LevelUpCharacter()
    {
        // TODO: Implement leveling up a character and updating the CSV file
        _output.Write("Enter character name to level up: ");
        var name = _input.ReadLine();
        var characters = CharacterReader.ReadCSV(_filePath);
        var character = characters.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (character != null)
        {
            character.Level++;
            CharacterWriter.WriteCSV(_filePath, characters);
            _output.WriteLine($"Character {character.Name} leveled up to level {character.Level}.");
        }
        else
        {
            _output.WriteLine("Character not found.");
        }
    }
}