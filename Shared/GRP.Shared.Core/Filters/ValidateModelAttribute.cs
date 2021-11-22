

using GRP.Shared.Core.ExtensionMethods;

using Microsoft.AspNetCore.Mvc.Filters;

namespace GRP.Shared.Core.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = context.GetBadRequestResultErrorDtoForModelState();
        }
    }
}
