using System.Linq;
using Application.ViewModel;
using Domain.Interfaces.Services;
using FluentValidation;

namespace Service.Validation
{
    public class AlterarCampeonatoViewModelValidation : AbstractValidator<AlterarCampeonatoViewModel>
    {
        
        private static ICampeonatoService _campeonatoService;
        public AlterarCampeonatoViewModelValidation(ICampeonatoService campeonatoService)
        {
            _campeonatoService = campeonatoService;
            
            RuleFor(x => x.nome).NotEmpty().WithMessage("O atributo NOME é obrigatório!");
            RuleFor(x => x.codigoCampeonato).Length(5).WithMessage("O Código do campeonato não pode ser maior ou menor que 5 Caracteres.")
                .Must(verificarcodigo).WithMessage("Não existe nenhum campeonato com o código indicado.");
        }

        private static bool verificarcodigo(string codigoCampeonato)
        {
            return _campeonatoService.Get(x => x.codigoCampeonato == codigoCampeonato).Any();
        }
    }
}