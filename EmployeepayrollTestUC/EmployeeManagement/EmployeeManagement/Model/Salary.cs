using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeManagement.Model
{
    public class Salary
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocaldb;Initial Catalog=SalaryDetails;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connectionString);


        /// <summary>
        /// Checks the connection.
        /// </summary>
        public void checkConnection()
        {
            try
            {
                this.sqlConnection.Open();
                Console.WriteLine("connection established");
                this.sqlConnection.Close();
            }
            catch
            {
                Console.WriteLine("not established");
            }
        }

        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public int getAllEmployee()
        {
            try
            {
                int count = 0;
                SalaryDetailsModel employeeModel = new SalaryDetailsModel();
                using (this.sqlConnection)
                {
                    this.sqlConnection.Open();
                    using (SqlCommand fetch = new SqlCommand(@"Select * from SalaryDetailsModel ", this.sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = fetch.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                count++;
                                employeeModel.EmployeeId = sqlDataReader.GetInt32(0);
                                employeeModel.EmployeeName = sqlDataReader.GetString(1);
                                employeeModel.JobDiscription = sqlDataReader.GetString(2);
                                employeeModel.Month = sqlDataReader.GetString(3);
                                employeeModel.EmployeeSalary = (double)sqlDataReader.GetDecimal(4);
                                employeeModel.SalaryId = sqlDataReader.GetInt32(5);
                                Console.WriteLine("{0},{1},{2},{3},{4},{5}", employeeModel.EmployeeId, employeeModel.EmployeeName, employeeModel.JobDiscription, employeeModel.Month, employeeModel.EmployeeSalary, employeeModel.SalaryId);
                                Console.WriteLine("\n");
                            }
                        }
                    }
                }
                return count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }

        public double UpdateEmployeeSalary(SalaryUpdateModel model)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand command = new SqlCommand("StoreProUpdateSalary", sqlConnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
                    command.Parameters.AddWithValue("@EmployeeSalary", model.EmployeeSalary);
                    this.sqlConnection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Salary Updated Successfully !");
                }
                return model.EmployeeSalary;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                this.sqlConnection.Close();
            }
        }
    }
}

