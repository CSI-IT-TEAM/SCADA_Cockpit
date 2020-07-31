using System;
using System.Data;
using System.Data.OracleClient;



namespace COM
{
	/// <summary>
	/// OraDB에 대한 요약 설명입니다.
	/// </summary>
	public class OraDB
	{

		#region 변수정의

		private DataSet DS_Select = new DataSet("Parameter DataSet");
		private DataSet DS_Modify = new DataSet("Modify DataSet");
		private DataSet DS_Run = new DataSet("Run DataSet");

		private DataSet DS_Ret = new DataSet("Return DataSet");

        

		//------- 프로시저 전달용 변수선언
		/// <summary>
		/// SP 프로세스명
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
		/// SP 파라메터 배열
		/// </summary>
		public  string[] Parameter_Name;
		/// <summary>
		/// SP 파라메터 유형 배열
		/// </summary>
		public  int[] Parameter_Type;
		/// <summary>
		/// SP 파라메터 값 배열
		/// </summary>
		public  string[] Parameter_Values;
		/// <summary>
		/// SP 파라메터 매트릭스 배열
		/// </summary>
		public  string[] Parameter_Matrix;


		#endregion



		public OraDB()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}

		/// <summary>
		/// ReDim_Parameter : 프로시저 기동용 변수 재정의
		/// </summary>
		/// <param name="arg_count">변수 Count</param>
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
		/// Add_Select_Parameter :  조회를 위해 미리 Setting 되어진 Parameter정보를 DataSet에 추가
		/// </summary>
		/// <param name="AfterClear">기존의 DataSet을 Clear하고 추가(Cleaer하지 않을 경우는 복수로 추가됨</param>
		/// <returns>정상 : true ,오류 : false</returns>
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
		/// Add_Run_Parameter : Procedure 실행을 위해 미리 Setting 되어진 Parameter정보를 DataSet에 추가
		/// </summary>
		/// <param name="AfterClear">기존의 DataSet을 Clear하고 추가(Cleaer하지 않을 경우는 복수로 추가됨)</param>
		/// <returns>정상 : true ,오류 : false</returns>
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
		/// Add_Modify_Parameter : Data 저장을 위해 미리 Setting 되어진 Parameter정보를 DataSet에 추가
		/// </summary>
		/// <param name="AfterClear">기존의 DataSet을 Clear하고 추가(Cleaer하지 않을 경우는 복수로 추가됨)</param>
		/// <returns>정상 : true ,오류 : false</returns>
		public bool Add_Modify_Parameter (bool AfterClear) 
		{
			DataTable DT_Modify = new DataTable(Process_Name);
			DataColumn[] dc= new DataColumn[Parameter_Name.Length];

			int row,col ;

			try
			{
				// DataTable의 Column 정의
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
		/// Exe_Select_Procedure : 복수개의 DataTable 파라미터를 이용하여 조회
		/// </summary>
		/// <returns>정상 : DataSet ,오류 : null</returns>
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
				// DataSet 에는 복수개의 DataTable을 이용하여 호출 할 수 있으면 Return도 복수개임
				// < 호출시 전달 값 >
				// 1. RunUser : Set_UserInfo에서 설정하여 배열로 전달
				// 2. DS_Select : Select 문장이 있는 DataSet(복수개의 Procedure를 호출할수 있슴)
				//		1) DT_Select.TableName : 호출하고자 하는 Oracle Package 및 Procedure 명
				//		2) DT_Select.Column[0] : 칼럼명 -> "Parameter_Name",데이터 Type -> Type.GetType("System.String") , 프로시저 전달인자
				//		3) DT_Select.Column[1] : 칼럼명 -> "Parameter_Type",데이터 Type -> Type.GetType("System.Int32") , OracleType형의 Enum값
				//		4) DT_Select.Column[2] : 칼럼명 -> "Parameter_Value",데이터 Type -> Type.GetType("System.String") , 프로시저 전달값
				// 
				// < 리턴시 전달 값 >
				// 1. 정상 Return 값
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 결과값의 데이터 필드
				//		3) DataSet.DT.Rows		: 결과값의 레코드
				// 2. 오류시 Return 값
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 오류내용의 데이터 필드 Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: 오류의 내용

				//Return 값 처리
				if(DS_Ret.DataSetName =="ERROR")		// 오류가 Return
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
		/// Exe_Run_Procedure : 복수개의 DataTable을 파라미터를 이용하여 프로시저를 실행
		/// </summary>
		/// <returns>정상 : DataSet ,오류 : null</returns>
		public DataSet Exe_Run_Procedure()
		{
			//DataSet DS_Ret = new DataSet();
			string[] RunUser;

			try
			{
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
				DS_Ret=  ComVar._WebSvc.Ora_Run_Procedure(RunUser,this.DS_Run );

				// --------------- DataSet Format----------------
				// DataSet 에는 복수개의 DataTable을 이용하여 호출 할 수 있으면 Return도 복수개임
				// < 호출시 전달 값 >
				// 1. RunUser : Set_UserInfo에서 설정하여 배열로 전달
				// 2. DS_Run : Procedure 실행을 위한 DataSet(복수개의 Procedure를 호출할수 있슴)
				//		1) DT_Run.TableName : 호출하고자 하는 Oracle Package 및 Procedure 명
				//		2) DT_Run.Column[0] : 칼럼명 -> "Parameter_Name",데이터 Type -> Type.GetType("System.String") , 프로시저 전달인자
				//		3) DT_Run.Column[1] : 칼럼명 -> "Parameter_Type",데이터 Type -> Type.GetType("System.Int32") , OracleType형의 Enum값
				//		4) DT_Run.Column[2] : 칼럼명 -> "Parameter_Value",데이터 Type -> Type.GetType("System.String") , 프로시저 전달값
				// 
				// < 리턴시 전달 값 >
				// 1. 정상 Return 값
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 결과값의 데이터 필드 Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows[0]	: 결과값의 레코드  Row[0]= 처리결과값
				// 2. 오류시 Return 값
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 오류내용의 데이터 필드 Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: 오류의 내용

				//Return 값 처리
				if(DS_Ret.DataSetName =="ERROR")		// 오류가 Return
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
		/// Exe_Modify_Procedure : 복수개의 DataTable을 이용하여 많은 데이터를 저장
		/// </summary>
		/// <returns>정상 : DataSet ,오류 : null</returns>
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
				// DataSet 에는 복수개의 DataTable을 이용하여 호출 할 수 있으면 Return도 복수개임
				// < 호출시 전달 값 >
				// 1. RunUser : Set_UserInfo에서 설정하여 배열로 전달
				// 2. DS_Modify : 배열형태의 데이터를 저장하기 위한 DataSet(복수개의 Procedure를 호출할수 있슴)
				//		1) DT_Modify.TableName : 호출하고자 하는 Oracle Package 및 Procedure 명
				//		2) DT_Modify.Column[0...] : 칼럼명 -> 각 필드의 인자값[0...],데이터 Type -> Type.GetType("System.String") , 프로시저 전달인자
				//		3) DT_Modify.Row[0...] : 값이 있는 레코드
				// 
				// < 리턴시 전달 값 >
				// 1. 정상 Return 값
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 결과값의 데이터 필드 Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows		: 결과값의 레코드  Row[0]= 처리결과값
				// 2. 오류시 Return 값
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 오류내용의 데이터 필드 Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: 오류의 내용

				//Return 값 처리
				if(DS_Ret.DataSetName =="ERROR")		// 오류가 Return
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
		/// Exe_Modify_Procedure : 복수개의 DataTable을 이용하여 많은 데이터를 저장
		/// </summary>
		/// <returns>정상 : DataSet ,오류 : null</returns>
		public bool Exe_Modify_Procedure_all()
		{
			string[] RunUser;
			
			try
			{
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
				DS_Ret=  ComVar._WebSvc.Ora_Modify_Procedure (RunUser,this.DS_Modify);

				// --------------- DataSet Format----------------
				// DataSet 에는 복수개의 DataTable을 이용하여 호출 할 수 있으면 Return도 복수개임
				// < 호출시 전달 값 >
				// 1. RunUser : Set_UserInfo에서 설정하여 배열로 전달
				// 2. DS_Modify : 배열형태의 데이터를 저장하기 위한 DataSet(복수개의 Procedure를 호출할수 있슴)
				//		1) DT_Modify.TableName : 호출하고자 하는 Oracle Package 및 Procedure 명
				//		2) DT_Modify.Column[0...] : 칼럼명 -> 각 필드의 인자값[0...],데이터 Type -> Type.GetType("System.String") , 프로시저 전달인자
				//		3) DT_Modify.Row[0...] : 값이 있는 레코드
				// 
				// < 리턴시 전달 값 >
				// 1. 정상 Return 값
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 결과값의 데이터 필드 Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows		: 결과값의 레코드  Row[0]= 처리결과값
				// 2. 오류시 Return 값
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 오류내용의 데이터 필드 Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: 오류의 내용

				//Return 값 처리
				if(DS_Ret.DataSetName =="ERROR")		// 오류가 Return
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


 
		// 2006 03 13 추가

		/// <summary>
		/// Exe_Modify_Procedure_Blob : Blob 데이터를 저장
		/// </summary>
		/// <returns>정상 : DataSet ,오류 : null</returns>
		public bool Exe_Modify_Procedure_Blob(byte[] BlobData)
		{ 

			try
			{ 
				bool ret =  ComVar._WebSvc.Ora_Run_Procedure_Blob (Process_Name, Parameter_Name, Parameter_Type, Parameter_Values, BlobData);

				 
				// < 리턴시 전달 값 >
				// 1. 정상 Return 값
				//		true
				// 2. 오류시 Return 값
				//		false

				return ret;


				/*
				//Return 값 처리
				if(DS_Ret.DataSetName =="ERROR")		// 오류가 Return
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
		/// Exe_Select_Query : 1개의 Query 문장으로 호출
		/// </summary>
		/// <param name="SqlTxt"> Query 문장</param>
		/// <returns>정상 : DataSet ,오류 : null</returns>
		public DataSet Exe_Select_Query(string SqlTxt)
		{
			//DataSet DS_Ret = new DataSet();
			string[] RunUser;

			try
			{
				RunUser =ComFunction.Set_UserInfo(ComVar.Log_Type.Write_File_DB);
				DS_Ret=  ComVar._WebSvc.Ora_Select(RunUser,SqlTxt);

				// --------------- DataSet Format----------------
				// 단일 Sql Query 문장을 전송하여 DataSet의 결과값 Return
				// < 호출시 전달 값 >
				// 1. RunUser : Set_UserInfo에서 설정하여 배열로 전달
				// 2. SqlTxt : 한개의 Select Sql문장
				// 
				// < 리턴시 전달 값 >
				// 1. 정상 Return 값
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 결과값의 데이터 필드 Column[0].ColumnName = "Result"
				//		3) DataSet.DT.Rows		: 결과값의 레코드  Row[0]= 처리결과값
				// 2. 오류시 Return 값
				//		1) DataSet.DataSetName  : "ERROR"
				//		1) DataSet.DT.TableName : 호출한 Oracle Package 및 Procedure 명
				//		2) DataSet.DT.Columns	: 오류내용의 데이터 필드 Column[0].ColumnName = "Method", Column[1].ColumnName = "Error" , Column[2].ColumnName = "Date"
				//		3) DataSet.DT.Rows		: 오류의 내용

				//Return 값 처리
				if(DS_Ret.DataSetName =="ERROR")		// 오류가 Return
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
