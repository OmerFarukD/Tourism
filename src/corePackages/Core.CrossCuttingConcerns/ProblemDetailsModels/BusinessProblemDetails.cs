using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.ProblemDetailsModels;

public class BusinessProblemDetails : ProblemDetails
{
    public BusinessProblemDetails(string detail)
    {
        Title = "Rule Validation";
        Detail = detail;
        Status = StatusCodes.Status400BadRequest;
    }
}