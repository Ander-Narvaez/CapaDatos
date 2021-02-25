using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClsPersonas
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
    } //pruebaghdghgddhgnsdgnsnfsnsfx
}
