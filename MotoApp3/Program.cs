using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.InMemory;
using MotoApp3.Data;
using MotoApp3;
using MotoApp3.DataProvider;
using MotoApp3.Entities;
using MotoApp3.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using MotoApp3.DataProvider;
using MotoApp3.DataProviders;



var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Car>, ListRepository<Car>>();
services.AddSingleton<IRepository<BusinesPartner>, ListRepository<BusinesPartner>>();
services.AddSingleton<ICarsProvider, CarsProvider>();
//services.AddSingleton<IEntiti, Car>();
services.AddDbContext<MotoAppDbContext>(options => options.UseInMemoryDatabase("StorageMotoApp3"));

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();

app.RUN();





//using MotoApp3.Repositories.Extensions;
//using MotoApp3.Repositories;
//using MotoApp3.Entities.Extensions;
//using MotoApp3.Entities;
//using MotoApp3.Data;
//using Microsoft.EntityFrameworkCore;


//var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());
//var businesPartnerRepository = new SqlRepository<BusinesPartner>(new MotoAppDbContext());
//sqlRepository.ItemAdded += EmployeeRepositoryOnItemAdded;
//businesPartnerRepository.ItemAdded += EmployeeRepositoryOnItemAdded2; ;
//string name2 = null;

//AddEmployess();
//Console.Clear();
//GetEmployeeById(sqlRepository);
//Console.ReadLine();
//AddEmployee(businesPartnerRepository);
//Console.WriteLine("\n" +
//    "Koniec programu");

//void EmployeeRepositoryOnItemAdded(object? item, Employee e)
//{
//    Console.SetCursorPosition(0, 1);
//    Console.WriteLine($"Dodano nowego pracownika => {e.FirstName} z ");
//    Console.SetCursorPosition(42, 2);
//    Console.WriteLine($":{item?.GetType().Name}");
//    Console.ReadLine();
//}

//void EmployeeRepositoryOnItemAdded2(object? item, BusinesPartner e)
//{

//    Console.Clear();
//    Console.SetCursorPosition(0, 1);
//    Console.WriteLine($"Dodano nowego pracownika => {e.FirstName} ");
//    Console.SetCursorPosition(38, 1);
//    Console.WriteLine($" z {item?.GetType().Name}");
//    Thread.Sleep(300);
//}

//void EmployeeAdded(object item)
//{
//    Console.Clear();
//    var employee = (Employee?)item;
//    Console.SetCursorPosition(0, 2);
//    Console.WriteLine($"{employee?.FirstName} :");
//    Console.SetCursorPosition(15, 2);
//    Console.WriteLine("Dodano nowego pracownika");
//    Thread.Sleep(1000);
//}
//static void EmployeeAdded2(object item)
//{
//    var busines = (BusinesPartner?)item;
//    Console.SetCursorPosition(0, busines.Id.Value + 1);
//    Console.WriteLine($"{busines?.FirstName} ");
//    Console.SetCursorPosition(15, busines.Id.Value + 1);
//    Console.WriteLine("Dodano nowego pracownika");
//    Thread.Sleep(250);
//}

//static void GetEmployeeById(IReadRepository<IEntity> sqlRepository)
//{
//    int i = sqlRepository.GetNumberId("listy Employee");
//    for (int j = 1; j <= i; j++)
//    {
//        var emp = sqlRepository.GetById(j);
//        Console.WriteLine(emp.ToString());
//    }
//}
//void AddEmployess()
//{
//    GetName("Podaj imię lub wciśnij X w celu wyjścia");

//    while (name2 != "X")
//    {
//        sqlRepository.Add(new Employee
//        {
//            FirstName = name2
//        });
//        sqlRepository.Save();
//        Console.Clear();
//        GetName("Podaj ponownie imię lub wciśnij X w celu wyjścia");
//    }
//}

//string GetName(string txt)
//{
//    Console.WriteLine(txt);
//    string name = Console.ReadLine();

//    while (name == null || name == " " || name == "")
//    {

//        Console.WriteLine("Brak wpisu lub znak pusty");
//        Thread.Sleep(1000);
//        Console.Clear();
//        Console.WriteLine(txt);
//        name = Console.ReadLine();
//    }
//    name2 = char.ToUpper(name[0]) + name.Substring(1);
//    return name2;

//}

//void AddEmployee(IRepository<BusinesPartner> businesPartnerRepository)
//{
//    var businesPartners = new[]
//    {

//        new BusinesPartner { FirstName = "Jan", },
//        new BusinesPartner { FirstName = "Krzysztof", },
//        new BusinesPartner { FirstName = "Anna", },
//        new BusinesPartner { FirstName = "Katarzyna", },
//        new BusinesPartner { FirstName = "Piotr", },
//        new BusinesPartner { FirstName = "Marek", },
//    };
//    Console.Clear();
//    businesPartnerRepository.AddBatch(businesPartners);
//    Thread.Sleep(2500);
//    Console.Clear();
//    Console.WriteLine("\n" +
//        "Lista partnerów biznesowych:\n" +
//        "");
//    int i = businesPartnerRepository.GetNumberId("listy Partnerów Biznesowych");

//    foreach (var partner in businesPartnerRepository.GetAll())
//    {
//        Console.WriteLine(partner.ToString());
//    }
//}
//Console.ReadLine();


