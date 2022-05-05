using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace FORM
{
    public class DatabaseTMS
    {
        public DataTable GetPlant(string ARG_FAC, string ARG_COM_CD,string ARG_YMD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_PLANT_SEL";
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_COM_CD";
                MyOraDB.Parameter_Name[2] = "ARG_YMD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_COM_CD;
                MyOraDB.Parameter_Values[2] = ARG_YMD;
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetOutScnByTrip(string ARG_O_SCN, string ARG_OP_CD, string ARG_CMP_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_TRIP_OUT_SCN";
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_O_SCN";
                MyOraDB.Parameter_Name[1] = "ARG_OP_CD";
                MyOraDB.Parameter_Name[2] = "ARG_CMP_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_O_SCN;
                MyOraDB.Parameter_Values[1] = ARG_OP_CD;
                MyOraDB.Parameter_Values[2] = ARG_CMP_CD;
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetOutScnByDay(string ARG_FAC, string ARG_COM_CD, string ARG_YMD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_TMS_DASHBOARD.TMS_OUT_SCN_BY_DAY";
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_FAC";
                MyOraDB.Parameter_Name[1] = "ARG_COM_CD";
                MyOraDB.Parameter_Name[2] = "ARG_YMD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_FAC;
                MyOraDB.Parameter_Values[1] = ARG_COM_CD;
                MyOraDB.Parameter_Values[2] = ARG_YMD;
                MyOraDB.Parameter_Values[3] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[0];
            }
            catch
            {
                return null;
            }
        }
    }
}
