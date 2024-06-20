namespace APIListaDeTarefas.Logs
{
    public static class Log
    {

        public static void LogInFile(string title, string message)
        {
            var fileName = DateTime.Now.ToString("ddMMyyyy") + ".txt";

            StreamWriter swLog;

            if (File.Exists(fileName))
            {
                swLog = File.AppendText(fileName);

             
            }
            else
            {
                swLog = new StreamWriter(fileName);
            }

            swLog.WriteLine("Log:");
            swLog.WriteLine(DateTime.Now.ToLongDateString() + ", " +  DateTime.Now.ToLongTimeString());  
            swLog.WriteLine("Title of message: " +  title);
            swLog.WriteLine("Message: " + message);
            swLog.WriteLine("------------------------------------------------------------------");
            swLog.WriteLine();
            swLog.Close();
        }
    }
}
