namespace VismasMeetings.Models
{
    public class Login
    {
        public static string user;
        public static bool user_status = false;

        public static void LoginUser()
        {
            Console.Clear();

            Console.WriteLine("Enter login name: ");
            string login = Console.ReadLine();

            Console.WriteLine("Enter password: ");
            string password = Console.ReadLine();

            LogIn(login, password);
        }

        public static void LogIn(string loginName, string password)
        {
            try
            {
                List<Person> auth = Program.users;

                    var loginAuth = auth.FirstOrDefault(p => p.name == loginName && p.password == password).ToString();
                if (loginAuth != null)
                {
                    Console.Clear();
                    Console.WriteLine("Login succesful \n");

                    user_status = true;
                    user = loginName;
                }
                else if (loginAuth == null)
                {
                    Console.WriteLine("Bad credentials");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("No user found");
            }
        }
    }
}
