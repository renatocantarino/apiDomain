using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Entities
{
    public abstract  class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataModificacao { get; set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        [NotMapped]
        public bool IsValid { get; private set; }

        protected bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            this.ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }
    }
}