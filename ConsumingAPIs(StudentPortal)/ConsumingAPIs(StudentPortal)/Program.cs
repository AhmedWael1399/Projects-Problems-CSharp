using Models;
using Models.Dtos;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TeacherApiClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            // Set the base address of the API
            client.BaseAddress = new Uri("https://localhost:7032/api/Teacher"); // Update with your actual API URL

            while (true)
            {
                Console.WriteLine("\n--- Teacher Management ---");
                Console.WriteLine("1. Get All Teachers");
                Console.WriteLine("2. Get Teacher By ID");
                Console.WriteLine("3. Add a New Teacher");
                Console.WriteLine("4. Update a Teacher");
                Console.WriteLine("5. Delete a Teacher");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await GetTeachers();
                        break;
                    case "2":
                        await GetTeacherById();
                        break;
                    case "3":
                        await AddTeacher();
                        break;
                    case "4":
                        await UpdateTeacher();
                        break;
                    case "5":
                        await DeleteTeacher();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Method to get all teachers and display them in a readable format
        private static async Task GetTeachers()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();

                    // Use JsonDocument to inspect the structure of the JSON data
                    using (JsonDocument doc = JsonDocument.Parse(data))
                    {
                        Console.WriteLine("\nParsed JSON Structure:");
                        PrintJson(doc.RootElement); // Helper method to print JSON structure
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        private static void PrintJson(JsonElement element, string indent = "")
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (JsonProperty property in element.EnumerateObject())
                    {
                        Console.WriteLine($"{indent}{property.Name}:");
                        PrintJson(property.Value, indent + "  ");
                    }
                    break;
                case JsonValueKind.Array:
                    foreach (JsonElement item in element.EnumerateArray())
                    {
                        PrintJson(item, indent + "  ");
                    }
                    break;
                default:
                    Console.WriteLine($"{indent}{element}");
                    break;
            }
        }

        // Method to get a teacher by ID
        private static async Task GetTeacherById()
        {
            Console.Write("Enter Teacher ID: ");
            var idInput = Console.ReadLine();
            if (int.TryParse(idInput, out int teacherId))
            {
                try
                {
                    var requestUrl = $"{client.BaseAddress}/{teacherId}";
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        // Use JsonDocument to inspect the structure of the JSON data
                        using (JsonDocument doc = JsonDocument.Parse(data))
                        {
                            Console.WriteLine("\nParsed JSON Structure:");
                            PrintJson(doc.RootElement); // Helper method to print JSON structure
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine($"Error: Teacher with ID {teacherId} not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
            }
        }

        // Method to add a new teacher
        private static async Task AddTeacher()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine(); 
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var newTeacher = new TeacherDto
            {
                Name = name,
                Email = email,
                Username = username,
                Password = password
            };

            var json = JsonSerializer.Serialize(newTeacher);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("", content);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Teacher added successfully:");
                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            }
        }


        private static async Task UpdateTeacher()
        {
            Console.Write("Enter Teacher ID to update: ");
            var idInput = Console.ReadLine();

            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (int.TryParse(idInput, out int teacherId))
            {
                // Provide updated teacher data
                var updatedTeacher = new TeacherDto
                {
                    Name = name,
                    Email = email,
                    Username = username,
                    Password = password
                };

                var json = JsonSerializer.Serialize(updatedTeacher);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var requestUrl = $"{client.BaseAddress}/{teacherId}";
                    HttpResponseMessage response = await client.PutAsync(requestUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();

                        // Use JsonDocument to inspect the structure of the JSON data
                        using (JsonDocument doc = JsonDocument.Parse(data))
                        {
                            Console.WriteLine("\nParsed JSON Structure:");
                            PrintJson(doc.RootElement); // Helper method to print JSON structure
                        }
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine($"Error: Teacher with ID {teacherId} not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
            }
        }

        // Method to delete a teacher by ID
        private static async Task DeleteTeacher()
        {
            Console.Write("Enter Teacher ID to delete: ");
            var idInput = Console.ReadLine();
            if (int.TryParse(idInput, out int teacherId))
            {
                try
                {
                    var requestUrl = $"{client.BaseAddress}/{teacherId}";
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        response = await client.DeleteAsync(requestUrl);
                        Console.WriteLine($"Teacher with ID {teacherId} deleted successfully.");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        Console.WriteLine($"Error: Teacher with ID {teacherId} not found.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid numeric ID.");
            }
        }
    }
}