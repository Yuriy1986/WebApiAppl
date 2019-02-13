using System;
using System.Collections.Generic;
using System.Linq;
using WebApiAppl.EF;

namespace WebApiAppl.Models
{
    public class UsersAndPositionViewModel
    {
        public IEnumerable<User> UsersAll { get; set; }

        public IEnumerable<Position> PositionAll { get; set; }
    }
}