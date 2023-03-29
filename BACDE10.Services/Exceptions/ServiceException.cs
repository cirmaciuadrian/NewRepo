//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;

namespace BACDE10.BusinessLogic.Exceptions;


[Serializable]
public class ServiceException : Exception
{
    //protected const string DefaultContentType = "application/json";

    //protected const string ProblemContentType = "application/problem+json";

    //protected const string RetryAfterHeaderName = "Retry-After";

    //protected static readonly JsonSerializerSettings SerializerSettings;

    //protected static readonly Regex ArgumentRegex;

    //public ExtendedProblemDetails ProblemDetails { get; protected set; }

    //public int? RetryAfter { get; set; }

    //public string? CorrelationId { get; set; }

    //public HttpStatusCode StatusCode { get; protected set; }

    //static ServiceException()
    //{
    //    ArgumentRegex = new Regex("(?<=\\{)[a-zA-Z0-9}]+(?=\\})", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
    //    SerializerSettings = new JsonSerializerSettings
    //    {
    //        NullValueHandling = NullValueHandling.Ignore,
    //        ContractResolver = new CamelCasePropertyNamesContractResolver(),
    //        TypeNameHandling = TypeNameHandling.All
    //    };
    //}

    //public ServiceException(HttpStatusCode statusCode, string? type = null, string? detail = null, string? resourceId = null, int? retryAfter = null)
    //{
    //    StatusCode = statusCode;
    //    RetryAfter = retryAfter;
    //    ProblemDetails = new ExtendedProblemDetails
    //    {
    //        Detail = detail,
    //        Status = (int)statusCode,
    //        Type = type,
    //        Instance = resourceId
    //    };
    //}

    //public ServiceException(HttpStatusCode statusCode, ExtendedProblemDetails problemDetails)
    //    : this(statusCode)
    //{
    //    ProblemDetails = problemDetails ?? throw new ArgumentNullException("problemDetails");
    //}

    //public ServiceException((string Message, string Code) error)
    //    : this(HttpStatusCode.BadRequest, error.Code, error.Message)
    //{
    //    if (string.IsNullOrWhiteSpace(error.Code))
    //    {
    //        throw new ArgumentNullException("Code");
    //    }
    //}

    //public ServiceException(HttpStatusCode status, (string Message, string Code) error)
    //    : this(status, error.Code, error.Message)
    //{
    //    if (string.IsNullOrWhiteSpace(error.Code))
    //    {
    //        throw new ArgumentNullException("Code");
    //    }
    //}

    //public ServiceException WithArguments(params object[]? arguments)
    //{
    //    Dictionary<string, string?> dictionary = MatchTextArguments(ProblemDetails.Detail, arguments);
    //    if (dictionary.Count > 0)
    //    {
    //        ProblemDetails.Args = dictionary;
    //    }

    //    return this;
    //}

    ////public async Task WriteAsync(HttpContext context, bool slim)
    ////{
    ////    if (context == null)
    ////    {
    ////        throw new ArgumentNullException("context");
    ////    }

    ////    await WriteHeadersAsync(context, slim);
    ////    string text = await GetContentAsync(slim);
    ////    if (string.IsNullOrEmpty(text))
    ////    {
    ////        context.Response.ContentLength = 0L;
    ////        return;
    ////    }

    ////    context.Response.ContentLength = text.Length;
    ////    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(text));
    ////}

    ////protected virtual Task WriteHeadersAsync(HttpContext context, bool slim)
    ////{
    ////    context.Response.ContentType = ((ProblemDetails == null) ? "application/json" : "application/problem+json");
    ////    context.Response.StatusCode = (int)StatusCode;
    ////    return Task.CompletedTask;
    ////}

    //protected virtual async Task<string?> GetContentAsync(bool slim)
    //{
    //    string result = ((ProblemDetails == null) ? JsonConvert.SerializeObject(new ProblemDetails
    //    {
    //        Type = "unknown",
    //        Status = (int)StatusCode
    //    }, Formatting.Indented, SerializerSettings) : JsonConvert.SerializeObject(slim ? ProblemDetails.AsSlim() : ProblemDetails, Formatting.Indented, SerializerSettings));
    //    return await Task.FromResult(result);
    //}

    //protected static string[] GetTextArguments(string text)
    //{
    //    string[] result = Array.Empty<string>();
    //    if (!string.IsNullOrWhiteSpace(text))
    //    {
    //        MatchCollection matchCollection = ArgumentRegex.Matches(text);
    //        if (matchCollection.Count > 0)
    //        {
    //            result = matchCollection.Select((Match m) => m.Value).ToArray();
    //        }
    //    }

    //    return result;
    //}

    //protected static Dictionary<string, string?> MatchTextArguments(string text, object[]? args)
    //{
    //    Dictionary<string, string> dictionary = new Dictionary<string, string>();
    //    if (args != null && args!.Length != 0)
    //    {
    //        string[] textArguments = GetTextArguments(text);
    //        for (int i = 0; i < Math.Max(textArguments.Length, args!.Length); i++)
    //        {
    //            dictionary.Add((i < textArguments.Length) ? textArguments[i] : i.ToString(), (i < args!.Length) ? args[i]?.ToString() : null);
    //        }
    //    }

    //    return dictionary;
    //}
}
