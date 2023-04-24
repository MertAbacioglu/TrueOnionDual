using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueOnion.APPLICATION.Validators;

namespace TrueOnion.APPLICATION.DTOs
{
    public class UserUpdateDTO : AddUserWithDepartmentDTO
    {
        public Guid Id { get; set; }

    }
}