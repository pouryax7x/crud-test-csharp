using Mc2.CrudTest.Application.Core.Dtos.Exception;
using Mc2.CrudTest.Application.Core.Exception.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Middleware.Exception
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                string errorMessage = string.Empty;
                switch (error)
                {
                    case BadRequestException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = e.Message;
                        break;
                    case NotFoundException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorMessage = e.Message;
                        break;
                    case UnexpectedException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = e.Message;
                        break;
                    case ValidationException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorMessage = e.Message;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorMessage = "Oops! Somthing Goes Wrong...";
                        break;
                }

                var result = JsonSerializer.Serialize(new ExceptionMessage(errorMessage));
                await response.WriteAsync(result);
            }
        }
    }
}
