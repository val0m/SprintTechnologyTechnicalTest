using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BoardingCards.DomainShared.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransportType
    {
        [EnumMember(Value = "None")]
        None = 0,
        [EnumMember(Value = "Airplane")]
        Airplane = 1,
        [EnumMember(Value = "Train")]
        Train = 2,
        [EnumMember(Value = "Bus")]
        Bus = 3,
        [EnumMember(Value = "AirportBus")]
        AirportBus = 4,
        [EnumMember(Value = "Taxi")]
        Taxi = 5
    }
}
