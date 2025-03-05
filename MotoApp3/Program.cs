using MotoApp3.Repositories;
using MotoApp3.Entities;
using System.ComponentModel.DataAnnotations;
using MotoApp3.Data;
using Microsoft.EntityFrameworkCore;

//var employeRepository = new GenericRepository<Employee>();


var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());
string name2 = null;

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

Console.Clear();
GetEmployeeById(sqlRepository);
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


Console.ReadLine();


