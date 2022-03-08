using Newtonsoft.Json;

namespace VismasMeetings.Models
{
    public class Register
    {
        public static void NewUser()
        {

            Console.Clear();
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Re-enter password: ");
            string rePassword = Console.ReadLine();

            bool registrated = passwordAuthenticator(password, rePassword);

            if (registrated)
            {
                Person person = new Person();
                person.name = name;
                person.password = password;

                Program.users.Add(person);

                var save = JsonConvert.SerializeObject(Program.users);

                File.WriteAllText("users.json", save);

            }
        }
        static bool passwordAuthenticator(string password, string rePassword)
        {
            Console.Clear();

            if (password == rePassword)
            {
                Console.WriteLine("User registered \n");
                return true;
            }
            else
            {
                Console.WriteLine("Passwords should match \n");
                return false;
            }
        }
    }
}
