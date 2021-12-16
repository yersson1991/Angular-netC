using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApi.Models;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class DepartamentController : Controller
    {
        private readonly IConfiguration configuration;
        public DepartamentController(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        [HttpGet]
        public List<Departament> Listar()
        {


            List<Departament> departaments = new List<Departament>();
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Departament_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Departament departament = new Departament();
                    departament.DepartamentId = (int)dr["DepartamentId"];
                    departament.DepartamentName = (string)dr["DepartamentName"];
                    departaments.Add(departament);
                }


                return departaments;


            }



        }

        [HttpPost]
        public int insertar(Departament departament)
        {
            int n;
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Departament_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DEPARTAMENTNAME",departament.DepartamentName);
                n = cmd.ExecuteNonQuery();
            }
            return n;
        }

        [HttpPut]
        public int Actualizar(Departament departament)
        {
            int n ;
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SP_Departamet_Actualizar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DEPARTAMENTID", departament.DepartamentId);
                cmd.Parameters.AddWithValue("@DEPARTAMENTNAME", departament.DepartamentName);
                n = cmd.ExecuteNonQuery();
            }

            return n;
        }

        [HttpDelete("{id}")]
        public int Eliminar(int  id)
        {
            int numero=-1;
            string conexion = configuration.GetConnectionString("conex");
            using (SqlConnection con = new SqlConnection(conexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("SP_Departament_Delete", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@DEPARTAMENTID", id);
                numero = comando.ExecuteNonQuery();
            }
            return numero;
        }
    }
}
