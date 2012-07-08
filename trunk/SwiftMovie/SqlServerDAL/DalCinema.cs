using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDAL
{
    public class DalCinema:IDAL.ICinema
    {
        /// <summary>
        /// 获得所有电影院的信息
        /// </summary>
        /// <returns>电影院信息列表</returns>
        public List<Model.Cinema> getCinemaList()
        {
            List<Model.Cinema> lst = new List<Model.Cinema>();
            DataTable dt = DBUtility.SqlHelper.executeTable("select * from vew_Cinemas", CommandType.Text, null);
            foreach (DataRow item in dt.Rows)
            {
                Model.Cinema emp = new Model.Cinema() { CinemaID = int.Parse(item[0].ToString()), CinemaName = item[1].ToString(), Address = item[2].ToString(), CinemaMap = item[3].ToString(), CinemaGrade =item[5].ToString(), CinemaTel = item[4].ToString(),Privilege=item[6].ToString(),
                VIP=item[7].ToString(),Dining=item[8].ToString(),Park=item[9].ToString(),GameCenter=item[10].ToString(),Intro3D=item[11].ToString(),IntroVIP=item[12].ToString(),Introduce=item[13].ToString()};
               
                List<Model.CinemaPic> cinemaPic = new List<Model.CinemaPic>();
                DataTable picDT = DBUtility.SqlHelper.executeTable("select * from CinemaPic where CinemaID=" + int.Parse(item[0].ToString()), CommandType.Text, null);
                foreach(DataRow picItem in picDT.Rows)
                {
                    Model.CinemaPic pic = new Model.CinemaPic() { PicURL = picItem[2].ToString() };
                    cinemaPic.Add(pic);
                }
                emp.CinemaPic = cinemaPic;
                lst.Add(emp);
            }
            return lst;
        }
        /// <summary>
        /// 添加电影院及其信息
        /// </summary>
        /// <param name="cinema">电影院信息</param>
        /// <returns>成功则true，否则false</returns>
        public bool addCinema(Model.Cinema cinema)
        {
            List<Model.Cinema> lst = new List<Model.Cinema>();
            //string sql = "INSERT INTO Cinemas(CinemaName,Address,CinemaMap,CinemaTel,CinemaGrade) Values ('" + cinema.CinemaName + "','" + cinema.Address + "','" + cinema.CinemaMap + "','" + cinema.CinemaTel + "','" + cinema.CinemaGrade + "')";


            string sql2 = "INSERT INTO Cinemas(CinemaID,CinemaName,Address,CinemaMap,CinemaTel,CinemaGrade) Values (@CinemaID,@CinemaName,@Address,@CinemaMap,@CinemaTel,@CinemaGrade);select @@IDENTITY;";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@CinemaID",Value=cinema.CinemaID},
            new SqlParameter(){ ParameterName="@CinemaName", Value=cinema.CinemaName},
            new SqlParameter(){ ParameterName="@Address", Value=cinema.Address},
            new SqlParameter(){ ParameterName="@CinemaMap", Value=cinema.CinemaMap},
            new SqlParameter(){ ParameterName="@CinemaTel", Value=cinema.CinemaTel},
            new SqlParameter(){ ParameterName="@CinemaGrade", Value=float.Parse(cinema.CinemaGrade)}
            };
            int id = DBUtility.SqlHelper.executeScalar(sql2, CommandType.Text, sps);
            if (id == -1)
            {
                return false;
            }

            string sql3 = "INSERT INTO CineNotice(CinemaID,Privilege,VIP) Values (@CinemaID,@Privilege,@VIP)";
            SqlParameter[] sps1 = new SqlParameter[]{
            new SqlParameter(){ParameterName="@CinemaID",Value = id},
            new SqlParameter(){ParameterName ="@Privilege",Value = cinema.Privilege},
            new SqlParameter(){ParameterName ="@VIP",Value = cinema.VIP}
            };
            if (DBUtility.SqlHelper.executeNonQuery(sql3, CommandType.Text, sps1) != 1)
            {
                return false;
            }
            string sql4 = "INSERT INTO CineFacility(CinemaID,Dining,Park,GameCenter,Intro3D,IntroVIP,Introduce) Values (@CinemaID,@Dining,@Park,@GameCenter,@Intro3D,@IntroVIP,@Introduce)";
            SqlParameter[] sps2 = new SqlParameter[]{
            new SqlParameter(){ParameterName ="@CinemaID",Value = id},
            new SqlParameter(){ParameterName="@Dining",Value=cinema.Dining},
            new SqlParameter(){ParameterName="@Park",Value=cinema.Park},
            new SqlParameter(){ParameterName="@GameCenter",Value=cinema.GameCenter},
            new SqlParameter(){ParameterName="@Intro3D",Value=cinema.Intro3D},
            new SqlParameter(){ParameterName="@IntroVIP",Value=cinema.IntroVIP},
            new SqlParameter (){ParameterName ="@Introduce",Value=cinema.Introduce}
            };
            if (DBUtility.SqlHelper.executeNonQuery(sql4, CommandType.Text, sps2) != 1)
            {
                return false;
            }

            List<Model.CinemaPic> cinemaPics = cinema.CinemaPic;
            foreach (Model.CinemaPic c in cinemaPics)
            {
                string sql5 = "INSERT INTO CinemaPic(CinemaID,PicURL) Values (@id,@PicURL)";
                SqlParameter[] sps5 = new SqlParameter[]{
                    new SqlParameter(){ParameterName ="@id",Value=id},
                    new SqlParameter(){ParameterName="@PicURL",Value=c.PicURL}
                    };
                if (DBUtility.SqlHelper.executeNonQuery(sql5, CommandType.Text, sps5) != 1)
                {
                    return false;
                }
            }

            return true;
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 删除电影院及其相关的数据
        /// </summary>
        /// <param name="id">电影院的id</param>
        /// <returns>成功则true，否则false</returns>
        public bool removeCinema(int id)
        {
            //List<Model.Cinema> lst = new List<Model.Cinema>();
            string sql = "Delete From Cinemas where CinemaID=@id";
            string sql2 = "DELETE FROM CineNotice WHERE CinemaID=@id";
            string sql3 = "DELETE FROM CineFacility WHERE CinemaID=@id";
            string sql4 = "DELETE FROM CinemaPic WHERE CinemaID=@id";
            string sql5 = "DELETE FROM CComments WHERE CinemaID=@id";
            string sql6 = "DELETE FROM Plays WHERE CinemaID=@id";
            string sql7 = "DELETE FROM PlayTimes WHERE CinemaID=@id";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName ="@id",Value=id}
            };

            //删除Cinemas表中的相关数据
            if (DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps) != 1)
            {
                return false;
            }
            //删除CineNotice表中的相关数据
            if (DBUtility.SqlHelper.executeNonQuery(sql2, CommandType.Text, sps) != 1)
            {
                return false;
            }
            //删除CineFacility表中的相关数据
            if (DBUtility.SqlHelper.executeNonQuery(sql3, CommandType.Text, sps) != 1)
            {
                return false;
            }
            //删除CinemaPic表中的相关数据
            if (DBUtility.SqlHelper.executeNonQuery(sql4, CommandType.Text, sps) == -1)
            {
                return false;
            }
            //删除CComments表中的相关数据
            if (DBUtility.SqlHelper.executeNonQuery(sql5, CommandType.Text, sps) == -1)
            {
                return false;
            }
            //删除Plays表中的相关数据
            if (DBUtility.SqlHelper.executeNonQuery(sql6, CommandType.Text, sps) == -1)
            {
                return false;
            }
            //删除PlayTimes表中的相关数据
            if (DBUtility.SqlHelper.executeNonQuery(sql7, CommandType.Text, sps) == -1)
            {
                return false;
            }
            return true;
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 更新电影院的相关信息
        /// </summary>
        /// <param name="cinema">电影院信息</param>
        /// <returns>成功则true，否则false</returns>
        public bool editCinema(Model.Cinema cinema)
        {
            //List<Model.Cinema> lst = new List<Model.Cinema>();
            //string sql = "Update Cinemas set CinemaName=" + cinema.CinemaName + ",Address=" + cinema.Address + ",CinemaMap=" + cinema.CinemaMap + ",CinemaTel=" + cinema.CinemaTel + ",CinemaGrade=" + cinema.CinemaGrade + ",where CinemaID="+cinema.CinemaID;

            string sql = "UPDATE Cinemas c SET c.CinemaName=@CinemaName,c.CinemaMap=@CinemaMap,c.CinemaTel=@CinemaTel,c.CinemaGrade=@CinemaGrade WHERE c.CinemaID=@CinemaID";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@CinemaMap",Value=cinema.CinemaMap},
                new SqlParameter(){ParameterName="@CinemaTel",Value=cinema.CinemaTel},
                new SqlParameter(){ParameterName="@CinemaGrade",Value=cinema.CinemaGrade},
                new SqlParameter(){ParameterName="@CinemaName",Value=cinema.CinemaName},
                new SqlParameter(){ParameterName="@CinemaID",Value=cinema.CinemaID}
            };
            int id = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, sps);//获取次电影院的ID
            if (id == -1)
            {
                return false;
            }
            //更新CineNotice表中的相关数据
            string sql2 = "UPDATE CineNotice c SET c.Pricilege=@Pricilege,c.VIP=@VIP WHERE c.CinemaID=@id";
            SqlParameter[] sps2 = new SqlParameter[]{
                new SqlParameter(){ParameterName = "@Pricilege",Value=cinema.Privilege},
                new SqlParameter(){ParameterName ="@VIP",Value=cinema.VIP},
                new SqlParameter(){ParameterName="@id",Value=cinema.CinemaID}
            };
            if (DBUtility.SqlHelper.executeNonQuery(sql2, CommandType.Text, sps2) != 1)
            {
                return false;
            }
            //更新CineFacility表中的相关数据
            string sql3 = "UPDATE CineFacility c SET c.Dining=@Dining,c.Park=@Park,c.GameCenter=@Game,c.Intro3D=@Intro3D,c.IntroVIP=@IntroVIP,c.Introduce=@Introduce WHERE c.CinemaID=@id";
            SqlParameter[] sps3 = new SqlParameter[]{
                new SqlParameter(){ParameterName = "@Dining",Value=cinema.Dining}, 
                new SqlParameter(){ParameterName = "@Park",Value=cinema.Park},
                new SqlParameter(){ParameterName = "@Game",Value=cinema.GameCenter}, 
                new SqlParameter(){ParameterName = "@Intro3D",Value=cinema.Intro3D}, 
                new SqlParameter(){ParameterName = "@IntroVIP",Value=cinema.IntroVIP}, 
                new SqlParameter(){ParameterName = "@Introduce",Value=cinema.Introduce}, 
                new SqlParameter(){ParameterName = "@id",Value=cinema.CinemaID}
            };
            if (DBUtility.SqlHelper.executeNonQuery(sql3, CommandType.Text, sps3) != 1)
            {
                return false;
            }
            //更新CinemaPic表中的相关数据
            string sql4 = "DELETE FROM CinemaPic WHERE CinemaID=@id";
            SqlParameter[] sps4 = new SqlParameter[]{
                new SqlParameter(){ParameterName="@id",Value=cinema.CinemaID}
            };
            if (DBUtility.SqlHelper.executeNonQuery(sql4, CommandType.Text, sps4) == -1)
            {
                return false;
            }
            List<Model.CinemaPic> cinemaPics = cinema.CinemaPic;
            foreach(Model.CinemaPic c in cinemaPics)
            {
                string sql5 = "INSERT INTO CinemaPic(CinemaID,PicURL) Values (@id,@PicURL)";
                SqlParameter[] sps5 = new SqlParameter[]{
                    new SqlParameter(){ParameterName ="@id",Value=cinema.CinemaID},
                    new SqlParameter(){ParameterName="@PicURL",Value=c.PicURL}
                    };
                if (DBUtility.SqlHelper.executeNonQuery(sql5, CommandType.Text, sps5) != 1)
                {
                    return false;
                }
            }

            //int dt = DBUtility.SqlHelper.executeNonQuery(sql, CommandType.Text, null);
            //if (dt == 1) return true;
            //else return false;
            return true;
            //throw new NotImplementedException();
        }

        public Model.Cinema getCinemaById(int id)
        {
            Model.Cinema cinema = new Model.Cinema();
            string sql = "SELECT * FROM vew_Cinemas WHERE CinemaID=@id";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@id",Value=id}
            };
            SqlDataReader sr = DBUtility.SqlHelper.executeReader(sql, CommandType.Text, sps);
            if (sr.Read())
            {
                cinema.CinemaID = int.Parse(sr[0].ToString());
                cinema.CinemaName = sr[1].ToString();
                cinema.Address = sr[2].ToString();
                cinema.CinemaMap = sr[3].ToString();
                cinema.CinemaTel = sr[4].ToString();
                cinema.CinemaGrade = sr[5].ToString();
                cinema.Privilege = sr[6].ToString();
                cinema.VIP = sr[7].ToString();
                cinema.Dining = sr[8].ToString();
                cinema.Park = sr[9].ToString();
                cinema.GameCenter = sr[10].ToString();
                cinema.Intro3D = sr[11].ToString();
                cinema.IntroVIP = sr[12].ToString();
                cinema.Introduce = sr[13].ToString();

                List<Model.CinemaPic> pics = new List<Model.CinemaPic>();
                string sql1 = "SELECT * FROM CinemaPic WHERE CinemaID=@cinemaID";
                SqlParameter[] sps2 = new SqlParameter[]{
                    new SqlParameter(){ParameterName="@cinemaID",Value=cinema.CinemaID}
                };
                DataTable dt = DBUtility.SqlHelper.executeTable(sql1, CommandType.Text, sps2);
                foreach (DataRow item in dt.Rows) {
                    Model.CinemaPic pic = new Model.CinemaPic() { PicURL = item[0].ToString() };
                    pics.Add(pic);
                }
                cinema.CinemaPic = pics;

                return cinema;
            }
            return null;
            //throw new NotImplementedException();
        }


        public int getCinemaIdByName(string name)
        {
            string sql = "SELECT * FROM Cinemas WHERE CinemaName = @Name";
            SqlParameter[] sps = new SqlParameter[]{
                new SqlParameter(){ParameterName="@Name",Value=name}
            };
            return DBUtility.SqlHelper.executeScalar(sql,CommandType.Text,sps);
        }
    }
}
