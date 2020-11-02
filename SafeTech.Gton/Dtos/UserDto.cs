using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos
{
    public class UserDto
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string JobTitle { get; private set; }
        public byte[] ImageByteBase { get; set; }
    }
}
