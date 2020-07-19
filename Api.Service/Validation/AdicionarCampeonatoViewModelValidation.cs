using Application.ViewModel;
using FluentValidation;

namespace Service.Validation
{
    public class AdicionarCampeonatoViewModelValidation: AbstractValidator<AdicionarCampeonatoViewModel> 
    {
        public AdicionarCampeonatoViewModelValidation()
        {
            RuleFor(x => x.nome).NotEmpty().WithMessage("O atributo NOME é obrigatório!");
            RuleFor(x => x.dataInicio).NotNull().WithMessage("A Data é obrigatória!");
        }
    }
}