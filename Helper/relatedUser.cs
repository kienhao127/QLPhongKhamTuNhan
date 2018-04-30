using MySql.Data.MySqlClient;
using Manager;
using QLPhongKhamTuNhan.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Helper
{
    class relatedUser
    {
        /*
         * ham dang nhap
         * dau vao: user - ten dang nhap, pass - mat khau
         * tra ve:  -1 - khong ket noi duoc database
         *          0 - nhap sai ten dang nhap va mat khau
         *          1 - nhap sai ten dang nhap
         *          2 - nhap sai mat khau
         *          3 - dang nhap thanh cong
        */
        static public short logIn(string user,string pass)
        {
            DataTable dt = Active.select("select user,pw from user where user='" + user + "' and pw='" + encodePassword.Encode(pass) + "'");

            if (dt == null) return -1;

            if (dt.Rows.Count == 0) return 0;

            if (dt.Rows[0][0].ToString() != user) return 1;

            if (dt.Rows[0][1].ToString() != encodePassword.Encode(pass)) return 2;

            return 3;
        }
        /*
         * ham them nguoi su dung phan mem
         * dau vao: u - thong tin co ban cua nguoi dung gom (ten dang nhap, ho ten, mat khau, email)
         * tra ve: -1 - khong ket noi duoc database
         *          0 - bi trung ten dang nhap khong the them nguoi dung
         *          >0 - ma nguoi dung da them thanh cong
         */
        static public short addUser(User u)
        {
            short id = Active.insert("INSERT INTO user(user, name, pw, email) VALUES ('" + u.name + "',N'" + u.full_name + "','" + encodePassword.Encode(u.password) + "','" + u.email + "')");
            if (id == -1 || id == 0) return id;
            return Convert.ToInt16(Active.select("SELECT id FROM user WHERE user='" + u.name + "'").Rows[0][0].ToString());
        }

        static public bool addRoleForUser(User u)
        {
            return Convert.ToBoolean(Active.update("UPDATE user SET role_id='" + u.role_id + "' WHERE id='" + u.id + "'"));
        }

        static public short addRole(string role_name,int user_id_add)
        {
            return Active.insert("INSERT INTO role(name, user_id_change) VALUES (N'" + role_name + "','" + user_id_add + "')");
        }

        static public DataTable tableRole()
        {
            return Active.select("SELECT id, name, user_id_change FROM role");
        }

        static public List<int> listFunctionByRole(int role_id)
        {
            return (from row in Active.@select("SELECT function FROM role_function WHERE role='" + role_id + "' and is_delete=0").AsEnumerable()
                    select Convert.ToInt32(row["function"])).ToList();
        }        
    }
}
