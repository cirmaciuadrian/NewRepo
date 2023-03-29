using BACDE10.BusinessLogic.Models.Options;
using BACDE10.WEBAPI.Validators;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BACDE10.WEBAPI.Middlewares
{
    public class HeadersValidationMiddleware : IMiddleware
    {
        private readonly IOptionsMonitor<HeadersConfigSettings> headersOptions = null!;

        private List<string>? apiHeadersWhitelist;

        public HeadersValidationMiddleware(IOptionsMonitor<HeadersConfigSettings> headersOptions)
        {
            this.headersOptions = headersOptions;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            apiHeadersWhitelist = ParseWhiteList(headersOptions.CurrentValue);
            apiHeadersWhitelist = apiHeadersWhitelist.Select((string key) => key.ToUpperInvariant()).ToList();
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            //add new headers validations
            IHeaderDictionary headerDictionary = context.Request!.Headers;
            List<string> list = (from key in headerDictionary?.Keys
                                 select key.ToUpperInvariant() into key
                                 where key.StartsWith("X-")
                                 select key).ToList();
            string text = JsonConvert.SerializeObject(list);
            string text2 = JsonConvert.SerializeObject(apiHeadersWhitelist);
            //logger.LogInformation("Request headers: " + text);
            //logger.LogInformation("Current header whitelist: " + text2);
            if (list?.Count > apiHeadersWhitelist!.Count)
            {
                //logger.LogCritical("Custom headers count error.");
                //throw new ValidationException(Errors.HeaderWhitelistError);
            }
            if (list != null && list.Any((string customHeaderKey) => !apiHeadersWhitelist!.Contains(customHeaderKey)))
            {
                IEnumerable<string> enumerable = list.Where((string customHeaderKey) => !apiHeadersWhitelist!.Contains(customHeaderKey));
                //logger.LogCritical("Custom headers whitelist error. Unrecognized header/s: " + JsonConvert.SerializeObject(enumerable));
                if (enumerable != null && enumerable.Count() > 0)
                {
                    //throw new ValidationException(Errors.HeaderWhitelistError);
                }
            }
            await next(context);
        }
        private List<string> ParseWhiteList(HeadersConfigSettings whitelistConfig)
        {
            if (!new HeadersConfigSettingsValidator().Validate(whitelistConfig).IsValid || whitelistConfig.Whitelist == null)
            {
                //logger.LogError(Errors.EmptyHeaderWhitelist.Message);
                //throw new ServiceException(HttpStatusCode.InternalServerError, Errors.EmptyHeaderWhitelist);
            }

            List<string> list = (from a in whitelistConfig.Whitelist!.Split(",", StringSplitOptions.RemoveEmptyEntries)
                                 select a.ToUpper().Trim()).ToList();
            if (list.Count == 0)
            {
                //logger.LogError(Errors.EmptyHeaderWhitelist.Message);
                //throw new ServiceException(HttpStatusCode.InternalServerError, Errors.EmptyHeaderWhitelist);
            }

            return list;
        }
    }
}
