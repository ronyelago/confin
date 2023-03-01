using confin.api.models;
using FluentValidation;

namespace confin.api.validators
{
    public class NovaCompraValidator : AbstractValidator<NovaCompraModel>
    {
        public NovaCompraValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Descricao).NotEmpty().Length(3).MaximumLength(64);
            RuleFor(x => x.Valor).NotEmpty().GreaterThan(0).Must();
            RuleFor(x => x.FormaPagamento).NotEmpty();
            RuleFor(x => x.DataCompra).LessThanOrEqualTo(DateTime.Now);//
        }
    }
}