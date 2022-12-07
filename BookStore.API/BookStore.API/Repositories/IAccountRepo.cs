using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Repositories
{
    public interface IAccountRepo
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
