using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroupsAPI.Models.Files
{
    public class CreateFileModel
    {
        public byte[] Data { get; set; }
        public string Type { get; set; }
    }
}
