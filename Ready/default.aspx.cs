using System;
using System.Data.SqlClient;

namespace Ready
{
    public partial class _default : System.Web.UI.Page
    {
        private string m_ROconnectionString = "";
        private string m_RWconnectionString = "";
        private string m_WebsiteName = "";
        private string m_Title = "";
        private string m_SubTitle = "";
        private string m_Description = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Always store connection strings securely. 
            m_ROconnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ReadOnlyDbConn"].ConnectionString;
            m_RWconnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WriteDbConn"].ConnectionString;
            m_WebsiteName = System.Configuration.ConfigurationManager.AppSettings["WEBSITE_SITE_NAME"];
            m_Title = System.Configuration.ConfigurationManager.AppSettings["Title"];
            m_SubTitle = System.Configuration.ConfigurationManager.AppSettings["SubTitle"];
            m_Description = System.Configuration.ConfigurationManager.AppSettings["Description"];
            WebSiteName.Text = m_WebsiteName;
            headertitle.Text = m_Title;
            headersubtitle.Text = m_SubTitle;
            description.Text = m_Description;

            // Best practice is to scope the SqlConnection to a "using" block
            string errorStr = "";

            if (!RefreshListBox(ref errorStr))
            {
                message.Text = errorStr;
            }
            else
            {
                message.Text = "";
            }


        }

        protected bool RefreshListBox(ref string returnVal)
        {
            bool abSuccess = true;
            try
            {
                ListBox1.Items.Clear();
                returnVal = "";
                
                // Best practice is to scope the SqlConnection to a "using" block
                using (SqlConnection conn = new SqlConnection(m_ROconnectionString))
                {
                    // Connect to the database
                    conn.Open();

                    // Read rows
                    SqlCommand selectCommand = new SqlCommand("SELECT * FROM dbo.ItemTable", conn);
                    SqlDataReader results = selectCommand.ExecuteReader();

                    // Enumerate over the rows
                    while (results.Read())
                    {
                        ListBox1.Items.Add(String.Format(" ID: {0}, Name: {1}", results[0].ToString(), results[1].ToString()));
                    }
                }
                int count = ListBox1.Items.Count;
                if (count > 12)
                {
                    ListBox1.Rows = 12;
                }
                else
                {
                    ListBox1.Rows = ListBox1.Items.Count;
                }

            }
            catch (Exception ex)
            {
                abSuccess = false;
                returnVal = ex.Message;
            }




            return abSuccess;
        }

        protected bool InsertItem(ref string returnVal)
        {
            bool abSuccess = true;
            try
            {
                returnVal = "";
                string valueToInsert = TextBox1.Text;
               // Best practice is to scope the SqlConnection to a "using" block
                using (SqlConnection conn = new SqlConnection(m_RWconnectionString))
                {
                    // Connect to the database
                    conn.Open();

                    // Read rows
                    SqlCommand selectCommand = new SqlCommand(String.Format("insert into dbo.ItemTable (Name) values ('{0}')", valueToInsert), conn);
                    SqlDataReader results = selectCommand.ExecuteReader();
                    abSuccess = RefreshListBox(ref returnVal);
                }

            }
            catch (Exception ex)
            {
                abSuccess = false;
                returnVal = ex.Message;
            }




            return abSuccess;
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string err = "";
            if (TextBox1.Text.Length > 0)
            {
                if (!InsertItem(ref err))
                {
                    message.Text = err;
                }
                else
                {
                    message.Text = "inserted";
                }
            }
            else
            {
                message.Text = "Enter some text!";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ret = "";
            if (!RefreshListBox(ref ret))
                {
                message.Text = ret;
            }
        }
    }
}