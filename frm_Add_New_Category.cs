using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ganesh_Cycle_Agency
{
    public partial class frm_Add_New_Category : Form
    {
        public frm_Add_New_Category()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Ganesh_Cycle_Agency_DB;Integrated Security=True");

        void Con_Open()
        {
            if (Con.State != ConnectionState.Open)
            {
                Con.Open();
            }
        }
        void Con_Close()
        {
            if (Con.State != ConnectionState.Closed)
            {
                Con.Close();
            }
        }

        void Clear_Controls()
        {
            tb_Category_ID.Text = Convert.ToString (Auto_Incr());
            tb_Category_Name.Clear();
        }

        int Auto_Incr()
        {
            int cnt = 0;
            Con_Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandText = "Select Count(*) From Category_Details";

            cnt = Convert.ToInt32(cmd.ExecuteScalar());

            if (cnt > 0)
            {
                cmd.CommandText = "Select Max(Category_ID) From Category_Details";
                cnt = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            else
            {
                cnt = 1;
            }
            Con_Close();
            return cnt;
        } 
       
        private void btn_Save_Click(object sender, EventArgs e)
        {
            Con_Open();

            if (tb_Category_ID.Text != "" && tb_Category_Name.Text != "")
            {
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = Con;
                cmd.CommandText = "Insert Into Category_Details(Category_ID,Category_Name)values(@CID,@CName)";

                cmd.Parameters.Add("CID", SqlDbType.Int).Value = tb_Category_ID.Text;
                cmd.Parameters.Add("CName", SqlDbType.VarChar).Value = tb_Category_Name.Text;


                cmd.ExecuteNonQuery();

                MessageBox.Show("Record inserted successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Clear_Controls();
            }
            else
            {
                MessageBox.Show("First fill all fields", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Con_Close();
        }

        private void frm_Add_New_Category_Load(object sender, EventArgs e)
        {
            Auto_Incr();
            Clear_Controls();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            frm_Product obj = new frm_Product();
            obj.Show();
            this.Hide();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure You Want to Logout ?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                frm_Login obj = new frm_Login();
                obj.Show();
                this.Hide();
            }
        }
    }
}

  

