using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Transactions;
using System.Xml;
using Azure;
using EntityPackage;
using HelperPackage;
using DAOPackage;

internal class Program
{
    private static void Main(string[] args)
    {

        //Pet pet = new Pet();
        //ANS 6.1
        //try
        //{
        //    Console.WriteLine("Enter Age: ");
        //    pet.Age = Convert.ToInt32(Console.ReadLine());
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}


        //ANS 6.2
        //try
        //{
        //    Console.WriteLine("Enter the amount for donation: ");
        //    Donation.Amount = Convert.ToDecimal(Console.ReadLine());
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}

        //ANS 6.3
        //Console.WriteLine("Enter the name of pet: ");
        //pet.Name = Console.ReadLine();
        //Console.WriteLine("Enter the breed of pet: ");
        //pet.Breed = Console.ReadLine();
        //Console.WriteLine("Enter the age of pet: ");
        //pet.Age = Convert.ToInt32(Console.ReadLine());
        //try
        //{
        //    if (string.IsNullOrEmpty(pet.Name))
        //    {
        //        throw new NullReferenceException("Name is missing");
        //    }
        //    if (string.IsNullOrEmpty(pet.Breed))
        //    {
        //        throw new NullReferenceException("Breed is missing");
        //    }
        //    if (pet.Age < 0)
        //    {
        //        throw new NullReferenceException("Age is missing");
        //    }
        //    Console.WriteLine($"Name: {pet.Name}, Breed: {pet.Breed}, Age: {pet.Age}");
        //}
        //catch (NullReferenceException ex)
        //{

        //    Console.WriteLine("Information is Missing: " + ex.Message);
        //}
        //Console.ReadLine();


        //ANS 6.4
        //string filePath = "pets.txt";

        //try
        //{
        //    string[] petDataLines = File.ReadAllLines(filePath);

        //    foreach (var line in petDataLines)
        //    {
        //        string[] petProperties = line.Split(',');

        //        if (petProperties.Length < 3)
        //        {
        //            Console.WriteLine("Invalid data format in line: " + line);
        //            continue;
        //        }

        //        Pet pet = new Pet
        //        {
        //            Name = petProperties[0].Trim(),
        //            Breed = petProperties[1].Trim(),
        //            Age = int.TryParse(petProperties[2].Trim(), out int age) ? age : -1
        //        };
        //        Console.WriteLine($"- Name: {pet.Name ?? "Unknown"}, Breed: {pet.Breed ?? "Unknown"}, Age: {(pet.Age >= 0 ? pet.Age.ToString() : "Invalid Age")}");
        //    }
        //}
        //catch (FileNotFoundException ex)
        //{
        //    Console.WriteLine("Error: The specified file was not found. " + ex.Message);
        //}
        //catch (IOException ex)
        //{
        //    Console.WriteLine("Error: An I/O error occurred while trying to read the file. " + ex.Message);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("An unexpected error occurred: " + ex.Message);
        //}


        //ANS 6.5
        //Console.Write("Enter the name of the pet: ");
        //pet.Name = Console.ReadLine();

        //Console.Write("Enter the breed of the pet: ");
        //pet.Breed = Console.ReadLine();

        //Console.Write("Enter the age of the pet: ");
        //string ageInput = Console.ReadLine();
        //int age;

        //try
        //{
        //    if (string.IsNullOrEmpty(pet.Name))
        //    {
        //        throw new AdoptionException("Name is missing.");
        //    }

        //    if (string.IsNullOrEmpty(pet.Breed))
        //    {
        //        throw new AdoptionException("Breed is missing.");
        //    }

        //    if (!int.TryParse(ageInput, out age) || age < 0) 
        //    {
        //        throw new AdoptionException("Age is missing or invalid.");
        //    }

        //    pet.Age = age; 


        //    Console.WriteLine($"Name: {pet.Name}, Breed: {pet.Breed}, Age: {pet.Age}");
        //}
        //catch (AdoptionException ex)
        //{
        //    Console.WriteLine("Adoption error: " + ex.Message);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("An unexpected error occurred: " + ex.Message);
        //}
        AdoptionEvent ev = new AdoptionEvent();


        AdoptionEvent.DisplayAvailablePets();

        Console.Read();
    }
}

