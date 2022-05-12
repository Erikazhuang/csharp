using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SecApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using HtmlAgilityPack;

namespace SecEdgar
{
    public class Person
    {
        private int _id;
        private string _name;

        private int _age;

        private List<Person> _friends;

        public int Id{
            set{_id =value;}
            get{ return _id;}
        }

        
        public int Age{
            set{_age =value;}
            get{ return _age;}
        }


        public string Name{
            set{_name =value;}
            get{ return _name;}
        }

        public Person(int id, string name)
        {
            _id= id;
            _name = name;
        }

        public List<Person> Friends{
            get {
                if (_friends==null)
                    _friends = new List<Person>();

                return _friends;
            }
            set
            {
                _friends = value;
            }
        }


        public void AddFriend(Person person){
           if ( !this.Friends.Contains(person))
            this.Friends.Add(person);
           else{
               //return exception friend already
               throw new ApplicationException("Person already in friend list.");
           }
        }


    }


    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string APIKey = "f31a6c4efa00c34de0bc6cfc0571e675d952197274155eb9a639532fc8984eac";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello SecEdgar!");
           
            //var result = await SecApiQuery();
            //GetHoldingInFilings(result);

            //System.Console.WriteLine(result);
          
            //await ProcessRepositories();
            //string response = await secApiClient.GetCompanyAsync("1318605");
            //System.Console.WriteLine(response);
            //string response = await DownloadUrl();
           //System.Console.WriteLine(response);
         
            // From Web
            // var url = "http://localhost/ming/Untitled-1.html";
            // var web = new HtmlWeb();
            // var doc = web.Load(url);
            // string content = doc.GetElementbyId("rescontent").InnerText;
            // File.WriteAllText(@"C:\tmp\1.txt",content);
            //PersonTest();
        //    Queue<string> numbers = new Queue<string>();
        //     numbers.Enqueue("one");
        //     numbers.Enqueue("two");
        //     numbers.Enqueue("three");
        //     numbers.Enqueue("three");
        //     numbers.Enqueue("four");
        //     numbers.Enqueue("five");

        //     foreach( string number in numbers )
        //     {
        //         Console.WriteLine(number);
        //     }

        //     Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
        //     Console.WriteLine("Peek at next item to dequeue: {0}",
        //         numbers.Peek());
        //     Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());

        //     Console.WriteLine("\numbers.Contains(\"four\") = {0}", numbers.Contains("four"));

        //     Queue<string> uniqueQueue = new Queue<string>(numbers.Distinct().ToArray<string>());
        //     foreach(var s in uniqueQueue)
        //         System.Console.WriteLine(s);
            //queueCopy.Clear();

            string teststring="tet";

            System.Console.WriteLine( (String.IsNullOrEmpty(teststring) ) ?  "is null" : teststring);

        }

        public class Node{
            public string name;
            public Node[] children;
        }

        void testArray()
        {
             int[] arr1 = {1,4,5,8,10,3};
            int[] arr2 = {5,7,9,1,3,0};
            int[] commonArray = arr1.Intersect(arr2).ToArray();

            ArrayList alist = new ArrayList();
            alist.AddRange(commonArray);
            alist.Sort();
            foreach(var a in alist)
            {
                System.Console.WriteLine(a);
          }
        }

        static async Task<string> DownloadUrl()
        {
            string url = @"http://localhost/ming/Untitled-1.html";
            string tmpfile = Path.GetTempFileName();
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                using (var fileStream = File.Create(tmpfile))
                {
                    streamToReadFrom.Seek(0, SeekOrigin.Begin);
                    streamToReadFrom.CopyTo(fileStream);
                    fileStream.Close();
                }
            }

            return tmpfile;
        }

        static void PersonTest()
        {
            Person person = new Person(1,"a");
            Person friend1 = new Person(2,"b");
            Person friend2 = new Person(3,"c");
            Person friend3 = new Person(4,"d");

            person.AddFriend(friend1);
            person.AddFriend(friend3);
            friend1.AddFriend(friend2);

            foreach(var f in person.Friends)
            {
                System.Console.WriteLine(person.Name + " is friend with " + f.Name);
            }

            int count = 0;
            System.Console.WriteLine("Is a and b friend? " + IsFriend(person, friend1,ref count));
            System.Console.WriteLine(count);
            System.Console.WriteLine("Is a and c friend? " + IsFriend(person, friend2,ref count));
            System.Console.WriteLine(count);
            System.Console.WriteLine("Is c and d friend? " + IsFriend(friend2, friend3,ref count));
            System.Console.WriteLine(count);
           
        }

        static bool IsFriend(Person p1, Person p2, ref int count)
        {
            count++;
            if (p1.Friends.Contains(p2))
                return true;

            foreach(Person l in p1.Friends)
            {
                return IsFriend(l,p2, ref count);
            }

            return false;
        }

           static async Task<string> LiveStream()
        {
            return "";
        }

        static async Task<string> XbrlToJson()
        {
            return "";
        }

        static async Task<string> SecApiQuery()
        {
             Client secApiClient = new Client(APIKey,"https://api.sec-api.io");
            //secquery options:
            //Find all SEC filings filed by the companies with CIK 1176334, 1413898 and 99780.
            //"cik:(1176334 OR 1413898 OR 99780)"
            //
            // 10-Q forms: "formType:\"10-Q\""  
            //
            //Return the most recently filed 8-K filings that include item 9.01 (financial statements and exhibits
            //"formType:\"8-K\" AND description:\"9.01\""
            //
            //List the most recent SEC filings filed by Apple using the ticker search expression.
            //"ticker:AAPL"
            //
            //all company filing that has holdings in APPLE cusip 037833100
            //"holdings.cusip:037833100 AND formType:\"13F\" "
             string secquery = "holdings.cusip:037833100 AND formType:\"13F\" ";
            JObject query = new JObject{
                new JProperty("query",
                    new JObject(
                        new JProperty("query_string",
                            new JObject(
                                new JProperty( "query",secquery )
                            )
                        )
                    ) ),
                new JProperty("from","0" ),
                new JProperty("size","2" ),
                new JProperty("sort",
                    new JArray(
                        new JObject{
                            new JProperty(
                                "filedAt", 
                                new JObject{
                                    new JProperty("order","desc")
                                }
                            )
                        }
                    )
                 )
            };
            string strQuery =  query.ToString();

            //string response = await secApiClient.GetCompanyAsync("1318605");
            //System.Console.WriteLine(strQuery);

            string response = await secApiClient.FindCompaniesAsync(strQuery);

            //System.Console.WriteLine(response);
   
           return response;

        }

        // private static List<Holding> GetHoldings(Filing filing)
        // {
                    
        //    dynamic jObj = JObject.Parse(jsonResponse);
        //    JArray jArray = (JArray)jObj["filings"][0]["holdings"];

        //    List<Holding> holdings = jArray.ToObject<List<Holding>>();

        //    return holdings;
        // }

        private static void GetHoldingInFilings(string jsonResponse)
        {
                    
           dynamic jObj = JObject.Parse(jsonResponse);
           JArray jArray = (JArray)jObj["filings"];
        
           for(int i = 0; i < jArray.Count; i ++)
           {
            JValue c = (JValue)jObj["filings"][i]["companyName"]; 
            System.Console.WriteLine("----------------- Filing company: " + c.ToString() + " -----------------");
            JArray j = (JArray)jObj["filings"][i]["holdings"];
            List<Holding> holdings = j.ToObject<List<Holding>>();
            int counter = 0;
            foreach(Holding h in holdings)
            {                
                System.Console.WriteLine(counter + ": " +h.ToString());
                counter++;
            }
            System.Console.WriteLine(" ----------------- end of " + c.ToString()+ "-----------------" );
           }
  
        }

    }
}
