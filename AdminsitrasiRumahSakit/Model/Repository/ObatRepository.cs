using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Policy;
using System.Data.SQLite;
using System.Diagnostics;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;

namespace AdminsitrasiRumahSakit.Model.Repository
{
    public class ObatRepository
    {
        private SQLiteConnection _conn;

        public ObatRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Obat obat)
        {
            int result = 0;
            string sql = @"insert into obat (nama_obat, stok, harga) values (@nama_obat, @stok, @harga)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama_obat", obat.nama_obat);
                cmd.Parameters.AddWithValue("@stok", obat.stok);
                cmd.Parameters.AddWithValue("@harga", obat.harga);

                try
                {
                    result = cmd.ExecuteNonQuery();
                    Debug.Print("Create success. Rows affected: " + result);
                }
                catch (Exception ex)
                {
                    Debug.Print($"Create error: {ex.Message}");
                }
            }
            return result;
        }

        public int Update(Obat obat)
        {
            int result = 0;
            string sql = @"update obat set nama_obat = @nama_obat, stok = @stok, harga = @harga where id_obat = @id_obat";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_obat", obat.id_obat);
                cmd.Parameters.AddWithValue("@nama_obat", obat.nama_obat);
                cmd.Parameters.AddWithValue("@stok", obat.stok);
                cmd.Parameters.AddWithValue("@harga", obat.harga);

                try
                {
                    result = cmd.ExecuteNonQuery();
                    Debug.Print("Update success. Rows affected: " + result);
                }
                catch (Exception ex)
                {
                    Debug.Print($"Update error: {ex.Message}");
                }
            }
            return result;
        }


        public int Delete(Obat obat)
        {
            int result = 0;
            string sql = @"delete from obat where id_obat = @id_obat";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_obat", obat.id_obat);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.Print($"Delete error: {ex.Message}");
                }
            }
            return result;
        }

        public List<Obat> ReadAll()
        {
            List<Obat> list = new List<Obat>();
            try
            {
                string sql = @"select id_obat, nama_obat, stok, harga from obat order by id_obat desc";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Obat obat = new Obat
                            {
                                id_obat = Convert.ToInt32(dtr["id_obat"]),
                                nama_obat = dtr["nama_obat"].ToString(),
                                stok = Convert.ToInt32(dtr["stok"]),
                                harga = Convert.ToInt32(dtr["harga"])
                            };

                            list.Add(obat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"ReadAll error: {ex.Message}");
            }
            return list;
        }

        public List<Obat> ReadByNama(string nama)
        {
            List<Obat> list = new List<Obat>();
            try
            {
                string sql = @"select id_obat, nama_obat, stok, harga from obat where nama_obat like @nama_obat order by nama_obat";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama_obat", $"%{nama}%");
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Obat obat = new Obat
                            {
                                id_obat = Convert.ToInt32(dtr["id_obat"]),
                                nama_obat = dtr["nama_obat"].ToString(),
                                stok = Convert.ToInt32(dtr["stok"]),
                                harga = Convert.ToInt32(dtr["harga"])
                            };

                            list.Add(obat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"ReadByNama error: {ex.Message}");
            }
            return list;
        }
    }
}
