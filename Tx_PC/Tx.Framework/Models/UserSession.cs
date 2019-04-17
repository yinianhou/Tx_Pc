using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tx.Framework.Models
{
    [Serializable]
    public class UserSession
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public UserSession()
        {
        }
    }
}
