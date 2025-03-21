using MotoApp3.Entities;

namespace MotoApp3.DataProviders;

public interface ICarsProvider
{
    List<Car> FilterCars(decimal minPrice);
    List<string> GetUniqueCarsColors();
    decimal GetMinimumPriceOfAllCars();
    List<Car> GetSpecyficColumns();
    string AnnonymousClass();

    // Order By

    List<Car> OrderByName();
    List<Car> OrderByNameDescending();
    List<Car> OrderByColorAndName();
    List<Car> OrderByColorAndNameDescending();

    //// Where
    List<Car> WhereStartsWith(string prefix);

    List<Car> WhereStartsWhenCostIsGreaterThan(decimal cost);
    List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost);

    List<Car> WhereColorIs(string prefix);

    // first last single

    Car FirstByColor(string color);
    Car FirstOrDefaultByColor(string color);

    Car FirstOrDefaultByColorWithDefault(string color);

    Car LastbyColor(string color);

    Car SingleById(int id);

    Car SingleOrDefault(int id);

    //Take

    List<Car> TakeCars(int howMany, string prefix);

    List<Car> TakeCar(Range range);

    List<Car> TakeWhileNameStartWith(string prefix);

    ////Skip
    List<Car> SkipCars(int howMany);

    List<Car> SkipCarsWhileNameStartsWith(string prefix);

    List<string> DistinctAllCollors();

    List<Car> DistinctByColors();

    List<Car[]> ChunkCars(int size);
}
