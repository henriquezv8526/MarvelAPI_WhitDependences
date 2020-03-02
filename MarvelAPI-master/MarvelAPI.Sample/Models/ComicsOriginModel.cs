using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelAPI.Sample.Models
{
    public class Url
    {
        public string Type { get; set; }
        public string Url2 { get; set; }
    }

    public class Series
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class Date
    {
        public string Type { get; set; }
        public DateTime Date2 { get; set; }
    }

    public class Price
    {
        public string Type { get; set; }
        public double Price2 { get; set; }
    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Creators
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<object> Items { get; set; }
    }

    public class Characters
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<object> Items { get; set; }
    }

    public class Item
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Stories
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Events
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<object> Items { get; set; }
    }

    public class ImagesDet
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class Datum
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
        public List<object> TextObjects { get; set; }
        public string ResourceURI { get; set; }
        public List<Url> Urls { get; set; }
        public Series Series { get; set; }
        public List<object> Variants { get; set; }
        public List<object> Collections { get; set; }
        public List<object> CollectedIssues { get; set; }
        public List<Date> Dates { get; set; }
        public List<Price> Prices { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public List<ImagesDet> Images { get; set; }
        public Creators Creators { get; set; }
        public Characters Characters { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
    }

    public class RootObject
    {
        public object ContentEncoding { get; set; }
        public object ContentType { get; set; }
        public List<Datum> Data { get; set; }
        public int JsonRequestBehavior { get; set; }
        public object MaxJsonLength { get; set; }
        public object RecursionLimit { get; set; }
    }
}