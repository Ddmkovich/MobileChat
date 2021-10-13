using System;
using System.Collections.Generic;
using System.Text;

namespace MobileChat.Classes
{
    class Users
    {
        public class _userdata
        {
            public string id;
            public string nickname;
        }

        public static List<_userdata> listusers = new List<_userdata>();
        public static void insert(string _id, string _name)
        {
            _userdata _userExample = new _userdata();
            _userExample.id = _id;
            _userExample.nickname = _name;
            listusers.Add(_userExample);
        }
    }
}
