using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotsRestServices.Models.JsonObjects;

namespace BotsRestServices.Models.UserService
{
    /// <summary>
    /// The user basic behaviour
    /// </summary>
    public interface IUserBehaviour
    {
        /// <summary>
        /// Is iser authorized in the system
        /// </summary>
        bool IsAuthorized { get; set; }
        
        /// <summary>
        /// Is user registered in the system
        /// </summary>
        bool IsRegistered { get; set; }

        /// <summary>
        /// Login to the system
        /// </summary>
        /// <param name="authorize">User login and password</param>
        /// <returns>True if authorized, else false</returns>
        bool LogIn(Authorize authorize);

    }
}
