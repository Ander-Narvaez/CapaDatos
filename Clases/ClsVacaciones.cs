using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Clases
{
    public class ClsVacaciones : ClsConexion
    {
        public String aMedico;

        public ClsVacaciones()
        {
            this.aMedico = "";
        }

        public ClsVacaciones(string pMedico)
        {
            this.aMedico = pMedico;
        }

        public String MantenimientoVacaciones(ClsVacaciones pClsvacaciones, String pAccion)
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
                    coneccion.CommandText = "Stp_MantenimientoVacaciones";
                    coneccion.CommandTimeout = 10;
                    coneccion.Parameters.AddWithValue("@EMPLEADO", pClsvacaciones.aMedico);
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
        public DataSet GetListaVacaciones(ClsVacaciones pClsvacaciones, String pAccion)
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
                coneccion.CommandText = "Stp_MantenimientoVacaciones";
                coneccion.Parameters.AddWithValue("@pEMPLEADO", pClsvacaciones.aMedico);
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
