namespace MajorLeagueMiruken.Api
{
    public record TeamData(
        int?         Id, 
        string       Name    = null, 
        Color?       Color   = null,
        CoachData    Coach   = null, 
        ManagerData  Manager = null,
        PlayerData[] Players = null);
}