using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDatos.Clases
{
    public class ClsPersonas : ClsConexion
    {
        public String aNif;
        public String aNombre_Completo;
        public String aDireccion;
        public String aTelefono;
        public String aPoblacion;
        public String aProvincia;
        public int    aCodigo_Postal;
        public String aNum_Seguridad_Social;

        public ClsPersonas()
        {
            this.aNif                  = "";
            this.aNombre_Completo      = "";
            this.aDireccion            = "";
            this.aTelefono             = "";
            this.aPoblacion            = "";
            this.aProvincia            = "";
            this.aCodigo_Postal        = 0;
            this.aNum_Seguridad_Social = "";
            
        }

        public ClsPersonas(string pNif, String pNombre_Completo, String pDireccion, String pTelefono, String pPoblacion, String pProvincia, int pCodigo_Postal, String pNum_Seguridad_Social )
        {
            this.aNif                  = pNif;
            this.aNombre_Completo      = pNombre_Completo;
            this.aDireccion            = pDireccion;
            this.aTelefono             = pTelefono;
            this.aPoblacion            = pPoblacion;
            this.aProvincia            = pProvincia;
            this.aCodigo_Postal        = pCodigo_Postal;
            this.aNum_Seguridad_Social = pNum_Seguridad_Social;
        }

        public String MantenimientoPersona(ClsPersonas pClspersona, String pAccion)
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
                    coneccion.CommandText = "stp_MantenimientoPersonas"; 
                    coneccion.CommandTimeout = 10;
                    coneccion.Parameters.AddWithValue("@pNif", pClspersona.aNif);
                    coneccion.Parameters.AddWithValue("@pNombre_Completo", pClspersona.aNombre_Completo);
                    coneccion.Parameters.AddWithValue("@pDireccion", pClspersona.aDireccion);
                    coneccion.Parameters.AddWithValue("@pTelefono", pClspersona.aTelefono);
                    coneccion.Parameters.AddWithValue("@pPoblacion", pClspersona.aPoblacion);
                    coneccion.Parameters.AddWithValue("@pProvincia", pClspersona.aProvincia);
                    coneccion.Parameters.AddWithValue("@pCodigo_Postal", pClspersona.aCodigo_Postal);
                    coneccion.Parameters.AddWithValue("@pNum_seguridad_Social", pClspersona.aNum_Seguridad_Social);
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
        public DataSet GetListaPersonas(ClsPersonas pClspersona, String pAccion)
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
                coneccion.CommandText = "Stp_MantenimientoPersonas";
                coneccion.Parameters.AddWithValue("@pNif", pClspersona.aNif);
                coneccion.Parameters.AddWithValue("@pNombre_Completo", pClspersona.aNombre_Completo);
                coneccion.Parameters.AddWithValue("@pDireccion", pClspersona.aDireccion);
                coneccion.Parameters.AddWithValue("@pTelefono", pClspersona.aTelefono);
                coneccion.Parameters.AddWithValue("@pPoblacion", pClspersona.aPoblacion);
                coneccion.Parameters.AddWithValue("@pProvincia", pClspersona.aProvincia);
                coneccion.Parameters.AddWithValue("@pCodigo_Postal", pClspersona.aCodigo_Postal);
                coneccion.Parameters.AddWithValue("@pNum_seguridad_Social", pClspersona.aNum_Seguridad_Social);
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

