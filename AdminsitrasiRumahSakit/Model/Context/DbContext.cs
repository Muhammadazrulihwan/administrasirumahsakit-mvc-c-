﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace AdminsitrasiRumahSakit.Model.Context
{
    public class DbContext : IDisposable
    {
        
        private SQLiteConnection _conn;
        
        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
       
        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null; 
            try 
            {
                
                string dbName = @"D:\amikom\Semester 3\Pemrograman Lanjut\uas\DBase\rumah-sakit-no-foreignkey.db";
          
                string connectionString = string.Format("Data Source ={0}; FailIfMissing = True", dbName);
                 conn = new SQLiteConnection(connectionString); 
                   conn.Open(); // buka koneksi ke database
            }
            
                 catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}",
               ex.Message);
            }
            return conn;
        }
       
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }


}