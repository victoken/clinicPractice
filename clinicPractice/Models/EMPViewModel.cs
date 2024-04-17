namespace clinicPractice.Models
{
    public class EMPViewModel
    {
        public List<Member_EmployeeList> Employees { get; set; }
        public List<Member_MemberList> Members { get; set; }
        public string SelectedEmployeeType { get; set; }
        public string SelectedMemberType { get; set; }

    }
}
