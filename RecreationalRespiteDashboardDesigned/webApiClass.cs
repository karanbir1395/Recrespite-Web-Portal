using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


using Newtonsoft.Json.Linq;
namespace RecreationalRespiteDashboardDesigned
    /*WebApi class makes connections (get/delete/put/patch) request with APIs to retrieve and populate the
     * model classes and the WebAPi methods are called in controllers to populate views.
     * 
     */
{
public class webApiClass
{
    public static JArray marker { get; set; }


    readonly string baseUri = "https://recrespite-3c13b.firebaseio.com/";
    public List<Models.articles> GetArticles()
    {
        string uri = baseUri + "articles/articles.json";


        List<Models.articles> artList = new List<Models.articles>();

        /* using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<Models.articles>>(response.Result).Result;
            }*/
        using (HttpClient httpClient = new HttpClient())
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/articles/articles/.json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse(data);


            //  var firstItem = o[0]["Title"]

            for (int i = 0; i < o.Count; i++)
            {
                Models.articles art = new Models.articles();
                if (o[i]["isDeleted"].ToString() == "1")
                {

                }
                else
                {
                    art.articleId = Convert.ToInt32(o[i]["articleId"]);
                    art.name = o[i]["name"].ToString();
                    art.articleImage = o[i]["articleImage"].ToString();
                    art.articlePDF = o[i]["articlePDF"].ToString();
                    art.description = o[i]["description"].ToString();
                    art.category = o[i]["category"].ToString();
                    artList.Add(art);
                }
            }


            return artList;

        }
    }
    public Models.articles GetArticle(int? id)
    {
        string uri = baseUri + "articles2/articles" + id + ".json";




        using (HttpClient httpClient = new HttpClient())
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/articles/articles/" + id + ".json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse("[" + data + "]");

            Models.articles art = new Models.articles();
            //  var firstItem = o[0]["Title"]


            art.articleId = Convert.ToInt32(o[0]["articleId"]);
            art.name = o[0]["name"].ToString();
            art.articleImage = o[0]["articleImage"].ToString();
            art.articlePDF = o[0]["articlePDF"].ToString();
            art.description = o[0]["description"].ToString();
            art.category = o[0]["category"].ToString();

            return art;



        }
    }

    public void insertArticle(string name, String image, String pdf, String description, String category)
    {
        List<Models.articles> test = new List<Models.articles>();
        test = GetArticles();
        int count = test.Count();
        int id = count;


        string ur = "https://recrespite-3c13b.firebaseio.com/articles/articles/" + id + ".json";
        String json = "{\"articleId\":" + count + ",\"articleImage\":\"" + image + "\",\"articlePDF\":\"" + pdf + "\",\"category\":\"" + category + "\",\"description\":\"" + description + "\",\"isDeleted\":0,\"name\":\"" + name + "\"}";


        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PUT", json);
        }
        Console.WriteLine(result);



    }

    public void editArticle(int id, string name, String image, String pdf, String description, String category)
    {
        List<Models.articles> test = new List<Models.articles>();
        test = GetArticles();
        // int testId = id;
        //id = id-1;

        string ur = "https://recrespite-3c13b.firebaseio.com/articles/articles/" + id + ".json";
        String json = "{\"articleId\":" + id + ",\"articleImage\":\"" + image + "\",\"articlePDF\":\"" + pdf + "\",\"category\":\"" + category + "\",\"description\":\"" + description + "\",\"name\":\"" + name + "\"}";


        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PATCH", json);
        }
        Console.WriteLine(result);



    }

    public void deleteArticle(int? id)
    {
        List<Models.articles> test = new List<Models.articles>();
        test = GetArticles();
        // int testId = id;
        //id = id-1;

        string ur = "https://recrespite-3c13b.firebaseio.com/articles/articles/" + id + ".json";
        String json = "{\"isDeleted\":1}";


        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PATCH", json);
        }
        Console.WriteLine(result);



    }

    //events

    public List<Models.events> GetEvents()
    {
        string uri = baseUri + "events/events.json";




        using (HttpClient httpClient = new HttpClient())
        {
            Task<String> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<List<Models.events>>(response.Result).Result;
        }

    }

    public Models.events GetEvent(int id)
    {

        string uri = baseUri + "events/events/" + id + ".json";




        using (HttpClient httpClient = new HttpClient())
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/events/events/" + id + ".json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse("[" + data + "]");

            Models.events ev = new Models.events();
            //  var firstItem = o[0]["Title"]

            ev.Id = Convert.ToInt32(o[0]["Id"]);
            ev.cost = o[0]["cost"].ToString();
            ev.date = o[0]["date"].ToString();
            ev.endTime = o[0]["endTime"].ToString();
            ev.eventImage = o[0]["eventImage"].ToString();
            ev.eventName = o[0]["eventName"].ToString();
            ev.region = o[0]["region"].ToString();
            ev.eventDescription = o[0]["eventDescription"].ToString();
            ev.location = o[0]["location"].ToString();
            ev.totalSeats = o[0]["totalSeats"].ToString();

            return ev;




        }

    }
    public void insertEvents(string cost, String date, String description, String image, String region, String name, String location, String startTime, String totalSeats, String endTime)
    {
        List<Models.events> test = new List<Models.events>();
        test = GetEvents();
        int count = test.Count();
        int id = count;

        // var file = api.UploadFile("dropbox", @"images\photo.jpg", @"C:\Pictures\photo.jpg");
        string ur = "https://recrespite-3c13b.firebaseio.com/events/events/" + id + ".json";

        String json = "{\"Id\":" + id + ",\"cost\":" + cost + ",\"date\": \"" + date + "\",\"endTime\": \"" + endTime + "\",\"eventDescription\": \"" + description + "\",\"eventImage\":\"" + description + "\",\"eventName\": \"" + name + "\",\"location\":\"" + location + "\",\"startTime\": \"" + startTime + "\",\"totalSeats\":\"" + totalSeats + "\",\"region\":\"" + region + "\"}";
        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PUT", json);
        }
        Console.WriteLine(result);



    }


    public void EditEvents(int id, string cost, String date, String region, String description, String image, String name, String location, String startTime, String totalSeats, String endTime)
    {
        List<Models.events> test = new List<Models.events>();
        test = GetEvents();

        string ur = "https://recrespite-3c13b.firebaseio.com/events/events/" + id + ".json";

        String json = "{\"Id\":" + id + ",\"cost\":" + Convert.ToInt32(cost) + ",\"date\":\"" + date + "\",\"endTime\":\"" + endTime + "\",\"eventDescription\":\"" + description + "\",\"eventImage\":\"" + image + "\",\"eventName\":\"" + name + "\",\"location\":\"" + location + "\",\"startTime\":\"" + startTime + "\",\"totalSeats\":\"" + totalSeats + "\",\"region\":\"" + region + "\"}";

        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PATCH", json);
        }
        Console.WriteLine(result);



    }

    public void deleteEvent(int id)
    {

        string ur = "https://recrespite-3c13b.firebaseio.com/events/events/" + id + ".json";


        using (var client = new HttpClient())
        {

            var response = client.DeleteAsync(ur).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
                Console.Write("Error");
            //  Console.WriteLine(result);



        }
    }

    //Diagnosis
    public List<Models.diagnosis> GetDiagnosis()
    {
        string uri = baseUri + "diagnosis/diagnosis/.json";




        using (HttpClient httpClient = new HttpClient())
        {
            Task<String> response = httpClient.GetStringAsync(uri);
            return JsonConvert.DeserializeObjectAsync<List<Models.diagnosis>>(response.Result).Result;
        }

    }
    public Models.diagnosis GetDiagnosises(int id)
    {





        using (HttpClient httpClient = new HttpClient())
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/diagnosis/diagnosis/" + id + ".json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse("[" + data + "]");

            Models.diagnosis art = new Models.diagnosis();
            //  var firstItem = o[0]["Title"]


            art.diagnosisId = Convert.ToInt32(o[0]["diagnosisId"]);
            art.name = o[0]["name"].ToString();

            return art;



        }
    }


    public void insertDiagnosis(string name)
    {
        List<Models.diagnosis> test = new List<Models.diagnosis>();
        test = GetDiagnosis();
        int count = test.Count();
        int id = count;
        string ur = "https://recrespite-3c13b.firebaseio.com/diagnosis/diagnosis/" + id + ".json";
        String json = "{\"diagnosisId\":" + id + ",\"name\":\"" + name + "\"}";



        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PUT", json);
        }
        Console.WriteLine(result);



    }

    public void EditDiagnosis(string name, int id)
    {


        string ur = "https://recrespite-3c13b.firebaseio.com/diagnosis/diagnosis/" + id + ".json";
        String json = "{\"diagnosisId\":" + id + ",\"name\":\"" + name + "\"}";



        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PUT", json);
        }
        Console.WriteLine(result);



    }
    public void deleteDiagnosis(int id)
    {

        string ur = "https://recrespite-3c13b.firebaseio.com/diagnosis/diagnosis/" + id + ".json";
        //  String json = "{\"articleId\":" + count + ",\"articleImage\":\"" + image + "\",\"articlePDF\":\"" + pdf + "\",\"description\":\"" + description + "\",\"name\":\"" + name + "\"}";

        using (var client = new HttpClient())
        {
            // client.BaseAddress = new Uri("http://localhost:1565/");    
            var response = client.DeleteAsync(ur).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.Write("Success");
            }
            else
                Console.Write("Error");
            //  Console.WriteLine(result);



        }

    }

    //regions

    public List<Models.regions> GetRegions()
    {
        string uri = baseUri + "regions/.json";

        List<Models.regions> regionList = new List<Models.regions>();


        /* using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObjectAsync<List<Models.regions>>(response.Result).Result;
            // List<Models.regions> t = new List<Models.regions>();
            // t= JsonConvert.DeserializeObjectAsync<List<Models.regions>>(response.Result).Result;



            }*/
        using (HttpClient httpClient = new HttpClient())
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/regions/.json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse(data);


            //  var firstItem = o[0]["Title"]

            for (int i = 0; i < o.Count; i++)
            {
                Models.regions reg = new Models.regions();
                if (o[i]["isDeleted"].ToString() == "1")
                {

                }
                else
                {


                    reg.regionId = Convert.ToInt32(o[i]["regionId"]);
                    reg.name = o[i]["name"].ToString();
                    regionList.Add(reg);


                }
            }


            return regionList;



        }
    }
    public Models.regions GetRegion(int id)
    {





        using (HttpClient httpClient = new HttpClient())
        {

            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/regions/" + id + ".json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse("[" + data + "]");

            Models.regions reg = new Models.regions();
            //  var firstItem = o[0]["Title"]


            reg.regionId = Convert.ToInt32(o[0]["regionId"]);
            reg.name = o[0]["name"].ToString();

            return reg;



        }
    }


    public void insertRegions(string name)
    {
        List<Models.regions> test = new List<Models.regions>();
        test = GetRegions();
        int count = test.Count();
        int id = count + 1;
        string ur = "https://recrespite-3c13b.firebaseio.com/regions/" + id + ".json";
        String json = "{\"isDeleted\":0,\"regionId\":" + id + ",\"name\":\"" + name + "\"}";



        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PUT", json);
        }
        Console.WriteLine(result);



    }

    public void EditRegion(string name, int id)
    {


        string ur = "https://recrespite-3c13b.firebaseio.com/regions/" + id + ".json";
        String json = "{\"regionId\":" + id + ",\"name\":\"" + name + "\"}";



        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PATCH", json);
        }
        Console.WriteLine(result);



    }
    public void deleteRegion(int id)
    {


        string ur = "https://recrespite-3c13b.firebaseio.com/regions/" + id + ".json";
        String json = "{\"isDeleted\":" + "1" + "}";



        string result = "";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            result = client.UploadString(ur, "PATCH", json);
        }
        Console.WriteLine(result);

    }



    public List<Models.registration> GetReg(int i)


    {
        using (HttpClient httpClient = new HttpClient())
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/events/events/"+i+".json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse("["+data+"]");


            //  var firstItem = o[0]["Title"]


               

            List <Models.registration> li= new List<Models.registration>();
            if (o[0]["registration"] == null)
            {
                return null;
            }
            else
            {
                dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(o[0]["registration"].ToString());

                var albums = x;
                JArray j = new JArray(albums);
                for (int k = 0; k < j.Count; k++)
                {
                    Models.registration art = new Models.registration();
                    art.id = k;
                    art.age = j[k]["age"].ToString();
                    art.name = j[k]["name"].ToString();
                    art.eventID = i;
                    art.location = j[k]["location"].ToString();
                    art.paymentType = j[k]["paymentType"].ToString();
                    art.phone = j[k]["phone"].ToString();
                    art.programOfInterest = j[k]["programOfInterest"].ToString();
                    art.recreationalInterest = j[k]["recreationalInterest"].ToString();
                    art.specialNeeds = j[k]["specialNeeds"].ToString();
                    art.username = j[k]["username"].ToString();
                    li.Add(art);

                }
                return li;
            }
            //   foreach (var album in albums)
            /*  {
                    var albumName = album.name;
                    //access album data;
                }*/

        }

    }
    public Models.registration GetRegById(int k,int eventID)


    {
        using (HttpClient httpClient = new HttpClient())
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("https://recrespite-3c13b.firebaseio.com/events/events/"+eventID+".json");
            //Console.WriteLine(data);
            JArray o = JArray.Parse("["+data+"]");


            //  var firstItem = o[0]["Title"]




            List<Models.registration> li = new List<Models.registration>();

            dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(o[0]["registration"].ToString());

            var albums = x;
            JArray j = new JArray(albums);
                
                Models.registration art = new Models.registration();
                art.id = k;
                art.age = j[k]["age"].ToString();
                art.eventID = eventID;
                art.name = j[k]["name"].ToString();
                art.location = j[k]["location"].ToString();
                art.paymentType = j[k]["paymentType"].ToString();
                art.phone = j[k]["phone"].ToString();
                art.programOfInterest = j[k]["programOfInterest"].ToString();
                art.recreationalInterest = j[k]["recreationalInterest"].ToString();
                art.specialNeeds = j[k]["specialNeeds"].ToString();
                art.username = j[k]["username"].ToString();
            return art;
            //   foreach (var album in albums)
            /*  {
                    var albumName = album.name;
                    //access album data;
                }*/

        }

    }


}
}