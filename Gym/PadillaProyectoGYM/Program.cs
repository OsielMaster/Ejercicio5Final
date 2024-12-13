namespace PadillaProyectoGYM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMvc();
            var app = builder.Build();

            app.MapDefaultControllerRoute();
            app.UseStaticFiles();
            app.UseRouting();


            app.Run();
        }
    }
}
