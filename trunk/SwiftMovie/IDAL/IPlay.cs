using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IPlay
    {
        List<Play> getPlayList();
        List<Play> getPlayListBymovieID(int movieID);
        List<Play> getPlayListBycinemaID(int cinemaID);
        List<Play> getPlayList(int movieID, int cinemaID);

        bool addNewPlay(Play play);
        bool removePlay(int playID);
        bool editPlay(Play play);
    }
}
