using MotoApp3.Repositories.Extensions;
using MotoApp3.Repositories;
using MotoApp3.Entities;
using MotoApp3.Data;
using Microsoft.EntityFrameworkCore;

var sqlRepository = new SqlRepository<Employee>(new MotoAppDbContext());
var businesPartnerRepository = new SqlRepository<BusinesPartner>(new MotoAppDbContext());
string name2 = null;

AddEmplyess();
Console.Clear();
GetEmployeeById(sqlRepository);
Console.ReadLine();
AddEmployee(businesPartnerRepository);
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

void AddEmployee(IRepository<BusinesPartner> businesPartnerRepository)
{
    var businesPartners = new[]
    {
        new BusinesPartner { FirstName = "Jan", },
        new BusinesPartner { FirstName = "Krzysztof", },
        new BusinesPartner { FirstName = "Anna", },
        new BusinesPartner { FirstName = "Katarzyna", },
        new BusinesPartner { FirstName = "Piotr", },
        new BusinesPartner { FirstName = "Marek", },
    };

    businesPartnerRepository.AddBatch(businesPartners);

    Console.WriteLine("Lista partnerów biznesowych:\n" +
        "");
    int i = businesPartnerRepository.GetNumberId("listy Partnerów Biznesowych");

    foreach (var partner in businesPartnerRepository.GetAll())
    {
        Console.WriteLine(partner.ToString());
    }
}



Console.ReadLine();


