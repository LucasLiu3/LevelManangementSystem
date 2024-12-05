namespace LevelManangementSystem.web.Data
{
    public class Period : BaseEntity
    {

        public string Name { get; set; }

        public DateOnly StartDay { get; set; }

        public DateOnly EndDay { get; set; }


    }
}
