using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; }= null!;

        public int OrganizationId { get; set; }
        public int RolesId { get; set; }
        [ForeignKey("OrganizationId")]
        public Organization Organization { get; set; }
        [ForeignKey("RolesId")]
        public Roles Roles { get; set; }
    }
}
