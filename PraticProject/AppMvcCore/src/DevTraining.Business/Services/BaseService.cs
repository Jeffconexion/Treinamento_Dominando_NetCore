
using DevTraining.Business.Models;
using FluentValidation;
using FluentValidation.Results;

namespace DevTraining.Business.Services
{
    public abstract class BaseService
    {

        protected void Notificar(ValidationResult validationResult)
        {

            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }

        }

        protected void Notificar(string mensagem)
        {
            //propagar esse erro até a camada de apresentação
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);

            return false;
        }

    }
}
