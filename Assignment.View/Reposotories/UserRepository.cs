using Assignment.View.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.View.Reposotories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public void add(UserModel usermodel)
        {
            UserModel user = null;

            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Insert *from [User] (FirstName,LastName,Gender,Email,DOB,Password,CPassword) values('\" + txtfname + \"','\" + txtlname + \"','\" + gender + \"','\" + email + \"','\" + date + \"')\"','\" + password + \"')\"','\" + cpassword + \"')\" )";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            FirstName = reader[0].ToString(),
                            LastName= reader[1].ToString(),
                            Gender = reader[2].ToString(),
                            Email = reader[3].ToString(),
                            DOB = (DateTime)reader[4],
                            Password = reader[5].ToString(),
                            CPassword= reader[6].ToString(),
                            

                        };
                    }
                }
            }
        }

        

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where Email=@Email and [password]=@password";
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select *from [User] where Email=@Email";
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = username;
                using(var reader = command.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        user = new UserModel()
                        {
                            Email = reader[1].ToString(),
                            Password = string.Empty,
                            FirstName = reader[3].ToString(),
                            LastName = reader[4].ToString(),

                        };
                    }
                }
  
           
            }
            return user;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
