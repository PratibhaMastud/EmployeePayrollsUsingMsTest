﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

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
                    SqlCommand command = new SqlCommand("StoreUpdateSalary", sqlConnection);
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
        public int getEmployeeDataWithGivenRange()
        {
            try
            {
                int count = 0;
                SalaryDetailsModel employeeModel = new SalaryDetailsModel();
                using (this.sqlConnection)
                {
                    string query = @"select count(EmployeeName) from SalaryDetailsModel where date between cast('2010-01-01' as date) and CAST('2020-01-01' as date)";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return count;
                }
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

        /// <summary>
        /// Gets the Arithmetic Functions of salary.
        /// </summary>
        public int getSumSalary()
        {
            try
            {
                {
                    this.sqlConnection.Close(); int sum = 0;
                    SalaryDetailsModel employeeModel = new SalaryDetailsModel();
                    using (this.sqlConnection)
                    {
                        string query = @"select sum(EmployeeSalary) from  SalaryDetailsModel;";
                        SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                        this.sqlConnection.Open();
                        SqlDataReader sqlDataReader = cmd.ExecuteReader();
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                sum = (int)sqlDataReader.GetDecimal(0);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Data Found");
                        }
                        sqlDataReader.Close();
                        this.sqlConnection.Close();
                        return sum;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getAverageSalary()
        {
            try
            {
                int avg = 0;
                SalaryDetailsModel employeeModel = new SalaryDetailsModel();
                using (this.sqlConnection)
                {
                    string query = @"select avg(EmployeeSalary) from  SalaryDetailsModel where Gender =  'M';";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            avg = (int)sqlDataReader.GetDecimal(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return avg;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getMinSalary()
        {
            try
            {
                int min = 0;
                SalaryDetailsModel employeeModel = new SalaryDetailsModel();
                using (this.sqlConnection)
                {
                    string query = @"select min(EmployeeSalary) from  SalaryDetailsModel where Gender =  'M';";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            min = (int)sqlDataReader.GetDecimal(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return min;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getMaxSalary()
        {
            try
            {
                int max = 0;
                SalaryDetailsModel employeeModel = new SalaryDetailsModel();
                using (this.sqlConnection)
                {
                    string query = @"select max(EmployeeSalary) from  SalaryDetailsModel;";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            max = (int)sqlDataReader.GetDecimal(0);
                            Console.WriteLine(max);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                    return max;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getCountSalary()
        {
            try
            {
                int count = 0;
                SalaryDetailsModel employeeModel = new SalaryDetailsModel();    
                using (this.sqlConnection)
                {
                    string query = @"select count(EmployeeSalary) from  SalaryDetailsModel where Gender = 'M';";
                    SqlCommand cmd = new SqlCommand(query, this.sqlConnection);
                    this.sqlConnection.Open();
                    SqlDataReader sqlDataReader = cmd.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            count = sqlDataReader.GetInt32(0);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                    this.sqlConnection.Close();
                }
                return count;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool addEmployee(SalaryDetailsModel employeeModel)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("sp_insertDataRecord", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeModel.EmployeeId);
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@JobDiscription", employeeModel.JobDiscription);
                    cmd.Parameters.AddWithValue("@Month", employeeModel.Month);
                    cmd.Parameters.AddWithValue("@EmployeeSalary", employeeModel.EmployeeSalary);
                    cmd.Parameters.AddWithValue("@date", employeeModel.date);
                    cmd.Parameters.AddWithValue("@SalaryId", employeeModel.CompanyId);
                    cmd.Parameters.AddWithValue("@gender", employeeModel.gender);
                    cmd.Parameters.AddWithValue("@SalaryId", employeeModel.SalaryId);

                    this.sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
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

        public bool AddNewEmployeeWithSalary(SalaryModel salaryModel)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("sp_insertTwotable", sqlConnection);

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@SalaryId", salaryModel.SalaryId);
                    sqlCommand.Parameters.AddWithValue("@deductions", salaryModel.deduction);
                    sqlCommand.Parameters.AddWithValue("@taxable_pay", salaryModel.taxable_pay);
                    sqlCommand.Parameters.AddWithValue("@tax", salaryModel.tax);
                    sqlCommand.Parameters.AddWithValue("@net_salary", salaryModel.net_salary);

                    this.sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result == 0)
                    {
                        return false;
                    }
                    return true;
                }
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

        public double updateEmployeeSalary(SalaryDetailsModel employeeModel)
        {
            try
            {
                using (this.sqlConnection)
                {
                    SqlCommand cmd = new SqlCommand("StoreProUpdateSalary", this.sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeName", employeeModel.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeSalary", employeeModel.EmployeeSalary);
                    this.sqlConnection.Open();
                    var result = cmd.ExecuteNonQuery();
                    this.sqlConnection.Close();
                }
                return employeeModel.EmployeeSalary;
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

        public bool AddNewEmployeeDEmo(SalaryDetailsModel model)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_insertDataRecord", this.sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@EmployeeId", model.EmployeeId);
                command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                command.Parameters.AddWithValue("@JobDiscription", model.JobDiscription);
                command.Parameters.AddWithValue("@Month", model.Month);
                command.Parameters.AddWithValue("@EmployeeSalary", model.EmployeeSalary);
                command.Parameters.AddWithValue("@date", model.date);
                command.Parameters.AddWithValue("@CompanyId", model.CompanyId);
                command.Parameters.AddWithValue("@gender", model.gender);
                command.Parameters.AddWithValue("@SalaryId", model.SalaryId);


                this.sqlConnection.Open();
                command.ExecuteNonQuery();
                this.sqlConnection.Close();

                int SalaryId = model.EmployeeId;
                double deduction = model.EmployeeSalary * 0.2;
                double taxable_pay = model.EmployeeSalary - deduction;
                double tax = taxable_pay * 0.1;
                double net_salary = model.EmployeeSalary - tax;
                SqlCommand sqlCommand = new SqlCommand("sp_insertTwotable", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@SalaryId", (model.EmployeeId));
                sqlCommand.Parameters.AddWithValue("@deduction", (model.EmployeeSalary * 0.2));
                sqlCommand.Parameters.AddWithValue("@taxable_pay", (model.EmployeeSalary - deduction));
                sqlCommand.Parameters.AddWithValue("@tax", (taxable_pay * 0.1));
                sqlCommand.Parameters.AddWithValue("@net_salary", (model.EmployeeSalary - tax));
                this.sqlConnection.Open();
                var result1 = sqlCommand.ExecuteNonQuery();
                this.sqlConnection.Close();
                if (result1 == 0)
                {
                    return false;
                }
                return true;
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


