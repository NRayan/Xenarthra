using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Models;
using DAL;

namespace WebService
{
    /// <summary>
    /// Summary description for WS1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS1 : System.Web.Services.WebService
    {

        [WebMethod]
        public void InserirAnimal (Animais A)
        {
            animalDAL ADAL = new animalDAL();
            A = new Animais();

            ADAL.InserirAnimal(A);  
        }
        [WebMethod]
        public List<Animais> ConsultaAnimais()
        {
            animalDAL ADAL = new animalDAL();

            return ADAL.ListarAnimais();
        }
        [WebMethod]
        public Animais BuscarAnimalCodigo(int Codigo)
        {
            animalDAL ADAL = new animalDAL();
            Animais A = new Animais();

            A = ADAL.BuscarAnimalCodigo(Codigo);


            return A;
        }
    }
}
