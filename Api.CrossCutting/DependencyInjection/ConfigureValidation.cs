using Application.ViewModel;
using Application.ViewModel.Time;
using Domain.Entities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Service.Validation;
using Service.Validation.Time;
using Service.ViewModel.Time;

namespace CrossCutting.DependencyInjection
{
    public static class ConfigureValidation
    {
        public static void ConfigureValidationService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IValidator<AdicionarCampeonatoViewModel>, AdicionarCampeonatoViewModelValidation>();
            serviceCollection.AddTransient<IValidator<AdicionarTimeViewModel>, AdicionarTimeViewModelValidation>();
            serviceCollection.AddTransient<IValidator<AlterarCampeonatoViewModel>, AlterarCampeonatoViewModelValidation>();
        }
    }
}