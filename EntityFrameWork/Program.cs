// See https://aka.ms/new-console-template for more information
using Azure;
using EntityFrameWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, Entity Framework!");



string dbFirst = "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=Persons;Integrated Security=True";

string codeFirst = "Data Source=(localdb)\\MSSQLLOcalDb;Initial Catalog=CodeFirst;Integrated Security=True";

//var op = CreateOptions<PersonsDbContext>(dbFirst);

//PersonsDbContext db = new PersonsDbContext(op.Options);

//Adding

//db.Persons.Add(new Person(Guid.NewGuid(), "Name3", "Surename3", 19));

//db.SaveChanges();

//Get

//var r = (from p in db.Persons where p.Name.Equals("Name1") select p).ToList();

//foreach (var item in r)
//{
//    Console.WriteLine(item);
//}

//Update

//var elem = (from p in db.Persons where p.Name.Equals("Name1") select p).First();

//elem.Age = 18;

//db.Update<Person>(elem);

//db.SaveChanges();

//Remove

//var elem = (from p in db.Persons where p.Name.Equals("Name1") select p).First();

//db.Remove<Person>(elem);

//db.SaveChanges();


#region Code First

var op2 = CreateOptions<PersonCodeFirstDataContext>(codeFirst);

PersonCodeFirstDataContext dbCd = new PersonCodeFirstDataContext(op2.Options, true);

Patient p = new Patient(Guid.NewGuid(), "Пациент1", "Пациент1", 23, new Adress(Guid.NewGuid(), "Ukraine", "Dnepr"),
   new List<AddInfo>() {new AddInfo(Guid.NewGuid(), "Записка пациента номер 1"),
       new AddInfo(Guid.NewGuid(), "Записка пациента номер 2")}, "Пневмония");

Doctor d = new Doctor(Guid.NewGuid(), "Доктор", "Доктор1", 23, new Adress(Guid.NewGuid(), "Ukraine", "Dnepr"),
   new List<AddInfo>() {new AddInfo(Guid.NewGuid(), "Записка номер 1"),
       new AddInfo(Guid.NewGuid(), "Записка номер 2")}, "Терапевт");

p.Patient_Doctors.Add(new Patient_Doctor(p.PrimKey, p, d.PrimKey, d));

var results = new List<ValidationResult>();
var context = new ValidationContext(p);
if (!Validator.TryValidateObject(p, context, results, true))
{
    foreach (var error in results)
    {
        Console.WriteLine(error.ErrorMessage);
    }
}
else
{
    Console.WriteLine($"Объект User успешно создан. Name: {p.Name}");

    dbCd.Persons.Add(p);

    dbCd.SaveChanges();
}


//var f = (from p in dbCd.Persons where p is Patient select p)
//    .Include(p => p.ActualAdress)
//    .Include(p => p.AddInfoList)
//    .Include(p => (p as Patient).Patient_Doctors).Include(p=> (p as Patient)).ToList();

//foreach (var item in f)
//{
//    Console.WriteLine(item as Patient);
//}

//var d = (from p in dbCd.Persons where p is Doctor select p)
//    .Include(p => p.ActualAdress).Include(p => p.AddInfoList).Include(p => (p as Doctor).Patient_Doctors).ToList();

//foreach (var item in d)
//{
//    Console.WriteLine(item as Doctor);
//}

var s = (from pd in dbCd.Patient_Physician select pd).Include(pd => pd.Patient)
    .Include(pd => pd.Doctor).Include(pd => pd.Patient.ActualAdress)
    .Include(pd=>pd.Doctor.ActualAdress).Include(pd=> pd.Patient.AddInfoList)
    .Include(pd=> pd.Doctor.AddInfoList).ToList();

foreach (var item in s)
{
    Console.WriteLine(item);
}

#endregion

Console.ReadKey();

static DbContextOptionsBuilder<DbContextType> CreateOptions<DbContextType>(string conString)
    where DbContextType : DbContext
{
    DbContextOptionsBuilder<DbContextType> options = new DbContextOptionsBuilder<DbContextType>();

    options.UseSqlServer(conString);

    return options;
}

