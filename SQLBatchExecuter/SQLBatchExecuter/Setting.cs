using System.Collections.Generic;
using System.IO;
using Library;

namespace SQLBatchExecuter
{
    public class Setting
    {
        public Setting()
        {
            ConfigFile applicationConfigFile = new ConfigFile(MainForm.Ini.IniFileName);
            Connectionstrings = new Dictionary<string, string>();
            string[] DBs = applicationConfigFile.GetValue("IKA1", "DSN", true).Split(',');
            
            for (int i = 0; i < DBs.Length; i++)
            {
                User = applicationConfigFile.GetValue("IKA1", "User", true);
                Password = applicationConfigFile.GetValue("IKA1", "Password", true);
                Password = Crypter.DecryptConfigValue(ref applicationConfigFile, "IKA1", "Password", User);
                ConnectionString = $"DSN={DBs[i]};Uid={User};Pwd={Password};";
                Connectionstrings.Add(DBs[i], ConnectionString);
            }

            DBs = applicationConfigFile.GetValue("IKA2", "DSN", true).Split(',');

            for (int i = 0; i < DBs.Length; i++)
            {
                User = applicationConfigFile.GetValue("IKA2", "User", true);
                Password = applicationConfigFile.GetValue("IKA2", "Password", true);
                Password = Crypter.DecryptConfigValue(ref applicationConfigFile, "IKA2", "Password", User);
                ConnectionString = $"DSN={DBs[i]};Uid={User};Pwd={Password};";
                Connectionstrings.Add(DBs[i], ConnectionString);
            }

            LogMode = (MainForm.Ini.GetInt("Log", "MODE") == 1) ? true : false;
            
        }
      
        private string Dsn { get; set; }
        private string User { get; set; }
        private string Password { get; set; }
        public string ConnectionString { get; set; }
        public bool LogMode { get; set; }
        public Dictionary<string,string> Connectionstrings { get; set; }
    }
}
