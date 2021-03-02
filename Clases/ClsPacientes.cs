using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Clases
{
    public class ClsPacientes : ClsConexion
    {
        public String aNif_Paciente;
        public String aMedico;

        public ClsPacientes()
        {
            this.aNif_Paciente = "";
            this.aMedico       = "";
        }

        public ClsPacientes(string pNif_Paciente, String pMedico)
        {
            this.aNif_Paciente = pNif_Paciente;
            this.aMedico       = pMedico;
        }

        public String MantenimientoPacientes(ClsPacientes pClspacientes, String pAccion)
        {
            String vResultado = "";
            if (this.Conectando())
            {
                try
                {
                    SqlConnection conectado = new SqlConnection(this.conexion);
                    conectado.Open();
                    SqlCommand coneccion = new SqlCommand();
                    coneccion.Connection = conectado;
                    coneccion.CommandType = CommandType.StoredProcedure;
                    coneccion.CommandText = "stp_MantenimientoPacientes";
                    coneccion.CommandTimeout = 10;
                    coneccion.Parameters.AddWithValue("@pNif_Paciente", pClspacientes.aNif_Paciente);
                    coneccion.Parameters.AddWithValue("@pMedico", pClspacientes.aMedico);
                    coneccion.Parameters.AddWithValue("@pAccion", pAccion);
                    coneccion.ExecuteNonQuery();
                    conectado.Close();
                    vResultado = "Ejecutado con exito";

                }
                catch (Exception Ex)
                {
                    vResultado = Ex.Message;
                }
            }
            return vResultado;
        }

        private DataSet dataTable = new DataSet();
        public DataSet GetListaPacientes(ClsPacientes pClspacientes, String pAccion)
        {
            try
            {
                SqlDataAdapter adapter;
                DataSet ds = new DataSet();
                SqlConnection conectado = new SqlConnection(this.conexion);
                conectado.Open();
                SqlCommand coneccion = new SqlCommand();
                coneccion.Connection = conectado;
                coneccion.CommandType = CommandType.StoredProcedure;
                coneccion.CommandText = "Stp_MantenimientoPacientes";
                coneccion.Parameters.AddWithValue("@pNif_Paciente", pClspacientes.aNif_Paciente);
                coneccion.Parameters.AddWithValue("@pMedico", pClspacientes.aMedico);
                coneccion.Parameters.AddWithValue("@pAccion", pAccion);
                adapter = new SqlDataAdapter(coneccion);
                adapter.Fill(dataTable);
                conectado.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
            return dataTable;
        }
    }
}
