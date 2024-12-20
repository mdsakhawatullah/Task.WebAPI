using System.ComponentModel.DataAnnotations;

namespace Datalytics.Task.WebAPI.Entities
{
    public class EventManagementModel
    {
        [Key]
        public Guid EventID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }



    }
}
