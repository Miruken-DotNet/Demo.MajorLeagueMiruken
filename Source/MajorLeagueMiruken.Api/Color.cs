namespace MajorLeagueMiruken.Api
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Color
    {
        Black,
        Blue,
        Green,
        LightBlue,
        Maroon,
        Orange,
        Red,
        White,
        Yellow
    }
}