using Microsoft.Win32.SafeHandles;
using System.Drawing;

namespace EntityPackage
{
    public class Pet
    {
        public string Name { get; set; }
        public string Breed { get; set; }

        
        private int? _age=null;

        public int? Age
        {
            get { 
                return _age; }
            set {
                if (value < 0)
                {
                    throw new Exception("Age cannot be negative");
                }
                else
                {
                    _age = value;
                }
                }
        }


        public Pet(string breed)
        {
            this.Breed = breed;
        }
        public Pet()
        {
        }

        public Pet(string name, string breed, int age) : this(breed)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Pet Name: {Name}, Type: {Breed}, Age: {Age} years"; ;
        }
    }

    public class Dog : Pet
    {
        public string DogBreed { get; set; }
        public Dog(string breed) : base(breed)
        {
            DogBreed = breed;
        }
    }

    public class Cat : Pet
    {
        public string CatColor { get; set; }
        public Cat(string catcolor)
        {
            CatColor = catcolor;
        }
    }

    public class PetShelter
    {
        public List<Pet> availablePets { get; set; }
    }
    public abstract class Donation
    {
        public static string DonorName { get; set; }
        public static decimal _amount;
        public static DateTime DontaionDate {get; set;}
        public static string ItemType { get; set; }
        public static decimal Amount { get {
                return _amount;
            }
            set {
                if (value < 10)
                {
                    throw new Exception("Donation amount must be at least $10");
                }
                else
                {
                    _amount = value;
                }
            } 
        
        }

        public Donation()
        {

        }
        public Donation(string donorName, decimal amount)
        {
            DonorName = donorName;
            Amount = amount;
        }

        public abstract void RecordDonation();
    }

    public class CashDonation : Donation
    {
        public DateTime DonationDate { get; set; }
        public CashDonation(DateTime donationDate)
        {
            DonationDate = donationDate;
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Cash donation of {Amount} received from {DonorName} on Date {DonationDate}");
        }
    }

    public class ItemDonation : Donation
    {
        public string ItemType { get; set; }
        public ItemDonation(string itemtype)
        {
            ItemType = itemtype;
        }

        public override void RecordDonation()
        {
            Console.WriteLine($"Item donation of {ItemType} received from {DonorName}");
        }
    }

    public class Event
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }

        public Event()
        {

        }
        public Event(int eventId, DateTime eventDate)
        {
            EventId = eventId;
            EventDate = eventDate;
        }
    }

    public class Paticipants
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int EvemtId { get; set; }
    }
}


