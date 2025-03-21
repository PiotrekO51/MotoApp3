
using MotoApp3.Repositories.Extensions;
using MotoApp3.Repositories;
using MotoApp3.Entities.Extensions;
using MotoApp3.Entities;
using MotoApp3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Identity.Client;
using MotoApp3.DataProviders;
using System.Drawing;

namespace MotoApp3;

public class App : IApp
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IRepository<Car> _carsRepository;
    private readonly ICarsProvider _carsProvider;
    public App(IRepository<Employee> employeeRepository, MotoAppDbContext dbContext, IRepository<Car> carRepository,
        ICarsProvider carsProvider)

    {

        _employeeRepository = employeeRepository;
        _carsRepository = carRepository;
        _carsProvider = carsProvider;
        //_employeeRepository.ItemAded += EmployeeAdded;
        //_employeeRepository.ItemDeleted += EmployeeDeleted;
    }


    //void EmployeeAdded(object? item, Employee? e)
    //{
    //    Console.Clear();
    //    Console.WriteLine($"Dodano Nowego klienta => {e.FirstName}  {item.GetType().Name}");
    //    Thread.Sleep(100);
    //}
    //void EmployeeDeleted(object? item, Employee? e)
    //{
    //    Console.Clear();
    //    Console.WriteLine($"Usunięto klienta => {e.FirstName}  {item.GetType().Name}");
    //    Thread.Sleep(1000);
    //}
    public void RUN()
    {
        //{   //var itemAdded = new ListRepository<Employee>();
        //    //var employee = new ListRepository<Employee>();
        //    //void EmployeeAdded(object item)
        //    //{
        //    //    var itemAdded = (Employee)item;
        //    //    Console.Clear();
        //    //    Console.WriteLine($"Dodano nowego instalatora {itemAdded.FirstName}");
        //    //    Thread.Sleep(10);
        //    //}


        //    var businesPartners = new[]
        //    {
        //    new Employee { FirstName = "Jan", },
        //    new Employee { FirstName = "Krzysztof", },
        //    new Employee { FirstName = "Anna", },
        //    new Employee { FirstName = "Katarzyna", },
        //    new Employee { FirstName = "Piotr", },
        //    new Employee { FirstName = "Marek", },
        //    };

        //    foreach (var item in businesPartners)
        //    {
        //        _employeeRepository.Add(item);

        //    }

        //    _employeeRepository.Save();

        //    var bsinessPartners = _employeeRepository.GetAll();
        //    foreach (var item in businesPartners)
        //    {
        //        Console.WriteLine($"ID:{item.Id}  imię: {item.FirstName}");
        //    }

        //    _employeeRepository.GetNumberId("Długość Listy");

        //    Console.WriteLine("Podaj Id do usnięcia");
        //    int id = Convert.ToInt32(Console.ReadLine());
        //    _employeeRepository.Remove(businesPartners[id - 1]);

        //    var bP = _employeeRepository.GetAll();
        //    foreach (var item in bP)
        //    {
        //        Console.WriteLine($"ID:{item.Id}  imię: {item.FirstName}");
        //    }

        //    Console.WriteLine("Podaj nowe imię");
        //    string name = Console.ReadLine();
        //    _employeeRepository.InsertItem(id - 1, new Employee { Id = id, FirstName = name });
        //    _employeeRepository.Save();

        //    var bP2 = _employeeRepository.GetAll();


        //    foreach (var item in bP2)
        //    {
        //        Console.WriteLine($"ID:{item.Id}  imię: {item.FirstName}");
        //    }

        //Create Cars Repository

        var cars = GenerateSampelCars();
        foreach (var item in cars)
        {
            _carsRepository.Add(item);
        }
        _carsRepository.Save();
        Console.Clear();
        var carsList = _carsRepository.GetAll();

        foreach (var item in carsList)
        {
            Console.WriteLine(item.ToString());
        }
        // Console.Clear();

        //Console.WriteLine($"Podaj cenę Max \n" +
        //    $"");
        //string txt = Console.ReadLine();
        //decimal cost = Convert.ToDecimal(txt);
        //var minPrice = _carsProvider.FilterCars(cost);
        //Console.Clear();
        //Console.WriteLine();
        //Console.ForegroundColor = ConsoleColor.Green;
        //Console.WriteLine($"Lista samochodów z ceną = lub < {cost},- zł\n" +
        //    $"");
        //Console.ForegroundColor = ConsoleColor.Blue;
        //Console.WriteLine($"Lista zawiera  {minPrice.Count} samochodów \n" +
        //    $"");

        // foreach (var item in minPrice)
        // {
        //     Console.ForegroundColor = ConsoleColor.Red;
        //     Console.WriteLine(item.ToString());
        // }

        // decimal minPrice2 = decimal.MaxValue;
        // List<Car> cars3 = new();
        // List<Car> cars2 = minPrice;
        // foreach (var item in cars2)
        // {
        //     if (item.ListPrice < minPrice2)
        //     {
        //         minPrice2 = item.ListPrice;
        //         cars3.Add(item);
        //     }
        // }
        // Console.ForegroundColor = ConsoleColor.Green;
        // foreach (var item in cars3)
        // {
        //     Console.WriteLine(item.ToString());
        // }

        // Console.ForegroundColor = ConsoleColor.White;

        // var carColor = _carsProvider.GetUniqueCarsColors();
        // foreach (var item in carColor)
        // {
        //     Console.WriteLine(item);
        // }
        // var minProce = _carsProvider.GetMinimumPriceOfAllCars();
        // Console.WriteLine($"Najniższa cena samochodu wynosi: {minProce} zł\n" +
        //     $"");
        // Console.WriteLine($"Lista samochodów\n" +
        //  $"");
        // var specyficColumns = _carsProvider.GetSpecyficColumns();
        // foreach (var item in specyficColumns)
        // {
        //     Console.WriteLine(item.ToString2());
        // }
        // Console.ReadLine();
        // Console.Clear();
        // Console.WriteLine("Podaj początek nazwy samochodu\n" +
        //     $"");
        // string prefix = Console.ReadLine();
        // var carsOrderByName = _carsProvider.WhereStartsWith(prefix);
        // foreach (var item in carsOrderByName)
        // {
        //     Console.WriteLine(item.ToString());
        // }
        // Console.ReadLine();
        // Console.Clear();
        // Console.WriteLine("Podaj początek nazwy samochodu\n" +
        //$"");
        // string prefix2 = Console.ReadLine();
        // Console.WriteLine("Podaj koszt standardowy" +
        //    $"");
        // Console.WriteLine(" ");
        // string cost1 = Console.ReadLine();
        // decimal cost2 = Convert.ToDecimal(cost1);
        // var namePrice = _carsProvider.WhereStartsWithAndCostIsGreaterThan(prefix2, cost2);
        // foreach (var item in namePrice)
        // {
        //     Console.WriteLine(item.ToString());
        // }
        // Console.ReadLine();
        // Console.Clear();
        // Console.WriteLine(" ");
        // Console.WriteLine("Podaj kolor samochodu \n" +
        //$"");
        // string color = Console.ReadLine();

        // var carsColorName = _carsProvider.WhereColorIs(color);
        // foreach (var item in carsColorName)
        // {
        //     Console.WriteLine(item.ToString());
        // }

        //Console.WriteLine($"ilość pozycji: = {carsOrderByName.Count}");
        // Console.WriteLine("Podaj kolor samochodu \n" +
        //$"");
        // string color4 = Console.ReadLine();
        // string color5 = char.ToUpper(color4[0]) + color4.Substring(1);
        // var firstColor = _carsProvider.FirstOrDefaultByColorWithDefault(color5);
        // {
        //     Console.WriteLine(firstColor.ToString());
        //     Thread.Sleep(1000);
        // }
        // Console.WriteLine("Podaj kolor samochodu \n" +
        //$""); 
        // color4 = Console.ReadLine();
        // color5 = char.ToUpper(color4[0]) + color4.Substring(1);
        // var lastColor = _carsProvider.LastbyColor(color5);
        // {
        //     Console.WriteLine(lastColor.ToString());
        //     Thread.Sleep(1000);
        // }
        Console.WriteLine("Podaj Nazwę samochodu \n" +
      $"");
        string prefix = Console.ReadLine();
        Console.WriteLine("Podaj ID samochodu \n" +
       $"");
        string id = Console.ReadLine();
        int Id = 0;
        if (int.TryParse(id, out Id))
        {
            var singleId = _carsProvider.TakeCars(Id, prefix);
            {
                foreach (var item in singleId)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
        else
        {
            Console.WriteLine("Podaj poprawne Id");
            //  }
            //Console.WriteLine("Podaj Zakres dolny samochodów \n" +
            //$"");
            //string Id2 = Console.ReadLine();
            //int Id21 = int.Parse(Id2);
            //Console.WriteLine("Podaj zakres górny \n" +
            //$"");
            //string Id3 = Console.ReadLine();
            //int Id31 = int.Parse(Id3);
            //var range = _carsProvider.TakeCar((Id21 - 1)..Id31);
            //{
            //    foreach (var item in range)
            //    {
            //        Console.WriteLine(item.ToString());
            //    }

            //}
            Console.WriteLine("Podaj ilośc do wylistowania \n" +
        $"");
            string prefix4 = Console.ReadLine();
            int prefix5 = int.Parse(prefix4);
            var cars6 = _carsProvider.SkipCars(prefix5);
            {
                foreach (var item in cars6)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("Podaj wartoś dla CHUNK \n" +
            $"");
            string chunk = Console.ReadLine();
            int chunk1 = int.Parse(prefix4);
            var cars7 = _carsProvider.ChunkCars(chunk1);
            {
                foreach (var item in cars7)
                {
                    Console.WriteLine($"\n");
                    foreach (var item2 in item)
                    {
                        Console.WriteLine(item2.ToString());
                    }
                }
            }
        }

        static List<Car> GenerateSampelCars()
        {
            return new List<Car>
        {
            new Car
            {
                Id = 1,
                Name = ("abc_Porsche"),
                Color = "Balck",
                StandardCost = 123.50m,
                ListPrice = 188.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 2,
                Name = "abc_Porsche",
                Color = "White",
                StandardCost = 111.50m,
                ListPrice = 145.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 3,
                Name = "Volvo",
                Color = "Yellow",
                StandardCost = 177.50m,
                ListPrice = 222.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 4,
                Name = "abc_Fiat",
                Color = "Red",
                StandardCost = 88.50m,
                ListPrice = 122.50m,
                Type = "PickUp",
            },
            new Car
            {
                Id = 5,
                Name = "Opel",
                Color = "Blue",
                StandardCost = 95.50m,
                ListPrice = 133.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 6,
                Name = "abc_Opel",
                Color = "Magenta",
                StandardCost = 98.50m,
                ListPrice = 132.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 7,
                Name = "Ford",
                Color = "Blue",
                StandardCost = 111.50m,
                ListPrice = 134.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 8,
                Name = "Ford",
                Color = "Silver",
                StandardCost = 99.50m,
                ListPrice = 123.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 9,
                Name = "Ford",
                Color = "Balck",
                StandardCost = 99.50m,
                ListPrice = 136.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 10,
                Name = "Citroen",
                Color = "Balck",
                StandardCost = 101.50m,
                ListPrice = 137.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 11,
                Name = "abc_Renault",
                Color = "Red",
                StandardCost = 89.50m,
                ListPrice = 109.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 12,
                Name = "abc_Porsche",
                Color = "Blue",
                StandardCost = 144.50m,
                ListPrice = 166.50m,
                Type = "Combi",
            },
            new Car
            {
                Id = 13,
                Name = "BMW",
                Color = "Blue",
                StandardCost = 155.50m,
                ListPrice = 200.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 14,
                Name = "Mercedes",
                Color = "Red",
                StandardCost = 120.50m,
                ListPrice = 155.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 15,
                Name = "abc_Mercedes",
                Color = "White",
                StandardCost = 144.50m,
                ListPrice = 176.50m,
                Type = "Sedan",
            },
            new Car
            {
                Id = 16,
                Name = "Mercedes",
                Color = "Balck",
                StandardCost = 177.50m,
                ListPrice = 222.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 17,
                Name = "Ferrari",
                Color = "Red",
                StandardCost = 222.50m,
                ListPrice = 288.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 18,
                Name = "Lamborgini",
                Color = "Balck",
                StandardCost = 234.50m,
                ListPrice = 277.50m,
                Type = "Cabrio",
            },
            new Car
            {
                Id = 19,
                Name = ("abc_Porsche"),
                Color = "Purple",
                StandardCost = 123.50m,
                ListPrice = 188.50m,
                Type = "Cabrio",
            },

        };
        }

    }
}




