using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetworks.VK
{

    public class FriendList
    {
        public int Count { get; set; }

        public string[] Items { get; set; }
    }

    public class Friends
    {
        public FriendList Response { get; set; }
    }
}
