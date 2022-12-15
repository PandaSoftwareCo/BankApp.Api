using System.Text.Json.Serialization;

namespace BankApp.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TransactionType
    {
        Withdrawl = 1,
        Deposit = 2
    }
}
