namespace MajorLeagueMiruken.Api
{
    public abstract class TeamData {
        public int? Id { get; set; }
        public string Name { get; set; }

        public Color? Color { get; set; }

        public PersonData Coach { get; set; } 
        public PersonData Manger { get; set; } 
        public PlayerData[] Roaster { get; set; }
    }
}