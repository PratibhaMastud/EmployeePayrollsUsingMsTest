using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestSharpTest
{
    public class EmployeePayroll
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }

        public EmployeePayroll(string name, string salary)
        {
            this.Name = name;
            this.Salary = salary;
        }
        public static List<EmployeePayroll> EmployeeList()
        {
            List<EmployeePayroll> employees = new List<EmployeePayroll>();
            employees.Add(new EmployeePayroll("minal", "30000"));
            employees.Add(new EmployeePayroll("mahesh", "50000"));
            employees.Add(new EmployeePayroll("Ramesh", "50000"));
            employees.Add(new EmployeePayroll("umesh", "45000"));
            return employees;
        }
    }

    [TestClass]
    public class UnitTest1
    {
        RestClient client;

        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost:4000");
        }

        public IRestResponse GetEmployeePayrollList()
        {
            //arrange
            RestRequest request = new RestRequest("/EmployeePayroll", Method.GET);

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void byCallingGetApi_ReturnEmployeeList()
        {
            IRestResponse response = GetEmployeePayrollList();
            //assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<EmployeePayroll> listResponse = JsonConvert.DeserializeObject<List<EmployeePayroll>>(response.Content);
            Assert.AreEqual(4, listResponse.Count);
            foreach (EmployeePayroll e in listResponse)
            {
                System.Console.Write("id: " + e.id + "Employee Name: " + e.Name + "Salary: " + e.Salary);
            }
        }

        /// <summary>
        /// Here We adding new Employee
        /// </summary>
        [TestMethod]
        public void GivenEmployee_OnPost_ShouldReturnAddedEmployeePayroll()
        {
            RestRequest request = new RestRequest("/EmployeePayroll", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Name", "Imran");
            jObjectbody.Add("Salary", "90000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            EmployeePayroll employee = JsonConvert.DeserializeObject<EmployeePayroll>(response.Content);
            //Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Imran", employee.Name);
            Assert.AreEqual("90000", employee.Salary);
        }

        [TestMethod]
        public void GivenEmployee_OnPost_ShouldReturnMultipleAddedEmployee()
        {
            List<EmployeePayroll> list = EmployeePayroll.EmployeeList();
            foreach (EmployeePayroll e in list)
            {
                RestRequest request = new RestRequest("/employee", Method.POST);
                JObject jObjectbody = new JObject();
                jObjectbody.Add("name", e.Name);
                jObjectbody.Add("Salary", e.Salary);
                request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
                client.Execute(request);
            }
            IRestResponse responses = GetEmployeePayrollList();
            Assert.AreEqual(responses.StatusCode, HttpStatusCode.OK);
            List<EmployeePayroll> dataResponse = JsonConvert.DeserializeObject<List<EmployeePayroll>>(responses.Content);
            Assert.AreEqual(5, dataResponse.Count);
            foreach (EmployeePayroll e in dataResponse)
            {
                System.Console.Write("id: " + e.id + "Name: " + e.Name + "Salary: " + e.Salary);
            }
        }
    }
}
