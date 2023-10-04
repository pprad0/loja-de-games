using FluentValidation;
using lojadegames.Model;

namespace lojadegames.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {

            RuleFor(p => p.Nome)
                .NotEmpty();
        }
    }
}
