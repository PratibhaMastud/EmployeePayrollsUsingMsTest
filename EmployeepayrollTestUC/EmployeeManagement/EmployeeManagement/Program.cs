using EmployeeManagement.Model;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome employee Management Using TDD");
            SalaryDetailsModel salaryDetailsModel = new SalaryDetailsModel();
            //  SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel();
            Salary salary = new Salary();
            /* //salary.checkConnection();
             //Console.WriteLine(salary.getAllEmployee());
             // Console.WriteLine(count);
             salaryUpdateModel.EmployeeId = 101;
             salaryUpdateModel.EmployeeSalary = 300000.00;
             //salary.UpdateEmployeeSalary(salaryUpdateModel);
             //int count = salary.getEmployeeDataWithGivenRange();
             //Console.WriteLine(count);
             int countSal = salary.getCountSalary();
             Console.WriteLine(countSal);
             int counsum = salary.getSumSalary();
             Console.WriteLine(counsum);
             int countA = salary.getAverageSalary();
             Console.WriteLine(countA);
             int countMax = salary.getMaxSalary();
             Console.WriteLine(countMax);
             int countMin = salary.getMinSalary();
 */
            // Console.WriteLine(countMin);

            salaryDetailsModel.EmployeeId = 1;
            salaryDetailsModel.EmployeeName = "Pritesh";
            salaryDetailsModel.JobDiscription = "Finance";
            salaryDetailsModel.Month = "jan";
            salaryDetailsModel.EmployeeSalary = 600000.00;
            salaryDetailsModel.date = new DateTime(2018, 12, 11);
            salaryDetailsModel.CompanyId = 102;
            salaryDetailsModel.gender = 'M';
            salaryDetailsModel.SalaryId = 1;
            
            salary.AddNewEmployeeDEmo(salaryDetailsModel);


            /* //salary.addEmployee(salaryDetailsModel);
             //SalaryDetailsModel salaryModel = new SalaryDetailsModel();
             salaryModel.EmployeeId = 105;
             salaryModel.EmployeeName = "mahes";
             salaryModel.JobDiscription = "IT";
             salaryModel.Month = "march";
             salaryModel.EmployeeSalary = 35000;
             salaryModel.SalaryId = 405;
             salaryModel.date = new DateTime(2018, 09, 22);
             salaryModel.gender = 'M';*/

            /*

             Console.WriteLine("Employee payroll using thread ");
             string[] words = CreateWordArray(@"http://www.gutenberg.org/files/54700/54700-0.txt");
             #region ParallelTasks
             Parallel.Invoke(() =>
             {
                 Console.WriteLine("Being first task");
                 GetLongestWord(words);
             },
             () =>
             {
                 GetMostCommonWords(words);
             },
             () =>
             {
                 GetCountForWord(words, "sleep");
             }
             );

             #endregion
         }

         private static void GetCountForWord(string[] words, string term)
         {
             var findWord = from word in words
                            where word.ToUpper().Contains(term.ToUpper())
                            select word;
             Console.WriteLine($"Task 3 ----------the word ''''{term}'''' occors { findWord.Count()} times.");
         }

         private static void GetMostCommonWords(string[] words)
         {
             var orderfrequency = from word in words where word.Length > 6 group word by word into g orderby g.Count() descending select g.Key;
             var commonWords = orderfrequency.Take(30);
             StringBuilder strb = new StringBuilder();
             strb.Append("Task 2 is The most common word are");
             foreach (var v in commonWords)
             {
                 strb.AppendLine(" " + v);

             }
             Console.WriteLine(strb.ToString());
         }
         private static string GetLongestWord(string[] words)
         {
             var longestWord = (from w in words orderby w.Length descending select w).First();
             Console.WriteLine($"Task 1 ----The longest word is { longestWord}");
             return longestWord;
         }

         static string[] CreateWordArray(string url)
         {
             Console.WriteLine($"Retriving from{url}");
             string blog = new WebClient().DownloadString(url);
             return blog.Split(
                 new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '_', '/' },
                 StringSplitOptions.RemoveEmptyEntries);
         }*/
        }
    }
}
