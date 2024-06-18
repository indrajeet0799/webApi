using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCPratice.Models
{
    public class BALUser
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RTCHIJF;Initial Catalog=MVCPractice;Integrated Security=True");
        public void SaveDate(string Name,string Address, Int64 Phone, int BOD,string Gender, string Email, int CityId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCPratice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "save");
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@BOD", BOD);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@CityId", CityId);
           
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public DataSet GetCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCPratice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "Country");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public DataSet GetState(int CountryId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCPratice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "State");
            cmd.Parameters.AddWithValue("@CountryId", CountryId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;



            con.Close();
        }
        public DataSet GetCity(int stateId)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("MVCPratice", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "City");
            cmd.Parameters.AddWithValue("@stateId", stateId);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            return ds;

            con.Close();
        }


    }
}