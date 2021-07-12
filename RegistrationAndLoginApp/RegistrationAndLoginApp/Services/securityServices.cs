using RegistrationAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationAndLoginApp.Services
{
    public class securityServices
    {
        UserDataDAO userDataDAO = new UserDataDAO();
        public bool isValid(UserModel userModel)
        {
            return userDataDAO.FindUserByNameAndPassword(userModel);
        }
    }
}
