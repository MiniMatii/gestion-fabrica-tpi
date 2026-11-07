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



            // Usa el HttpClient compartido de ApiClient: el token del login llega a todos los formularios
            var api = new ApiClient();

            using (var login = new Login(api))
            {
                if (login.ShowDialog() != DialogResult.OK) return;
            }

            Application.Run(new MenuPPal(api));

        }
    }
}