﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace sqlServerAdo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shipper> shippers = new List<Shipper>();

            //SqlConnection: verilen conectionstring üzerinden veri tabanına baglanır.
            string constr = "Server=(localdb)\\mssqllocaldb; Database = Northwind; Trusted_Connection = True; TrustServerCertificate=true";
            SqlConnection con = new SqlConnection(constr);

            //SqlCommand: SqlConnection nesnesine ihtiyaç duyar.
            //Çalıştığı zaman gerekli sql scriptler yazılarak sonuç beklenir.

           
           try
           {
                 con.Open();
                //Reading data from SQl
                //SqlCommand cmd2 = con.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "Select * from Shippers";
                //SqlDataReader rdr = cmd.ExecuteReader();

                //while (rdr.Read())
                //{
                //    Shipper shipper = new Shipper();
                //    shipper.ShipperId = int.Parse(rdr[0].ToString());
                //    shipper.CompanyName = rdr[1].ToString();
                //    shipper.Phone = rdr[2].ToString();
                //    shippers.Add(shipper);
                //}

                //shippers.ForEach(shipper => Console.WriteLine(shipper.ShipperId + " " + shipper.CompanyName + " " + shipper.Phone));

                //Console.WriteLine("Durum:" + con.State);

                //----CRUD operations
                //create => ınsert
                string insertsql = "insert into shippers (companyname,phone) values('yurtici kargo','444 6677')";
                string updatesql = "update shippers set phone='444 99 88' where companyname='yurtici kargo'";
                string deletesql = "delete shippers where companyname='speedy express' ";
                cmd.commandtext = deletesql;
                int res = cmd.ExecuteNonQuery();

                if (sonuc > 0)
                {
                    console.writeline("Transaction successful");
                }
                else
                {

                    console.writeline("Transaction failed");
                }

                //DataSet, DataTable, SqlDataAdaptor usage
                cmd.CommandText = "Select * from Shippers";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.InsertCommand.CommandText = "Insert into ....";
                DataSet ds = new DataSet(); // Database'e karşılık gelen nesne.
                DataTable table = new DataTable(); // Database de tabloya karşılık gelen nesne.

                adapter.Fill(ds);
                adapter.Fill(table);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    Console.WriteLine(item["ShipperId"] + " " + item["CompanyName"]);
                }
                adapter.Fill(table);
                Console.WriteLine(" Table ");
                foreach (DataRow item in table.Rows)
                {
                    Console.WriteLine(item["ShipperId"] + " " + item["CompanyName"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open) ;
                con.Close();
            }
        }
    }
    public struct Shipper
    {
        public int ShipperId;
        public string CompanyName;
        public string Phone;
    }
}
