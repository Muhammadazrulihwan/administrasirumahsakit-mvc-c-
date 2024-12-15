using AdminsitrasiRumahSakit.Model.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminsitrasiRumahSakit.Model.Context;
using System.Data.SQLite;
using System.Security.Policy;

namespace AdminsitrasiRumahSakit.Model.Repository
{
    public class PasienRepository
    {
        private SQLiteConnection _conn;

        public PasienRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Pasien pasien)
        {
            int result = 0;
            string sql = @"insert into pasien (nama, jenis_kelamin, alamat, tinggi_badan, berat_badan, tempat_lahir, tanggal_lahir, no_telp) 
                                    values (@nama, @jenis_kelamin, @alamat, @tinggi_badan, @berat_badan, @tempat_lahir, @tanggal_lahir, @no_telp)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@nama", pasien.nama);
                cmd.Parameters.AddWithValue("@jenis_kelamin", pasien.jenis_kelamin);
                cmd.Parameters.AddWithValue("@alamat", pasien.alamat);
                cmd.Parameters.AddWithValue("@tinggi_badan", pasien.tinggi_badan);
                cmd.Parameters.AddWithValue("@berat_badan", pasien.berat_badan);
                cmd.Parameters.AddWithValue("@tempat_lahir", pasien.tempat_lahir);
                cmd.Parameters.AddWithValue("@tanggal_lahir", pasien.tanggal_lahir);
                cmd.Parameters.AddWithValue("@no_telp", pasien.no_telp);

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

        public int Update(Pasien pasien)
        {
            int result = 0;
            string sql = @"update pasien set nama = @nama, jenis_kelamin = @jenis_kelamin, alamat = @alamat, tinggi_badan = @tinggi_badan, 
                                berat_badan = @berat_badan, tempat_lahir = @tempat_lahir, tanggal_lahir = @tanggal_lahir, no_telp = @no_telp where id_pasien = @id_pasien";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_pasien", pasien.id_pasien);
                cmd.Parameters.AddWithValue("@nama", pasien.nama);
                cmd.Parameters.AddWithValue("@jenis_kelamin", pasien.jenis_kelamin);
                cmd.Parameters.AddWithValue("@alamat", pasien.alamat);
                cmd.Parameters.AddWithValue("@tinggi_badan", pasien.tinggi_badan);
                cmd.Parameters.AddWithValue("@berat_badan", pasien.berat_badan);
                cmd.Parameters.AddWithValue("@tempat_lahir", pasien.tempat_lahir);
                cmd.Parameters.AddWithValue("@tanggal_lahir", pasien.tanggal_lahir);
                cmd.Parameters.AddWithValue("@no_telp", pasien.no_telp);

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

        public int Delete(Pasien pasien)
        {
            int result = 0;
            string sql = @"delete from pasien where id_pasien = @id_pasien";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_pasien", pasien.id_pasien);

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

        public List<Pasien> ReadAll()
        {
            List<Pasien> list = new List<Pasien>();
            try
            {
                string sql = @"SELECT id_pasien, nama, jenis_kelamin, alamat, tinggi_badan, berat_badan, tempat_lahir, tanggal_lahir, no_telp 
                            FROM pasien ORDER BY id_pasien DESC";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Pasien pasien = new Pasien();
                            pasien.id_pasien = Convert.ToInt32(dtr["id_pasien"]);
                            pasien.nama = dtr["nama"].ToString();
                            pasien.jenis_kelamin = dtr["jenis_kelamin"].ToString();
                            pasien.alamat = dtr["alamat"].ToString();
                            pasien.tinggi_badan = Convert.ToInt32(dtr["tinggi_badan"].ToString());
                            pasien.berat_badan = Convert.ToInt32(dtr["berat_badan"].ToString());
                            pasien.tempat_lahir = dtr["tempat_lahir"].ToString();
                            pasien.tanggal_lahir = dtr["tanggal_lahir"].ToString();
                            pasien.no_telp = dtr["no_telp"].ToString();

                            list.Add(pasien);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                // Handle SQLite-related exceptions
                System.Diagnostics.Debug.Print("SQLite Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                System.Diagnostics.Debug.Print("Error: {0}", ex.Message);
            }
            return list;
        }

        /*public List<Pasien> ReadAll()
        {
            List<Pasien> list = new List<Pasien>();
            try
            {
                string sql = @"select nama, jenis_kelamin, alamat, tinggi_badan, berat_badan, tempat_lahir, tanggal_lahir 
                                    from pasien order by id_pasien desc";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                     using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Pasien pasien = new Pasien();
                            pasien.id_pasien = Convert.ToInt32(dtr["id_pasien"]);
                            pasien.nama = dtr["nama"].ToString();
                            pasien.jenis_kelamin = dtr["jenis_kelamin"].ToString();
                            pasien.alamat = dtr["alamat"].ToString();
                            pasien.tinggi_badan = Convert.ToInt32(dtr["tinggi_badan"].ToString());
                            pasien.berat_badan = Convert.ToInt32(dtr["berat_badan"].ToString());
                            pasien.tempat_lahir = dtr["tempat_lahir"].ToString();
                            pasien.tanggal_lahir = dtr["tanggal_lahir"].ToString();
                            
                            list.Add(pasien);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }*/

        public List<Pasien> ReadByNama(string nama)
        {
            List<Pasien> list = new List<Pasien>();
            try
            {
                string sql = @"select nama, jenis_kelamin, alamat, tinggi_badan, berat_badan, tempat_lahir, tanggal_lahir, no_telp 
                                    from pasien where nama like @nama order by nama asc";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", $"%{nama}%");
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Pasien pasien = new Pasien();
                            pasien.nama = dtr["nama"].ToString();
                            pasien.jenis_kelamin = dtr["jenis_kelamin"].ToString();
                            pasien.alamat = dtr["alamat"].ToString();
                            pasien.tinggi_badan = Convert.ToInt32(dtr["tinggi_badan"].ToString());
                            pasien.berat_badan = Convert.ToInt32(dtr["berat_badan"].ToString());
                            pasien.tempat_lahir = dtr["tempat_lahir"].ToString();
                            pasien.tanggal_lahir = dtr["tanggal_lahir"].ToString();
                            pasien.no_telp = dtr["no_telp"].ToString();

                            list.Add(pasien);
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
