namespace MyProject.Model
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Can_Create_Documents { get; set; }
        public bool Can_Read_Documents { get; set; }
        public bool Can_Update_Documents { get; set; }

    }
}
