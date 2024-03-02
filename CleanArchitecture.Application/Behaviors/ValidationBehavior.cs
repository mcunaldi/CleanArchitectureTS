using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Behaviors;
public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>

{    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var errorDictionary = validators
            .Select(s=> s.Validate(context))
            .SelectMany(s=> s.Errors)
            .Where(s=> s != null)
            .GroupBy(
            s=> s.PropertyName,
            s=> s.ErrorMessage, (propertyName, errorMessaege) => new
            {
                Key = propertyName,
                Values = errorMessaege.Distinct().ToArray()
            })
            .ToDictionary(s=> s.Key, s=> s.Values[0]);

        if (errorDictionary.Any())
        {
            var errors = errorDictionary.Select(s => new ValidationFailure
            {
                PropertyName = s.Value,
                ErrorCode = s.Key
            });

            throw new ValidationException(errors);            
        }

        return await next();
    }
}
