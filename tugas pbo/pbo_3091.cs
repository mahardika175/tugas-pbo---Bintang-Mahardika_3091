using Npgsql;
using System.Data;
namespace TugasPbo
{
    class getting_data
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=killpack@11;database=pbo;");
        }
        public bool ExecuteQuery(out bool info)

        {
            info = true;
            try
            {

                NpgsqlConnection con = koneksi();
                con.Open();
                string sql = "select * from karyawan";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return info;
            }
            catch (Exception)
            {
                info = false;
                return info;
            }

        }
    }
    class operasi
    {
        private static NpgsqlConnection koneksi()
        {
            return new NpgsqlConnection(@"server=localhost;port=5432;user id=postgres;password=killpack@11;database=pbo;");
        }
        public bool insert(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into karyawan(id_karyawan,nama,no_hp) values('1','arthur','083849328808')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
        public bool update(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("update karyawan set nama = lucas, no_hp = 082139242512 where id_karyawan = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
        public bool Delete(ref bool info)
        {
            try
            {
                NpgsqlConnection con = koneksi();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("delete from karyawan where id_karyawan = 1", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                info = true;
                return info;
            }
            catch (Exception)
            {
                return info;
            }
        }
    }
    class program_utama
    {
        static void Main(string[] args)
        {
            bool info;
            bool ingfo = false;
            getting_data dat = new getting_data();
            operasi op = new operasi();
            if (dat.ExecuteQuery(out info) == true)
            {
                Console.WriteLine("data terkonfirmasi");
            }
            else if (dat.ExecuteQuery(out info) == false)
            {
                Console.WriteLine("data tidak terkonfirmasi");
            }
            if (op.insert(ref ingfo) == true)
            {
                Console.WriteLine("insert sukses");
            }
            else if (op.insert(ref ingfo) == false)
            {
                Console.WriteLine("insert gagal");
            }
            if (op.update(ref ingfo) == true)
            {
                Console.WriteLine("update sukses");
            }
            else if (op.update(ref ingfo) == false)
            {
                Console.WriteLine("update gagal");
            }
            if (op.Delete(ref ingfo) == true)
            {
                Console.WriteLine("delete sukses");
            }
            else if (op.Delete(ref ingfo) == false)
            {
                Console.WriteLine("delete gagal");
            }
        }
    }
}