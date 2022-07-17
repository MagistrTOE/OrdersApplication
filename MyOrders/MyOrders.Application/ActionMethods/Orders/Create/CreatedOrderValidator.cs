using FluentValidation;

namespace MyOrders.Application.ActionMethods.Orders.Create
{
    public class CreatedOrderValidator : AbstractValidator<CreatedOrderRequest>
    {
        public CreatedOrderValidator()
        {
            RuleFor(x => x.SenderCity)
                .NotEmpty()
                .WithMessage("Введите город отправителя");

            RuleFor(x => x.SenderCity)
                .MaximumLength(20)
                .WithMessage("Название города не должно содержать более 20 символов");

            RuleFor(x => x.SenderAddress)
                .NotEmpty()
                .WithMessage("Введите адрес отправителя");

            RuleFor(x => x.RecipientCity)
                .NotEmpty()
                .WithMessage("Введите город отправителя");

            RuleFor(x => x.RecipientCity)
                .MaximumLength(20)
                .WithMessage("Название города не должно содержать более 20 символов");

            RuleFor(x => x.Weight)
                .NotEmpty()
                .WithMessage("Введите вес груза в КГ");

            RuleFor(x => x.Weight)
                .NotEmpty()
                .WithMessage("Введите вес груза в КГ");

            RuleFor(x => x.Weight)
                .Must(x => x <= 10000)
                .WithMessage("Максимальный вес груза 10000 КГ");

            RuleFor(x => x.RecivedDate)
                .NotEmpty()
                .WithMessage("Введите дату забора груза");
        }
    }
}