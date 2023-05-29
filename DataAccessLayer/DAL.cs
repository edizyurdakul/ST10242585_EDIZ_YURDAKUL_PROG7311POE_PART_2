using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Models;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.DataAccessLayer
{
    public class DAL
    {
        string connectionString = "Data Source=DESKTOP-2QJ41E2;Initial Catalog=ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2;Integrated Security=True";

        public List<User> GetUsersByRole(int roleId)
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE RoleId = @roleId", con);
                cmd.Parameters.AddWithValue("@roleId", roleId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        RoleId = Convert.ToInt32(reader["RoleId"])
                    };

                    users.Add(user);
                }
            }

            return users;
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        RoleId = Convert.ToInt32(reader["RoleId"])
                    };

                    users.Add(user);
                }
            }

            return users;
        }

        public List<User> GetAllFarmers()
        {
            List<User> farmers = new List<User>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE RoleId = 2", con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User farmer = new User();
                    farmer.UserId = Convert.ToInt32(reader["UserId"]);
                    farmer.FirstName = reader["FirstName"].ToString();
                    farmer.LastName = reader["LastName"].ToString();
                    farmer.Email = reader["Email"].ToString();
                    farmer.Password = reader["Password"].ToString();
                    farmer.StartDate = Convert.ToDateTime(reader["StartDate"]);

                    farmers.Add(farmer);
                }

                reader.Close();
            }

            return farmers;
        }


        public User GetUserByEmailAndPassword(string email, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = @Email AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        UserId = Convert.ToInt32(reader["UserId"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Password = reader["Password"].ToString(),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        RoleId = Convert.ToInt32(reader["RoleId"])
                    };

                    return user;
                }
            }

            return null;
        }
        public User GetUserById(int userId)
        {
            User user = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserId = Convert.ToInt32(userId),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                        };
                    }
                }
            }

            return user;
        }

        public List<Product> GetProductsByUserId(int userId)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products WHERE UserId = @UserId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ProductId = (int)reader["ProductId"];
                        product.Name = reader["Name"].ToString();
                        product.Type = reader["Type"].ToString();
                        product.DateAdded = (DateTime)reader["DateAdded"];
                        product.Price = (decimal)reader["Price"];
                        product.UserId = (int)reader["UserId"];

                        products.Add(product);
                    }
                }
            }

            return products;
        }
        public Product GetProductById(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductId = @ProductId", con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        Name = reader["Name"].ToString(),
                        Type = reader["Type"].ToString(),
                        DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        UserId = Convert.ToInt32(reader["UserId"])
                    };

                    reader.Close();
                    return product;
                }

                reader.Close();
            }

            return null;
        }

        public void AddUser(User user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (FirstName, LastName, Email, Password, StartDate, RoleId) " +
                                                "VALUES (@FirstName, @LastName, @Email, @Password, @StartDate, @RoleId)", con);

                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@StartDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@RoleId", user.RoleId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = Convert.ToInt32(reader["ProductId"]),
                        Name = reader["Name"].ToString(),
                        Type = reader["Type"].ToString(),
                        DateAdded = Convert.ToDateTime(reader["DateAdded"]),
                        Price = Convert.ToDecimal(reader["Price"]),
                        UserId = Convert.ToInt32(reader["UserId"])
                    };

                    products.Add(product);
                }
            }

            return products;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Products (Name, Type, DateAdded, Price, UserId) " +
                                                "VALUES (@Name, @Type, @DateAdded, @Price, @UserId)", con);

                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Type", product.Type);
                cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@UserId", product.UserId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteProduct(int productId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = @ProductId", con);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Products SET Name = @Name, Type = @Type, " +
                                                "DateAdded = @DateAdded, Price = @Price WHERE ProductId = @ProductId", con);

                cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Type", product.Type);
                cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                cmd.Parameters.AddWithValue("@Price", product.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
