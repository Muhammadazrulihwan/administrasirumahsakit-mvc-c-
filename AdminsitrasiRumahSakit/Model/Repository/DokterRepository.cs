using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using AdminsitrasiRumahSakit.Model.Context;
using System.Data.SQLite;
using AdminsitrasiRumahSakit.Model.Entity;
using System.Security.Policy;
using System.Diagnostics;

namespace AdminsitrasiRumahSakit.Model.Repository
{
    public class DokterRepository
    {
        private SQLiteConnection _conn;

        public DokterRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Dokter dokter)
        {
            int result = 0;
            string sql = @"insert into dokter (nama, spesialis, no_telp, alamat) values (@nama, @spesialis, @no_telp, @alamat)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", dokter.nama);
                cmd.Parameters.AddWithValue("@spesialis", dokter.spesialis);
                cmd.Parameters.AddWithValue("@no_telp", dokter.no_telp);
                cmd.Parameters.AddWithValue("@alamat", dokter.alamat);

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

        public int Update(Dokter dokter)
        {
            int result = 0;
            string sql = @"update dokter set nama = @nama, spesialis = @spesialis, no_telp = @no_telp, alamat = @alamat where id_dokter = @id_dokter";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_dokter", dokter.id_dokter);
                cmd.Parameters.AddWithValue("@nama", dokter.nama);
                cmd.Parameters.AddWithValue("@spesialis", dokter.spesialis);
                cmd.Parameters.AddWithValue("@no_telp", dokter.no_telp);
                cmd.Parameters.AddWithValue("@alamat", dokter.alamat);

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

        public int Delete(Dokter dokter)
        {
            int result = 0;
            string sql = @"delete from dokter where id_dokter = @id_dokter";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_dokter", dokter.id_dokter);

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

        public List<Dokter> ReadAll()
        {
            List<Dokter> list = new List<Dokter>();
            try
            {
                string sql = @"select id_dokter, nama, spesialis, no_telp, alamat from dokter order by id_dokter desc";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Dokter dokter = new Dokter
                            {
                                id_dokter = Convert.ToInt32(dtr["id_dokter"]),
                                nama = dtr["nama"].ToString(),
                                spesialis = dtr["spesialis"].ToString(),
                                no_telp = dtr["no_telp"].ToString(),
                                alamat = dtr["alamat"].ToString()
                            };

                            list.Add(dokter);
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

        public List<Dokter> ReadByNama(string nama)
        {
            List<Dokter> list = new List<Dokter>();
            try
            {
                string sql = @"select nama, spesialis, no_telp, alamat from dokter where nama like @nama order by nama";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", $"%{nama}%");
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Dokter dokter = new Dokter();
                            dokter.nama = dtr["nama"].ToString();
                            dokter.spesialis = dtr["spesialis"].ToString();
                            dokter.no_telp = dtr["no_telp"].ToString();
                            dokter.alamat = dtr["alamat"].ToString();
                            list.Add(dokter);
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
