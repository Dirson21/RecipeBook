using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UserAccountDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = "";

        public string Description { get; set; } = "";

        public string Name { get; set; } = "";

        public string NewPassword { get; set; } = "";

    }
}
