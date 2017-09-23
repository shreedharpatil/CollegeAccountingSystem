using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Facede
{
    public class TakeDatabaseBackupCommand
    {
        private readonly ILogger logger;

        public TakeDatabaseBackupCommand()
        {
            logger = new Logger();
        }
        public bool TakeBackup(string application)
        {
            string connectionString = ConfigurationManager.AppSettings["connectionString"];
            string fileLocation = ConfigurationManager.AppSettings["backUpLocation"];
            string folderName = DateTime.Today.FormatDate("-");
            string pathString = System.IO.Path.Combine(fileLocation, application, folderName);
            string fileName = DateTime.Now.ToString("dd-MMM-yyyy hh-mm-ss") + ".sql";
            bool doesFolderExist = System.IO.Directory.Exists(pathString);
            if (!doesFolderExist)
            {
                System.IO.Directory.CreateDirectory(pathString);
            }

            string filePath = System.IO.Path.Combine(pathString, fileName);
            MySqlCommand command;
            MySqlConnection connection = null;
            MySqlBackup backup;
            try
            {
                using (connection = new MySqlConnection(connectionString))
                {
                    using (command = new MySqlCommand())
                    {
                        using (backup = new MySqlBackup(command))
                        {
                            command.Connection = connection;
                            connection.Open();
                            backup.ExportToFile(filePath);
                            connection.Close();
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if (connection != null)
                {
                    connection.Close();
                }
                logger.Log(exception);
                return false;
            }

            return true;
        }
    }
}
