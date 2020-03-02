using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Sample.Models
{
    public class Url3
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Thumbnail3
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Item3
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Comics3
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<Item3> Items { get; set; }
    }

    public class Item23
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Stories3
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<Item23> Items { get; set; }
    }

    public class Item33
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Events3
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<Item33> Items { get; set; }
    }

    public class Item43
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Series3
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<Item43> Items { get; set; }
    }

    public class Data3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string ResourceURI { get; set; }
        public List<Url3> Urls { get; set; }
        public Thumbnail3 Thumbnail { get; set; }
        public Comics3 Comics { get; set; }
        public Stories3 Stories { get; set; }
        public Events3 Events { get; set; }
        public Series3 Series { get; set; }
    }

    public class CharacterModel
    {
        public object ContentEncoding { get; set; }
        public object ContentType { get; set; }
        public Data3 Data { get; set; }
        public int JsonRequestBehavior { get; set; }
        public object MaxJsonLength { get; set; }
        public object RecursionLimit { get; set; }
    }
   
}