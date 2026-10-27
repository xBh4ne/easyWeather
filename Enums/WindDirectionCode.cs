using System.ComponentModel;

namespace EasyWeather.Enums
{
    public enum WindDirectionCode
    {
        [Description("N")] North,
        [Description("E")] East,
        [Description("S")] South,
        [Description("W")] West,
        [Description("NE")] NorthEast,
        [Description("NW")] NorthWest,
        [Description("NNE")] NorthNorthEast,
        [Description("NNW")] NorthNorthWest,
        [Description("ENE")] EastNorthEast,
        [Description("ESE")] EastSouthEast,
        [Description("SE")] SouthEast,
        [Description("SW")] SouthWest,
        [Description("SSE")] SouthSouthEast,
        [Description("SSW")] SouthSouthWest,
        [Description("WSW")] WestSouthWest,
        [Description("WNW")] WestNorthWest
    }
}
