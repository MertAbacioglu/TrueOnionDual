using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueOnion.APPLICATION.DTOs
{
    public class AddUserWithDepartmentDTO :UserCreateDTO
    {
        public Guid DepartmentId { get; set; }

    }
}
