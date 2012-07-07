using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISpider
{
    public interface ICinemaSpider
    {
        int getCinemaID(string url);
        string getCinemaName(string html);
        string getAddress(string html);
        string getCinemaMap(string html);
        string getCinemaTel(string html);
        float getCinemaGrade(string html);
        string getPrivilege(string html);
        string getVIP(string html);
        //string getDining(string html);
        //string getPark(string html);
        //string getGameCenter(string html);
        //string getIntro3D(string html);
        //string getIntroVIP(string html);
        bool getCinemaFive(string html, out string dining, out string park, out string gameCenter, out string intro3D, out string introVIP);
        string getIntroduce(string html);
    }
}
