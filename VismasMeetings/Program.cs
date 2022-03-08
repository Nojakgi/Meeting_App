using Newtonsoft.Json;
using VismasMeetings.Models;

namespace VismasMeetings
{
    public class Program
    {
        public static List<Person> users = new();
        public static List<Meeting> meets = new();

        static void Main(string[] args)
        {

            var userInfo = File.ReadAllText("users.json");
            users = JsonConvert.DeserializeObject<List<Person>>(userInfo);

            var meetsInfo = File.ReadAllText("meets.json");
            meets = JsonConvert.DeserializeObject<List<Meeting>>(meetsInfo);

            MainUI.MainMenuUI();
        }
    }
}

