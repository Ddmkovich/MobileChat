using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobileChat.Modules
{
    public static class Connection
    {
        public static string ConnectionCheck(string srvrAddress)
        {
            string serverAnswer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + srvrAddress + "/index.php";
                serverAnswer = client.DownloadString(sendTxt);
            }
            if (serverAnswer == "")
            {
                string error = "Сервер не отвечает...";
                return error;
            }
            else
            {
                return serverAnswer;
            }
        }
    }
}
