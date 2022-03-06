using CodeFood.Core;
using System;
using System.Collections.Generic;

namespace CodeFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetResturantsByName(string name);
        Resturant GetResturantById(int id);
        Resturant Add(Resturant resturant);
        Resturant Update(Resturant resturant);
        Resturant Delete(int id);
        int GetCountOfResturants();
        int Commit();
    }
}
