using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HummanResorser
{
    /// <summary>
    /// Main
    /// </summary>
    public class Acess
    {
        /// <summary>
        /// id
        /// </summary>
        public int id
        {
            get;
            private set;
        }

        /// <summary>
        /// ID معلومات الإساسية
        /// </summary>
        public int id_Information
        {
            get;
            private set;
        }

        /// <summary>
        /// Usernaem
        /// </summary>
        public string Username
        {
            get;
            private set;
        }

        /// <summary>
        /// passwoard
        /// </summary>
        public string Password
        {
            get;
            private set;
        }

        /// <summary>
        /// العمل المراد منه الدخول إلى البرنامج
        /// </summary>
        public string WaitIsWork
        {
            get;
            private set;
        }
    }
}
