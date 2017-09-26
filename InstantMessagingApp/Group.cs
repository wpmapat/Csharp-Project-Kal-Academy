using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantMessagingApp
{
    class Group:Account
    {
#region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; }
        /// <summary>
        /// Name os the User
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// List of the participants of the group
        /// </summary>
        public List<User> Participants { get; set; }
        #endregion
        #region Methods

#endregion
    }
}