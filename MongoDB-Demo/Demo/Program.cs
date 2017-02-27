using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost");
            var db = client.GetDatabase("aa");
            var persons = db.GetCollection<User>("persondd");
            //var ss = db.GetCollection<BsonDocument>("ss");
            //ss.InsertOne(new BsonDocument(new Dictionary<string, object>() { {"aa","lldsa"} }));
            //ss.InsertOne(new BsonDocument(new Dictionary<string, object>() { {"bb","lldsa"}, { "cc","dsasda"} }));
            //persons.InsertOne(new User {Id = "b",Name = "worl"});
            for (int i = 0; i < 19; i++)
            {
                persons.InsertOne(new User { Name = "hello" + i, Id = i + "", NameId = Guid.NewGuid().ToString() });
            }
            var ssd = persons.FindSync(x => true).ToList();

            for (int i = 0; i < ssd.Count; i++)
            {
                Console.WriteLine(ssd[i]);
            }
            Console.WriteLine();
        }
    }

    class User
    {
        [BsonId]
        public string NameId { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
