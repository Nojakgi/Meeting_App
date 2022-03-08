namespace VismasMeetings.Models
{
    public class Filter
    {
        public static void FiltersMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(
                    " 1 - Filter by description \n " +
                    "2 - Filter by responsible person \n " +
                    "3 - Filter by category \n " +
                    "4 - Filter by type \n " +
                    "5 - Filter by dates \n " +
                    "6 - Filter by the number of attendees (Should be more then 10 participants) \n " +
                    "0 - Back");

                Console.Write("Your choice: ");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        FilterByDescription();

                        break;

                    case "2":
                        FilterByResponsiblePerson();

                        break;

                    case "3":
                        FilterByCategory(); 

                        break;

                    case "4":
                        FilterByType();

                        break;

                    case "5":
                        FilterByDates();

                        break;

                    case "6":
                        FilterByMembersNumber();

                        break;

                    case "0":
                        Console.Clear();
                        MeetingsControl.FirstMenu();

                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Enter valid number 1-5\n");

                        break;
                }


            }
        }

        public static void FilterByDescription()
        {
            Console.Clear();
            Console.WriteLine("Enter meeting description\n");
            string userInput = Console.ReadLine();

            List<Meeting> meetings = Program.meets;
            var meeting = meetings.Where(m => m.description == userInput).ToList();

            if (meeting.Count != 0)
            {
                Meeting.PrintAllMeetings(meeting);
            }
            else
            {
                Console.WriteLine("Description not found");
            }
        }

        public static void FilterByResponsiblePerson()
        {
            Console.Clear();
            Console.WriteLine("Enter responsible person\n");
            string userInput = Console.ReadLine();

            List<Meeting> meetings = Program.meets;
            var meeting = meetings.Where(m => m.responsiblePerson == userInput).ToList();

            if (meeting.Count != 0)
            {
                Meeting.PrintAllMeetings(meeting);
            }
            else
            {
                Console.WriteLine("This person has no meetings");
            }
        }

        public static void FilterByCategory()
        {
            Console.Clear();
            Console.WriteLine("Enter category (- CodeMonkey / Hub / Short / TeamBuilding) \n");
            string userInput = Console.ReadLine();

            List<Meeting> meetings = Program.meets;
            var meeting = meetings.Where(m => m.category == userInput).ToList();

            if (meeting.Count != 0)
            {
                Meeting.PrintAllMeetings(meeting);
            }
            else
            {
                Console.WriteLine("Category does not exist or no meeting by this category");
            }
        }

        public static void FilterByType()
        {
            Console.Clear();
            Console.WriteLine("Enter type (- Live / InPerson) \n");
            string userInput = Console.ReadLine();

            List<Meeting> meetings = Program.meets;
            var meeting = meetings.Where(m => m.type == userInput).ToList();

            if (meeting.Count != 0)
            {
                Meeting.PrintAllMeetings(meeting);
            }
            else
            {
                Console.WriteLine("Type does not exist or no meeting by this type");
            }
        }

        public static void FilterByDates()
        {
            Console.Clear();
            Console.WriteLine("Enter start date: \n");
            string userInputStartDate = Console.ReadLine();

            Console.WriteLine("Enter end date: \n");
            string userInputEndDate = Console.ReadLine();

            List<Meeting> meetings = Program.meets;
            var meeting = meetings.Where(m => m.startDate == userInputStartDate && m.endDate == userInputEndDate).ToList();

            if (meeting.Count != 0)
            {
                Meeting.PrintAllMeetings(meeting);
            }
            else
            {
                Console.WriteLine("No meetings by this date");
            }
        }

        public static void FilterByMembersNumber()
        {
            Console.Clear();
            //Console.WriteLine("Enter number of participants in meeting \n");
            //int participants = int.Parse(Console.ReadLine());
            int participants = 10;

            List<Meeting> meetings = Program.meets;
            var meeting = meetings.Where(m => m.People.Count() == participants).ToList();

            if (meeting.Count > 0)
            {
                Meeting.PrintAllMeetings(meeting);
            }
            else
            {
                Console.WriteLine("There is no meeting with {0} participants", participants);
            }
        }
    }
}
