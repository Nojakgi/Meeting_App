using System.Text;

namespace VismasMeetings.Models
{
    public class Meeting
    {
		private List<string> people = new List<string>();

		public IEnumerable<string> People => people;
		public string responsiblePerson { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public string type { get; set; }
		public string startDate { get; set; }
		public string endDate { get; set; }

		public static void PrintAllMeetings(List<Meeting> meetings)
		{
			meetings.ForEach(x => Console.WriteLine(
								"Participants: {0}\n" +
								"Responsible person: {1}\n" +
								"Description: {2}\n" +
								"Category: {3}\n" +
								"Meeting type: {4}\n" +
								"Start date: {5}\n" +
								"End date: {6} \n" +
								"**************************************",
								x.PrintMember(), x.responsiblePerson, x.description, x.category, x.type, x.startDate, x.endDate));
		}
		public string PrintMember()
		{
			var b = new StringBuilder();
			people.ForEach(x => b.Append(x + ","));
			return b.ToString();
		}

		public void AddPersonToMeeting(string name)
		{
			if (people.Contains(name))
			{
				return;
			}
			people.Add(name);
		}

		public void RemovePersonFromMeeting(string name)
		{
			people.RemoveAt(int.Parse(name));
		}
	}
}
