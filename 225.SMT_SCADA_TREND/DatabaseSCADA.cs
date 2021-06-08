using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;

namespace FORM
{
	class DatabaseSCADA
	{
		public String strError;
		private String strConnection, strConnectionSql;
		public int ProcNumParam = 100;
		public String[] ProcParams = new String[100];
		public String[] ProcValues = new String[100];
        public DataTable SEL_SCADA_SET_COMBO(string ARG_QTYPE, string ARG_LINE)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_SET_COMBO";

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        public DataTable SP_SCADA_SET_TREELIST(string ARG_QTYPE, string ARG_DATE, string ARG_LINE, string ARG_MLINE, string ARG_OP)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_SET_TREELIST";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_DATE";
                MyOraDB.Parameter_Name[2] = "V_P_LINE";
                MyOraDB.Parameter_Name[3] = "V_P_MLINE";
                MyOraDB.Parameter_Name[4] = "V_P_OP";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = ARG_LINE;
                MyOraDB.Parameter_Values[3] = ARG_MLINE;
                MyOraDB.Parameter_Values[4] = ARG_OP;
                MyOraDB.Parameter_Values[5] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }

        public DataTable SP_SCADA_GET_CHART(string ARG_QTYPE, string ARG_YMD, string ARG_LINE, string ARG_MLINE, string ARG_OP)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_GET_CHART_V02";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_DATE";
                MyOraDB.Parameter_Name[2] = "V_P_LINE";
                MyOraDB.Parameter_Name[3] = "V_P_MLINE";
                MyOraDB.Parameter_Name[4] = "V_P_OP";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMD;
                MyOraDB.Parameter_Values[2] = ARG_LINE;
                MyOraDB.Parameter_Values[3] = ARG_MLINE;
                MyOraDB.Parameter_Values[4] = ARG_OP;
                MyOraDB.Parameter_Values[5] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        
        public DataTable SEL_SCADA_SET_COMBO2(string ARG_QTYPE, string ARG_LINE,string ARG_MLINE,string ARG_OP,string ARG_MC)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_SET_COMBO2";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE";
                MyOraDB.Parameter_Name[3] = "V_P_OP";
                MyOraDB.Parameter_Name[4] = "V_P_MC";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_MLINE;
                MyOraDB.Parameter_Values[3] = ARG_OP;
                MyOraDB.Parameter_Values[4] = ARG_MC;
                MyOraDB.Parameter_Values[5] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        public DataTable SEL_SCADA_SET_COMBO2_T(string ARG_QTYPE, string ARG_LINE, string ARG_MLINE, string ARG_OP, string ARG_MC)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_SET_COMBO3";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_LINE";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE";
                MyOraDB.Parameter_Name[3] = "V_P_OP";
                MyOraDB.Parameter_Name[4] = "V_P_MC";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_LINE;
                MyOraDB.Parameter_Values[2] = ARG_MLINE;
                MyOraDB.Parameter_Values[3] = ARG_OP;
                MyOraDB.Parameter_Values[4] = ARG_MC;
                MyOraDB.Parameter_Values[5] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        public DataTable SELECT_DATA_KM_TEMP(string ARG_ZONE)
        {
            try
            {
                System.Data.DataSet retDS;
                COM.OraDB MyOraDB = new COM.OraDB();
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = "PKG_IPEX3.SEL_DATA_UC_KM_CHART_MONTHLY";
                MyOraDB.Parameter_Name[0] = "ARG_ZONE";
                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Values[0] = ARG_ZONE;

                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[1] = "";

                MyOraDB.Add_Select_Parameter(true);

                retDS = MyOraDB.Exe_Select_Procedure();
                if (retDS == null) return null;
                return retDS.Tables[MyOraDB.Process_Name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public DataTable GET_DATA(string ARG_QTYPE,string ARG_YMDF,string ARG_YMDT, string ARG_LINE, string ARG_MLINE, string ARG_OP, string ARG_MC,string ARG_ID)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_GET_REAL_CHART";

                MyOraDB.ReDim_Parameter(9);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMDF";
                MyOraDB.Parameter_Name[2] = "V_P_YMDT";
                MyOraDB.Parameter_Name[3] = "V_P_LINE";
                MyOraDB.Parameter_Name[4] = "V_P_MLINE";
                MyOraDB.Parameter_Name[5] = "V_P_OP";
                MyOraDB.Parameter_Name[6] = "V_P_MC";
                MyOraDB.Parameter_Name[7] = "V_P_ID";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[7] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[8] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMDF;
                MyOraDB.Parameter_Values[2] = ARG_YMDT;
                MyOraDB.Parameter_Values[3] = ARG_LINE;
                MyOraDB.Parameter_Values[4] = ARG_MLINE;
                MyOraDB.Parameter_Values[5] = ARG_OP;
                MyOraDB.Parameter_Values[6] = ARG_MC;
                MyOraDB.Parameter_Values[7] = ARG_ID;
                MyOraDB.Parameter_Values[8] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        public DataTable GET_DATA_4_ALL(string ARG_QTYPE, string ARG_YMDF, string ARG_YMDT, string ARG_LINE, string ARG_MLINE, string ARG_OP, string ARG_MC, string ARG_ID)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_GET_REAL_CHART_ALL";

                MyOraDB.ReDim_Parameter(9);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMDF";
                MyOraDB.Parameter_Name[2] = "V_P_YMDT";
                MyOraDB.Parameter_Name[3] = "V_P_LINE";
                MyOraDB.Parameter_Name[4] = "V_P_MLINE";
                MyOraDB.Parameter_Name[5] = "V_P_OP";
                MyOraDB.Parameter_Name[6] = "V_P_MC";
                MyOraDB.Parameter_Name[7] = "V_P_ID";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[7] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[8] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMDF;
                MyOraDB.Parameter_Values[2] = ARG_YMDT;
                MyOraDB.Parameter_Values[3] = ARG_LINE;
                MyOraDB.Parameter_Values[4] = ARG_MLINE;
                MyOraDB.Parameter_Values[5] = ARG_OP;
                MyOraDB.Parameter_Values[6] = ARG_MC;
                MyOraDB.Parameter_Values[7] = ARG_ID;
                MyOraDB.Parameter_Values[8] = "";


                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        public DataTable GET_DATA_COUNT_CHART(string ARG_QTYPE, string ARG_YMDF, string ARG_YMDT, string ARG_LINE, string ARG_MLINE, string ARG_OP, string ARG_MC, string ARG_ID)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA.SP_SCADA_GET_COUNT_CHART";

                MyOraDB.ReDim_Parameter(9);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMDF";
                MyOraDB.Parameter_Name[2] = "V_P_YMDT";
                MyOraDB.Parameter_Name[3] = "V_P_LINE";
                MyOraDB.Parameter_Name[4] = "V_P_MLINE";
                MyOraDB.Parameter_Name[5] = "V_P_OP";
                MyOraDB.Parameter_Name[6] = "V_P_MC";
                MyOraDB.Parameter_Name[7] = "V_P_ID";
                MyOraDB.Parameter_Name[8] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[7] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[8] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_YMDF;
                MyOraDB.Parameter_Values[2] = ARG_YMDT;
                MyOraDB.Parameter_Values[3] = ARG_LINE;
                MyOraDB.Parameter_Values[4] = ARG_MLINE;
                MyOraDB.Parameter_Values[5] = ARG_OP;
                MyOraDB.Parameter_Values[6] = ARG_MC;
                MyOraDB.Parameter_Values[7] = ARG_ID;
                MyOraDB.Parameter_Values[8] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
		public String settingDBORA()
		{
			XmlDocument xmldoc = new XmlDocument();
			XmlNodeList xmlDBSQL;
			String strFileName = AppDomain.CurrentDomain.BaseDirectory + "DBORA.xml";
			try
			{
				using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
				{
					xmldoc.Load(fs);
					xmlDBSQL = xmldoc.GetElementsByTagName("DBORA");
					String DATA_SOURCE = xmlDBSQL[0].ChildNodes.Item(0).InnerText.Trim();
					String USR = xmlDBSQL[0].ChildNodes.Item(1).InnerText.Trim();
					String PWD = xmlDBSQL[0].ChildNodes.Item(2).InnerText.Trim();

					strConnection = "Provider=MSDAORA;Data Source=" + DATA_SOURCE + ";" +
									"Persist Security Info=True;" +
									"User ID=" + USR + ";" +
									"Password=" + PWD;

					return "";
				}
			}
			catch (Exception e)
			{
				return "Error : " + e.Message;
			}
		}
        public DataTable getData(string SQLCommand)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(settingDBSQL()))
                {
                    conn.Open();
                    string SQL = SQLCommand;
                    using (SqlDataAdapter da = new SqlDataAdapter(SQL, conn))
                    {
                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            return ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable getDataTrendProc(string Proc,string Ymd)
        {
            try
            {
                var  dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(settingDBSQL()))
                {
                    conn.Open();
                    using (var command = new SqlCommand(Proc, conn)
                    {
                        CommandType = CommandType.StoredProcedure                      
                    })
                    {
                        command.Parameters.Add(new SqlParameter("@ymd", Ymd));
                        command.ExecuteNonQuery();
                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            dt.Load(rdr);
                            return dt;
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
		public String settingDBSQL()
		{
			XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlDBSQL, xmlSHUTDOWN;
			String strFileName = AppDomain.CurrentDomain.BaseDirectory + "DBSQL.xml";
			try
			{
				using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
				{
					xmldoc.Load(fs);
					xmlDBSQL = xmldoc.GetElementsByTagName("DBSQL");
					String DATA_SOURCE = xmlDBSQL[0].ChildNodes.Item(0).InnerText.Trim();
					String DB_NAME = xmlDBSQL[0].ChildNodes.Item(1).InnerText.Trim();
					String USR = xmlDBSQL[0].ChildNodes.Item(2).InnerText.Trim();
					String PWD = xmlDBSQL[0].ChildNodes.Item(3).InnerText.Trim();
					strConnectionSql = "Data Source = " + DATA_SOURCE + ";" +
								  "Initial Catalog = " + DB_NAME + ";" +
								  "Persist Security Info = True;" +
								  "User ID = " + USR + ";" +
								  "Password = " + PWD;
                    return strConnectionSql;
				}
			}
			catch (Exception e)
			{
				return "Error : " + e.Message;
			}
		}
        public void settingSQL()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlDBSQL, xmlSHUTDOWN;
            String strFileName = AppDomain.CurrentDomain.BaseDirectory + "DBSQL.xml";
            try
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    xmldoc.Load(fs);
                    xmlDBSQL = xmldoc.GetElementsByTagName("DBSQL");
                    String DATA_SOURCE = xmlDBSQL[0].ChildNodes.Item(0).InnerText.Trim();
                    String DB_NAME = xmlDBSQL[0].ChildNodes.Item(1).InnerText.Trim();
                    String USR = xmlDBSQL[0].ChildNodes.Item(2).InnerText.Trim();
                    String PWD = xmlDBSQL[0].ChildNodes.Item(3).InnerText.Trim();
                    strConnectionSql = "Data Source =" + DATA_SOURCE + ";" +
                                  "Initial Catalog = " + DB_NAME + ";" +
                                  "Persist Security Info = True;" +
                                  "User ID = " + USR + ";" +
                                  "Password = " + PWD;
                }
            }
            catch (Exception e)
            {
            }
        }
        public string HH, MM = null;
        public void settingShutdown()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlSHUTDOWN;
            String strFileName = AppDomain.CurrentDomain.BaseDirectory + "DBSQL.xml";
            try
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    xmldoc.Load(fs);
                    xmlSHUTDOWN = xmldoc.GetElementsByTagName("SHUTDOWN");
                    HH = xmlSHUTDOWN[0].ChildNodes.Item(0).InnerText.Trim();
                     MM = xmlSHUTDOWN[0].ChildNodes.Item(1).InnerText.Trim();
                }
            }
            catch (Exception e)
            {
                
            }
        }
		public ArrayList getDataORA(String str)
		{
			try
			{
				using (OleDbConnection con_ora = new OleDbConnection(strConnection))
				{
					con_ora.Open();
					using (OleDbCommand command = new OleDbCommand(str, con_ora))
					{
						using (OleDbDataReader reader = command.ExecuteReader())
						{
							ArrayList list = new ArrayList();
							while (reader.Read())
							{
								object[] values = new object[reader.FieldCount];
								reader.GetValues(values);
								list.Add(values);
							}
							return list;
						}
					}
				}
			}
			catch (Exception e)
			{
				strError = e.Message.ToString();
				return null;
			}
		}
		public DataTable getDataORASource(String str)
		{
			try
			{
				using (OleDbConnection con_ora = new OleDbConnection(strConnection))
				{
					con_ora.Open();
					using (OleDbDataAdapter da = new OleDbDataAdapter(str, con_ora))
					{
						DataTable dt = new DataTable();
						da.Fill(dt);
						return dt;
					}
				}
			}
			catch (Exception e)
			{
				strError = e.Message.ToString();
				return null;
			}
		}
		public ArrayList getDataSQL(String str)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(strConnectionSql))
				{
					con.Open();
					using (SqlCommand command = new SqlCommand(str, con))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							ArrayList list = new ArrayList();
							while (reader.Read())
							{
								object[] values = new object[reader.FieldCount];
								reader.GetValues(values);
								list.Add(values);
							}
							return list;
						}
					}
				}
			}
			catch (Exception e)
			{
				strError = e.Message.ToString();
				return null;
			}
		}
		public DataTable getDataSQL_DT(String str)
		{
			try
			{
				using (SqlConnection con = new SqlConnection(strConnectionSql))
				{
					con.Open();
					using (SqlCommand command = new SqlCommand(str, con))
					{
						using (SqlDataReader reader = command.ExecuteReader())
						{
							//ArrayList list = new ArrayList();
							DataTable dt = new DataTable();
							dt.Load(reader);
							//while (reader.Read())
							//{
							//    object[] values = new object[reader.FieldCount];
							//    reader.GetValues(values);
							//    list.Add(values);
							//}
							return dt;
						}
					}
				}
			}
			catch (Exception e)
			{
				strError = e.Message.ToString();
				return null;
			}
		}
		public String saveDataORA(String str)
		{
			try
			{
				using (OleDbConnection con_ora = new OleDbConnection(strConnection))
				{
					using (OleDbCommand command = new OleDbCommand(str, con_ora))
					{
						con_ora.Open();
						command.ExecuteNonQuery();
						return "";
					}
				}
			}
			catch (Exception e)
			{
				return e.Message.ToString();
			}
		}
		public String saveDataSQL(String str)
		{
			try
			{
				using (SqlConnection con_sql = new SqlConnection(strConnectionSql))
				{
					using (SqlCommand command = new SqlCommand(str, con_sql))
					{
						con_sql.Open();
						command.ExecuteNonQuery();
						return "";
					}
				}
			}
			catch (Exception e)
			{
				return e.Message.ToString();
			}
		}
		public ArrayList SelectStoreProc(string arg_proc_name)
		{
			int i = 0;
			try
			{
				using (SqlConnection con_sql = new SqlConnection(strConnectionSql))
				using (SqlCommand command = new SqlCommand(arg_proc_name, con_sql)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					con_sql.Open();
					while (i < ProcNumParam)
					{
						command.Parameters.Add(new SqlParameter("@" + ProcParams[i].ToString(), ProcValues[i].ToString()));
						i++;
					}
					using (SqlDataReader reader = command.ExecuteReader())
					{
						ArrayList list = new ArrayList();
						while (reader.Read())
						{
							object[] values = new object[reader.FieldCount];
							reader.GetValues(values);
							list.Add(values);
						}
						return list;
					}
				}
			}
			catch (Exception e)
			{
				strError = e.Message.ToString();
				return null;
			}
		}
		public String ExecStoreProc(string arg_proc_name)
		{
			int i = 0;
			try
			{
				using (SqlConnection con_sql = new SqlConnection(strConnectionSql))
				using (SqlCommand command = new SqlCommand(arg_proc_name, con_sql)
				{
					CommandType = CommandType.StoredProcedure
				})
				{
					con_sql.Open();
					while (i < ProcNumParam)
					{
						command.Parameters.Add(new SqlParameter("@" + ProcParams[i].ToString(), ProcValues[i].ToString()));
						i++;
					}
					command.ExecuteNonQuery();
					return "";
				}
			}
			catch (Exception e)
			{
				strError = e.Message.ToString();
				return strError;
			}
		}
	}
}
