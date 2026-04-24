namespace BuilderPattern
{
    public class RPGCharacter
    {
        public string Hair { get; set; }
        
        public string Armor { get; set; }
        
        public string Weapon { get; set; }

        public void Show()
        {
            Console.WriteLine($"Hair: {Hair}, Armor: {Armor}, Weapon: {Weapon}");
        }

    }

    // Builder
    public abstract class CharacterBuilder
    {
        protected RPGCharacter character;

        public void CreateCharacter()
        {
            character = new RPGCharacter();
        }

        public RPGCharacter GetCharacter()
        {
            return character;
        }

        public abstract void SetHair();
        
        public abstract void SetArmor();
        
        public abstract void SetWeapon();
    }

    // Concrete Builder
    public class WarriorBuilder : CharacterBuilder
    {
        public override void SetHair() => character.Hair = "Short";
       
        public override void SetArmor() => character.Armor = "Plate Armor";
        
        public override void SetWeapon() => character.Weapon = "Sword";
    }

    public class ScribeBuilder : CharacterBuilder
    {
        public override void SetHair() => character.Hair = "Long";
        
        public override void SetArmor() => character.Armor = "Robe";
        
        public override void SetWeapon() => character.Weapon = "Pen";
    }

    // Director
    public class CharacterCreator
    {
        private CharacterBuilder builder;

        public CharacterCreator(CharacterBuilder builder)
        {
            this.builder = builder;
        }

        public void CreateCharacter()
        {
            builder.CreateCharacter();
            builder.SetHair();
            builder.SetArmor();
            builder.SetWeapon();
        }

        public RPGCharacter GetCharacter()
        {
            return builder.GetCharacter();
        }
    }
}
