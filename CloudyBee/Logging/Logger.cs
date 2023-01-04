using System;
using System.IO;

namespace CloudyBeeEngine.Logging
{
    public class Logger
    {
        private static Logger instance;
        private const string LOG_FILE_NAME = "Engine.log";
        private const string ERROR_MESSAGE = "----ERROR ENCOUNTERED----";
        private const string WARNING_MESSAGE = "----WARNING----";

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }

        private Logger()
        {
            /*
            //Create a new log file for this session.
            if (File.Exists(LOG_FILE_NAME))
            {
                File.Delete(LOG_FILE_NAME);
            }*/

            //Create a new log file for this session, make sure the stream is closed.
            File.Create(LOG_FILE_NAME).Close();
        }

        /// <summary>
        /// Prints some text to the log file.
        /// </summary>
        /// <param name="message">The text to be logged.</param>
        public void Log(string message)
        {
            //Append the message to the log file and add some spacing for readability.
            File.AppendAllText(LOG_FILE_NAME, message + Environment.NewLine);
        }

        /// <summary>
        /// Prints some text to the log with error warnings.
        /// </summary>
        /// <param name="message">The text to be logged.</param>
        public void LogError(string message)
        {
            File.AppendAllText(LOG_FILE_NAME, ERROR_MESSAGE + Environment.NewLine);
            Log(message);
        }

        /// <summary>
        /// Prints some text to the log that is notable but not an actual error.
        /// </summary>
        /// <param name="message">The text to be logged.</param>
        public void LogWarning(string message)
        {
            File.AppendAllText(LOG_FILE_NAME, WARNING_MESSAGE + Environment.NewLine);
            Log(message);
        }
    }
}