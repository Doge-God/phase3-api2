namespace phase3_api2.Domain.Model
{
    public class Prod : BaseEntity
    {
        string Name { get; set; }

        DateTime TimeStored { get; set; }

        DateTime TimeExpire { get; set; }

        bool? isWasted { get; set; }

        DateTime? TimeTaken { get; set; }

    }
}