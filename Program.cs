using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;

namespace MongoCRUDdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AddressBook"); //opens and connect tothe database or create the database 
           
            db.InsertRecord("Users",new PersonModel {FirstName="Yashen->" , LastName="Raveesha" }); //inserts to a table and a row "addressbook " alredy defines as the db and users table and record is mentioned here
         
            Console.ReadLine(); //passed the object and give values
        }
    }

    public class PersonModel                 //making the table/collection model or structure how data is stored
    {
        [BsonId]
        public  Guid Id { get; set; } //making the id as _id 
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

   
    public class MongoCRUD{

        private IMongoDatabase db; //Connection to database ctrl+. to import system if not written up 

        public MongoCRUD(string database) //making a constructor and passing database name 
        {
            var client = new MongoClient(); //client to use on mongodb , pass connection string
            db=client.GetDatabase(database); //initialize , get the database or create it
        }

        public void InsertRecord<T>(string table,T record) // insert function inside params contain collection and record
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        


    }
}
