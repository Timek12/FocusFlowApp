using Microsoft.AspNetCore.Identity;

namespace FocusFlow.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<UserTask> Tasks { get; set; } = new List<UserTask>();
    }
}
