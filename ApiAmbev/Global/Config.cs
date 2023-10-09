namespace ApiAmbev.Global
{
    public class Config
    {
        public enum ErrorCode
        {
             NoError = 0,
	        UnknownError = 1,
            ProductAddError = 2,
            ProductGetError = 3,
            ProductDeleteError = 4
        }
        public static string token = string.Empty;
        public static DateTime lifeTime = DateTime.MinValue;

        public static string key = string.Empty;


        public static string basePath = string.Empty;
        public static string filePath = string.Empty;
        public static string folderPath = string.Empty;

        public static string dbHost = string.Empty;
        public static string dbPort = string.Empty;
        public static string dbName = string.Empty;
        public static string dbUser = string.Empty;
        public static string dbPass = string.Empty;

        public static string appRootFolder = AppDomain.CurrentDomain.BaseDirectory;
        public static string logSuccessEnabled = string.Empty;
        public static string logErrorEnabled = string.Empty;
        public static string logInfoEnabled = string.Empty;
        public static string logName = string.Empty;
        public static string logPath = string.Empty;
        public static string logFolder = string.Empty;
        public static void LoadConfigurations()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            try
            {
                
                     logSuccessEnabled = config.GetValue<string>("Log:logSuccessEnabled");
                     logErrorEnabled = config.GetValue<string>("Log:logErrorEnabled");
                     logInfoEnabled = config.GetValue<string>("Log:logInfoEnabled");

        
                logName = config.GetValue<string>("Log:logName");
                logFolder = config.GetValue<string>("Log:logFolder");
                logPath = config.GetValue<string>("Log:logPath");

               

                dbHost = config.GetValue<string>("dbHost");
                dbPort = config.GetValue<string>("dbPort");
                dbName = config.GetValue<string>("dbName");
                dbUser = config.GetValue<string>("dbUser");
                dbPass = config.GetValue<string>("dbPass");

                key = config.GetValue<string>("Key");
 
            }
            catch (Exception e)
            {

            }
        }
    }
    public enum LogType
    {
        success = 1,
        info = 2,
        error = 3
    }

}
