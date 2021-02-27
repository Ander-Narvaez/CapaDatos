using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Clases
{
    class ClsMedicos : ClsConexion
    {
        public String   aNif_Medico;
        public DateTime aFecha_Alta;
        public DateTime aFecha_Baja;
        public String   aNum_Colegiado;
        public String   aEstatus;

        public ClsMedicos()
        {
            this.aNif_Medico    = "";
            this.aFecha_Alta    = DateTime.Today;
            this.aFecha_Baja    = DateTime.Today;
            this.aNum_Colegiado = "";
            this.aEstatus       = "";
        }

        public ClsMedicos(string pNif_Medico, DateTime pFecha_Alta, DateTime pFecha_Baja, String pNum_Colegiado, String pEstatus)
        {
            this.aNif_Medico    = pNif_Medico;
            this.aFecha_Alta    = pFecha_Alta;
            this.aFecha_Baja    = pFecha_Baja;
            this.aNum_Colegiado = pNum_Colegiado;
            this.aEstatus       = pEstatus;
        }


        public String MantenimientoMedicos(ClsMedicos pClsmedico, String pAccion)
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
                    coneccion.Parameters.AddWithValue("@pNif_Medico", pClsmedico.aNif_Medico);
                    coneccion.Parameters.AddWithValue("@pNombre_Completo", pClsmedico.aFecha_Alta);
                    coneccion.Parameters.AddWithValue("@pDireccion", pClsmedico.aFecha_Baja);
                    coneccion.Parameters.AddWithValue("@pTelefono", pClsmedico.aNum_Colegiado);
                    coneccion.Parameters.AddWithValue("@pPoblacion", pClsmedico.aEstatus);
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
        public DataSet GetListaPersonas(ClsMedicos pClsmedico, String pAccion)
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
                coneccion.CommandText = "Stp_MantenimientoMedicos";
                coneccion.Parameters.AddWithValue("@pNif_Medico", pClsmedico.aNif_Medico);
                coneccion.Parameters.AddWithValue("@pNombre_Completo", pClsmedico.aFecha_Alta);
                coneccion.Parameters.AddWithValue("@pDireccion", pClsmedico.aFecha_Baja);
                coneccion.Parameters.AddWithValue("@pTelefono", pClsmedico.aNum_Colegiado);
                coneccion.Parameters.AddWithValue("@pPoblacion", pClsmedico.aEstatus);
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
