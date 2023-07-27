namespace Case.Api.Helpers;

public static class IdentityHelper
{
    public static Guid GetUserId(HttpContext context) =>
        context.Items.TryGetValue("userId", out var id) && id is string idString &&
        Guid.TryParse(idString, out var userId)
            ? userId
            : Guid.Empty;
}