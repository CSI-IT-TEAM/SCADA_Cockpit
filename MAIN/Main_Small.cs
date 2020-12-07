using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace MAIN
{
    public partial class Main_Small : Form
    {
        public Main_Small()
        {
            InitializeComponent();
            

        }

       // Dictionary<string, int> _dtn = new Dictionary<string, int>();
       // int _iFrm = 0;
       
        DataTable _dtXML = null;
        

        private  void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _dtXML = ComVar.Func.ReadXML(Application.StartupPath + "\\Config.XML", "MAIN");

                ComVar.Var._strValue5 = _dtXML.Rows[0]["Path"].ToString();
                if (_dtXML.Rows[0]["Auto_Download"].ToString() == "true")
                {
                    Download();
                }

                runSingleForm();
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.Name + "/Load_Form :    " + ex.ToString());
            }
        }

        /// <summary>
        /// Run 1 form using Test
        /// </summary>
        /// 
        
        private void runSingleForm()
        {           
            Assembly assembly = Assembly.LoadFile(Application.StartupPath + @"\DLL\SMT_SCADA_POPUP_INFOR.DLL");
            Type type = assembly.GetType("FORM.SMT_SCADA_POPUP_INFOR");

            Form form = (Form)Activator.CreateInstance(type);

            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.AutoScroll = false;
            pnMain.Controls.Add(form);
            form.Show();
            
        }

        

        private void CheckingFolder(string arg_folder)
        {
            if (!Directory.Exists(Environment.CurrentDirectory + arg_folder))
                Directory.CreateDirectory(Environment.CurrentDirectory + arg_folder);
        }

        private void Download()
        {
            
            string folder = @"\DLL";
            string fileName = "SMT_SCADA_POPUP_INFOR.dll";
            string ftpDirectory = @"ftp://211.54.128.12/pgmdown/DOWNLOAD/DLL/";
            DateTime tiLastModifiedSever, tiLastModifiedLocal;
            NetworkCredential credentials = new NetworkCredential("ftpsystem", "csiftpsystem");
            string exePath = Path.GetDirectoryName(Application.ExecutablePath);
            CheckingFolder(folder);
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpDirectory + fileName);
                request.Credentials = credentials;
                request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                using (FtpWebResponse aResponse = (FtpWebResponse)request.GetResponse())
                {
                    tiLastModifiedSever = aResponse.LastModified;
                    tiLastModifiedLocal = System.IO.File.GetLastWriteTime(exePath + folder + "\\" + fileName);
                }

                if (tiLastModifiedSever != tiLastModifiedLocal)
                {
                    DownloadFTP( fileName);
                    File.SetLastWriteTime(exePath + folder + "\\" + fileName, tiLastModifiedSever);
                }
            }
            catch
            {
                //  ComVar.Var.writeToLog(this.GetType().Name + "/LoadData :    " + ex.ToString());
            }
            

           // bool rtn= await DownloadFTP("SMT_SCADA_POPUP_INFOR.dll");
        }

        private void DownloadFTP( string arg_file_name)
        {
            string arg_folder = @"\DLL";
            string arg_directory = @"ftp://211.54.128.12/pgmdown/DOWNLOAD/DLL/";
            try
            {
                NetworkCredential credentials = new NetworkCredential("ftpsystem", "csiftpsystem");
                WebRequest request = WebRequest.Create(arg_directory + arg_file_name);
                string exePath = Path.GetDirectoryName(Application.ExecutablePath);
                request.Credentials = credentials;
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                {
                    using (Stream fileStream = File.Create(exePath + arg_folder + "\\" + arg_file_name))
                    {
                        byte[] buffer = new byte[10240];
                        int read;
                        while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, read);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "/DownloadFTP /" + arg_file_name + "    :    " + ex.ToString());
            }
        }

       

    }
}
