namespace EmployeeDetaiIsIKFAssessment.DalLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using WebApplication1.Models;

    public class EmployeeDAL
    {

        private readonly string connectionString;
        public EmployeeDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public List<Employee> GetEmployees()
        {

            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Designation = reader["Designation"].ToString(),
                                Skills = reader["Skills"].ToString().Split(',').ToList()
                            });
                        }
                    }
                }
            }

            return employees;
        }

        public Employee GetEmployees(int Id)
        {
            Employee employee = new Employee();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Employees where Id = @Id", connection))
                {

                    cmd.Parameters.AddWithValue("@Id", Id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee = new Employee
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Designation = reader["Designation"].ToString(),
                                Skills = reader["Skills"].ToString().Split(',').ToList()
                            };
                        }
                    }
                }
            }

            return employee;
        }
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO Employees (Name, DOB, Designation, Skills) VALUES (@Name, @DOB, @Designation, @Skills)", connection))
                {
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                    cmd.Parameters.AddWithValue("@Skills", string.Join(",", employee.Skills));

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE Employees SET Name = @Name, DOB = @DOB, Designation = @Designation, Skills = @Skills WHERE Id = @Id", connection))
                {
                    cmd.Parameters.AddWithValue("@Id", employee.Id);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                    cmd.Parameters.AddWithValue("@Skills", string.Join(",", employee.Skills));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE Id = @Id", connection))
                {
                    cmd.Parameters.AddWithValue("@Id", employeeId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
