using ProjectBase.Database;
using ProjectBase.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FluentGenerator
{
    public partial class Form1 : Form
    {
        IDatabase2 db = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            db = DatabaseFactory.GetDbObject();
            TBConString.Text = db.ConnectionString.ConnectionString;
        }

        private void BtListele_Click(object sender, EventArgs e)
        {
            DataTable dt = db.ExecuteQueryDataTable("SELECT table_name,owner FROM all_tables where table_name is not null order by table_name");
            DataTable dt2 = db.ExecuteQueryDataTable("SELECT VIEW_NAME,owner FROM all_VIEWS where VIEW_NAME is not null order by VIEW_NAME");

            GWTables.DataSource = dt;
            GWView.DataSource = dt2;
        }

        private void BTKlasor_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            LBPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void BTOlustur_Click(object sender, EventArgs e)
        {          

            if (string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
            {
                MessageBox.Show("Bir klasör seçiniz!");
            }
            else
            {
                string mapDir = folderBrowserDialog1.SelectedPath + "\\" + "Mapping";
                Directory.CreateDirectory(mapDir);

                List<string> pKey = new List<string>();
                List<string[]> propList = new List<string[]>();

                StringBuilder builder4 = new StringBuilder(@"        protected override void OnModelCreating(DbModelBuilder modelBuilder)" +
            "\r\n        {\r\n");

                StringBuilder builder3 = new StringBuilder(@"using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using FirmaSinifDegisimOnay.Models.Mapping;

namespace FirmaSinifDegisimOnay.Models
{
    public partial class DatabaseContext : DbContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(null);
        }

        public DatabaseContext()
            : base(" + "\"Name=Context\")\r\n" +
           "        {\r\n" +
           "        }\r\n\r\n");

                foreach (DataGridViewRow item in GWSelectedTable.Rows)
                {
                    if (item.Cells[0].Value != null && (bool)item.Cells[0].Value)
                    {
                        string tableName = item.Cells[1].Value.ToString();
                        string cTableName = GetCapitalizedString(tableName);
                        string owner = item.Cells[2].Value.ToString();

                        builder3.Append("        public DbSet<" + cTableName + "> " + cTableName + "s { get; set; }\r\n");
                        builder4.Append("            modelBuilder.Configurations.Add(new " + cTableName + "Map());\r\n");

                        StringBuilder builder2 = new StringBuilder(@"using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace " + TBNameSpace.Text + @".Models.Mapping
{
    public class " + cTableName + @"Map : EntityTypeConfiguration<" + cTableName + @">
    {
        public " + cTableName + @"Map()
        {");

                        StringBuilder builder = new StringBuilder(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace " + TBNameSpace.Text + ".Models\r\n" +
    "{\r\n");


                        builder.Append(@"    public partial class " + cTableName + "\r\n" +
                                        "    {\r\n");

                        DataTable dt = db.ExecuteQueryDataTable("Select * from all_tab_columns where table_name='" + tableName + "' and OWNER='" + owner + "'");
                        DataTable dt2 = db.ExecuteQueryDataTable(@"SELECT a.table_name, 
       a.column_name, 
       a.constraint_name, 
       c.CONSTRAINT_TYPE,
       c.owner,
       c.R_CONSTRAINT_NAME,
       c2.TABLE_NAME R_TABLE_NAME,
       c2.CONSTRAINT_TYPE R_TABLE_CONSTRAINT_NAME
      FROM ALL_CONS_COLUMNS A 
      , ALL_CONSTRAINTS C
      LEFT OUTER JOIN ALL_CONSTRAINTS C2 on C2.CONSTRAINT_NAME = c.R_CONSTRAINT_NAME and c2.OWNER = c.OWNER  
      where A.CONSTRAINT_NAME = C.CONSTRAINT_NAME and
      a.OWNER = c.OWNER 
      and a.table_name= '" + tableName + "' and a.owner='" + owner + "'");

                        foreach (DataRow dr in dt2.Rows)
                        {
                            if (dr["CONSTRAINT_TYPE"].ToString() == "P")
                            {
                                pKey.Add(GetCapitalizedString(dr["COLUMN_NAME"].ToString()));
                            }
                        }

                        if (pKey.Count() == 0)
                        {
                            foreach (DataRow dr in dt2.Rows)
                            {
                                if (dr["CONSTRAINT_TYPE"].ToString() == "U")
                                {
                                    pKey.Add(GetCapitalizedString(dr["COLUMN_NAME"].ToString()));
                                }
                            }
                        }

                        if (pKey.Count() == 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["NULLABLE"].ToString() == "N")
                                {
                                    pKey.Add(GetCapitalizedString(dr["COLUMN_NAME"].ToString()));
                                }
                            }
                        }

                        string yaz = "";

                        for (int i = 0; i < pKey.Count; i++)
                        {

                            yaz += " t." + pKey[i];

                            if (i != pKey.Count - 1)
                            {
                                yaz += ", ";
                            }
                            else
                                yaz += " ";
                        }

                        builder2.Append("\r\n            // Primary Key\r\n" +
            "            this.HasKey(t => new {" + yaz + "});\r\n");

                        builder2.Append("\r\n            // Properties");

                        foreach (DataRow dr in dt.Rows)
                        {
                            string val = dr["DATA_TYPE"].ToString();
                            string cloumnName = dr["COLUMN_NAME"].ToString();
                            string cCloumnName = GetCapitalizedString(cloumnName);

                            int lenght = dr["DATA_LENGTH"] != System.DBNull.Value ? Convert.ToInt32(dr["DATA_LENGTH"]) : 0;
                            string Nullable = dr["NULLABLE"].ToString();
                            int? precision = null;
                            int? scale = null;

                            if (Nullable == "N")
                            {
                                pKey.Add(cCloumnName);
                            }

                            if (dr["DATA_PRECISION"] != System.DBNull.Value)
                            {
                                precision = Convert.ToInt32(dr["DATA_PRECISION"]);
                            }

                            if (dr["DATA_SCALE"] != System.DBNull.Value)
                            {
                                scale = Convert.ToInt32(dr["DATA_SCALE"]);
                            }

                            switch (val)
                            {
                                case "NUMBER":

                                    if (pKey.Where(r => r == cCloumnName).Count() > 0)
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
");

                                    }

                                    if (scale > 0)
                                    {
                                        if (Nullable == "N")
                                            builder.Append("        public decimal " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<decimal> " + cCloumnName + " { get; set; }\r\n");
                                    }
                                    else if (precision < 5)
                                    {
                                        if (Nullable == "N")
                                            builder.Append("        public short " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<short> " + cCloumnName + " { get; set; }\r\n");
                                    }
                                    else if (precision < 10)
                                    {
                                        if (Nullable == "N")
                                            builder.Append("        public int " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<int> " + cCloumnName + " { get; set; }\r\n");
                                    }
                                    else
                                        if (Nullable == "N")
                                            builder.Append("        public decimal " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<decimal> " + cCloumnName + " { get; set; }\r\n");
                                    break;
                                case "CLOB":
                                    if (Nullable == "N")
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .IsRequired();
");
                                    }
                                    else
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @");
");
                                    }

                                    builder.Append("        public string " + cCloumnName + " { get; set; }\r\n");

                                    break;
                                case "CHAR":
                                case "VARCHAR":
                                case "NVARCHAR2":
                                case "VARCHAR2":

                                    if (Nullable == "N")
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .IsRequired()
                .HasMaxLength(" + lenght + ");\r\n");
                                    }
                                    else
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .HasMaxLength(" + lenght + ");\r\n");
                                    }

                                    builder.Append("        public string " + cCloumnName + " { get; set; }\r\n");

                                    break;
                                case "DATE":
                                    if (Nullable == "N")
                                        builder.Append("        public DateTime " + cCloumnName + " { get; set; }\r\n");
                                    else
                                        builder.Append("        public Nullable<DateTime> " + cCloumnName + " { get; set; }\r\n");
                                    break;
                                case "BLOB":
                                    builder.Append("        public byte[] " + cCloumnName + " { get; set; }\r\n");
                                    break;
                                default:
                                    break;
                            }

                            propList.Add(new string[] { cCloumnName, cloumnName });
                        }

                        pKey.Clear();

                        builder.Append(@"
    }
}");
                        builder2.Append("\r\n            // Table & Column Mappings\r\n" +
    "            this.ToTable(\"" + tableName + "\", \"" + owner + "\");\r\n");

                        foreach (string[] s in propList)
                        {
                            builder2.Append("            this.Property(t => t." + s[0] + ").HasColumnName(\"" + s[1] + "\");\r\n");
                        }

                        propList.Clear();

                        builder2.Append(@"        }
    }
}");
                        File.WriteAllText(folderBrowserDialog1.SelectedPath + "\\" + cTableName + ".cs", builder.ToString());
                        File.WriteAllText(mapDir + "\\" + cTableName + "Map.cs", builder2.ToString());
                    }
                }


                foreach (DataGridViewRow item in GWSelectedView.Rows)
                {
                    if (item.Cells[0].Value != null && (bool)item.Cells[0].Value)
                    {
                        string TableName = item.Cells[1].Value.ToString();
                        string CTableName = GetCapitalizedString(TableName);
                        string owner = item.Cells[2].Value.ToString();

                        builder3.Append("        public DbSet<" + CTableName + "> " + CTableName + "s { get; set; }\r\n");
                        builder4.Append("            modelBuilder.Configurations.Add(new " + CTableName + "Map());\r\n");

                        StringBuilder builder2 = new StringBuilder(@"using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace " + TBNameSpace.Text + @".Models.Mapping
{
    public class " + CTableName + @"Map : EntityTypeConfiguration<" + CTableName + @">
    {
        public " + CTableName + @"Map()
        {");

                        StringBuilder builder = new StringBuilder(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace " + TBNameSpace.Text + ".Models\r\n" +
    "{\r\n");


                        builder.Append(@"    public partial class " + CTableName + "\r\n" +
                                        "    {\r\n");

                        DataTable dt = db.ExecuteQueryDataTable("Select * from all_tab_columns where table_name='" + TableName + "' and OWNER='" + owner + "'");
                        DataTable dt2 = db.ExecuteQueryDataTable(@"SELECT a.table_name, 
       a.column_name, 
       a.constraint_name, 
       c.CONSTRAINT_TYPE,
       c.owner,
       c.R_CONSTRAINT_NAME,
       c2.TABLE_NAME R_TABLE_NAME,
       c2.CONSTRAINT_TYPE R_TABLE_CONSTRAINT_NAME
      FROM ALL_CONS_COLUMNS A 
      , ALL_CONSTRAINTS C
      LEFT OUTER JOIN ALL_CONSTRAINTS C2 on C2.CONSTRAINT_NAME = c.R_CONSTRAINT_NAME and c2.OWNER = c.OWNER  
      where A.CONSTRAINT_NAME = C.CONSTRAINT_NAME and
      a.OWNER = c.OWNER 
      and a.table_name= '" + TableName + "' and a.OWNER='" + owner + "'");

                        foreach (DataRow dr in dt2.Rows)
                        {
                            if (dr["CONSTRAINT_TYPE"].ToString() == "P")
                            {
                                pKey.Add(GetCapitalizedString(dr["COLUMN_NAME"].ToString()));
                            }
                        }

                        if (pKey.Count() == 0)
                        {
                            foreach (DataRow dr in dt2.Rows)
                            {
                                if (dr["CONSTRAINT_TYPE"].ToString() == "U")
                                {
                                    pKey.Add(GetCapitalizedString(dr["COLUMN_NAME"].ToString()));
                                }
                            }
                        }

                        if (pKey.Count() == 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                if (dr["NULLABLE"].ToString() == "N")
                                {
                                    pKey.Add(GetCapitalizedString(dr["COLUMN_NAME"].ToString()));
                                }
                            }
                        }

                        string yaz = "";

                        for (int i = 0; i < pKey.Count; i++)
                        {

                            yaz += " t." + pKey[i];

                            if (i != pKey.Count - 1)
                            {
                                yaz += ", ";
                            }
                            else
                                yaz += " ";
                        }

                        builder2.Append("\r\n            // Primary Key\r\n" +
            "            this.HasKey(t => new {" + yaz + "});\r\n");

                        builder2.Append("\r\n            // Properties");

                        foreach (DataRow dr in dt.Rows)
                        {
                            string val = dr["DATA_TYPE"].ToString();
                            string cloumnName = dr["COLUMN_NAME"].ToString();
                            string cCloumnName = GetCapitalizedString(cloumnName);
                            int lenght = dr["DATA_LENGTH"] != System.DBNull.Value ? Convert.ToInt32(dr["DATA_LENGTH"]) : 0;
                            string nullable = dr["NULLABLE"].ToString();
                            int? precision = null;
                            int? scale = null;

                            if (nullable == "N")
                            {
                                pKey.Add(cCloumnName);
                            }

                            if (dr["DATA_PRECISION"] != System.DBNull.Value)
                            {
                                precision = Convert.ToInt32(dr["DATA_PRECISION"]);
                            }

                            if (dr["DATA_SCALE"] != System.DBNull.Value)
                            {
                                scale = Convert.ToInt32(dr["DATA_SCALE"]);
                            }

                            switch (val)
                            {
                                case "NUMBER":

                                    if (pKey.Where(r => r == cCloumnName).Count() > 0)
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
");

                                    }

                                    if (scale > 0)
                                    {
                                        if (nullable == "N")
                                            builder.Append("        public decimal " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<decimal> " + cCloumnName + " { get; set; }\r\n");
                                    }
                                    else if (precision < 5)
                                    {
                                        if (nullable == "N")
                                            builder.Append("        public short " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<short> " + cCloumnName + " { get; set; }\r\n");
                                    }
                                    else if (precision < 10)
                                    {
                                        if (nullable == "N")
                                            builder.Append("        public int " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<int> " + cCloumnName + " { get; set; }\r\n");
                                    }
                                    else
                                        if (nullable == "N")
                                            builder.Append("        public decimal " + cCloumnName + " { get; set; }\r\n");
                                        else
                                            builder.Append("        public Nullable<decimal> " + cCloumnName + " { get; set; }\r\n");
                                    break;
                                case "CLOB":
                                    if (nullable == "N")
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .IsRequired();
");
                                    }
                                    else
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @");
");
                                    }

                                    builder.Append("        public string " + cCloumnName + " { get; set; }\r\n");

                                    break;
                                case "CHAR":
                                case "VARCHAR":
                                case "NVARCHAR2":
                                case "VARCHAR2":

                                    if (nullable == "N")
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .IsRequired()
                .HasMaxLength(" + lenght + ");\r\n");
                                    }
                                    else
                                    {
                                        builder2.Append(@"
            this.Property(t => t." + cCloumnName + @")
                .HasMaxLength(" + lenght + ");\r\n");
                                    }

                                    builder.Append("        public string " + cCloumnName + " { get; set; }\r\n");

                                    break;
                                case "DATE":
                                    if (nullable == "N")
                                        builder.Append("        public DateTime " + cCloumnName + " { get; set; }\r\n");
                                    else
                                        builder.Append("        public Nullable<DateTime> " + cCloumnName + " { get; set; }\r\n");
                                    break;
                                case "BLOB":
                                    builder.Append("        public byte[] " + cCloumnName + " { get; set; }\r\n");
                                    break;
                                default:
                                    break;
                            }

                            propList.Add(new string[] { cloumnName, cCloumnName });
                        }

                        pKey.Clear();

                        builder.Append(@"
    }
}");
                        builder2.Append("\r\n            // Table & Column Mappings\r\n" +
    "            this.ToTable(\"" + TableName + "\", \"" + owner + "\");\r\n");

                        foreach (string[] s in propList)
                        {
                            builder2.Append("            this.Property(t => t." + s[0] + ").HasColumnName(\"" + s[1] + "\");\r\n");
                        }

                        propList.Clear();

                        builder2.Append(@"        }
    }
}");
                        File.WriteAllText(folderBrowserDialog1.SelectedPath + "\\" + CTableName + ".cs", builder.ToString());
                        File.WriteAllText(mapDir + "\\" + CTableName + "Map.cs", builder2.ToString());
                    }
                }

                builder3.Append("\r\n");
                builder3.Append(builder4.ToString());
                builder3.Append(@"        }
    }
}");

                File.WriteAllText(folderBrowserDialog1.SelectedPath + "\\Context.cs", builder3.ToString());
            }
        }

        private void BTTableNameAra_Click(object sender, EventArgs e)
        {
            DataTable dt = db.ExecuteQueryDataTable("SELECT table_name,owner FROM all_tables where table_name is not null and table_name like '%" + TBTableName.Text + "%' order by table_name");
            GWTables.DataSource = dt;
        }

        private void BTViewNameAra_Click(object sender, EventArgs e)
        {
            DataTable dt2 = db.ExecuteQueryDataTable("SELECT VIEW_NAME,owner FROM all_VIEWS where VIEW_NAME is not null and VIEW_NAME like '%" + TBViewName.Text + "%' order by VIEW_NAME");
            GWView.DataSource = dt2;
        }

        private void BtConStrDegistir_Click(object sender, EventArgs e)
        {
            db.ClearConnection();
            db.ConnectionString = new System.Configuration.ConnectionStringSettings("yContext", TBConString.Text);
        }

        private void BTAddTable_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in GWTables.Rows)
            {
                if (item.Cells[0].Value != null && (bool)item.Cells[0].Value)
                {
                    GWSelectedTable.Rows.Add(CloneRowWithValues(item));
                }
            }
        }

        private void BtRemoveTable_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in GWSelectedTable.Rows)
            {
                if (item.Cells[0].Value != null && (bool)item.Cells[0].Value)
                {
                    GWSelectedTable.Rows.Remove(item);
                }
            }
        }

        private void BTAddView_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in GWView.Rows)
            {
                if (item.Cells[0].Value != null && (bool)item.Cells[0].Value)
                {
                    GWSelectedView.Rows.Add(CloneRowWithValues(item));
                }
            }
        }

        private void BTRemoveView_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in GWSelectedView.Rows)
            {
                if (item.Cells[0].Value != null && (bool)item.Cells[0].Value)
                {
                    GWSelectedView.Rows.Remove(item);
                }
            }
        }

        public DataGridViewRow CloneRowWithValues(DataGridViewRow SingleRow)
        {
            DataGridViewRow Results = (DataGridViewRow)SingleRow.Clone();
            for (Int32 Row = 0; Row < SingleRow.Cells.Count; Row++)
            {
                Results.Cells[Row].Value = SingleRow.Cells[Row].Value;
            }

            return Results;
        }

        public string GetCapitalizedString(string value)
        {
            string[] degers = value.Split('_');
            string result = "";

            if (RbPascal.Checked)
            {
                foreach (var item in degers)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        result += Util.GetEnglishLocalizedString(item[0].ToString().ToUpper()) + Util.GetEnglishLocalizedString(item.Substring(1).ToLower());
                    }
                }
            }
            else if (RbCamel.Checked)
            {
                result = degers[0].ToLower();

                for (int i = 1; i < degers.Length; i++)
                {
                    if (!string.IsNullOrEmpty(degers[i]))
                    {
                        result += Util.GetEnglishLocalizedString(degers[i][0].ToString().ToUpper()) + Util.GetEnglishLocalizedString(degers[i].Substring(1));
                    }
                }
            }
            else
            {
                return value.ToUpper();
            }

            return result;
        }
    }
}
