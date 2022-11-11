using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace ApiApplication.Infrastructure;

public class ValidationErrorResult
{
    public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
}

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var result = new ValidationErrorResult();

            switch(error)
            {
                case ValidationException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                    result.Errors.AddRange(e.Errors); 
                    break;
                case KeyNotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    result.Errors.Add(new ValidationFailure(string.Empty, e.Message));
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result.Errors.Add(new ValidationFailure(string.Empty, error.Message));
                    break;
            }

            await response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}

