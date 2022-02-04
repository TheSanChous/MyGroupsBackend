using FluentValidation;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroupByIdentifier
{
    public class GetGroupByIdentifierQueryValidator : AbstractValidator<GetGroupByIdentifierQuery>
    {
        public GetGroupByIdentifierQueryValidator()
        {
            RuleFor(query => query.GroupIdentifier)
                .Length(8)
                .NotEmpty()
                .NotNull();
        }
    }
}