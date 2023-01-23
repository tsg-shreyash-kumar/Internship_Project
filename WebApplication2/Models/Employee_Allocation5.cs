using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace WebApplication2.Models
{
    public class Employee_Allocation5
    {
        public string employee_code { get; set; }
        public string  full_name { get;set; }
        public int  Allocation_pt { get; set; }
        public string Status { get; set; }
    }
}
