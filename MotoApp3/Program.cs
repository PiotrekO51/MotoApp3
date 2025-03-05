using MotoApp3.Repositories;
using MotoApp3.Entities;
using MotoApp3.Data;
using Microsoft.EntityFrameworkCore;

var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());
//var sqlRepository2 = new SqlRepository<Employee>(new MotoAppDbContext());
string name2 = null;

AddEmplyess();
Console.Clear();
GetEmployeeById(sqlRepository);
Console.ReadLine();
AddEmployee(sqlRepository);
Console.WriteLine("\n" +
    "Koniec programu");

static void GetEmployeeById(IReadRepository<IEntity> sqlRepository)
{
    int i = sqlRepository.GetNumberId("listy Employee");
    for (int j = 1; j <= i; j++)
    {
        var emp = sqlRepository.GetById(j);
        Console.WriteLine(emp.ToString());
    }
}
void AddEmplyess()
{
    GetName("Podaj imię lub wciśnij X w celu wyjścia");

    while (name2 != "X")
    {
        sqlRepository.Add(new Employee
        {
            FirstName = name2
        });
        sqlRepository.Save();
        Console.Clear();
        GetName("Podaj ponownie imię lub wciśnij X w celu wyjścia");
    }
}

string GetName(string txt)
{
    Console.WriteLine(txt);
    string name = Console.ReadLine();

    while (name == null || name == " " || name == "")
    {

        Console.WriteLine("Brak wpisu lub znak pusty");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine(txt);
        name = Console.ReadLine();
    }
    name2 = char.ToUpper(name[0]) + name.Substring(1);
    return name2;
}


void AddEmployee(IRepository<Employee> sqlRepository)
{
    var employess = new[]
    {
        new Employee { FirstName = "Jan", },
        new Employee { FirstName = "Krzysztof", },
        new Employee { FirstName = "Anna", },
        new Employee { FirstName = "Katarzyna", },
        new Employee { FirstName = "Piotr", },
        new Employee { FirstName = "Marek", },
    };
    AddBatch(sqlRepository, employess);
    foreach (var emp in sqlRepository.GetAll())
    {
        Console.WriteLine(emp.ToString());
    }
}

static void AddBatch<T>(IRepository<T> repository, T[] items) where T : class, IEntity, new()
{
    foreach (var emp in items)
    {
        repository.Add(emp);
    }
    repository.Save();
}

Console.ReadLine();


