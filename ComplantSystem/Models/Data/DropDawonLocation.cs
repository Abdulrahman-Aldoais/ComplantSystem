//namespace ComplantSystem.Models.Data
//{
//    public class DropDawonLocation
//    {
//          //Get Country List

//        public DataSet GetCountry()
//        {
//            SqlCommand com = new SqlCommand("Sp_Country", con);
//            com.CommandType = CommandType.StoredProcedure;
//            SqlDataAdapter da = new SqlDataAdapter(com);
//            DataSet ds = new DataSet();
//            da.Fill(ds);
//            return ds;
//        }
//        public DataSet GetState(int cid)
//        {
//            SqlCommand com = new SqlCommand("Sp_State", con);
//            com.CommandType = CommandType.StoredProcedure;
//            com.Parameters.AddWithValue("@Country_id", cid);
//            SqlDataAdapter da = new SqlDataAdapter(com);
//            DataSet ds = new DataSet();
//            da.Fill(ds);
//            return ds;
//        }
//        public DataSet GetCity(int Sid)
//        {
//            SqlCommand com = new SqlCommand("Sp_City", con);
//            com.CommandType = CommandType.StoredProcedure;
//            com.Parameters.AddWithValue("@State_id", Sid);
//            SqlDataAdapter da = new SqlDataAdapter(com);
//            DataSet ds = new DataSet();
//            da.Fill(ds);
//            return ds;
//        }
//    }
//    }
//}