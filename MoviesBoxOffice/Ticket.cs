namespace MoviesBoxOffice
{
    public class Ticket
    {
        private string fname;
        private string lname;
        private string datetime;
        private string movieName;
        public string Fname
        {
            get { return fname; }
        }
        public string Lname
        {
            get { return lname; }
        }
        public string MovieName
        {
            get { return movieName; }
        }

        public Ticket(string fname, string lname, string movieName)
        {
            this.fname = fname;
            this.lname = lname;
            datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            this.movieName = movieName;
        }

        public string TicketDesc()
        {
            return $"{datetime} | {fname} {lname} - Movie: {movieName}";
        }
    }
}