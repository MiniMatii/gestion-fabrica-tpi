using Alemana.API;

namespace MenuDesk
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();



            var api = new ApiClient(new HttpClient { BaseAddress = new Uri("https://localhost:7150") });

            using (var login = new Login(api))
            {
                if (login.ShowDialog() != DialogResult.OK) return;
            }

            Application.Run(new MenuPPal(api));

        }
    }
}