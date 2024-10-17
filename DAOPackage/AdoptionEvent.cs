using System.Diagnostics;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using System.Xml.Serialization;
using EntityPackage;
using Microsoft.Data.SqlClient;
using UtilPackage;

namespace DAOPackage
{
    public class AdoptionEvent : IAdoptable
    {
        Pet pet = new Pet();
        PetShelter Shelter = new PetShelter();
        public List<IAdoptable> Participants = new List<IAdoptable>();

        //public int EventId { get; set; }
        //public DateTime EventDate { get; set; }

        public void Adopt()
        {
            Console.WriteLine($"{pet.Name} has been adopted!");
        }
        public void RegisterParticipant(IAdoptable participant)
        {
            Participants.Add(participant);
        }

        public void HostEvent()
        {
            Console.WriteLine("Adoption event is starting!");

            foreach (IAdoptable participant in Participants)
            {
                participant.Adopt();
            }

            Console.WriteLine("Adoption event has concluded.");
        }
        public void AddPet(Pet pet)
        {
            Shelter.availablePets.Add(pet);
            Console.WriteLine("Pet is Added");
        }

        public void RemovePet(Pet pet)
        {
            Shelter.availablePets.Remove(pet);
            Console.WriteLine("Pet is Removed");
        }

        public void ListAvailablePets()
        {
            if (Shelter.availablePets.Count == 0)
            {
                Console.WriteLine("No pets available for adoption.");
                return;
            }

            Console.WriteLine("Available Pets:");
            foreach (var pet in Shelter.availablePets)
            {
                Console.WriteLine($"- {pet.Name}, Age: {pet.Age}");
            }
        }
        public void ShowPet()
        {
            List<Pet> availablePets = new List<Pet>();
            DisplayAvailablePets();
            Console.WriteLine("Available Pets:");
            foreach (var pet in availablePets)
            {
                Console.WriteLine($"Name: {pet.Name}, Breed: {pet.Breed}, Age: {pet.Age}");
            }

        }
        public static void DisplayAvailablePets()
        {
            string cnstr=DbConnUtil.GetConnection("PetPalscnstring");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Name, Breed, Age FROM pets WHERE IsAvailable = 1", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Pet> availablePets = new List<Pet>();
                if (!dr.HasRows)
                {
                    Console.WriteLine("No available pets found.");
                }
                else
                {
                    while (dr.Read())
                    {
                        Pet pet = new Pet();
                        pet.Name = dr["Name"].ToString();
                        pet.Breed = dr["Breed"].ToString();
                        pet.Age = Convert.ToInt32(dr["Age"]);
                        availablePets.Add(pet);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
        }

        public static bool InsertDonorinfo(Donation donate, out bool status)
        {
            status = false;
            string cnstr = DbConnUtil.GetConnection("PetPalscnstring");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO donations (DonorName, Amount, DonationDate, ItemType) VALUES (@DonorName, @Amount, @DonationDate, @ItemType)", cn);

                cmd.Parameters.AddWithValue("@DonorName", Donation.DonorName);
                cmd.Parameters.AddWithValue("@Amount", Donation.Amount);
                cmd.Parameters.AddWithValue("@DonationDate", Donation.DontaionDate);
                cmd.Parameters.AddWithValue("@ItemType", Donation.ItemType);

                cn.Open();
                int cnt = cmd.ExecuteNonQuery();

                if (cnt > 0)
                {
                    status = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Input error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return status;
        }

        public List<Event> GetUpcomingEvents()
        {
            List<Event> events = new List<Event>();
            string cnstr = DbConnUtil.GetConnection("PetPalscnstring");
            SqlConnection cn = new SqlConnection(cnstr);
            

            try
            {
                SqlCommand command = new SqlCommand("SELECT EventID, EventDate FROM Events WHERE EventDate > GETDATE()", cn);
                cn.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (!dr.HasRows)
                {
                    Console.WriteLine("No available data found.");
                }
                else
                {
                    while (dr.Read())
                    {
                        Event adoptionEvent = new Event
                        {
                            EventId = Convert.ToInt32(dr["EventID"]),
                            EventDate = Convert.ToDateTime(dr["EventDate"])
                        };
                        events.Add(adoptionEvent);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error while retrieving events: " + ex.Message);
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return events;
        }
        public bool RegisterParticipant(string participantName, string email, int eventId)
        {
            string cnstr = DbConnUtil.GetConnection("PetPalscnstring");
            SqlConnection cn = new SqlConnection(cnstr);

            try
            {
                cn.Open();
                string query = "INSERT INTO participants (ParticipantName, Email, EventId) VALUES (@ParticipantName, @Email, @EventId)";
                using (SqlCommand command = new SqlCommand(query, cn))
                {
                    command.Parameters.AddWithValue("@ParticipantName", participantName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@EventId", eventId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database error while registering participant: " + ex.Message);
                return false;
            }
        }
    }
}
