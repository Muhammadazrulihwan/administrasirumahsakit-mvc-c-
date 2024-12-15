using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminsitrasiRumahSakit.Model.Context;
using AdminsitrasiRumahSakit.Model.Entity;
using System.Data;
using Org.BouncyCastle.Crypto.Macs;

namespace AdminsitrasiRumahSakit.Model.Repository
{
    public class RekamMedisRepository
    {
        private SQLiteConnection _conn;

        public RekamMedisRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(RekamMedis medis)
        {
            int result = 0;
            string sql = @"insert into data_rekam_medis (id_rekam_medis, nama_pasien, nama_dokter, nama_ruangan, nama_obat, diagnosis, tindakan, tgl_masuk, tgl_keluar) 
                            values (@id_rekam_medis, @nama_pasien, @nama_dokter, @nama_ruangan, @nama_obat, @diagnosis, @tindakan, @tgl_masuk, @tgl_keluar)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_rekam_medis", medis.id_rekam_medis);
                cmd.Parameters.AddWithValue("@nama_pasien", medis.nama_pasien);
                cmd.Parameters.AddWithValue("@nama_dokter", medis.nama_dokter);
                cmd.Parameters.AddWithValue("@nama_ruangan", medis.nama_ruangan);
                cmd.Parameters.AddWithValue("@nama_obat", medis.nama_obat);
                cmd.Parameters.AddWithValue("@diagnosis", medis.diagnosis);
                cmd.Parameters.AddWithValue("@tindakan", medis.tindakan);
                cmd.Parameters.AddWithValue("@tgl_masuk", medis.tgl_masuk);
                cmd.Parameters.AddWithValue("@tgl_keluar", medis.tgl_keluar);

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

        public int Update(RekamMedis medis)
        {
            int result = 0;
            string sql = @"update data_rekam_medis set nama_pasien = @nama_pasien, nama_dokter = @nama_dokter, 
                            nama_ruangan = @nama_ruangan, nama_obat = @nama_obat, diagnosis = @diagnosis, 
                            tindakan = @tindakan, tgl_masuk = @tgl_masuk, tgl_keluar = @tgl_keluar 
                            where id_rekam_medis = @id_rekam_medis";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_rekam_medis", medis.id_rekam_medis);
                cmd.Parameters.AddWithValue("@nama_pasien", medis.nama_pasien);
                cmd.Parameters.AddWithValue("@nama_dokter", medis.nama_dokter);
                cmd.Parameters.AddWithValue("@nama_ruangan", medis.nama_ruangan);
                cmd.Parameters.AddWithValue("@nama_obat", medis.nama_obat);
                cmd.Parameters.AddWithValue("@diagnosis", medis.diagnosis);
                cmd.Parameters.AddWithValue("@tindakan", medis.tindakan);
                cmd.Parameters.AddWithValue("@tgl_masuk", medis.tgl_masuk);
                cmd.Parameters.AddWithValue("@tgl_keluar", medis.tgl_keluar);

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

        public int Delete(RekamMedis medis)
        {
            int result = 0;
            string sql = @"delete from data_rekam_medis where id_rekam_medis = @id_rekam_medis";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_rekam_medis", medis.id_rekam_medis);

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

        public List<RekamMedis> ReadAll()
        {
            List<RekamMedis> list = new List<RekamMedis>();
            try
            {
                string sql = @"select id_rekam_medis, nama_pasien, nama_dokter, nama_ruangan, nama_obat, diagnosis, tindakan, 
                                tgl_masuk, tgl_keluar from data_rekam_medis";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {

                            RekamMedis medis = new RekamMedis
                            {
                                id_rekam_medis = dtr[0].ToString(),
                                nama_pasien = dtr[1].ToString(),
                                nama_dokter = dtr[2].ToString(),
                                nama_ruangan = dtr[3].ToString(),
                                nama_obat = dtr[4].ToString(),
                                diagnosis = dtr[5].ToString(),
                                tindakan = dtr[6].ToString(),
                                tgl_masuk = dtr[7].ToString(),
                                tgl_keluar = dtr[8].ToString()
                            };
                            list.Add(medis);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                System.Diagnostics.Debug.Print("SQLite Error: {0}", ex.Message);
                // Handle SQLite-related exceptions
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Error: {0}", ex.Message);
                // Handle other exceptions
            }
            return list;
        }



        public List<RekamMedis> ReadByNama(string nama)
        {
            List<RekamMedis> list = new List<RekamMedis>();
            try
            {
                string sql = @"select id_rekam_medis, nama_pasien, nama_dokter, nama_ruangan, nama_obat, diagnosis, tindakan, tgl_masuk, tgl_keluar 
                                from data_rekam_medis WHERE nama_pasien LIKE @nama";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", $"%{nama}%");
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            RekamMedis medis = new RekamMedis
                            {
                                id_rekam_medis = dtr[0].ToString(),
                                nama_pasien = dtr[1].ToString(),
                                nama_dokter = dtr[2].ToString(),
                                nama_ruangan = dtr[3].ToString(),
                                nama_obat = dtr[4].ToString(),
                                diagnosis = dtr[5].ToString(),
                                tindakan = dtr[6].ToString(),
                                tgl_masuk = dtr[7].ToString(),
                                tgl_keluar = dtr[8].ToString()
                            };

                            list.Add(medis);
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
