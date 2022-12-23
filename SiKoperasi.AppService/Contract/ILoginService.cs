using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiKoperasi.AppService.Contract
{
    public interface ILoginService
    {
        string EncryptPassword(string password);
        bool PasswordVerification(string hashedPassword, string providedPassword);
    }
}
