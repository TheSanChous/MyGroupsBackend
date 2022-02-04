using System.Collections.Generic;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroupUsers
{
    public class GroupUsersListViewModel
    {
        public ICollection<GroupUserViewModel> GroupUsersList { get; set; }
    }
}