using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Model
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Type_Of_OrganizationId { get; set; }
        [ForeignKey("Type_Of_OrganizationId")]
        public Type_Of_Organization Type_Of_Organization { get; set; }
    }
}
