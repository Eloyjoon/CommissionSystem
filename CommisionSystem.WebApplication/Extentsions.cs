using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using CommissionSystem.WebApplication.Models.ViewModels;
using CommissionSystem.Data;
using CommissionSystem.Data.Sepidar;

namespace CommissionSystem.WebApplication
{
    public static class Extentsions
    {
        



        #region User

        public static ReadUserModel ToReadUserModel(this User input)
        {
            ReadUserModel readUserModel = new ReadUserModel()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                RoleName = input.Role.RoleName,
                UserID = input.ID,
                UserName = input.UserName,
                Status=input.Status
            };

            return readUserModel;
        }



        #endregion
    }
}
