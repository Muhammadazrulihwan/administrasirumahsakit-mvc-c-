using AdminsitrasiRumahSakit.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;

namespace AdminsitrasiRumahSakit.Model.Repository
{
    public class RuanganInapRepository
    {
        private SQLiteConnection _conn;

        public RuanganInapRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(RuanganInap kamar)
        {
            int result = 0;
            string sql = @"insert into ruangan_inap (nama, tipe, harga) values (@nama, @tipe, @harga)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", kamar.nama);
                cmd.Parameters.AddWithValue("@tipe", kamar.tipe);
                cmd.Parameters.AddWithValue("@harga", kamar.harga);

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

        public int Update(RuanganInap kamar)
        {
            int result = 0;
            string sql = @"update ruangan_inap set nama = @nama, tipe = @tipe, harga = @harga where id_ruangan = @id_ruangan";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_ruangan", kamar.id_ruangan);
                cmd.Parameters.AddWithValue("@nama", kamar.nama);
                cmd.Parameters.AddWithValue("@tipe", kamar.tipe);
                cmd.Parameters.AddWithValue("@harga", kamar.harga);

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

        public int Delete(RuanganInap kamar)
        {
            int result = 0;
            string sql = @"delete from ruangan_inap where id_ruangan = @id_ruangan";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_ruangan", kamar.id_ruangan);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print($"Delete error: {ex.Message}");
                }
            }
            return result;
        }

        public List<RuanganInap> ReadAll()
        {
            List<RuanganInap> list = new List<RuanganInap>();
            try
            {
                string sql = @"select id_ruangan, nama, tipe, harga from ruangan_inap WHERE nama != '-' AND tipe != '-' order by id_ruangan desc";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            RuanganInap kamar = new RuanganInap
                            {
                                id_ruangan = Convert.ToInt32(dtr["id_ruangan"]),
                                nama = dtr["nama"].ToString(),
                                tipe = dtr["tipe"].ToString(),
                                harga = Convert.ToInt32(dtr["harga"].ToString()),
                            };

                            list.Add(kamar);
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

        public List<RuanganInap> ReadByNama(string nama)
        {
            List<RuanganInap> list = new List<RuanganInap>();
            try
            {
                string sql = @"select nama, tipe, harga from ruangan_inap where nama like @nama order by nama asc";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", $"%{nama}%");
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            RuanganInap kamar = new RuanganInap();
                            kamar.nama = dtr["nama"].ToString();
                            kamar.tipe = dtr["tipe"].ToString();
                            kamar.harga = Convert.ToInt32(dtr["harga"].ToString());
                            list.Add(kamar);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print($"ReadByNama error: {ex.Message}");
            }
            return list;
        }
    }
}
