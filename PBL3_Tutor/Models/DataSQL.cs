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
        static ReadSQL rs = new ReadSQL(@"Data Source=HELLO;Initial Catalog=PBL3_Tutor;Integrated Security=True");
        DataTable student = rs.GetRecords("select * from student");
        DataTable account = rs.GetRecords("select * from account");
        DataTable tutor = rs.GetRecords("select * from tutor");
        public DataTable displayinfor(string actor)
        {
            if (actor == "student")
            {
                return rs.GetRecords("SELECT name,birthday,age,numberphone,gender,address,subject,class,luong FROM student");
            } 
            else
            {
                return rs.GetRecords("SELECT name,age,numberphone,gender,address,subject,class,experience FROM student");
            }       
        }
        public void insert(string actor,DataTable dt)
        {
            if (actor == "student")
            {
                student.Rows.Add(dt);
                //rs.ExcuteDB("insert into student(id,name,birthday,age,numberphone,gender,address,subject,class,luong) values "+dt.Rows.ToString());
            }
            if (actor == "account")
            {
                account.Rows.Add(dt);
            }    
            else
            {
                tutor.Rows.Add(dt);
            }    
        }
    }
}
