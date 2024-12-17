namespace IMS.Common.DTOs.Admin
{
    public class DashboardStatsDTO
    {
        public int TotalUsers { get; set; }
        public Dictionary<string, int> UsersByRole { get; set; }
        public int ActiveUsers { get; set; }
        public int InactiveUsers { get; set; }
    }
}