using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BLL
{
    //获取电影院信息
    public class CinemaBLL
    {
        public List<Model.Cinema> getCinemaList()
        {
            IDAL.ICinema lst = DALFactory.DataAccess.createDalCinema();
            return lst.getCinemaList();
        }

        public Cinema getCinemaById(int cinemaId)
        {
            IDAL.ICinema lst = DALFactory.DataAccess.createDalCinema();
            return lst.getCinemaById(cinemaId);
        }

    }
}
