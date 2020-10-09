using DataPie.Core;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
            this.cbdbtype.SelectedIndex = 0;
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
            bool bdb = directnull(cbdbtype.Text, "数据库类型");
            bool bip = directnull(ip, "ip地址");
            bool bport = directnull(port, "端口");
            bool bname = directnull(name, "用户名");
            bool bpwd = directnull(pwd, "密码");
            if (bdb && bip && bport && bname && bpwd)
            {
                //连接数据库
                using (DbConnection conn = connect(ip, port, name, pwd))
                {
                    if (conn != null)
                    {
                        lblstatus.Text = "测试通过！";
                        lblstatus.ForeColor = Color.White;
                        //禁用所有输入框
                        txtip.ReadOnly = true;
                        txtport.ReadOnly = true;
                        txtpwd.ReadOnly = true;
                        txtuname.ReadOnly = true;
                        cbdbtype.DropDownStyle = ComboBoxStyle.DropDownList;
                        //btngene.Visible = true;
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
            MysqlTypeChangesUtil typeChanges = new MysqlTypeChangesUtil();
            foreach (var tbname in tbnames)
            {
                lblstatus.Text = $"共有{tbnames.Count}张表。正在生成第{i++}张表。。。";
                var list = readtable(command, tbname);
                string enchangetxt = typeChanges.EnChange(txtnamespace.Text.Trim(), tbname, list);
                FileROWUtil row = new FileROWUtil();
                bool bres = row.Write(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/CodeGenerator/", enchangetxt, tbname);
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
        private List<TableProperModel> readtable(DbCommand cmd, string tbname)
        {
            string sql = $@"SELECT COLUMN_NAME,DATA_TYPE,COLUMN_COMMENT FROM `information_schema`.`columns` WHERE  `table_name` = '{tbname}'";
            cmd.CommandText = sql;
            MySqlDataAdapter adapter = new MySqlDataAdapter((MySqlCommand)cmd);
            System.Data.DataTable table = new System.Data.DataTable();
            adapter.Fill(table);
            List<TableProperModel> list = Utils.DataTableToList<TableProperModel>(table).ToList();
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
                System.Data.DataTable dt = new System.Data.DataTable();
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
        /// <summary>
        /// 获取数据库表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetTables_Click(object sender, EventArgs e)
        {
            //清空表
            tableListBox.Items.Clear();
            //是否连接成功
            using (DbConnection conn = getDbConn())
            {
                if (conn == null)
                {
                    lblstatus.Text = "数据库连接异常！";
                    lblstatus.ForeColor = Color.Red;
                }
                else
                {

                    //获取选中的数据库名称
                    string dbname = cbdb.Text;
                    if (dbname==""||string.IsNullOrEmpty(dbname))
                    {
                        lblstatus.Text = "请选择数据库！";
                        lblstatus.ForeColor = Color.Red;
                        return;
                    }
                    //获取ip port name pwd
                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt = getTables(dbname, conn);
                    foreach (DataRow da in dt.Rows)
                    {
                        tableListBox.Items.Add(da["tableName"]);
                    }
                }
            }
            
        }
        private DbConnection getDbConn()
        {
            //获取ip port name pwd
            string ip = txtip.Text.Trim();
            string port = txtport.Text.Trim();
            string name = txtuname.Text.Trim();
            string pwd = txtpwd.Text.Trim();
            bool bdb = directnull(cbdbtype.Text, "数据库类型");
            bool bip = directnull(ip, "ip地址");
            bool bport = directnull(port, "端口");
            bool bname = directnull(name, "用户名");
            bool bpwd = directnull(pwd, "密码");
            DbConnection conn = connect(ip, port, name, pwd);
            return conn;
        }
        /// <summary>
        /// 获取表名称
        /// </summary>
        /// <param name="dbName">选中的数据库名称</param>
        /// <param name="conn">数据连接</param>
        /// <returns></returns>
        private System.Data.DataTable getTables(string dbName, DbConnection conn)
        {
            string sql = $"use {dbName};show tables;";
            DbCommand command = new MySqlCommand(sql);
            command.Connection = conn;
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            DbDataReader reader = command.ExecuteReader();
            System.Data.DataTable dt = new System.Data.DataTable();
            DataColumn dc = new DataColumn("tableName");
            dt.Columns.Add(dc);
            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["tableName"] = reader[0].ToString();
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 导出表数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            //获取选中的表名称
            List<string> tblist = new List<string>();
            if (tableListBox.CheckedItems.Count == 0)
            {
                lblstatus.Text = "请选择要导出的表！";
                lblstatus.ForeColor = Color.Red;
                return;
            }
            for (int i = 0; i < tableListBox.CheckedItems.Count; i++)
            {
                tblist.Add(tableListBox.CheckedItems[i].ToString());
            }
            exportToExcel(tblist);
        }

        private void exportToExcel(List<string> tblist)
        {
            for (int i = 0; i < tblist.Count; i++)
            {
                lblstatus.Text = $"共{tblist.Count}张表，正在导出第{i + 1}张表，表名为{tblist[i]}...";
                lblstatus.ForeColor = Color.White;
                generalExcel(tblist[i]);
            }
            lblstatus.Text = $"导出完成";
            lblstatus.ForeColor = Color.White;
        }
        private void generalExcel(string tbname)
        {
            using (DbConnection conn = getDbConn())
            {
                //选择路径
                string fileName = tbname;
                string saveFileName = tbname;
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xlsx";
                saveDialog.Filter = "Excel文件|*.xlsx";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消
                System.Data.DataTable dt = parseTable(conn, tbname);
                DataTableToExcel.SaveExcel(saveFileName, dt, tbname);
            }
        }
        private System.Data.DataTable parseTable(DbConnection conn,string tablename) {
            System.Data.DataTable dt = new System.Data.DataTable();
            string sql = $"select COLUMN_NAME from information_schema.COLUMNS where table_name = '{tablename}';";
            DbCommand command = new MySqlCommand(sql);
            command.Connection = conn;
            if (conn.State==ConnectionState.Closed)
            {
                conn.Open();
            }
            DbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                DataColumn dc = new DataColumn(reader[0].ToString());
                dt.Columns.Add(dc);
            }
            reader.Close();
            //给列赋值
            string sqldata = $"select * from {tablename};";
            command = new MySqlCommand(sqldata);
            command.Connection = conn;
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            DbDataReader dbreader = command.ExecuteReader();
            while (dbreader.Read())
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn item in dt.Columns)
                {
                    dr[item]= dbreader[item.ColumnName].ToString();
                }
                dt.Rows.Add(dr);
            }
            dbreader.Close();
            return dt;
        }

        #region 方法一，比较慢

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dt"></param>
        //protected void ExportExcel(System.Data.DataTable dt, string filename)
        //{
        //    if (dt == null || dt.Rows.Count == 0) return;
        //    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

        //    if (xlApp == null)
        //    {
        //        return;
        //    }
        //    System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
        //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        //    Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
        //    Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
        //    Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
        //    Microsoft.Office.Interop.Excel.Range range;
        //    long totalCount = dt.Rows.Count;
        //    long rowRead = 0;
        //    float percent = 0;
        //    for (int i = 0; i < dt.Columns.Count; i++)
        //    {
        //        worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
        //        range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
        //        range.Interior.ColorIndex = 15;
        //        range.Font.Bold = true;
        //    }
        //    for (int r = 0; r < dt.Rows.Count; r++)
        //    {
        //        for (int i = 0; i < dt.Columns.Count; i++)
        //        {
        //            worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
        //        }
        //        rowRead++;
        //        percent = ((float)(100 * rowRead)) / totalCount;
        //    }
        //    xlApp.Visible = true;
        //    workbook.Saved = true;
        //    workbook.SaveCopyAs(filename);
        //}
        #endregion
    }
}
