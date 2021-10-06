using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLibaryTest
{
    public class UserDetail
    {
        String Name, Surname, Password, Email;
        public void setName(String Name)
        {
            this.Name = Name;
        }
        public void setSurname(String Surname)
        {
            this.Surname = Surname;
        }
        public void setPassword(String Password)
        {
            this.Password = Password;
        }
        public void setEmail(String Email)
        {
            this.Email = Email;
        }
        public String getName()
        {
            return this.Name;
        }
        public String getSurname()
        {
            return this.Surname;
        }
        public String getPassword()
        {
            return this.Password;
        }
        public String getEmail()
        {
            return this.Email;
        }

    }
}
