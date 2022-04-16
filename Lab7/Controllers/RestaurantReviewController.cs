using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab7.Models;
using Microsoft.AspNetCore.Cors;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab7.Controllers
{
    [EnableCors]
    [Route("[controller]")]
    [ApiController]
    public class RestaurantReviewController : ControllerBase
    {
        public Restaurants GetRestaurantReviewsFromXml()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.Namespace = "https://www.algonquincollege.com/cst8259/labs";


            string xmlFilePath = Path.GetFullPath("Data/restaurant_review.xml");
            Restaurants items = null;
            using (FileStream xs = new FileStream(xmlFilePath, FileMode.Open))
            {
                XmlSerializer serializor = new XmlSerializer(typeof(Restaurants));
                items = (Restaurants)serializor.Deserialize(xs);
            }

            return items;
        }
        public RestaurantInfo GetRestaurantInfo(RestaurantsRestaurant rest)
        {
            RestaurantInfo newRestaurant = new RestaurantInfo();

            Address newAddress = new Address();

            newAddress.city = rest.Address.city;
            newAddress.address = rest.Address.address;
            newAddress.postalcode = rest.Address.postalcode;
            newAddress.province = rest.Address.province;

            newRestaurant.Name = rest.Name;
            newRestaurant.Food = rest.Food;
            newRestaurant.Summary = rest.Summary;
            newRestaurant.Rating = rest.Rating.Value;
            newRestaurant.Price = rest.Price.Value;

            newRestaurant.address = newAddress;

            return newRestaurant;
        }

        [HttpGet]
        public List<RestaurantInfo> GetAllRestaurants()
        {
            Restaurants reviews = GetRestaurantReviewsFromXml();
            List<RestaurantInfo> restInfos = new List<RestaurantInfo>();
            int id = 0;
            foreach (RestaurantsRestaurant rest in reviews.Restaurant)
            {
                RestaurantInfo restInfo = GetRestaurantInfo(rest);
                restInfo.Id = id;
                restInfos.Add(restInfo);
                id++;
            }
            return restInfos;
        }

        [HttpGet("{id}")]
        public RestaurantInfo GetRestaurantById(int id)
        {
            List<RestaurantInfo> allOfThem = new List<RestaurantInfo>();

            Restaurants allRestaurantXml = GetRestaurantReviewsFromXml();

            int Id = 0;

            foreach (var item in allRestaurantXml.Restaurant)
            {
                RestaurantInfo newRestaurant = new RestaurantInfo();
                Address newAddress = new Address();
                Id = Id + 1;

                newAddress.city = item.Address.city;
                newAddress.address = item.Address.address;
                newAddress.postalcode = item.Address.postalcode;
                newAddress.province = item.Address.province;

                newRestaurant.Id = Id;
                newRestaurant.Name = item.Name;
                newRestaurant.Food = item.Food;
                newRestaurant.Summary = item.Summary;
                newRestaurant.Rating = item.Rating.Value;
                newRestaurant.Price = item.Price.Value;

                newRestaurant.address = newAddress;
                allOfThem.Add(newRestaurant);
            }

            RestaurantInfo theRestaurant = new RestaurantInfo();

            foreach (var item in allOfThem)
            {
                if (item.Id == id)
                {
                    theRestaurant.Id = item.Id;
                    theRestaurant.Name = item.Name;
                    theRestaurant.Food = item.Food;
                    theRestaurant.Summary = item.Summary;
                    theRestaurant.Rating = item.Rating;
                    theRestaurant.Price = item.Price;
                    theRestaurant.address = item.address;
                }
            }
            Id = 0;

            return theRestaurant;
        }

        [HttpPut]
        public Restaurants UpdateRestaurants([FromBody] RestaurantInfo restInfo)
        {
            int Id = restInfo.Id;

            Restaurants items = GetRestaurantReviewsFromXml();

            var curId = 0;
            foreach (var item in items.Restaurant)
            {
                if (Id == curId)
                {

                    string toString = restInfo.address.city;
                    item.Address.city = toString;
                    ProvinceType toString2 = restInfo.address.province;
                    item.Address.province = toString2;
                    string toString3 = restInfo.address.address;
                    item.Address.address = toString3;
                    string toString4 = restInfo.address.postalcode;
                    item.Address.postalcode = toString4;

                    item.Name = restInfo.Name;
                    item.Summary = restInfo.Summary;
                    item.Rating.Value = (byte)restInfo.Rating;
                }
                curId = curId + 1;

            }

            string xmlFilePath = Path.GetFullPath("Data/restaurant_review.xml");
            using (FileStream xs = new FileStream(xmlFilePath, FileMode.Create))
            {
                XmlSerializer serializor = new XmlSerializer(typeof(Restaurants));
                serializor.Serialize(xs, items);
            }

            return items;
        }
        
        [HttpPost]
        public bool SaveRestaurants (RestaurantInfo restInfo)
        {
            Restaurants items = GetRestaurantReviewsFromXml();

            List<Restaurants> restInfos = new List<Restaurants>();

            Restaurants newRest = new Restaurants();

            Restaurants restaurants = new Restaurants();

            foreach (var item in newRest.Restaurant)
            {

                string toString = restInfo.address.city;
                item.Address.city = toString;
                ProvinceType toString2 = restInfo.address.province;
                item.Address.province = toString2;
                string toString3 = restInfo.address.address;
                item.Address.address = toString3;
                string toString4 = restInfo.address.postalcode;
                item.Address.postalcode = toString4;

                item.Name = restInfo.Name;
                item.Summary = restInfo.Summary;
                item.Rating.Value = (byte)restInfo.Rating;
            }

            restInfos.Add(items);

            restInfos.Add(newRest);

            foreach (var item in restInfos)
            {
                restaurants = item;
            }

            string xmlFilePath = Path.GetFullPath("Data/restaurant_review.xml");
            using (FileStream xs = new FileStream(xmlFilePath, FileMode.Create))
            {
                XmlSerializer serializor = new XmlSerializer(typeof(Restaurants));
                serializor.Serialize(xs, items);
            }

            return true;
        }

        [HttpDelete("{id}")]
        public bool DeleteRestaurants(int Id)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();

            xRoot.Namespace = "https://www.algonquincollege.com/cst8259/labs";

            XmlSerializer serializator = new XmlSerializer(typeof(Restaurants), xRoot);

            string xmlFilePath = Path.GetFullPath("Data/restaurant_review.xml");

            FileStream xs = new FileStream(xmlFilePath, FileMode.Open);

            Restaurants items = (Restaurants)serializator.Deserialize(xs);

            List<Restaurants> restInfos = new List<Restaurants>();

            Restaurants restaurants = new Restaurants();

            xs.Close();

            restInfos.Add(items);

            restInfos.RemoveAt(Id);

            foreach (var item in restInfos)
            {
                restaurants = item;
            }

            XmlTextWriter tw = new XmlTextWriter(xmlFilePath, Encoding.UTF8);
            serializator.Serialize(tw, restaurants);
            tw.Close();

            return true;
        }
    }
}
