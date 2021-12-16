using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApi.Models;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : Controller
    {

        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment _env;
        public EmployeeController(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.configuration = configuration;
            this._env = env;

        }   


        [HttpGet]
        public List<Employee> Listar()
        {
            List<Employee> employees = new List<Employee>();
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Employee_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeId = (int)dr["EmployeId"];
                    employee.EmployeeName = (string)dr["EmployeName"];
                    employee.Departament = (string)dr["Departament"];
                    employee.PhotoName = (string)dr["PhotoFileName"];

                    employees.Add(employee);
                }

                return employees;

            }


        }



        [HttpPost]
        public int insertar(Employee employee)
        {
            int n;
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Employee_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMPLOYEENAME", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@DEPARTAMENT", employee.Departament);
                cmd.Parameters.AddWithValue("@PHOTONAME", employee.PhotoName);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }


        [HttpPut]
        public int Actualizar(Employee employee)
        {
            int n;
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Employee_Actualizar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", employee.EmployeId);
                cmd.Parameters.AddWithValue("@EMPLOYEENAME", employee.EmployeeName);
                cmd.Parameters.AddWithValue("@DEPARTAMENT", employee.Departament);
                cmd.Parameters.AddWithValue("@PHOTONAME", employee.PhotoName);

                n = cmd.ExecuteNonQuery();
            }

            return n;
        }



        [HttpDelete("{id}")]
        public int Eliminar(int id)
        {
            int numero = -1;
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("SP_Employee_Delete", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@ID", id);
                numero = comando.ExecuteNonQuery();
            }
            return numero;
        }



        [Route("SaveFile")]
        [HttpPost]

        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {

                    postedFile.CopyTo(stream);

                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("NAME.PNG");
            }
        }

    }
}
