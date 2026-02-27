using System.IO;

namespace MoviesBoxOffice
{
    public class FileManager
    {
        private string filepath;
        private List<string> content = [];
        public FileManager(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            filepath = path;
        }
        public void AddTicket(Ticket ticket)
        {
            File.AppendAllText(filepath, ticket.TicketDesc() + Environment.NewLine);
        }
        public string CancelTicket(string fname ,string lname)
        {
            if (content.Count == 0)
            {
                foreach (string ticket in File.ReadLines(filepath))
                {
                    content.Add(ticket);
                }
            }
            foreach (string ticket in content)
            {
                if (ticket.IndexOf($"{fname} {lname}") > 0)
                {
                    content.Remove(ticket);
                    File.WriteAllText(filepath, string.Join("\n", content));
                    return ticket;
                }
            }
            Console.WriteLine("Ticket not found.");
            return "";
        }
    }
}