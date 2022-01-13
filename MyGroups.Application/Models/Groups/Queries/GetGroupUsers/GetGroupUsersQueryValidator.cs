using FluentValidation;

namespace MyGroups.Application.Models.Groups.Queries.GetGroupUsers
{
    public class GetGroupUsersQueryValidator : AbstractValidator<GetGroupUsersQuery>
    {
        public GetGroupUsersQueryValidator()
        {
            RuleFor(query => query.GroupId)
                .NotNull()
                .NotEmpty();
        }
    }
}