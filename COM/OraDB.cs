using System;
using System.Data;
using System.Data.OracleClient;



namespace COM
{
	/// <summary>
	/// OraDB�� ���� ��� �����Դϴ�.
	/// </summary>
	public class OraDB
	{

		#region ��������

		private DataSet DS_Select = new DataSet("Parameter DataSet");
		private DataSet DS_Modify = new DataSet("Modify DataSet");
		private DataSet DS_Run = new DataSet("Run DataSet");

		private DataSet DS_Ret = new DataSet("Return DataSet");

        

		//------- ���ν��� ���޿� ��������
		/// <summary>
		/// SP ���μ�����
		/// </summary>
		public  string Process_Name;

        public enum ConnectDB
        {
            SEPHIROTH, LMES
        }

        public int TimeOut = 90000;
        public bool ShowErr = false;

        public ConnectDB ConnectName = ConnectDB.SEPHIROTH;
		/// <summary>
		/// SP �Ķ���� �迭
		/// </summary>
		public  string[] Parameter_Name;
		/// <summary>
		/// SP �Ķ���� ���� �迭
		/// </summary>
		public  int[] Parameter_Type;
		/// <summary>
		/// SP �Ķ���� �� �迭
		/// </summary>
		public  string[] Parameter_Values;
		/// <summary>
		/// SP �Ķ���� ��Ʈ���� �迭
		/// </summary>
		public  string[] Parameter_Matrix;


		#endregion



		public OraDB()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
		}

		/// <summary>
		/// ReDim_Parameter : ���ν��� �⵿�� ���� ������
		/// </summary>
		/// <param name="arg_count">���� Count</param>
		public void ReDim_Parameter(int arg_count)
		{
			this.Parameter_Name = new string[arg_count]; 
			this.Parameter_Type = new int[arg_count]; 
			this.Parameter_Values = new string[arg_count] ;
		}


		/// <summary>
		/// Clear_Select_DataSet
		/// </summary>
		private void Clear_Select_DataSet()
		{
			DS_Select.Reset();
		}


		/// <summary>
		/// Clear_Run_DataSet
		/// </summary>
		private void Clear_Run_DataSet()
		{
			DS_Run.Reset();
		}


		/// <summary>
		/// Clear_Modify_DataSet
		/// </summary>
		public void Clear_Modify_DataSet()
		{
			DS_Modify.Reset();
		}


		/// <summary>
		/// Add_Select_Parameter :  ��ȸ�� ���� �̸� Setting �Ǿ��� Parameter������ DataSet�� �߰�
		/// </summary>
		/// <param name="AfterClear">������ DataSet�� Clear�ϰ� �߰�(Cleaer���� ���� ���� ������ �߰���</param>
		/// <returns>���� : true ,���� : false</returns>
		public bool Add_Select_Parameter (bool AfterClear) //string Process_Name, string[]  Parameter_Name, int[] Parameter_Type, string[] Parameter_Values)
		{
			DataTable DT_Select = new DataTable(Process_Name);
			DataColumn[] dc= new DataColumn[3];

			try
			{
				dc[0] = new DataColumn("Parameter_Name",Type.GetType("System.String"));
				dc[1] = new DataColumn("Parameter_Type",Type.GetType("System.Int32"));
				dc[2] = new DataColumn("Parameter_Value",Type.GetType("System.String"));
				DT_Select.Columns.AddRange(dc);

				for(int i=0; i< Parameter_Name.Length ;i++)
				{
					DataRow newRow = DT_Select.NewRow() ;
				
					newRow["Parameter_Name"] = Parameter_Name[i]; 
					newRow["Parameter_Type"] = (int)Parameter_Type[i];
					newRow["Parameter_Value"] = (Parameter_Values[i]==null) ? "": Parameter_Values[i]  ;
					DT_Select.Rows.Add(newRow);

				}
				if (AfterClear) this.Clear_Select_DataSet();
				DS_Select.Tables.Add(DT_Select);
				return true;
			}
			catch
			{
				//MessageBox.Show("Error: " + Process_Name + " at Add_Select_Parameter !!"+ "\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}


		}


		/// <summary>
		/// Add_Run_Parameter : Procedure ������ ���� �̸� Setting �Ǿ��� Parameter������ DataSet�� �߰�
		/// </summary>
		/// <param name="AfterClear">������ DataSet�� Clear�ϰ� �߰�(Cleaer���� ���� ���� ������ �߰���)</param>
		/// <returns>���� : true ,���� : false</returns>
		public bool Add_Run_Parameter (bool AfterClear) //string Process_Name, string[]  Parameter_Name, int[] Parameter_Type, string[] Parameter_Values)
		{
			DataTable DT_Run = new DataTable(Process_Name);
			DataColumn[] dc= new DataColumn[3];

			try
			{
				dc[0] = new DataColumn("Parameter_Name",Type.GetType("System.String"));
				dc[1] = new DataColumn("Parameter_Type",Type.GetType("System.Int32"));
				dc[2] = new DataColumn("Parameter_Value",Type.GetType("System.String"));
				DT_Run.Columns.AddRange(dc);

				for(int i=0; i< Parameter_Name.Length ;i++)
				{
					DataRow newRow = DT_Run.NewRow() ;
				
					newRow["Parameter_Name"] = Parameter_Name[i]; 
					newRow["Parameter_Type"] = (int)Parameter_Type[i];
					newRow["Parameter_Value"] = (Parameter_Values[i]==null) ? "" : Parameter_Values[i] ;
					DT_Run.Rows.Add(newRow);

				}
				if (AfterClear) this.Clear_Run_DataSet();
				DS_Run.Tables.Add(DT_Run);
				return true;
			}
			catch
			{
				//MessageBox.Show("Error: " + Process_Name + " at Add_Run_Parameter !!" + "\n" + ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}


		}


		/// <summary>
		/// Add_Modify_Parameter : Data ������ ���� �̸� Setting �Ǿ��� Parameter������ DataSet�� �߰�
		/// </summary>
		/// <param name="AfterClear">������ DataSet�� Clear�ϰ� �߰�(Cleaer���� ���� ���� ������ �߰���)</param>
		/// <returns>���� : true ,���� : false</returns>
		public bool Add_Modify_Parameter (bool AfterClear) 
		{
			DataTable DT_Modify = new DataTable(Process_Name);
			DataColumn[] dc= new DataColumn[Parameter_Name.Length];

			int row,col ;

			try
			{
				// DataTable�� Column ����
				for(int i=0 ;i< Parameter_Name.Length;i++)
				{
					dc[i] = new DataColumn (Parameter_Name[i],Type.GetType("System.String"));
				}
				DT_Modify.Columns.AddRange(dc);

				col=0;
				DataRow newRow = DT_Modify.NewRow() ;

				for(row=0 ;row< Parameter_Values.Length ;row++)
				{
					
					newRow[col] =(Parameter_Values[row]==null) ? "" : Parameter_Values[row].ToString() ;
					col = col +1;
					if(col == Parameter_Name.Length)
					{
						DT_Modify.Rows.Add(newRow);
						col=0;
						
						if (row < (Parameter_Values.Length -1)) newRow = DT_Modify.NewRow() ;
					}
				
				}
				if (AfterClear) this.Clear_Modify_DataSet();
				this.DS_Modify.Tables.Add(DT_Modify);
				return true;
			}
			catch
			{
				//MessageBox.Show("Error: " + Process_Name + " at Add_Modify_Parameter !!" + "\n" + ex.Message ,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}


		}


 


		/// <summary>
		/// Exe_Select_Procedure : �������� DataTable �Ķ���͸� �̿��Ͽ� ��ȸ
		/// </summary>
		/// <returns>���� : DataSet ,���� : null</returns>
		public DataSet Exe_Select_Procedure()
		{
			//DataSet DS_Ret = new DataSet();
			string[] RunUser;

			try
			{
                
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_NOLog);
                if (ConnectName == ConnectDB.LMES)
                {
                    ComVar._WebSvcLMES.Timeout = TimeOut;
                    DS_Ret = ComVar._WebSvcLMES.Ora_Select_Procedure(RunUser, this.DS_Select);
                }
                else
                {
                    ComVar._WebSvc.Timeout = TimeOut;
                    DS_Ret = ComVar._WebSvc.Ora_Select_Procedure(RunUser, this.DS_Select);
                }
				// --------------- DataSet Format----------------
				// DataSet ���� �������� DataTable�� �̿��Ͽ� ȣ�� �� �� ������ Return�� ��������
				// < ȣ��� ���� �� >
				// 1. RunUser : Set_UserInfo���� �����Ͽ� �迭�� ����
				// 2. DS_Select : Select ������ �ִ� DataSet(�������� Procedure�� ȣ���Ҽ� �ֽ�)
				//		1) DT_Select.TableName : ȣ���ϰ��� �ϴ� Oracle Package �� Procedure ��
				//		2) DT_Select.Column[0] : Į���� -> "Parameter_Name",������ Type -> Type.GetType("System.String") , ���ν��� ��������
				//		3) DT_Select.Column[1] : Į���� -> "Parameter_Type",������ Type -> Type.GetType("System.Int32") , OracleType���� Enum��
				//		4) DT_Select.Column[2] : Į���� -> "Parameter_Value",������ Type -> Type.GetType("System.String") , ���ν��� ���ް�
				// 
				// < ���Ͻ� ���� �� >
				// 1. ���� Return ��
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ������� ������ �ʵ�
				//		3) DataSet.DT.Rows		: ������� ���ڵ�
				// 2. ������ Return ��
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ���������� ������ �ʵ� Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: ������ ����

				//Return �� ó��
				if(DS_Ret.DataSetName =="ERROR")		// ������ Return
				{
                    if (ShowErr) return DS_Ret;
                    //string err_msg = "";
                    //for(int i=0 ; i< DS_Ret.Tables.Count ;i++)
                    //{
                    //    DataRow dr = DS_Ret.Tables[i].Rows[0];
                    //    err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n" ;
                    //    err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n"  ;    
                    //}
					//MessageBox.Show( err_msg,"Oracle DataBase Process",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
					return null;
					
				}
				else
				{
					return DS_Ret;
				}

			}
			catch(System.Threading.ThreadAbortException)
			{
				return null;
			}
			catch(Exception)
			{
				//MessageBox.Show( ex.Message,"Exe_Select_Procedure",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
				return null;
			}

		}


		/// <summary>
		/// Exe_Run_Procedure : �������� DataTable�� �Ķ���͸� �̿��Ͽ� ���ν����� ����
		/// </summary>
		/// <returns>���� : DataSet ,���� : null</returns>
		public DataSet Exe_Run_Procedure()
		{
			//DataSet DS_Ret = new DataSet();
			string[] RunUser;

			try
			{
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
				DS_Ret=  ComVar._WebSvc.Ora_Run_Procedure(RunUser,this.DS_Run );

				// --------------- DataSet Format----------------
				// DataSet ���� �������� DataTable�� �̿��Ͽ� ȣ�� �� �� ������ Return�� ��������
				// < ȣ��� ���� �� >
				// 1. RunUser : Set_UserInfo���� �����Ͽ� �迭�� ����
				// 2. DS_Run : Procedure ������ ���� DataSet(�������� Procedure�� ȣ���Ҽ� �ֽ�)
				//		1) DT_Run.TableName : ȣ���ϰ��� �ϴ� Oracle Package �� Procedure ��
				//		2) DT_Run.Column[0] : Į���� -> "Parameter_Name",������ Type -> Type.GetType("System.String") , ���ν��� ��������
				//		3) DT_Run.Column[1] : Į���� -> "Parameter_Type",������ Type -> Type.GetType("System.Int32") , OracleType���� Enum��
				//		4) DT_Run.Column[2] : Į���� -> "Parameter_Value",������ Type -> Type.GetType("System.String") , ���ν��� ���ް�
				// 
				// < ���Ͻ� ���� �� >
				// 1. ���� Return ��
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ������� ������ �ʵ� Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows[0]	: ������� ���ڵ�  Row[0]= ó�������
				// 2. ������ Return ��
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ���������� ������ �ʵ� Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: ������ ����

				//Return �� ó��
				if(DS_Ret.DataSetName =="ERROR")		// ������ Return
				{
                    //string err_msg="" ;
                    //for(int i=0 ; i< DS_Ret.Tables.Count ;i++)
                    //{
                    //    DataRow dr = DS_Ret.Tables[i].Rows[0];
                    //    err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n" ;
                    //    err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n"  ;  
                    //}
                    //MessageBox.Show( err_msg,"Oracle DataBase Process",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
                    return null;
						
				}
				else
				{

					return DS_Ret;
				}

			}
			catch(Exception )
			{
				//MessageBox.Show( ex.Message,"Exe_Select_Procedure",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
				return null;
			}

		}




 




		/// <summary>
		/// Exe_Modify_Procedure : �������� DataTable�� �̿��Ͽ� ���� �����͸� ����
		/// </summary>
		/// <returns>���� : DataSet ,���� : null</returns>
		public DataSet Exe_Modify_Procedure()
		{
			//DataSet DS_Ret = new DataSet();
			string[] RunUser;

			try
			{
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_NOLog);
                if (ConnectName == ConnectDB.LMES)
                {
                    ComVar._WebSvcLMES.Timeout = TimeOut;
                    DS_Ret = ComVar._WebSvcLMES.Ora_Modify_Procedure(RunUser, this.DS_Modify);
                }
                else
                {
                    ComVar._WebSvc.Timeout = TimeOut;
                    DS_Ret = ComVar._WebSvc.Ora_Modify_Procedure(RunUser, this.DS_Modify);
                }
				// --------------- DataSet Format----------------
				// DataSet ���� �������� DataTable�� �̿��Ͽ� ȣ�� �� �� ������ Return�� ��������
				// < ȣ��� ���� �� >
				// 1. RunUser : Set_UserInfo���� �����Ͽ� �迭�� ����
				// 2. DS_Modify : �迭������ �����͸� �����ϱ� ���� DataSet(�������� Procedure�� ȣ���Ҽ� �ֽ�)
				//		1) DT_Modify.TableName : ȣ���ϰ��� �ϴ� Oracle Package �� Procedure ��
				//		2) DT_Modify.Column[0...] : Į���� -> �� �ʵ��� ���ڰ�[0...],������ Type -> Type.GetType("System.String") , ���ν��� ��������
				//		3) DT_Modify.Row[0...] : ���� �ִ� ���ڵ�
				// 
				// < ���Ͻ� ���� �� >
				// 1. ���� Return ��
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ������� ������ �ʵ� Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows		: ������� ���ڵ�  Row[0]= ó�������
				// 2. ������ Return ��
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ���������� ������ �ʵ� Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: ������ ����

				//Return �� ó��
				if(DS_Ret.DataSetName =="ERROR")		// ������ Return
				{
                    if (ShowErr) return DS_Ret;
                    //string err_msg="";
                    //for(int i=0 ; i< DS_Ret.Tables.Count ;i++)
                    //{
                    //    DataRow dr = DS_Ret.Tables[i].Rows[0];
                    //    err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n" ;
                    //    err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n"  ;  
                    //}
					//MessageBox.Show( err_msg,"Oracle DataBase Process",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
					return null;
					
				}
				else
				{
					return DS_Ret;
				}

			}
			catch
			{
			//	MessageBox.Show( ex.Message,"Exe_Modify_Procedure",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
				return null;
			}
		}



		/// <summary>
		/// Exe_Modify_Procedure : �������� DataTable�� �̿��Ͽ� ���� �����͸� ����
		/// </summary>
		/// <returns>���� : DataSet ,���� : null</returns>
		public bool Exe_Modify_Procedure_all()
		{
			string[] RunUser;
			
			try
			{
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
				DS_Ret=  ComVar._WebSvc.Ora_Modify_Procedure (RunUser,this.DS_Modify);

				// --------------- DataSet Format----------------
				// DataSet ���� �������� DataTable�� �̿��Ͽ� ȣ�� �� �� ������ Return�� ��������
				// < ȣ��� ���� �� >
				// 1. RunUser : Set_UserInfo���� �����Ͽ� �迭�� ����
				// 2. DS_Modify : �迭������ �����͸� �����ϱ� ���� DataSet(�������� Procedure�� ȣ���Ҽ� �ֽ�)
				//		1) DT_Modify.TableName : ȣ���ϰ��� �ϴ� Oracle Package �� Procedure ��
				//		2) DT_Modify.Column[0...] : Į���� -> �� �ʵ��� ���ڰ�[0...],������ Type -> Type.GetType("System.String") , ���ν��� ��������
				//		3) DT_Modify.Row[0...] : ���� �ִ� ���ڵ�
				// 
				// < ���Ͻ� ���� �� >
				// 1. ���� Return ��
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ������� ������ �ʵ� Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows		: ������� ���ڵ�  Row[0]= ó�������
				// 2. ������ Return ��
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ���������� ������ �ʵ� Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: ������ ����

				//Return �� ó��
				if(DS_Ret.DataSetName =="ERROR")		// ������ Return
				{
					string err_msg="";
					for(int i=0 ; i< DS_Ret.Tables.Count ;i++)
					{
						DataRow dr = DS_Ret.Tables[i].Rows[0];
						err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n" ;
						err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n"  ;  
					}
				//	MessageBox.Show( err_msg,"Oracle DataBase Process",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
					return false;
					
				}
				else
				{
					if (DS_Ret == null) return false;
					else return true;
				}

			}
			catch
			{
			//	MessageBox.Show( ex.Message,"Exe_Modify_Procedure",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
				return false;
			}
		}


 
		// 2006 03 13 �߰�

		/// <summary>
		/// Exe_Modify_Procedure_Blob : Blob �����͸� ����
		/// </summary>
		/// <returns>���� : DataSet ,���� : null</returns>
		public bool Exe_Modify_Procedure_Blob(byte[] BlobData)
		{ 

			try
			{ 
				bool ret =  ComVar._WebSvc.Ora_Run_Procedure_Blob (Process_Name, Parameter_Name, Parameter_Type, Parameter_Values, BlobData);

				 
				// < ���Ͻ� ���� �� >
				// 1. ���� Return ��
				//		true
				// 2. ������ Return ��
				//		false

				return ret;


				/*
				//Return �� ó��
				if(DS_Ret.DataSetName =="ERROR")		// ������ Return
				{
					string err_msg="";
					for(int i=0 ; i< DS_Ret.Tables.Count ;i++)
					{
						DataRow dr = DS_Ret.Tables[i].Rows[0];
						err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n" ;
						err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n"  ;  
					}
					MessageBox.Show( err_msg,"Oracle DataBase Process",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
					return null;
					
				}
				else
				{
					return DS_Ret;
				}
				*/


			}
			catch
			{
				//MessageBox.Show( ex.Message,"Exe_Modify_Procedure_Blob",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
				return false;
			}
		}



		/// <summary>
		/// Exe_Select_Query : 1���� Query �������� ȣ��
		/// </summary>
		/// <param name="SqlTxt"> Query ����</param>
		/// <returns>���� : DataSet ,���� : null</returns>
		public DataSet Exe_Select_Query(string SqlTxt)
		{
			//DataSet DS_Ret = new DataSet();
			string[] RunUser;

			try
			{
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
				DS_Ret=  ComVar._WebSvc.Ora_Select(RunUser,SqlTxt);

				// --------------- DataSet Format----------------
				// ���� Sql Query ������ �����Ͽ� DataSet�� ����� Return
				// < ȣ��� ���� �� >
				// 1. RunUser : Set_UserInfo���� �����Ͽ� �迭�� ����
				// 2. SqlTxt : �Ѱ��� Select Sql����
				// 
				// < ���Ͻ� ���� �� >
				// 1. ���� Return ��
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ������� ������ �ʵ� Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows		: ������� ���ڵ�  Row[0]= ó�������
				// 2. ������ Return ��
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : ȣ���� Oracle Package �� Procedure ��
				//		2) DataSet.DT.Columns	: ���������� ������ �ʵ� Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: ������ ����

				//Return �� ó��
				if(DS_Ret.DataSetName =="ERROR")		// ������ Return
				{
					string err_msg="";
					for(int i=0 ; i< DS_Ret.Tables.Count ;i++)
					{
						DataRow dr = DS_Ret.Tables[i].Rows[0];
						err_msg = err_msg + "Exec. Procedur :" + DS_Ret.Tables[i].TableName + " ,Method :" + dr["Method"].ToString() + "\n" ;
						err_msg = err_msg + "Error Message :" + dr["Error"].ToString() + "\n"  ;  
					}
					//MessageBox.Show( err_msg,"Oracle DataBase Process",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
                    return DS_Ret;
					
				}
				else
				{
					return DS_Ret;
				}

			}
			catch
			{
				//MessageBox.Show( ex.Message,"Exe_Modify_Procedure",MessageBoxButtons.OK,MessageBoxIcon.Error) ;
				return null;
			}


		}


	}
}
