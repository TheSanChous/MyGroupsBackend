using MyGroups.Application.SQRS.Groups.Queries.GetGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGroups.Application.SQRS.Groups.Queries.GetGroupList
{
    public class GroupListViewModel
    {
        public IList<GroupViewModel> Groups { get; set; }
    }
}
