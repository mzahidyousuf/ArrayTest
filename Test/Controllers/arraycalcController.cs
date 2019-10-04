using System;
using System.Web;
using System.Web.Http;

namespace arraycalc.Controllers
{
    public class arraycalcController : ApiController
    {
        [AcceptVerbs("GET")]
        public IHttpActionResult reverse()
        {
            int[] ProdIds = null;
            try
            {
                if (!String.IsNullOrWhiteSpace(Request.RequestUri.Query)) //Get query string from Browser and checking null or white space.
                {
                    //split and convert string prod id to int
                    ProdIds = Array.ConvertAll(HttpUtility.ParseQueryString(Request.RequestUri.Query.Substring(1))["productIds"].Split(','), int.Parse);
                    for (int i = 0, j = ProdIds.Length - 1; i < j; i++, j--)
                    {
                        int c = ProdIds[i];
                        ProdIds[i] = ProdIds[j];
                        ProdIds[j] = c;
                    }
                    return Ok(ProdIds);
                }
            }
            catch (Exception ex) //Catch exception
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return NotFound();
        }

        [AcceptVerbs("GET")]
        public IHttpActionResult deletepart()
        {
            int[] ProdIds = null;
            int Deletepartpos;
            int i = 0;
            string Afterdeletepart = null;
            try
            {
                if (!String.IsNullOrWhiteSpace(Request.RequestUri.Query)) //Get query string from Browser and checking null or white space.
                {
                    //split and convert string prod id to int
                    ProdIds = Array.ConvertAll(HttpUtility.ParseQueryString(Request.RequestUri.Query.Substring(1))["productIds"].Split(','), int.Parse);
                    //Get  Delete Part position 
                    Deletepartpos = Convert.ToInt32(HttpUtility.ParseQueryString(Request.RequestUri.Query.Substring(0))["position"]);

                    for (i = Deletepartpos - 1; i < ProdIds.Length - 1; i++)
                    {
                        ProdIds[i] = ProdIds[i + 1];
                    }
                    for (i = 0; i < ProdIds.Length - 1; i++)
                    {
                        Afterdeletepart += ProdIds[i]+",";
                    }
                    return Ok(new[] { Afterdeletepart.Remove(Afterdeletepart.Length - 1) }); //concert String into Array and remove Last Comma
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return NotFound();
        }

        /// Testing Reverse and Delete part
        /// In this testing I am using Noraml Input not through Http

        public IHttpActionResult reversetest(string nonreverserstring)
        {
            int[] ProdIds = null;
            try
            {
                if (!String.IsNullOrWhiteSpace(nonreverserstring))
                {
                    ProdIds = Array.ConvertAll(nonreverserstring.Split(','), int.Parse);
                    for (int i = 0, j = ProdIds.Length - 1; i < j; i++, j--)
                    {
                        int c = ProdIds[i];
                        ProdIds[i] = ProdIds[j];
                        ProdIds[j] = c;
                    }
                    return Ok(ProdIds);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return NotFound();
        }

        public IHttpActionResult deleteparttest(string deletepartvalue, int deletepartpos)
        {
            int[] ProdIds = null;
            string deletepartafter = null;
            try
            {
                int i = 0;
                if (!String.IsNullOrWhiteSpace(deletepartvalue))
                {
                    ProdIds = Array.ConvertAll(deletepartvalue.Split(','), int.Parse);
                    for (i = deletepartpos - 1; i < ProdIds.Length - 1; i++)
                    {
                        ProdIds[i] = ProdIds[i + 1];
                    }
                    for (i = 0; i < ProdIds.Length - 1; i++)
                    {
                        deletepartafter += ProdIds[i] + ",";
                    }
                    return Ok(new[] { deletepartafter.Remove(deletepartafter.Length - 1) });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return NotFound();
        }
    }
}
