using Core.CrossCuttingConcerns.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.ProblemDetailsModels;

public class ValidationProblemDetails : ProblemDetails
{ 
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }
    
    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error(s)";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
    }
}