using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RegistrationUsers.Application.Dto.Validators
{
    public static class ValidationModelState
    {
        public static string ReturnErrosModel(this ModelStateDictionary model)
        {
            var message = string.Join(" | ", model.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            return message;
        }
    }
}
