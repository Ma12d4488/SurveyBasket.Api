//namespace SurveyBasket.Api.Contracts.Validations;

//public class StudentValidator : AbstractValidator<Student>
//{
//    public StudentValidator()
//    {
//        RuleFor(x => x.Name)
//            .NotEmpty()
//            .Length(2, 50);

//        RuleFor(x => x.Email)
//            .NotEmpty()
//            .EmailAddress();

//        RuleFor (x => x.DateOfBirth)
//            .Must(BeMoreThan18YearsOld)
//            .When(x => x.DateOfBirth.HasValue)
//            .WithMessage("{PropertyName} is invalid, age should be 18 years at least");
//    }

//    private bool BeMoreThan18YearsOld(DateTime? dateOfBirth)
//    {
//        return DateTime.Today > dateOfBirth!.Value.AddYears(18);
//    }
//}
