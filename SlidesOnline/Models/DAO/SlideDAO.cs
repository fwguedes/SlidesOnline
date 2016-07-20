using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;





namespace SlidesOnline.Models.DAO
{
    public class SlideDAO
    {

        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public SlideDAO()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("test");
        }

        public void Deletar()
        {
            var collection = _database.GetCollection<BsonDocument>("Musicas");
            var filter = Builders<BsonDocument>.Filter.Eq("Titulo", "Musica Atualizada");
            var result = collection.DeleteOne(filter);
        }

        public void Atualizar()
        {
            var collection = _database.GetCollection<BsonDocument>("Musicas");
            var filter = Builders<BsonDocument>.Filter.Eq("Titulo", "Nova Musica");
            var update = Builders<BsonDocument>.Update.Set("Titulo", "Musica Atualizada");

            var result = collection.UpdateOne(filter, update);
        }

        public string Listar()
        {
            var collection = _database.GetCollection<BsonDocument>("Musicas");
            var filter = new BsonDocument();
            string retorno = "";
            using (var cursor = collection.FindSync<BsonDocument>(filter))
            {
                while (cursor.MoveNext())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        retorno += document["Titulo"].RawValue.ToString() + "  ";
                    }
                }
            }

            return retorno;


        }

        public void Inserir()
        {

            var document = new BsonDocument
            {
                {"Titulo", "Nova Musica" },
                {"Album", "Novo Album" },
                {"Artista", "Novo Artista" },
                {"Estrofes", new BsonArray {"Primeira Estrofe","Segunda Estrofe","Terceira Estrofe" } }
            };

            var collection = _database.GetCollection<BsonDocument>("Musicas");
            collection.InsertOne(document);
            
        }

    }
}