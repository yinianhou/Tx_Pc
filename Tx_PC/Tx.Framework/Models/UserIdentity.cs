using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tx.Framework.Models
{
    /// <summary>
    /// 请求用户身份
    /// </summary>
    [Serializable]
    public class UserIdentity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
    }
}
