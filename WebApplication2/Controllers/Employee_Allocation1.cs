using Microsoft.AspNetCore.Mvc;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
//using Ubiety.Dns.Core;
using WebApplication2.Models;
using Response1 = WebApplication2.Models.Response1;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee_Allocation1 : ControllerBase
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public Employee_Allocation1(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("Active_Employees/{old_case_code}")]
        public string get(string old_case_code)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                //string newString = "'" + id + "'";
                SqlDataAdapter da = new SqlDataAdapter($"EXEC Exercise_3_c_shreyash_kumar '{old_case_code}';", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Employee employee = new Employee();
                List<Employee_Allocation4> employeeList = new List<Employee_Allocation4>();
                Response1 response = new Models.Response1();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Employee_Allocation4 employee = new Employee_Allocation4();
                        employee.employee_code = Convert.ToString(dt.Rows[i]["employee_code"]);
                        employee.full_name = Convert.ToString(dt.Rows[i]["full_name"]);
                        employee.office_name = Convert.ToString(dt.Rows[i]["office_name"]);
                        employee.Position_name = Convert.ToString(dt.Rows[i]["title"]);
                        employee.old_case_code = Convert.ToString(dt.Rows[i]["old_case_code"]);
                        employee.case_name = Convert.ToString(dt.Rows[i]["case_name"]);
                        employee.client_name = Convert.ToString(dt.Rows[i]["client_name"]);
                        employee.case_office_name = Convert.ToString(dt.Rows[i]["case_office_name"]);
                        employee.Allocation_start_date = Convert.ToString(dt.Rows[i]["Allocation_start_date"]);
                        employee.Allocation_end_date = Convert.ToString(dt.Rows[i]["Allocation_end_date"]);
                        employee.Allocation_pt = Convert.ToInt32(dt.Rows[i]["Allocation_pt"]);
                        employeeList.Add(employee);
                    }
                }
                if (employeeList.Count > 0)
                {
                    return JsonConvert.SerializeObject(employeeList);
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Data not found";
                    return JsonConvert.SerializeObject(response);

                }
            }
            catch (Exception ex)
            {
                Response1 response = new Models.Response1();
                response.StatusCode = 500;
                response.StatusMessage = ex.Message;
                return JsonConvert.SerializeObject(response);
            }
        }
        [HttpPost("Case_history")]
        public string post([FromBody] Employee_Allocation3 e)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                //string newString = "'" + id + "'";
                SqlDataAdapter da = new SqlDataAdapter($"EXEC Exercise_3_b_shreyash_kumar '{e.employee_code}','{e.start_date}','{e.end_date}';", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Employee employee = new Employee();
                List<Employee_Allocation4> employeeList = new List<Employee_Allocation4>();
                Response1 response = new Models.Response1();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Employee_Allocation4 employee = new Employee_Allocation4();
                        employee.employee_code = Convert.ToString(dt.Rows[i]["employee_code"]);
                        employee.full_name = Convert.ToString(dt.Rows[i]["full_name"]);
                        employee.office_name= Convert.ToString(dt.Rows[i]["office_name"]);
                        employee.Position_name = Convert.ToString(dt.Rows[i]["title"]);
                        employee.old_case_code = Convert.ToString(dt.Rows[i]["old_case_code"]);
                        employee.case_name = Convert.ToString(dt.Rows[i]["case_name"]);
                        employee.client_name = Convert.ToString(dt.Rows[i]["client_name"]);
                        employee.case_office_name = Convert.ToString(dt.Rows[i]["case_office_name"]);
                        employee.Allocation_start_date = Convert.ToString(dt.Rows[i]["Allocation_start_date"]);
                        employee.Allocation_end_date= Convert.ToString(dt.Rows[i]["Allocation_end_date"]);
                        employee.Allocation_pt = Convert.ToInt32(dt.Rows[i]["Allocation_pt"]);
                        employeeList.Add(employee);
                    }
                }
                if (employeeList.Count > 0)
                {
                    return JsonConvert.SerializeObject(employeeList);
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Data not found";
                    return JsonConvert.SerializeObject(response);

                }
            }
            catch (Exception ex)
            {
                Response1 response = new Models.Response1();
                response.StatusCode = 500;
                response.StatusMessage = ex.Message;
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpPost("Employee_Allocation")]
        public string Post([FromBody] Employee_Allocation2 e)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                //string newString = "'" + id + "'";
                SqlCommand cmd = new SqlCommand($"EXEC Exercise_3_a_shreyash_kumar '{e.employee_code1}','{e.old_case_code1}','{e.allocation_start_date1}','{e.allocation_end_date1}',{e.allocation_pt};", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                Response1 response = new Response1();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Success";
                    return JsonConvert.SerializeObject(response);
                }
                else
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Failure";
                    return JsonConvert.SerializeObject(response);
                }
            }
            catch (Exception ex)
            {
                Response1 response = new Response1();
                response.StatusCode = 500;
                response.StatusMessage = ex.Message;
                return JsonConvert.SerializeObject(response);
            }
        }

        [HttpPost("Employee_Status")]
        public string Get_Employee_Status([FromBody] Employee_Allocation3 e)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                //string newString = "'" + id + "'";
                SqlDataAdapter da = new SqlDataAdapter($"EXEC Exercise_3_d_shreyash_kumar '{e.employee_code}','{e.start_date}','{e.end_date}';", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Employee employee = new Employee();
                List<Employee_Allocation5> employeeList = new List<Employee_Allocation5>();
                Response1 response = new Models.Response1();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Employee_Allocation5 employee = new Employee_Allocation5();
                        employee.employee_code = Convert.ToString(dt.Rows[i]["employee_code"]);
                        employee.full_name = Convert.ToString(dt.Rows[i]["full_name"]);
                        employee.Allocation_pt = Convert.ToInt32(dt.Rows[i]["allocation_pt"]);
                        employee.Status = Convert.ToString(dt.Rows[i]["Status"]);

                        employeeList.Add(employee);
                    }
                }
                if (employeeList.Count > 0)
                {
                    return JsonConvert.SerializeObject(employeeList);
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Data not found";
                    return JsonConvert.SerializeObject(response);

                }
            }
            catch (Exception ex)
            {
                Response1 response = new Models.Response1();
                response.StatusCode = 500;
                response.StatusMessage = ex.Message;
                return JsonConvert.SerializeObject(response);
            }
        }




    }
}
