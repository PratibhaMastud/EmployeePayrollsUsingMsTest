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
            employees.Add(new EmployeePayroll("nalmi", "30000"));
            employees.Add(new EmployeePayroll("ahesh", "50000"));
            employees.Add(new EmployeePayroll("Ramu", "50000"));
            employees.Add(new EmployeePayroll("mesh", "45000"));
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
            Assert.AreEqual(6, listResponse.Count);
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
            jObjectbody.Add("Name", "Vidyadhar");
            jObjectbody.Add("Salary", "90000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            EmployeePayroll employee = JsonConvert.DeserializeObject<EmployeePayroll>(response.Content);
            //Employee dataResponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Vidyadhar", employee.Name);
            Assert.AreEqual("90000", employee.Salary);
        }

        [TestMethod]
        public void GivenEmployee_OnPost_ShouldReturnMultipleAddedEmployee()
        {
            List<EmployeePayroll> list = EmployeePayroll.EmployeeList();
            foreach (EmployeePayroll e in list)
            {
                RestRequest request = new RestRequest("/EmployeePayroll", Method.POST);
                JObject jObjectbody = new JObject();
                jObjectbody.Add("name", e.Name);
                jObjectbody.Add("Salary", e.Salary);
                request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
                client.Execute(request);
            }
            IRestResponse responses = GetEmployeePayrollList();
            Assert.AreEqual(responses.StatusCode, HttpStatusCode.OK);
            List<EmployeePayroll> dataResponse = JsonConvert.DeserializeObject<List<EmployeePayroll>>(responses.Content);
            Assert.AreEqual(15, dataResponse.Count);
            foreach (EmployeePayroll e in dataResponse)
            {
                System.Console.Write("id: " + e.id + "Name: " + e.Name + "Salary: " + e.Salary);
            }
        }

        [TestMethod]
        public void GivenEmployee_OnPut_ShouldReturnUpdatedEmpDetails()
        {
            RestRequest request = new RestRequest("/EmployeePayroll/4", Method.PUT);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("Name", "Prati");
            jObjectbody.Add("Salary", "45000");
            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            EmployeePayroll dataResponse = JsonConvert.DeserializeObject<EmployeePayroll>(response.Content);
            Assert.AreEqual("Prati", dataResponse.Name);
            Assert.AreEqual("45000", dataResponse.Salary);
            System.Console.WriteLine(response.Content);
        }

        [TestMethod]
        public void GivenEmployee_OnDelete_ShouldEmpDetails()
        {
            RestRequest request = new RestRequest("/EmployeePayroll/11", Method.DELETE);
            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            IRestResponse responses = GetEmployeePayrollList();
            Assert.AreEqual(responses.StatusCode, HttpStatusCode.OK);
            List<EmployeePayroll> dataResponse = JsonConvert.DeserializeObject<List<EmployeePayroll>>(responses.Content);
            Assert.AreEqual(14, dataResponse.Count);
            foreach (EmployeePayroll e in dataResponse)
            {
                System.Console.Write("id: " + e.id + "Name: " + e.Name + "Salary: " + e.Salary);
            }
        }
    }
}
