using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration ;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
//using Ubiety.Dns.Core;
using WebApplication2.Models;
using Response1 = WebApplication2.Models.Response1;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("GetEmployees_PerformanceHistory")]
        public List<string> Post1(List<string> id)
        {
            List<string> ResponseList = new List<string>();
            for (int j = 0; j < id.Count; j++)
            {
                try
                {
                    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                    //string newString = "'" + id + "'";

                    SqlDataAdapter da = new SqlDataAdapter($"EXEC Exercise_1_a_shreyash_kumar '{id[j]}';", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //Employee employee = new Employee();
                
                    List<Employee> employeeList = new List<Employee>();
                    Response1 response = new Models.Response1();
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Employee employee = new Employee();
                            employee.employee_code = Convert.ToString(dt.Rows[i]["employee_code"]);
                            employee.first_name = Convert.ToString(dt.Rows[i]["first_name"]);
                            employee.last_name = Convert.ToString(dt.Rows[i]["last_name"]);
                            employee.email_id = Convert.ToString(dt.Rows[i]["email_id"]);
                            employee.position_name = Convert.ToString(dt.Rows[i]["position_name"]);
                            employee.start_date1 = Convert.ToString(dt.Rows[i]["start_date1"]);
                            employee.days = Convert.ToString(dt.Rows[i]["days"]);
                            employee.office_name1 = Convert.ToString(dt.Rows[i]["office_name1"]);
                            employeeList.Add(employee);
                        }
                    }
                    if (employeeList.Count > 0)
                    {
                        ResponseList.Add(JsonConvert.SerializeObject(employeeList));
                    }
                    else
                    {
                        response.StatusCode = 100;
                        response.StatusMessage = "Data not found";
                        ResponseList.Add(JsonConvert.SerializeObject(employeeList));

                    }
                }
                catch (Exception ex)
                {
                    Response1 response = new Models.Response1();
                    response.StatusCode = 500;
                    response.StatusMessage = ex.Message;
                    ResponseList.Add(JsonConvert.SerializeObject(response));
                }
               
            }
            return ResponseList;

        }

        [HttpGet("GetEmployees_PerformanceHistory/{id}")]
        public string Get(string id)
        {
            try { 
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
            //string newString = "'" + id + "'";
            SqlDataAdapter da = new SqlDataAdapter($"EXEC Exercise_1_a_shreyash_kumar '{id}';", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Employee employee = new Employee();
            List<Employee> employeeList = new List<Employee>();
            Response1 response = new Models.Response1();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.employee_code = Convert.ToString(dt.Rows[i]["employee_code"]);
                    employee.first_name = Convert.ToString(dt.Rows[i]["first_name"]);
                    employee.last_name = Convert.ToString(dt.Rows[i]["last_name"]);
                    employee.email_id = Convert.ToString(dt.Rows[i]["email_id"]);
                    employee.position_name = Convert.ToString(dt.Rows[i]["position_name"]);
                    employee.start_date1 = Convert.ToString(dt.Rows[i]["start_date1"]);
                    employee.days = Convert.ToString(dt.Rows[i]["days"]);
                    employee.office_name1 = Convert.ToString(dt.Rows[i]["office_name1"]);
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
            catch(Exception ex) {
                Response1 response = new Models.Response1();
                response.StatusCode = 500;
                response.StatusMessage = ex.Message;
                return JsonConvert.SerializeObject(response);
            }

        }

        [HttpPost("Update_Position")]


        public string Post([FromBody] Position p)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                //string newString = "'" + id + "'";
                SqlCommand cmd = new SqlCommand($"EXEC Exercise_1_b_shreyash_kumar '{p.employee_id1}',{p.position_no1},'{p.start_date1}';", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
               // con.Close();
                Response1 response = new Response1();
                if (i > 0)
                {
                    try
                    {
                       // SqlConnection con1 = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                        //string newString = "'" + id + "'";
                        SqlDataAdapter da = new SqlDataAdapter($"EXEC Exercise_1_a_shreyash_kumar '{p.employee_id1}';", con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        //Employee employee = new Employee();
                        List<Employee> employeeList = new List<Employee>();
                       // Response1 response = new Models.Response1();
                        if (dt.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                Employee employee = new Employee();
                                employee.employee_code = Convert.ToString(dt.Rows[j]["employee_code"]);
                                employee.first_name = Convert.ToString(dt.Rows[j]["first_name"]);
                                employee.last_name = Convert.ToString(dt.Rows[j]["last_name"]);
                                employee.email_id = Convert.ToString(dt.Rows[j]["email_id"]);
                                employee.position_name = Convert.ToString(dt.Rows[j]["position_name"]);
                                employee.start_date1 = Convert.ToString(dt.Rows[j]["start_date1"]);
                                employee.days = Convert.ToString(dt.Rows[j]["days"]);
                                employee.office_name1 = Convert.ToString(dt.Rows[j]["office_name1"]);
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
                        Response1 response2 = new Models.Response1();
                        response2.StatusCode = 500;
                        response2.StatusMessage = ex.Message;
                        return JsonConvert.SerializeObject(response2);
                    }
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Not Added";

                }


            return JsonConvert.SerializeObject(response); ;
        }
            catch(Exception ex) { 
                Response1 response = new Models.Response1();
                response.StatusCode = 500;
                response.StatusMessage = ex.Message;
                return JsonConvert.SerializeObject(response); ;
            }

        }




        [HttpGet("Practice_leaders/{office_code}")]
        public string Get_Practice_leaders(string office_code)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("EmployeeAppCon").ToString());
                //string newString = "'" + id + "'";
                SqlDataAdapter da = new SqlDataAdapter($"EXEC Exercise_2_a_shreyash_kumar {office_code};", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //Employee employee = new Employee();
                List<Employee_p> employeeList = new List<Employee_p>();
                Response1 response = new Models.Response1();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Employee_p employee = new Employee_p();
                        employee.employee_code = Convert.ToString(dt.Rows[i]["employee_code"]);
                        employee.employee_name = Convert.ToString(dt.Rows[i]["employee_name"]);
                        employee.office_name = Convert.ToString(dt.Rows[i]["office_name"]);
                        //employee.email_id = Convert.ToString(dt.Rows[i]["email_id"]);
                        employee.position = Convert.ToString(dt.Rows[i]["position"]);
                        employee.practice_affiliation = Convert.ToString(dt.Rows[i]["practice_affiliation"]);
                        employee.practice_role= Convert.ToString(dt.Rows[i]["practice_role"]);
                      //  employee.office_name1 = Convert.ToString(dt.Rows[i]["office_name1"]);
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
