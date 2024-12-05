namespace LevelManangementSystem.web.Data
{
    public class LeaveRequestStatus : BaseEntity
    {
        [StringLength(50)]
        public string StatusName { get; set; }



    }
}