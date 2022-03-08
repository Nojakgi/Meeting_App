namespace VismasMeetings.Models
{
    public class MainUI
    {
        public static void MainMenuUI()
        {
            while (true)
            {
                Console.WriteLine(" " +
                    "1 - Register | " +
                    "2 - Login | " +
                    "3 - Meeting system | " +
                    "0 - Exit |");

                Console.Write("Your choice: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Register.NewUser();

                        break;

                    case "2":
                        Login.LoginUser();

                        break;


                    case "3":
                        if (Login.user_status)
                        {
                            MeetingsControl.FirstMenu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("please login to proceed\n");
                        }

                        break;

                    case "0":
                        Console.Clear();
                        Environment.Exit(0);

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter valid number 1-3 or 0 to EXIT\n");

                        break;

                }

            }
        }
    }
}
