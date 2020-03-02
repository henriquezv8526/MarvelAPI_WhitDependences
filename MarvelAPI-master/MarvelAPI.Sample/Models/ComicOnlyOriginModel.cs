using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Sample.Models
{
    public class TextObject2
    {
        public string Type { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }

    public class Url2
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Series2
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Date2
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class Price2
    {
        public string Type { get; set; }
        public double Price { get; set; }
    }

    public class Thumbnail2
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Image2
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Item2
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class Creators2
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<Item2> Items { get; set; }
    }

    public class Characters2
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<ItemCharacters> Items { get; set; }
    }

    public class ItemCharacters
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class Item22
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Stories2
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<Item22> Items { get; set; }
    }

    public class Events2
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<object> Items { get; set; }
    }

    public class Data2
    {
        public int Id { get; set; }
        public int DigitalId { get; set; }
        public string Title { get; set; }
        public int IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public string ISBN { get; set; }
        public string UPC { get; set; }
        public string DiamondCode { get; set; }
        public string EAN { get; set; }
        public string ISSN { get; set; }
        public string Format { get; set; }
        public int PageCount { get; set; }
        public List<TextObject2> TextObjects { get; set; }
        public string ResourceURI { get; set; }
        public List<Url> Urls { get; set; }
        public Series2 Series { get; set; }
        public List<object> Variants { get; set; }
        public List<object> Collections { get; set; }
        public List<object> CollectedIssues { get; set; }
        public List<Date2> Dates { get; set; }
        public List<Price2> Prices { get; set; }
        public Thumbnail2 Thumbnail { get; set; }
        public List<Image2> Images { get; set; }
        public Creators2 Creators { get; set; }
        public Characters2 Characters { get; set; }
        public Stories2 Stories { get; set; }
        public Events2 Events { get; set; }
    }

    public class RootObject2
    {
        public object ContentEncoding { get; set; }
        public object ContentType { get; set; }
        public Data2 Data { get; set; }
        public int JsonRequestBehavior { get; set; }
        public object MaxJsonLength { get; set; }
        public object RecursionLimit { get; set; }
    }
}