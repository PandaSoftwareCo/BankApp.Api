using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BankApp.Application.DTOs.User
{
    public class AuthenticateRequest
    {
        [Required]
        [JsonPropertyName("userName")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
