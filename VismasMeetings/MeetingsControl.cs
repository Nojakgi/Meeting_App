using Newtonsoft.Json;

namespace VismasMeetings.Models
{
    public class MeetingsControl
    {
        public static void FirstMenu()
        {
            Console.Clear();

            while (true)
            {
                Console.WriteLine(
                    " 1 - Create a meeting \n " +
                    "2 - Delete a meeting \n " +
                    "3 - Add person to your meeting \n " +
                    "4 - Delete member from your meeting \n " +
                    "5 - Display all the meetings \n " +
                    "6 - Filters menu \n " +
                    "0 - Back");

                Console.Write("Your choice: ");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        AddNewMeeting();

                        break;

                    case "2":
                        DeleteMeeting();

                        break;

                    case "3":
                        AddPersonToMeeting();

                        break;

                    case "4":
                        DeletePersonFromMeeting();

                        break;

                    case "5":
                        List<Meeting> meetings = Program.meets;
                        Meeting.PrintAllMeetings(meetings);

                        break;

                    case "6":
                        Filter.FiltersMenu();

                        break;

                    case "0":
                        Console.Clear();
                        MainUI.MainMenuUI();

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter valid number 1-5\n");

                        break;
                }


            }
        }

        public static void AddNewMeeting()
        {
            Meeting meeting = new Meeting();

            while (true)
            {
                Console.Clear();

                Console.WriteLine("Meeting with who?: ");
                meeting.AddPersonToMeeting(Console.ReadLine());

                Console.WriteLine("Responsible person: \nGonna be you");
                meeting.responsiblePerson = Login.user;

                Console.WriteLine("Meeting description?: ");
                meeting.description = Console.ReadLine();

                Console.WriteLine("Choose category: 1 - CodeMonkey, 2 - Hub, 3 - Short, 4 - TeamBuilding): ");
                int categoryInput = int.Parse(Console.ReadLine());
                switch (categoryInput)
                {
                    case 1:

                        meeting.category = "CodeMonkey";
                        Console.WriteLine("{0}\n", meeting.category);
                        break;

                    case 2:

                        meeting.category = "Hub";
                        Console.WriteLine("{0}\n", meeting.category);
                        break;

                    case 3:

                        meeting.category = "Short";
                        Console.WriteLine("{0}\n", meeting.category);
                        break;

                    case 4:

                        meeting.category = "TeamBuilding";
                        Console.WriteLine("{0}\n", meeting.category);
                        break;
                }

                Console.WriteLine("Choose type (1 - Live, 2 - InPerson): ");
                int typeInput = int.Parse(Console.ReadLine());
                switch (typeInput)
                {

                    case 1:

                        meeting.type = "Live";
                        Console.WriteLine("{0}\n", meeting.type);
                        break;

                    case 2:

                        meeting.type = "InPerson";
                        Console.WriteLine("{0} \n", meeting.type);
                        break;
                }


                Console.WriteLine("Enter start date: ");
                meeting.startDate = Console.ReadLine();

                Console.WriteLine("Enter end date: ");
                meeting.endDate = Console.ReadLine();

                List<Meeting> meets = Program.meets;
                meets.Add(meeting);

                var save = JsonConvert.SerializeObject(meets);

                File.WriteAllText("meets.json", save);

                Console.WriteLine("Meeting added!\n");
                break;
            }
        }

        public static void AddPersonToMeeting()
        {
            Console.Clear();
            Console.WriteLine("Enter description to add member to that meeting\n");
            string input = Console.ReadLine();

            List<Meeting> description = Program.meets;

            var selected = description.SingleOrDefault(x => x.description == input);

            if (selected != null)
            {
                Console.WriteLine(
                    "Members: {0}\n" +
                    "Responsible person: {1}\n" +
                    "Description: {2}\n" +
                    "Category: {3}\n" +
                    "Meeting type: {4}\n" +
                    "Start date {5}\n" +
                    "End date: {6}\n\n",
                    selected.PrintMeeting(), selected.responsiblePerson, selected.description, selected.category, selected.type, selected.startDate, selected.endDate);

                Console.WriteLine("Add to this one? Y/n\n");
                string userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "Y")
                {
                    Console.WriteLine("Please enter member name: ");

                    string inputPerson = Console.ReadLine();
                    selected.AddPersonToMeeting(inputPerson);

                    var save = JsonConvert.SerializeObject(Program.meets);

                    File.WriteAllText("meets.json", save);
                }


            }
        }

        public static void DeleteMeeting()
        {
            Console.Clear();
            Console.WriteLine("Enter meeting description to delete: \n");
            string input = Console.ReadLine();

            List<Meeting> descr = Program.meets;

            var selected = descr.SingleOrDefault(x => x.description == input);

            if (selected != null)
            {
                Console.WriteLine(
                    "Members: {0}\n" +
                    "Responsible person: {1}\n" +
                    "Description: {2}\n" +
                    "Category: {3}\n" +
                    "Meeting type: {4}\n" +
                    "Start date: {5}\n" +
                    "End date: {6}\n\n",
                    selected.PrintMeeting(), selected.responsiblePerson, selected.description, selected.category, selected.type, selected.startDate, selected.endDate);

                Console.WriteLine("You sure? Y/n\n");

                string userInput = Console.ReadLine();
                if (userInput == "y" || userInput == "Y")
                {
                    if (Login.user == selected.responsiblePerson)
                    {
                        descr.Remove(selected);
                        var save = JsonConvert.SerializeObject(Program.meets);

                        File.WriteAllText("meets.json", save);

                        Console.WriteLine("Deleted.\n");
                    }
                    else
                    {
                        Console.WriteLine("You need to be responsible for this meeting.\n");
                    }
                }

            }
        }
        public static void DeletePersonFromMeeting()
        {
            Console.Clear();

            Console.WriteLine("Enter meeting description \n");
            string input = Console.ReadLine();

            List<Meeting> description = Program.meets;

            var selected = description.SingleOrDefault(m => m.description == input);

            if (selected != null)
            {
                Console.WriteLine(
                    "Members: {0}\n" +
                    "Responsible person: {1}\n" +
                    "Description: {2}\n" +
                    "Category: {3}\n" +
                    "Meeting type: {4}\n" +
                    "Start date: {5}\n" +
                    "End date: {6}\n\n",
                    selected.PrintMeeting(), selected.responsiblePerson, selected.description, selected.category, selected.type, selected.startDate, selected.endDate);

                Console.WriteLine("This meeting? Y/n\n");
                string userInput = Console.ReadLine();

                if (userInput == "y" || userInput == "Y")
                {
                    Console.WriteLine("Enter number which one to detele (0,1,2,3)\n");
                    string inputPerson = Console.ReadLine();
                    selected.RemovePersonFromMeeting(inputPerson);

                    var save = JsonConvert.SerializeObject(Program.meets);

                    File.WriteAllText("meets.json", save);

                    Console.WriteLine("Deleted.\n");
                }
            }
        }
    }
}
