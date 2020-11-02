using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeTech.Gton.Dtos.Screen
{
    public class HomeScreenResponseDto
    {
        public List<HomeScreenOperationResponseDto> Operations { get; set; }
        public UserDto User { get; set; }
    }

    public class HomeScreenOperationResponseDto
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string OrganType { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
    }
}
