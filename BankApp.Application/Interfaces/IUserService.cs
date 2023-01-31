using BankApp.Application.DTOs.User;
using BankApp.Domain.Entities;

namespace BankApp.Application.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        User? GetById(int id);
        void AddUser(User user, string password);
    }
}
