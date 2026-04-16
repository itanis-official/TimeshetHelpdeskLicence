//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace HelpDeskAPI.Data
//{
//    public class HelpDeskContextFactory : IDesignTimeDbContextFactory<HelpDeskContext>
//    {
//        public HelpDeskContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<HelpDeskContext>();

//            optionsBuilder.UseSqlServer(
//                "Server=localhost\\SQLEXPRESS;Database=helpDeskFIN;Integrated Security=True;TrustServerCertificate=True;"
//            );

//            return new HelpDeskContext(optionsBuilder.Options);
//        }
//    }
//}