namespace BankApp.Application.DTOs
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public int? StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
