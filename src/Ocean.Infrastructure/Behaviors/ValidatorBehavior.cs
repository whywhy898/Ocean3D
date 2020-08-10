using FluentValidation;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ocean.Infrastructure.Exceptions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Ocean.Infrastructure.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(IValidator<TRequest>[] validators, ILogger<ValidatorBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetType();

            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                _logger.LogWarning("验证错误 - {CommandType} - 指令: {@Command} - 错误: {@ValidationErrors}", typeName, request, failures);

                var error = string.Empty;
                failures.ForEach(e => {
                    error+= $"'{e.PropertyName}':{e.ErrorMessage}.";
                });

                throw new ValidateException($"参数验证错误，{error}");

            }

            return await next();
        }
    }
}