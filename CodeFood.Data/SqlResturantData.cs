using CodeFood.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeFood.Data
{
    public class SqlResturantData : IResturantData
    {
        public CodeToFoodDbContext Database { get; }

        public SqlResturantData(CodeToFoodDbContext database)
        {
            this.Database = database;
        }

        public Resturant Add(Resturant resturant)
        {
            this.Database.Add(resturant);
            return resturant;
        }

        public int Commit()
        {
            return this.Database.SaveChanges();
        }

        public Resturant Delete(int id)
        {
            var resturant = GetResturantById(id);
            if (resturant != null)
            {
                this.Database.Remove(resturant);
            }
            return resturant;
        }

        public Resturant GetResturantById(int id)
        {
            return this.Database.Resturants.Find(id);
        }

        public IEnumerable<Resturant> GetResturantsByName(string name)
        {
            return from r in Database.Resturants
                   where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   orderby r.Name
                   select r;
        }

        public Resturant Update(Resturant resturant)
        {
            var entity = Database.Resturants.Attach(resturant);
            entity.State = EntityState.Modified;
            return resturant;
        }

        public int GetCountOfResturants()
        {
            return Database.Resturants.Count();
        }
    }
}
