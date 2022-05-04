using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PBL3_Tutor.Models
{
    public class DataSQL
    {
        public string s = @"Data Source=HELLO;Initial Catalog=PBL3_Tutor;Integrated Security=True";
        SqlConnection cnn=new SqlConnection();
        string query = "select * from SV";
        SqlCommand cmd=new SqlCommand();
        SqlDataReader r;
        // DataTable dtacount=new DataTable();
        DataTable dtstudent=new DataTable();
        DataTable dttutor = new DataTable();
        public void readsql() 
        {
            cnn = new SqlConnection(s);
            cmd=new SqlCommand(query,cnn);
            cnn.Open();
            dtstudent.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName="Name",DataType=typeof(string) },
                new DataColumn {ColumnName="Age",DataType=typeof(int) },
                new DataColumn {ColumnName="Number Phone",DataType = typeof(string) },
                new DataColumn {ColumnName ="Gender", DataType = typeof(bool) },
                new DataColumn {ColumnName="Address",DataType=typeof(string)},
                new DataColumn {ColumnName="Class" ,DataType=typeof(string) },
                new DataColumn {ColumnName=""}

            

            });
        }
    }
}
