using System.IO;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Text.Json.Serialization;


namespace Tp10
{
    class Program
    {
        static void Main(string[] args){
            P1();
            P2();
           

        }
        static public void P1(){
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations"; 
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            Root ListCivi = JsonSerializer.Deserialize<Root>(responseBody);
                            
                            foreach (Civilization Civi in ListCivi.Civilizations)
                            {
                                Console.WriteLine("id: " + Civi.Id + " Nombre: " + Civi.Name + " Expansion : "+Civi.Expansion);
                            }

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }



        }
        static public void P2(){
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/structures"; 
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            RootStr Stru;
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                             Stru = JsonSerializer.Deserialize<RootStr>(responseBody);
                            
                            foreach (Structure i in Stru.Structures)
                            {
                                Console.WriteLine("id: " + i.Id + " Age: " + i.Age+ " Expansion : "+i.Expansion + " Name: " + i.Name);
                            }

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Problemas de acceso a la API");
            }


        }
    
    }
    
}