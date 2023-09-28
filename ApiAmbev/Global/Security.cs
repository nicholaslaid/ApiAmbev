namespace ApiAmbev.Global
{
    public class Security
    {

        public bool ValidateToken(string token)
        {
            bool result = false;

            if (token == Config.token && DateTime.Now < Config.lifeTime)
            {
                result = true;
            }
            return result;
        }

        public string GenerateToken(string user, string passsword)
        {
            string result = string.Empty;

            if (user == "admin" && passsword == "admin")
            {
                Guid guid = Guid.NewGuid();
                result = guid.ToString();
                Config.token = result;
                Config.lifeTime = DateTime.Now.AddSeconds(60);
            }
            return result;
        }
    }
}
