using System.Globalization;

namespace CARL.API.Middlewares;

public class CultureMiddleware
{
    private readonly RequestDelegate _next;

    public CultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();

        var requestLanguage = context.Request.Headers.AcceptLanguage.FirstOrDefault();

        var cultureName = "en"; // Linguagem Padrão da API

        if(!string.IsNullOrWhiteSpace(requestLanguage) && supportedLanguages.Exists(l => l.Name.Equals(requestLanguage)))
            cultureName = requestLanguage;

        var cultureInfo = new CultureInfo(cultureName);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        await _next(context);
    }
}
