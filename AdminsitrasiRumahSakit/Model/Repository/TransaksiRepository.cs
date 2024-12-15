using AdminsitrasiRumahSakit.Model.Entity;
using AdminsitrasiRumahSakit.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminsitrasiRumahSakit.Model.Repository
{
    public class TransaksiRepository
    {
        private SQLiteConnection _conn;

        public TransaksiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(Transaksi transaksi)
        {
            int result = 0;
            string sql = @"INSERT INTO transaksi(id_rekam_medis, jumlah_obat, lama_inap, tanggal, jatuh_tempo, status, total)
                        VALUES(@id_rekam_medis, @jumlah_obat, @lama_inap, @tanggal, @jatuh_tempo, @status, @total)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_rekam_medis", transaksi.id_rekam_medis);
                cmd.Parameters.AddWithValue("@jumlah_obat", transaksi.jumlah_obat);
                cmd.Parameters.AddWithValue("@lama_inap", transaksi.lama_inap);
                cmd.Parameters.AddWithValue("@tanggal", transaksi.tanggal);
                cmd.Parameters.AddWithValue("@jatuh_tempo", transaksi.jatuh_tempo);
                cmd.Parameters.AddWithValue("@status", transaksi.status);
                cmd.Parameters.AddWithValue("@total", transaksi.total);

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

        public int Update(Transaksi transaksi)
        {
            int result = 0;
            string sql = @"update transaksi set id_rekam_medis = @id_rekam_medis, jumlah_obat = @jumlah_obat, lama_inap = @lama_inap, 
                    tanggal = @tanggal, jatuh_tempo = @jatuh_tempo, status = @status, total = @total 
                    where id_transaksi = @id_transaksi";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_transaksi", transaksi.id_transaksi);
                cmd.Parameters.AddWithValue("@id_rekam_medis", transaksi.id_rekam_medis);
                cmd.Parameters.AddWithValue("@jumlah_obat", transaksi.jumlah_obat);
                cmd.Parameters.AddWithValue("@lama_inap", transaksi.lama_inap);
                cmd.Parameters.AddWithValue("@tanggal", transaksi.tanggal);
                cmd.Parameters.AddWithValue("@jatuh_tempo", transaksi.jatuh_tempo);
                cmd.Parameters.AddWithValue("@status", transaksi.status);
                cmd.Parameters.AddWithValue("@total", transaksi.total);

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


        public int Delete(Transaksi transaksi)
        {
            int result = 0;
            string sql = @"delete from transaksi where id_transaksi = @id_transaksi";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_transaksi", transaksi.id_transaksi);

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

        public List<Transaksi> ReadAll()
        {
            List<Transaksi> list = new List<Transaksi>();
            try
            {
                string sql = @"SELECT transaksi.id_transaksi, transaksi.id_rekam_medis, data_rekam_medis.nama_pasien, 
                data_rekam_medis.nama_dokter, data_rekam_medis.diagnosis, data_rekam_medis.nama_obat, obat.harga, transaksi.jumlah_obat, 
                data_rekam_medis.nama_ruangan, ruangan_inap.harga, transaksi.lama_inap, transaksi.tanggal, 
                transaksi.jatuh_tempo, transaksi.total, transaksi.status 
                FROM transaksi
                INNER join data_rekam_medis on transaksi.id_rekam_medis = data_rekam_medis.id_rekam_medis
                INNER join obat on data_rekam_medis.nama_obat = obat.nama_obat
                INNER join ruangan_inap on data_rekam_medis.nama_ruangan = ruangan_inap.nama";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {

                            Transaksi transaksi = new Transaksi
                            {
                                id_transaksi = Convert.ToInt32(dtr[0].ToString()),
                                id_rekam_medis = dtr[1].ToString(),
                                nama_pasien = dtr[2].ToString(),
                                nama_dokter = dtr[3].ToString(),
                                diagnosis = dtr[4].ToString(),
                                nama_obat = dtr[5].ToString(),
                                harga_obat = Convert.ToInt32(dtr[6].ToString()),
                                jumlah_obat = Convert.ToInt32(dtr[7].ToString()),
                                nama_ruangan = dtr[8].ToString(),
                                harga_ruangan = Convert.ToInt32(dtr[9].ToString()),
                                lama_inap = Convert.ToInt32(dtr[10].ToString()),
                                tanggal = dtr[11].ToString(),
                                jatuh_tempo = dtr[12].ToString(),
                                total = Convert.ToInt32(dtr[13].ToString()),
                                status = dtr[14].ToString(),
                            };
                            list.Add(transaksi);
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



        public List<Transaksi> ReadByNama(string nama)
        {
            List<Transaksi> list = new List<Transaksi>();
            try
            {
                string sql = @"SELECT transaksi.id_transaksi, transaksi.id_rekam_medis, data_rekam_medis.nama_pasien, 
                data_rekam_medis.nama_dokter, data_rekam_medis.diagnosis, data_rekam_medis.nama_obat, obat.harga, transaksi.jumlah_obat, 
                data_rekam_medis.nama_ruangan, ruangan_inap.harga, transaksi.lama_inap, transaksi.tanggal, 
                transaksi.jatuh_tempo, transaksi.total, transaksi.status 
                FROM transaksi
                INNER join data_rekam_medis on transaksi.id_rekam_medis = data_rekam_medis.id_rekam_medis
                INNER join obat on data_rekam_medis.nama_obat = obat.nama_obat
                INNER join ruangan_inap on data_rekam_medis.nama_ruangan = ruangan_inap.nama
                WHERE data_rekam_medis.nama_pasien LIKE @nama";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", $"%{nama}%");
                    using (SQLiteDataReader dtr = cmd.ExecuteReader())
                    {
                        while (dtr.Read())
                        {
                            Transaksi transaksi = new Transaksi
                            {
                                id_transaksi = Convert.ToInt32(dtr[0].ToString()),
                                id_rekam_medis = dtr[1].ToString(),
                                nama_pasien = dtr[2].ToString(),
                                nama_dokter = dtr[3].ToString(),
                                diagnosis = dtr[4].ToString(),
                                nama_obat = dtr[5].ToString(),
                                harga_obat = Convert.ToInt32(dtr[6].ToString()),
                                jumlah_obat = Convert.ToInt32(dtr[7].ToString()),
                                nama_ruangan = dtr[8].ToString(),
                                harga_ruangan = Convert.ToInt32(dtr[9].ToString()),
                                lama_inap = Convert.ToInt32(dtr[10].ToString()),
                                tanggal = dtr[11].ToString(),
                                jatuh_tempo = dtr[12].ToString(),
                                total = Convert.ToInt32(dtr[13].ToString()),
                                status = dtr[14].ToString(),
                            };

                            list.Add(transaksi);
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
