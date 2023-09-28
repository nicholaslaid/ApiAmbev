namespace ApiAmbev.Global
{
    public class Config
    {
        public enum ErrorCode
        {
            UnhandledException = 1,
            UnknownError = 2,
            JobNotFoundError = 3
        }
        public static string token = string.Empty;
        public static DateTime lifeTime = DateTime.MinValue;


        public static string fileName = string.Empty;
        public static string folderName = string.Empty;

        public static string basePath = string.Empty;
        public static string filePath = string.Empty;
        public static string folderPath = string.Empty;

        public static void LoadConfigurations()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            try
            {
                fileName = config.GetValue<string>("Log:FileName");
                folderName = config.GetValue<string>("Log:Foldername");


                basePath = AppDomain.CurrentDomain.BaseDirectory;

                folderPath = Path.Combine(basePath, folderName);

                filePath = Path.Combine(folderPath, fileName);
            }
            catch (Exception e)
            {

            }
        }
    }
}
