using System;
using System.Collections.Generic;
using System.IO;
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
        private List<Person> _friends;

        public int Id{
            set{_id =value;}
            get{ return _id;}
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
   
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello SecEdgar!");
           
            // From Web
            // var url = "http://localhost/ming/Untitled-1.html";
            // var web = new HtmlWeb();
            // var doc = web.Load(url);
            // string content = doc.GetElementbyId("rescontent").InnerText;
            // File.WriteAllText(@"C:\tmp\1.txt",content);
            PersonTest();
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

         



    }
}
