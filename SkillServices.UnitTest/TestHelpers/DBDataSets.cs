namespace SkillServices.UnitTest.TestHelpers
{
    public static class DBDataSets
    {
        public static List<Skill> GetEmployeeTableTestData()
        {
            List<Skill> employees = new List<Skill>();
            return employees;
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Skill>().HasData(GetEmployeeTableTestData());
        }
    }
}
