using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class BUser
    {

        #region properties

        public int Id { get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        #endregion

    }
}
