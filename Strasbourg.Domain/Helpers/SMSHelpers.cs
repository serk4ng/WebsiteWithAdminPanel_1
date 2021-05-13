using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Strasbourg.Domain.Helpers
{
    public class SMSHelpers
    { 

      

        public bool Send(string message, string phone, string username, string password, string sendername, string apilink)
        {
            String testXml = "<request>";
            testXml += "<authentication>";
            testXml += "<username>"+username+"</username>";
            testXml += "<password>"+password+"</password>";
            testXml += "</authentication>";
            testXml += "<order>";
            testXml += "<sender>"+sendername+"</sender>";
            testXml += "<message>";
            testXml += "<text>" + message + "</text>";
            testXml += "<receipents>";
            testXml += "<number>" + phone + "</number>";
            testXml += "</receipents>";
            testXml += "</message>";
            testXml += "</order>";
            testXml += "</request>";

            var result = XMLPOST(apilink, testXml);

            if (result == "-1")
            {
                return false;
            }

            return true;
        }

        public bool Send2(string apilink,string account, string login, string password, string from, string to, string message)
        {
            string apistring = apilink+"?&account="+account+"&login="+login+"&password="+password+"&from="+from+"&to="+to+ "&message="+message;

            HttpWebRequest _createRequest = (HttpWebRequest)WebRequest.Create(apistring);

            HttpWebResponse myResp = (HttpWebResponse)_createRequest.GetResponse();

            System.IO.StreamReader _responseStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = _responseStreamReader.ReadToEnd();
            _responseStreamReader.Close();
            myResp.Close();
            var test = myResp.GetResponseStream();
            var test2 = myResp.GetResponseHeader("status");
            var test3 = myResp.Headers; 
            

            if (myResp.StatusCode == HttpStatusCode.Continue || myResp.StatusCode == HttpStatusCode.SwitchingProtocols)
            {
                return true;
            }
            else
            {
                return false;
            }
         
        }

        private string XMLPOST(string PostAddress, string xmlData)
        {
            try
            {
                var res = "";
                byte[] bytes = Encoding.UTF8.GetBytes(xmlData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(PostAddress);

                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "text/xml";
                request.Timeout = 300000000;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format(
                        "POST failed. Received HTTP {0}",
                        response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    Stream responseStream = response.GetResponseStream();
                    using (StreamReader rdr = new StreamReader(responseStream))
                    {
                        res = rdr.ReadToEnd();
                    }
                    return res;
                }
            }
            catch
            {

                return "-1";
            }

        }


        /* ------------------- */

        //calcul du SHA1
        public static string HashSHA1(string sInputString)
        {
            SHA1Managed sha = new SHA1Managed();
            byte[] bHash = sha.ComputeHash(Encoding.UTF8.GetBytes(sInputString));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < bHash.Length; i++)
            {
                sBuilder.Append(bHash[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }



        public string sendSms(string appkey, string secret, string consumerkey,string servicename, string message, string phone)
        {
            String AK = appkey;
            String AS = secret;
            String CK = consumerkey;


            //Paramètres de la méthode appellée
            String ServiceName = servicename;
            String METHOD = "POST";
            String QUERY = "https://eu.api.ovh.com/1.0/sms/" + ServiceName + "/jobs";
            String BODY = @"{ ""charset"": ""UTF-8"", ""receivers"": [ """+phone+ @""" ], ""message"":  """ + message + @""" , ""priority"": ""high"",  ""senderForResponse"": true}";

            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            String TSTAMP = (unixTimestamp).ToString();


            String signature = "$1$" + HashSHA1(AS + "+" + CK + "+" + METHOD + "+" + QUERY + "+" + BODY + "+" + TSTAMP);
            Console.WriteLine(signature);

            //Création de la requete
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(QUERY);
            req.Method = METHOD;
            req.ContentType = "application/json";
            req.Headers.Add("X-Ovh-Application:" + AK);
            req.Headers.Add("X-Ovh-Consumer:" + CK);
            req.Headers.Add("X-Ovh-Signature:" + signature);
            req.Headers.Add("X-Ovh-Timestamp:" + TSTAMP);

            //Ecriture des paramètres BODY
            using (System.IO.Stream s = req.GetRequestStream())
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(s))
                    sw.Write(BODY);
            }

            try
            {
                //Récupération du résultat de l'appel
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)req.GetResponse();
                String[] l = null;
                using (var respStream = myHttpWebResponse.GetResponseStream())
                {
                    var reader = new StreamReader(respStream);
                    String result = reader.ReadToEnd().Trim();

                    myHttpWebResponse.Close();
                    return result;
                }
          
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                using (Stream data = ((HttpWebResponse)response).GetResponseStream())
                using (var reader = new StreamReader(data))
                {
           
                    return reader.ReadToEnd();
                }
            }
        }

    }
}
