﻿using Core.CrossCuttingConcerns.Types;

namespace Core.CrossCuttingConcerns.ExceptionHandlers.Handler;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception) => exception switch
    {
        BusinessException businessException => HandleException(businessException),
        ValidationException validationException => HandleException(validationException),
        AuthorizationException authorizationException => HandleException(authorizationException),
        NotFoundException notFoundException => HandleException(notFoundException),
        _=> HandleExceptionAsync(exception)
    };
    
    protected abstract Task HandleException(AuthorizationException authorizationException);
    
    protected abstract Task HandleException(ValidationException validationException);
    
    protected abstract Task HandleException(BusinessException businessException);
    
    protected abstract Task HandleException(Exception exception);

    protected abstract Task HandleException(NotFoundException notFoundException);

}