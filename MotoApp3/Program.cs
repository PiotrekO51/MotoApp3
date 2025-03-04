using MotoApp3.Repositories;
using MotoApp3.Entities;
using System.ComponentModel.DataAnnotations;
using MotoApp3.Data;
using Microsoft.EntityFrameworkCore;

//var employeRepository = new GenericRepository<Employee>();


var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());

Console.WriteLine("Podaj imię");
string name = Console.ReadLine();
string name2 = char.ToUpper(name[0]) + name.Substring(1);

while (name2 != "Q")
{
    sqlRepository.Add(new Employee { FirstName = name2 });
    sqlRepository.Save();
    Console.Clear();
    Console.WriteLine("Podaj imię");
    name = Console.ReadLine();
    name2 = char.ToUpper(name[0]) + name.Substring(1);
}

Console.Clear();
int i = sqlRepository.GetNumberId("listy bucu");
for (int j = 1; j <= i; j++)
{
    var emp = sqlRepository.GetById(j);
    Console.WriteLine(emp.ToString());
}
Console.WriteLine();
foreach (var e in sqlRepository.GetAll())
{
    Console.WriteLine(e.ToString());

}

Console.WriteLine();

GetEmployeeById(sqlRepository);

static void GetEmployeeById(IReadRepository<IEntity> sqlRepository)
{
    int i = sqlRepository.GetNumberId("listy GetEmployee");
    for (int j = 1; j <= i; j++)
    {
        var emp = sqlRepository.GetById(j);
        Console.WriteLine(emp.ToString());
    }
}

Console.ReadLine();


