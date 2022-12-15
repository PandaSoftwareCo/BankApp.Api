using System.Text.Json.Serialization;

namespace BankApp.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountType
    {
        Debit = 1,
        Credit = 2
    }
}
