using System.Text.Json.Serialization;

namespace BankApp.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        User = 1,
        Admin = 2
    }
}
