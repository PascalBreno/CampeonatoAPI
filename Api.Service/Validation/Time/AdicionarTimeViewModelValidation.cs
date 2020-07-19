using System.Linq;
using Domain.Interfaces.AppService;
using Domain.Interfaces.Services;
using FluentValidation;
using Service.ViewModel.Time;

namespace Service.Validation.Time
{
    public class AdicionarTimeViewModelValidation : AbstractValidator<AdicionarTimeViewModel>
    {
        private static ITimeAppService _timeAppService;
        public AdicionarTimeViewModelValidation(ITimeAppService timeService)
        {
            _timeAppService = timeService;
            
            RuleFor(x => x.nome).NotEmpty().WithMessage("O Nome é obrigatório ao registrar um time");
            RuleFor(x => x.sigla).Must(verificarSigla).WithMessage("Essa sigla já está registrada");
        }

        private static bool verificarSigla(string sigla)
        {
            return !_timeAppService.Get(x => x.sigla == sigla).Any();
        }
    }
}