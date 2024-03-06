using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MigrationDemo.BL;
using MigrationDemo.DAL.Model;
using AppContext = MigrationDemo.DAL.AppContext;

//получаем конфигурацию из файла  appsettings.json           


//using var db = new AppContext(options);

/*var firstName = new FirstName() { Name = "Yuriy" };
var lastName = new LastName() { Name = "Shubin" };

var person = new Person()
{
    FirstName = firstName,
    LastName = lastName
};

db.Persons.Add(person); 
db.SaveChanges();*/

var service = new AppService();
var persons = service.GetAllPersons();
foreach (var p in persons)
{
    Console.WriteLine($"{p.FullName}");
    foreach (var ph in p.Phones)
    {
        Console.WriteLine($"\t[{ph.Id}]: {ph.Number} <{ph.Type}>");
    }
}


