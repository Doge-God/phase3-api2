namespace phase3_api2.Domain.Model
{
    public class Prod 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime TimeExpire { get; set; }

        public DateTime TimeStored { get; set; }

        public bool? isWasted { get; set; }

        public DateTime? TimeTaken { get; set; }


        // **CONSTRUCTOR**
        public Prod(string name, DateTime timeExpire, DateTime timeStored)
        {
            Name = name;
            TimeExpire = timeExpire;
            TimeStored = timeStored;
        }
    }
}