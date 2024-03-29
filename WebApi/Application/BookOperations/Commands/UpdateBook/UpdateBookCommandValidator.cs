using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
            RuleFor(command => command.Model.genreId).GreaterThan(0);
            // RuleFor(command => command.Model.pageCount).GreaterThan(0);
            // RuleFor(command => command.Model.publishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.title).NotEmpty().MinimumLength(2);
          
        }

    }
}