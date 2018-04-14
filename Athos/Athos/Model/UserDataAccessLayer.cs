using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Athos.Model
{
    public class UserDataAccessLayer
    {
        string connectionString = "";

        public IEnumerable<User> GetUsers()
        {
            try
            {
                List<User> listUsuario = new List<User>();

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GET_ALL_USERS", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cn.Open();


                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        listUsuario.Add(new User()
                        {
                            ID = Convert.ToInt32(rdr["Id"]),
                            Name = rdr["Name"].ToString(),
                            Gender = rdr["Gender"].ToString(),
                            Department = rdr["Department"].ToString(),
                            City = rdr["City"].ToString()
                        });
                    }
                }

                return listUsuario;
            }
            catch
            {
                throw;
            }
        }

        public User GetUserData(int id)
        {
            try
            {
                User user = new User();

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GET_ALL_USERS", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cn.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        user.ID = Convert.ToInt32(rdr["Id"]);
                        user.Name = rdr["Name"].ToString();
                        user.Gender = rdr["Gender"].ToString();
                        user.Department = rdr["Department"].ToString();
                        user.City = rdr["City"].ToString();
                    }
                }

                return user;
            }
            catch
            {
                throw;
            }
        }

        public void AddUser(User obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ADD_USER", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pName", obj.Name);
                    cmd.Parameters.AddWithValue("@pGender", obj.Gender);
                    cmd.Parameters.AddWithValue("@pDepartment", obj.Department);
                    cmd.Parameters.AddWithValue("@pCity", obj.City);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(User obj)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE_USER", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pName", obj.Name);
                    cmd.Parameters.AddWithValue("@pGender", obj.Gender);
                    cmd.Parameters.AddWithValue("@pDepartment", obj.Department);
                    cmd.Parameters.AddWithValue("@pCity", obj.City);
                    cmd.Parameters.AddWithValue("@pId", obj.ID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DELETE_USER", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@pId", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
