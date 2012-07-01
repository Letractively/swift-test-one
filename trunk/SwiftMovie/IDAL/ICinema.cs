using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface ICinema
    {
        List<Cinema> getCinemaList();
        bool addCinema(Cinema cinema);
        bool removeCinema(int id);
        bool editCinema(Cinema cinema);

        Cinema getCinemaById(int id);
        int getCinemaIdByName(string name);
    }
}
