using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.IO;
using System.Text.RegularExpressions;
using SpiderDAL;

namespace SystemBLL
{
    public class SaveCinemas
    {
        public bool saveCinemas()
        {
            bool success = false;
            CinemaSpider cs = new CinemaSpider();
            string fileURL = @"F:\lily\TextCache\Cinema\";
            string[] cinemaFiles = Directory.GetDirectories(fileURL);
            if (cinemaFiles != null)
            {
                foreach (string cinemaFile in cinemaFiles)
                {
                    Match match = Regex.Match(cinemaFile,@"\d\d\d\d");
                    string strID = match.Value;
                    string cineURL = cinemaFile + "\\" + strID + ".txt";
                    string cineHtml = File.ReadAllText(cineURL);
                    int cinemaID = cs.getCinemaID(cineURL);
                    string cinemaName = cs.getCinemaName(cineHtml);
                    string address = cs.getAddress(cineHtml);
                    string cinemaTel = cs.getCinemaTel(cineHtml);
                    float cinemaGrade = cs.getCinemaGrade(cineHtml);

                    string infoURL = cinemaFile + @"\info.txt";
                    string infoHtml = File.ReadAllText(infoURL);
                    string dining = string.Empty;
                    string park = string.Empty;
                    string game = string.Empty;
                    string intro3D = string.Empty;
                    string introVIP = string.Empty;
                    cs.getCinemaFive(infoHtml, out dining, out park, out game, out intro3D, out introVIP);
                    string introduce = cs.getIntroduce(infoHtml);

                    string discountURL = cinemaFile + @"discount.txt";
                    string discountHtml = File.ReadAllText(discountURL);
                    string privilege = cs.getPrivilege(discountHtml);
                    string vip = cs.getVIP(discountHtml);

                    Cinema cinema = new Cinema()
                    {
                        CinemaID = cinemaID,
                        CinemaName = cinemaName,
                        Address = address,
                        CinemaTel = cinemaTel,
                        CinemaGrade = cinemaGrade.ToString(),
                        Privilege = privilege,
                        VIP = vip,
                        Dining = dining,
                        Park = park,
                        GameCenter = game,
                        Intro3D = intro3D,
                        IntroVIP = introVIP,
                        Introduce = introduce
                    };
                    IDAL.ICinema cinemaDAL = DALFactory.DataAccess.createDalCinema();
                    if (cinemaDAL.getCinemaById(cinemaID) == null)
                    {
                        success = cinemaDAL.addCinema(cinema);
                    }
                }
            }
            return success;
        }
    }
}
