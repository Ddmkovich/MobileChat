using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MobileChat.Classes;
using Newtonsoft.Json;

namespace MobileChat.Modules
{
    class ChangeUserData
    {
        public static string ChangeUsernameMethod(string _oldnick, string _newnick)
        {
            string answer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + ServerAddress.srvrAddress + "/changeusername.php?nicknameOld=" + _oldnick + "&nicknameNew=" + _newnick;
                answer = client.DownloadString(sendTxt);
                answer = answer.Trim();
            }
            return answer;
        }
        public static string ChangeUserPasswordMethod(string _curPass, string _NewPass)
        {
            string answer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + ServerAddress.srvrAddress + "/changepassword.php?userid=" + ClassStatus.user_id + "&passwordOld=" + _curPass + "&passwordNew=" + _NewPass;
                answer = client.DownloadString(sendTxt);
                answer = answer.Trim();
            }
            return answer;
        }
    
    }
}
