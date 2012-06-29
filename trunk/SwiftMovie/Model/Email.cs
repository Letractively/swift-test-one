using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 向用户发送Email的实体类
    /// </summary>
    public class Email
    {
        public User User { get; set; }
        public string content { get; set; }

    }
}
