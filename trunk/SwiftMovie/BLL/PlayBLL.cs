using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    class PlayBLL
    {
         public List<Model.Play> getPlayList(int movieID)
         {
            IDAL.IPlay lst = DALFactory.DataAccess.createDalPlay();
            return lst.getPlayListBymovieID(movieID);
         }


         public class SortByPrice : IComparer<Model.Play>
         {
             public int Compare(Model.Play x, Model.Play y)
             {
                 return (x.Price.CompareTo(y.Price));
                 //throw new NotImplementedException();
             }
         }

         //public class SortByGrade : IComparer<Model.Play>
         //{
         //    public int Compare(Model.Play x, Model.Play y)
         //    {
         //        return (x.Grade.CompareTo(y.Price));
         //        //throw new NotImplementedException();
         //    }
         //}

         public List<Model.Play> sortPlayListByPrice(int movieID)
         {
             List<Model.Play> lst;
             lst = getPlayList(movieID);
             lst.Sort(new SortByPrice());
             return lst;
         }



    }
}
