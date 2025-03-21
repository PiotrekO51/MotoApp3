using MotoApp3.DataProviders;
using MotoApp3.DataProviders.Extensions;
using MotoApp3.Entities;
using MotoApp3.Repositories;
using System;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
namespace MotoApp3.DataProvider;

public class CarsProvider : ICarsProvider
{
    private readonly IRepository<Car> _carsRepository;
    public CarsProvider(IRepository<Car> repository)
    {
        _carsRepository = repository;
    }


    public List<Car> FilterCars(decimal txt)
    {
        var cars = _carsRepository.GetAll();
        var list = new List<Car>();

        decimal minPrice = Convert.ToDecimal(txt);
        foreach (var car in cars)
        {
            if (car.ListPrice <= minPrice)
            {
                list.Add(car);
            }
        }
        return list;
    }

    public List<string> GetUniqueCarsColors()
    {
        var cars = _carsRepository.GetAll();
        var colors = cars.Select(c => c.Color).Distinct().ToList();
        return colors;
    }


    public decimal GetMinimumPriceOfAllCars(decimal car)
    {
        var cars = _carsRepository.GetAll();
        return cars.Select(c => c.ListPrice).Min();
    }

    public List<Car> GetSpecyficColumns()
    {
        var cars = _carsRepository.GetAll();
        var list = cars.Select(c => new Car
        {
            Id = c.Id,
            Name = c.Name,
            Color = c.Color,
            Type = c.Type,
        }).ToList();
        return list;
    }


    public string AnnonymousClass()
    {
        var cars = _carsRepository.GetAll();
        var list = cars.Select(c => new
        {
            Identifier = c.Id,
            ProductName = c.Name,
            ProductType = c.Type
        });

        StringBuilder sb = new(2024);
        foreach (var item in list)
        {
            sb.AppendLine($"ID: {item.Identifier}    ");
            sb.AppendLine($"    Product Name: {item.ProductName}");
            sb.AppendLine($"    Product Type: {item.ProductType} ");
        }
        return sb.ToString();
    }

    //Order By
    public List<Car> OrderByName()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(c => c.Name).ToList();
    }

    public List<Car> OrderByNameDescending()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderByDescending(c => c.Name).ToList();
    }

    public List<Car> OrderByColorAndName()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderBy(c => c.Color).
            ThenBy(c => c.Name).ToList();
    }

    public List<Car> OrderByColorAndNameDescending()
    {
        var cars = _carsRepository.GetAll();
        return cars.OrderByDescending(c => c.Color).
            ThenByDescending(c => c.Name).ToList();
    }

    //Where
    public List<Car> WhereStartsWith(string prefix)
    {
        var carsStartWith = _carsRepository.GetAll();
        return carsStartWith.Where(c => c.Name.StartsWith(prefix)).ToList();
    }

    public List<Car> WhereStartsWhenCostIsGreaterThan( decimal cost)
    {
        var carsStartWith = _carsRepository.GetAll();
        return carsStartWith.Where(c => c.StandardCost < cost).ToList();
    }
    public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix ,decimal cost)
    {
        var carsStartWith = _carsRepository.GetAll();
        return carsStartWith.Where(c => c.Name.StartsWith(prefix) && c.StandardCost < cost).ToList();
    }

    public List<Car> WhereColorIs(string color)
    {
        var carColor = _carsRepository.GetAll();
        return carColor.ByColor(color).ToList();
    }

    // first last single
    public Car FirstByColor(string color)
    {
        var carColor = _carsRepository.GetAll();
        return carColor.First(c => c.Color == color );
    }

    public Car ? FirstOrDefaultByColor(string color)
    {
        var carColor = _carsRepository.GetAll();
        return carColor.FirstOrDefault(c => c.Color == color );
    }

    public Car FirstOrDefaultByColorWithDefault(string color)
    {
        var carColor = _carsRepository.GetAll();
        return carColor.
            FirstOrDefault(
            c => c.Color == color,
            new Car { Id = 0, Color = color, Name = "COLOR NOT FOUND" });
    }
   
    public Car LastbyColor(string color)
    {
        var cars = _carsRepository.GetAll();
        return cars.LastOrDefault(
            c => c.Color == color,
            new Car { Id = 0, Color = color, Name = "COLOR NOT FOUND" });
    }

    public Car SingleById(int id)
    {
        var cars = _carsRepository.GetAll();
        return cars.Single(c => c.Id == id);
    }

    public Car SingleOrDefault(int id)
    {
        var cars = _carsRepository.GetAll();
        return cars.SingleOrDefault(c => c.Id == id,
            new Car { Id = 0,Name = "COLOR NOT FOUND" });
            
    }

    //Take

    public List<Car> TakeCars(int howMany)
    {
        var cares = _carsRepository.GetAll();
        return cares.OrderBy(c => c.Name)
            .Take(howMany)
            .ToList();
    }



    public List<Car> TakeCar(Range range)
    {
        var cares = _carsRepository.GetAll();
        return cares.OrderBy(c => c.Id)
            .Take(range)
            .ToList();

    }

    public List<Car> TakeWhileNameStartWith(string prefix)
    {
        var cares = _carsRepository.GetAll();
        return cares
            .OrderBy(c => c.Name)
            .TakeWhile(c => c.Name.StartsWith(prefix))
            .ToList();
    }
     //Skip
    public List<Car> SkipCars(int howMany)
    {
        var cares = _carsRepository.GetAll();
        return cares.OrderBy(c => c.Name)
            .Take(howMany)
            .ToList();
    }

    public List<Car> SkipCarsWhileNameStartsWith(string prefix)
    {
        var cares = _carsRepository.GetAll();
        return cares
            .OrderBy(c => c.Name)
            .SkipWhile(c => c.Name.StartsWith(prefix))
            .ToList();
    }

    // Distinct
    public List<string> DistinctAllCollors()
    {
        var cares = _carsRepository.GetAll();
        return cares
            .Select(c => c.Color)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }

    public List<Car> DistinctByColors()
    {
        var cares = _carsRepository.GetAll();
        return cares
            .DistinctBy(c => c.Color)
            .OrderBy(c => c.Color)
            .ToList();
    }

    public List<Car[]> ChunkCars(int size)
    {
        var cars = _carsRepository.GetAll();
        return cars.Chunk(size).ToList();
    }

    public decimal GetMinimumPriceOfAllCars()
    {
        throw new NotImplementedException();
    }


    
}
