namespace RegistrationUsers.Domain.Models
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int ScholarityId { get; set; }
        public Scholarity Scholarity { get; set; }
        public int SchoolRecordsId { get; set; }
        public virtual SchoolRecords SchoolRecords { get; set; }

    }
}
