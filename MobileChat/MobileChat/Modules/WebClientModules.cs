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
    public static class WebClientModules
    {
        public class Message
        {
            public string datetime { get; set; }
            public string nickname { get; set; }
            public string content { get; set; }
        }
        public static string[] LoginMethod(string _login, string _pass)
        {
            string answer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + ServerAddress.srvrAddress + "/login.php?login=" + _login + "&password=" + _pass;
                answer = client.DownloadString(sendTxt);
            }
            string[] subs = answer.Split(' ');
            return subs;
        }
        public static string RegisterMethod(string _login, string _pass)
        {
            string answer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + ServerAddress.srvrAddress + "/register.php?login=" + _login + "&password=" + _pass;
                answer = client.DownloadString(sendTxt);
                answer = answer.Trim();
            }
            return answer;
        }
        public static string[] SearchUserMethod(string _username)
        {
            //отправляем запрос на сервер
            string _searchAnswer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + ServerAddress.srvrAddress + "/search.php?nickname=" + _username;
                _searchAnswer = client.DownloadString(sendTxt);
            }
            //разделим ответ через ' ', сервер должен вернуть что то вроде "ok 1"
            string[] subs = _searchAnswer.Split(' ');
            return subs;
            //string TrimString = answer.Trim();
        }

        public static string SendMessageMethod(string _userid, string _content)
        {
            string answer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + ServerAddress.srvrAddress + "/sendmessage.php?userid1=" + ClassStatus.user_id + "&userid2=" + _userid + "&content=" + _content;
                answer = client.DownloadString(sendTxt);
                answer = answer.Trim();
            }
            return answer;
        }
        public static List<Message> ShowMessageMethod(string _userid)
        {
            string _searchAnswer;
            using (WebClient client = new WebClient())
            {
                string sendTxt = "http://" + ServerAddress.srvrAddress + "/message.php?userid1=" + ClassStatus.user_id + "&userid2=" + _userid;
                _searchAnswer = client.DownloadString(sendTxt);
            }
            //когда сервер возвращал кирилические символы, их нужно было перекодировать, оставлю это здесь на всякий случай
            //byte[] bytes = Encoding.Default.GetBytes(answer);
            //string CodStr = Encoding.UTF8.GetString(bytes);
            //ответ будет в формате json, преобразуем его в Лист объектов класса Message
            if (_searchAnswer!="null")
            {
                List<Message> Data = JsonConvert.DeserializeObject<List<Message>>(_searchAnswer);
                return Data;
            }
            else
            {
                return null;
            }
            
            
        }
    }
}
