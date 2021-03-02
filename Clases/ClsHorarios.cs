using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Clases
{
    public class ClsHorarios : ClsConexion
    {
        public String aCodigoH;
        public String aDia;
        public String aJornada;
        public String aMedico;

        public ClsHorarios()
        {
            this.aCodigoH = "";
            this.aDia     = "";
            this.aJornada = "";
            this.aMedico  = "";
        }

        public ClsHorarios(string pCodigoH, String pDia, String pJornada, String pMedico)
        {
            this.aCodigoH = pCodigoH;
            this.aDia     = pDia;
            this.aJornada = pJornada;
            this.aMedico  = pMedico;
        }

        public String MantenimientoHorarios(ClsHorarios pClshorarios, String pAccion)
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
                    coneccion.CommandText = "Stp_MantenimientoHorarios";
                    coneccion.CommandTimeout = 10;
                    coneccion.Parameters.AddWithValue("@pCodigoH",pClshorarios.aCodigoH);
                    coneccion.Parameters.AddWithValue("@pDia", pClshorarios.aDia);
                    coneccion.Parameters.AddWithValue("@pJornada", pClshorarios.aJornada);
                    coneccion.Parameters.AddWithValue("@pMedico", pClshorarios.aMedico);
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
        public DataSet GetListaHorarios(ClsHorarios pClshorarios, String pAccion)
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
                coneccion.CommandText = "Stp_MantenimientoHorarios";
                coneccion.Parameters.AddWithValue("@pCodigoH", pClshorarios.aCodigoH);
                coneccion.Parameters.AddWithValue("@pDia", pClshorarios.aDia);
                coneccion.Parameters.AddWithValue("@pJornada", pClshorarios.aJornada);
                coneccion.Parameters.AddWithValue("@pMedico", pClshorarios.aMedico);
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
