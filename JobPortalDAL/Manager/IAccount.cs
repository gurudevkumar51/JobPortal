﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalDAL.Manager
{
    public interface IAccount
    {
        string Login(string username, string pass);
        Task<string> GetUserDetailsAsync(string token);
    }
}
