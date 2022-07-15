
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Project_PRN211.Models;

namespace Project_PRN211.DataAccess
{
    public class ManageDAO
    {
        public static List<RoomTY> listAllRoom()
        {
            List<RoomTY> lstRo = new List<RoomTY>();
            string sql = @"select a.RoomNo, b.RoomPrice, b.NumberOfPersons, a.Status 
                            from Room a inner join RoomType b on a.RoomTypeId = b.RoomTypeId";
            DataTable dt = DAO.getDataBySql(sql);
            foreach (DataRow dr in dt.Rows)
            {
                lstRo.Add(new RoomTY(Convert.ToInt32(dr[0]),
                                    Convert.ToInt32(dr[1]),
                                    Convert.ToInt32(dr[2]),
                                    Convert.ToInt32(dr[3])));
            }
            return lstRo;
        }
    }
}
