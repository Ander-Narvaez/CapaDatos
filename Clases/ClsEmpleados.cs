using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Clases
{
    public class ClsEmpleados : ClsConexion
    {
        public String aNif_Empleado;
        public String aPuesto_Empleado;

        public ClsEmpleados()
        {
            this.aNif_Empleado    = "";
            this.aPuesto_Empleado = "";
        }

        public ClsEmpleados(string pNif_Empleado, String pPuesto_Empleado)
        {
            this.aNif_Empleado    = pNif_Empleado;
            this.aPuesto_Empleado = pPuesto_Empleado;
        }

        public String MantenimientoMedicos(ClsEmpleados pClsempleado, String pAccion)
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
                    coneccion.CommandText = "stp_MantenimientoMedicos";
                    coneccion.CommandTimeout = 10;
                    coneccion.Parameters.AddWithValue("@pNif_Empleado", pClsempleado.aNif_Empleado);
                    coneccion.Parameters.AddWithValue("@pPuesto_Empleado", pClsempleado.aPuesto_Empleado);
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
        public DataSet GetListaMedicos(ClsEmpleados pClsempleado, String pAccion)
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
                coneccion.CommandText = "Stp_MantenimientoEmpleados";
                coneccion.Parameters.AddWithValue("@pNif_Empleado", pClsempleado.aNif_Empleado);
                coneccion.Parameters.AddWithValue("@pPuesto_Empleado", pClsempleado.aPuesto_Empleado);
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
