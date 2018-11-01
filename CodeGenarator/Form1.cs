using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenarator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 连接测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnconnect_Click(object sender, EventArgs e)
        {

            //获取ip port name pwd
            string ip = txtip.Text.Trim();
            string port = txtport.Text.Trim();
            string name = txtuname.Text.Trim();
            string pwd = txtpwd.Text.Trim();
            bool bdb=directnull(cbdbtype.Text, "数据库类型");
            bool bip = directnull(ip, "ip地址");
            bool bport = directnull(port, "端口");
            bool bname = directnull(name, "用户名");
            bool bpwd = directnull(pwd, "密码");
            if (bdb&&bip && bport && bname && bpwd)
            {
                //连接数据库
                using (DbConnection conn = connect(ip, port, name, pwd))
                {
                    if (conn != null)
                    {
                        lblstatus.Text = "测试通过！";
                        lblstatus.ForeColor = Color.Green;
                        //禁用所有输入框
                        txtip.ReadOnly = true;
                        txtport.ReadOnly = true;
                        txtpwd.ReadOnly = true;
                        txtuname.ReadOnly = true;
                        cbdbtype.DropDownStyle = ComboBoxStyle.DropDownList;
                        btngene.Visible = true;
                        //获取所有数据库名称并绑定数据
                        GetDBS(conn, cbdbtype.Text);
                    }
                    else
                    {
                        lblstatus.Text = "测试失败！";
                        lblstatus.ForeColor = Color.Red;
                    }
                }

            }

        }
        /// <summary>
        /// 打开数据库并生成model
        /// </summary>
        /// <param name="conn"></param>
        private void Generator(DbConnection conn)
        {
            string db = cbdb.Text;
            string sql = $"use {db};show tables;";
            DbCommand command = new MySqlCommand(sql);
            command.Connection = conn;
            conn.Open();
            DbDataReader reader = command.ExecuteReader();
            List<string> tbnames = new List<string>();
            while (reader.Read())
            {
                //lblstatus.Text += reader[0].ToString();
                tbnames.Add(reader[0].ToString());
            }
            lblstatus.Text = $"共有{tbnames.Count}张表。";
            reader.Close();
            int i = 0;
            TypeChangesUtil typeChanges = new TypeChangesUtil();
            foreach (var tbname in tbnames)
            {
                lblstatus.Text = $"共有{tbnames.Count}张表。正在生成第{i++}张表。。。";
                var list=readtable(command, tbname);
                string enchangetxt=typeChanges.EnChange(txtnamespace.Text.Trim(),tbname, list);
                FileROWUtil row = new FileROWUtil();
                bool bres=row.Write(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"/CodeGenerator/", enchangetxt,tbname);
                if (bres)
                {
                    continue;
                }
                else
                {
                    lblstatus.Text = "出现异常！";
                    return;
                }
            }
            lblstatus.Text = $"已生成{tbnames.Count}张表。";
            //MessageBox.Show(lblstatus.Text);
        }
        /// <summary>
        /// 读取表属性
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="tbname"></param>
        /// <returns></returns>
        private List<TableProperModel> readtable(DbCommand cmd,string tbname)
        {
            string sql = $@"SELECT COLUMN_NAME,DATA_TYPE,COLUMN_COMMENT FROM `information_schema`.`columns` WHERE  `table_name` = '{tbname}'";
            cmd.CommandText = sql;
            MySqlDataAdapter adapter = new MySqlDataAdapter((MySqlCommand)cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            List<TableProperModel> list= Utils.DataTableToList<TableProperModel>(table).ToList();
            return list;
        }
        /// <summary>
        /// 获取所有数据库名称
        /// </summary>
        /// <param name="conn">连接</param>
        /// <param name="dbtype">数据库类型</param>
        private void GetDBS(DbConnection conn, string dbtype)
        {
            if (dbtype.ToUpper() == "MYSQL")
            {

                string sql = "show databases";
                DbCommand command = new MySqlCommand(sql);
                command.Connection = conn;
                conn.Open();
                DbDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("name");
                dt.Columns.Add(dc);
                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    dr["name"] = reader[0].ToString();
                    dt.Rows.Add(dr);
                }
                cbdb.DataSource = dt;
                cbdb.ValueMember = "name";
                cbdb.DisplayMember = "name";
            }

        }
        /// <summary>
        /// 获取连接
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        private DbConnection connect(string ip, string port, string name, string pwd)
        {
            switch (cbdbtype.Text.ToUpper())
            {
                case "MYSQL": return new MysqlConnect(ip, port, name, pwd).connect(); break;
                default:
                    return null;
                    break;
            }
        }
        /// <summary>
        /// 验空
        /// </summary>
        /// <param name="str"></param>
        /// <param name="restr"></param>
        /// <returns></returns>
        private bool directnull(string str, string restr)
        {
            if (string.IsNullOrEmpty(str))
            {
                lblstatus.Text = $"{restr}不能为空";
                lblstatus.ForeColor = Color.Red;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngene_Click(object sender, EventArgs e)
        {
            Generator(connect(txtip.Text, txtport.Text, txtuname.Text, txtpwd.Text));
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
