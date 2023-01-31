using System.Text.Json.Serialization;

namespace BankApp.Application.DTOs.User
{
    public class AuthenticateResponse
    {
        //public int UserId { get; set; }
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("expires")]
        public DateTime Expires { get; set; }

        public AuthenticateResponse(BankApp.Domain.Entities.User user, string token, DateTime expires)
        {
            //UserId = user.UserId;
            UserName = user.Username;
            Token = token;
            Expires = expires;
        }
    }
}
