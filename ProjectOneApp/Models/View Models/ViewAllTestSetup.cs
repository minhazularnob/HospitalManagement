namespace ProjectOneApp.Models.View_Models
{
    public class ViewAllTestSetup
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public double Fee { get; set; }
        public int TestTypeId { get; set; }

        public string TestTypeName { get; set; }
    }
}