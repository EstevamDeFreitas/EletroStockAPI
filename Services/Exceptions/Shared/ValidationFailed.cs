using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions.Shared
{
    [Serializable]
    public class ValidationFailed : Exception
    {
        public List<FieldError> Errors { get; set; }
        public ValidationFailed(List<ValidationFailure> validationFailures, string entityName) : base($"Validation failed for entity {entityName}")
        {
            Errors = validationFailures.Select(validation => new FieldError
            {
                Error = validation.ErrorMessage,
                FieldName = validation.PropertyName
            }).ToList();
        }
    }

    public class FieldError
    {
        public string FieldName { get; set; }
        public string Error { get; set; }
    }
}
