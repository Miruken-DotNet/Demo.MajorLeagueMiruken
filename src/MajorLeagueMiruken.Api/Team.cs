namespace MajorLeagueMiruken.Api
{
    using System.Collections.Generic;
    using System.Text;

    public class Team
    {
        public int      Id         { get; set; }
        public string   Name       { get; set; }
        public Color    TeamColor  { get; set; }
        public Person   Coach      { get; set; }
        public Person   Manager    { get; set; }
        public List<Player> Roster { get; set; } = new List<Player>();

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"{Name}");
            builder.AppendLine($"  Color  : {TeamColor}");
            builder.AppendLine($"  Manager: {Manager?.FullName}");
            builder.AppendLine($"  Coach  : {Coach?.FullName}");
            builder.AppendLine();
            return builder.ToString();

        }
    }
}
