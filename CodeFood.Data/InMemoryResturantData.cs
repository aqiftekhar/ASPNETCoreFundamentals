using CodeFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFood.Data
{
    public class InMemoryResturantData : IResturantData
    {
        List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>()
            {
                new Resturant{Id = 1, Name = "McDonalds", Location = "Maryland", Cuisine=CuisineType.FastFood},
                new Resturant{Id = 2, Name = "Pizza Italian", Location = "Texas", Cuisine = CuisineType.Italian},
                new Resturant{Id = 3, Name = "Chicken Karahi", Location="Maryland", Cuisine = CuisineType.Pakistani},
                new Resturant{Id = 4, Name = "Stake", Location= "Houston", Cuisine= CuisineType.Mexican}

            };
        }
        public IEnumerable<Resturant> GetResturantsByName(string name)
        {
            return from r in resturants
                   where string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower())
                   orderby r.Name
                   select r;
        }
        public Resturant GetResturantById(int Id)
        {
            return resturants.SingleOrDefault(x => x.Id == Id);
        }

        public Resturant Add(Resturant resturant)
        {
            resturants.Add(resturant);
            resturant.Id = resturants.Max(x => x.Id) + 1;
            return resturant;
        }

        public Resturant Update(Resturant req)
        {
            var resturant = resturants.SingleOrDefault(x => x.Id == req.Id);
            if (resturant != null)
            {
                resturant.Name = req.Name;
                resturant.Location = req.Location;
                resturant.Cuisine = req.Cuisine;
            }
            return resturant;
        }

        public Resturant Delete(int id)
        {
            var resturant = resturants.FirstOrDefault(r =>  r.Id == id);
            if (resturant != null)
            {
                resturants.Remove(resturant);
            }
            return resturant;
        }
        public int Commit()
        {
            return 0;
        }

        public int GetCountOfResturants()
        {
            return resturants.Count();
        }
    }
}
