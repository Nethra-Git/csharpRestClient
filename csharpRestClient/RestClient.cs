using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace csharpRestClient
{

    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }


    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }



        public RestClient()
        {

            endPoint = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            string strResponseValue = "http://data.fixer.io/api/latest?access_key=e893e2e8622b73546983d793c7af3643";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();           

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + response.StatusCode.ToString());
                }
                //Process the response stream... (could be JSON,XML or HTML etc..)

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }//End of StreamReader
                    }
                }//end of using ResponseStream

            }//end of using Response
            catch(Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally 
            {
                if(response != null)
                {
                    ((IDisposable)response).Dispose();
                }

            }

            return strResponseValue;
        }

    }
}
