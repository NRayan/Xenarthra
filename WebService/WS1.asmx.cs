using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Models;
using DAL;
public struct Retorno
{
    public Animais A;
    public Aparicoes APA;

}

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
            aparicaoDAL APADAL = new aparicaoDAL();
            A = new Animais();
            Aparicoes APA = new Aparicoes();

            ADAL.InserirAnimal(A);
            APA.apa_ID_ANI = ADAL.BuscarCodUltimoAnimal();
            APADAL.InserirAparicao(APA);
        }
        [WebMethod]
        public List<Animais> ConsultaAnimais()
        {
            animalDAL ADAL = new animalDAL();

            return ADAL.ListarAnimais();
        }
        [WebMethod]

        public Retorno BuscarAnimalCodigo(int Codigo)
        {
            animalDAL ADAL = new animalDAL();
            aparicaoDAL APADAL = new aparicaoDAL();
            Retorno Ret = new Retorno();

            Ret.A = ADAL.BuscarAnimalCodigo(Codigo);
            Ret.APA = APADAL.BuscarAparicaoCodigoAnimal(Codigo);


            return Ret;
        }
    }
}
