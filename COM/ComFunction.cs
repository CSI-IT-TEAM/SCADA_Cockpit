using System;
using System.Data;
using System.Data.OracleClient;



namespace COM
{
	/// <summary>
	/// ComFunction : :공통함수 클래스
	/// </summary>
	public class ComFunction
	{
		public ComFunction()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}

		#region Webservice URL 변경


		public static void Change_WebService_URL(string arg_factory)
		{

			try
			{

				switch(arg_factory)
				{
					case "DS":
						COM.ComVar._WebSvc.Url = COM.ComVar.DS_WebSvc_Url;
						break;

					case "QD":
						COM.ComVar._WebSvc.Url = COM.ComVar.QD_WebSvc_Url;
						break;

					case "VJ":
						COM.ComVar._WebSvc.Url = COM.ComVar.VJ_WebSvc_Url;
						break;

					case "JJ":
						COM.ComVar._WebSvc.Url = COM.ComVar.JJ_WebSvc_Url;
						break;

					case "EIS":
						COM.ComVar._WebSvc.Url = COM.ComVar.EIS_WebSvc_Url;
						break;

				}


			}
			catch
			{
				COM.ComVar._WebSvc.Url = COM.ComVar.DS_WebSvc_Url;
				//COM.ComFunction.User_Message(ex.Message, "Change_WebService_URL", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 

		}



		#endregion

        public static string[] Set_UserInfo(ComVar.Log_Type LType)
        {
            string[] info = new string[5];

            info[0] = ComVar.This_Factory.ToString();
            info[1] = ComVar.This_User.ToString();
            info[2] = ComVar.This_SysJob.ToString();
            info[3] = "";
            info[4] = ((int)LType).ToString();

            return info;
        }

        /*
		#region 공통 메소드

		#region 사용자 정보 메소드

		


		#endregion

		#region ConvertDate

		/// <summary>
		/// ConvertDate : 데이터베이스 입력 형식(yyyyMMdd)의 날짜값을 설정 date형식에 변경
		/// </summary>
		/// <param name="arg_yyyyMMdd">arg_date : DB형 날짜형식(yyyyMMdd로 고정) </param>
		/// <returns>date형식으로 변경된 값</returns>
		public  string ConvertDate2Type(string arg_yyyyMMdd)
		{
			try
			{
				string sdatetype = ComVar.This_SetedDateType;			//설정된 날짜 형식
				string sdatesign = ComVar.This_SetedDateSign ;			//기호구분

				int firstsign = sdatetype.IndexOf(sdatesign);			// 첫 번째 기호 자릿수
				int secondsign = sdatetype.LastIndexOf(sdatesign);		// 두번째 기호 자릿 수

				string ftype = sdatetype.Substring(0,firstsign);		// yyyy
				string stype = sdatetype.Substring(firstsign+1,secondsign-firstsign-1); // MM
				string ttype = sdatetype.Substring(secondsign+1);		// dd

				return GetDatevalue(ftype, arg_yyyyMMdd) + sdatesign + GetDatevalue(stype, arg_yyyyMMdd) + sdatesign + GetDatevalue(ttype, arg_yyyyMMdd);
		
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"ConvertDate2Type",MessageBoxButtons.OK,MessageBoxIcon.Error );
				return arg_yyyyMMdd;
			}
		}


		/// <summary>
		/// ConvertDate2DbType : 현재형식의 날짜를 DB 저장형식으로 변경
		/// </summary>
		/// <param name="arg_Date">현재형식의 날짜</param>
		/// <returns>DB 형식의 날짜</returns>
		public string ConvertDate2DbType(string arg_Date)
		{
			return ConvertDate(arg_Date,ComVar.This_SetedDateSign,ComVar.This_SetedDateType,"",ComVar.This_SetedDBType);
		}


		/// <summary>
		/// ConvertDate : 날짜형식과 DataBase날자형식(yyyyMMdd) 또는 날자형식간 상호 변환
		/// </summary>
		/// <param name="arg_Date">입력날자 </param>
		/// <param name="arg_inSign">입력 날자구분자</param>
		/// <param name="arg_inType">일력 날자형식</param>
		/// <param name="arg_outSign">출력 날자구분자</param>
		/// <param name="arg_outType">출력 날자형식</param>
		/// <returns>변경된 값</returns>
		public string ConvertDate(string arg_Date,string arg_inSign,string arg_inType,string arg_outSign,string arg_outType)
		{			
			// yyyy-MM-dd   -> M-d-yy
			string indate = "" ;		//yyyyMMdd
			string outdate = "" ;		
			string y="";
			string m="";
			string d = "" ;
			
			try
			{
				string[] intk = arg_inType.Split(arg_inSign.ToCharArray()) ;
				string[] outtk = arg_outType.Split(arg_outSign.ToCharArray());
				string[] inymd = arg_Date.Split(arg_inSign.ToCharArray()) ;
				string[] outymd= new string[3];



				if (arg_inSign.Trim()=="")
				{
					intk = new string[3];
					inymd = new string[3];
					intk[0] = "yyyy";		// yyyy
					intk[1] = "MM"; 		// MM
					intk[2] = "dd";			// dd

					inymd =new string[3];
					inymd[0] = arg_Date.Substring(0,intk[0].Length);
					inymd[1] = arg_Date.Substring(intk[0].Length,intk[1].Length);
					inymd[2] = arg_Date.Substring(intk[0].Length+intk[1].Length,intk[2].Length);
				}

				for(int i =0 ; i<3 ;i++)
				{
					if(intk[i].Substring(0,1)=="y") 
					{
						y=inymd[i];
						if (y.Length < 4) 
						{	
							string pre_year = System.DateTime.Today.Year.ToString().Substring(0,4-y.Length);
							y = pre_year + y;
						}
					}
					else if(intk[i].Substring(0,1)=="M") 
					{

						m=inymd[i];
						if (m.Length == 1)	m = "0" + m;

					}
					else if(intk[i].Substring(0,1)=="d") 
					{
						d=inymd[i];
						if(d.Length == 1) d = "0" + d;
					}

				}

				indate = y + m + d ;   // yyyyMMdd (정형화)

				if (arg_outSign.Trim()=="")
				{
					return indate;
				}
				else
				{
					outdate = indate;
					return GetDatevalue(outtk[0], outdate) + arg_outSign + GetDatevalue(outtk[1], outdate) + arg_outSign + GetDatevalue(outtk[2], outdate)  ;
				}


			}
			catch(Exception ex)
			{

				MessageBox.Show(ex.Message.ToString(),"ConvertDate",MessageBoxButtons.OK,MessageBoxIcon.Error );
				return arg_Date;
			}
		}


		/// <summary>
		/// GetDatevalue : date type 조건에 맞는 날짜 변형 메소드 
		/// </summary>
		/// <param name="arg_datetyep">날짜 형식</param>
		/// <param name="arg_date"> DB형 날짜형식(yyyyMMdd로 고정)</param>
		/// <returns>날짜 형식에 맞는 변확값 , 실패시 :null</returns>
		private  string GetDatevalue(string arg_datetyep, string arg_date)
		{
			string stype ="";
			try
			{
				string yyyy = arg_date.Substring(0,4);		// yyyy
				string MM = arg_date.Substring(4,2);		// MM
				string dd = arg_date.Substring(6,2);		// dd

				if(arg_datetyep == "yyyy")
				{
					stype = yyyy;
				}

				else if(arg_datetyep == "yy")
				{
					stype = yyyy.Substring(2,2);
				}

				else if(arg_datetyep == "MM")
				{
					stype = MM;
				}

				else if(arg_datetyep == "M")
				{
					if(MM.Substring(0,1) == "0")
					{
						stype = MM.Substring(1,1);
					}
				}

				else if(arg_datetyep == "dd")
				{
					stype = dd;
				}

				else if(arg_datetyep == "d")
				{
					if(dd.Substring(0,1) == "0")
					{
						stype = dd.Substring(1,1);
					}
				}

				return stype;
			}
			catch
			{
				return null;
			}
		}



		#endregion

		#region 언어 처리 메소드

		/// <summary>
		/// SetLangDic : 각 폼에 언어사전을 적용
		/// </summary>
		/// <param name="arg_Form">폼이름</param>
		/// <param name="arg_pg_id">프로그램 id</param>
		public static void SetLangDic(System.Windows.Forms.Form arg_Form)
		{

			string ctlname ="";
			string ctltext = "";

			DataTable dt;


			FieldInfo info = null;
			Control ctl = null;

			OraDB MyOraDB = new OraDB();

            string[] token = arg_Form.ToString().Split(',');
            string arg_pg_id = token[0];


			////// DB에서 언어사전 호출 
			dt = MyOraDB.Select_LangDic (ComVar.This_Factory, ComVar.This_Lang, arg_pg_id);
		
            //if(dt== null)
            //{
            //    MessageBox.Show("[" + ComVar.This_Lang + "] Language Dictionary is not found!!" ,"Language Dictionary",MessageBoxButtons.OK,MessageBoxIcon.Error );
            //    return;
            //}

            if (dt == null || dt.Rows.Count == 0) return;


			for(int i=0; i<dt.Rows.Count; i++)
			{

				ctlname = dt.Rows[i].ItemArray[4].ToString();
				ctltext = dt.Rows[i].ItemArray[7].ToString();


				if(ctltext.Trim().Length == 0)
				{
					ctltext = dt.Rows[i].ItemArray[5].ToString();
				}





				try
				{
					if(ctlname == "Form")		// Form Head Title 처리
					{
						arg_Form.Text    =     ctltext;
					}
					else						
					{	
						// Control Text 처리
						info = arg_Form.GetType().GetField(ctlname, BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
						ctl = (Control) info.GetValue(arg_Form);
						ctl.Text = ctltext;


						// 기타 처리??????
					}
				}
				catch//(Exception ex)
				{
					//MessageBox.Show(ctlname + " : " + ctltext);
				}
			}







			try
			{
				//StateBar가 있으면 표시
				ctlname = "stbar";
				info = arg_Form.GetType().GetField(ctlname,BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
				StatusBar ctl_bar = (System.Windows.Forms.StatusBar) info.GetValue(arg_Form);
				//ctl1.Panels.Clear();
				//ctl1.Panels.Add(arg_text);
				ctl_bar.Panels[0].Width = (int)Math.Round((arg_Form.Width * 0.8),0);
				ctl_bar.Panels[1].Width = (int)Math.Round((arg_Form.Width * 0.2),0);
				ctl_bar.Panels[1].Text = arg_Form.Name;
			}
			catch
			{
			}

				
		}

		public static string Check_Y_N(string arg_Y_N)
		{
			string ResultTrueFalse = null;
		
			if(arg_Y_N == "Y")
			{
				ResultTrueFalse = "True";
			}
			else
			{
				ResultTrueFalse = "False";
			}
		
			return ResultTrueFalse;
		}



		public static DataTable Select_Button(string arg_factory, string arg_pg_name)
		{
			OraDB oraDB = new OraDB();

			string Proc_Name = "PKG_SPS_MENU.SELECT_FORM_BTN";
			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_MENU_PG";
			oraDB.Parameter_Name[2] = "OUT_CURSOR";

			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = arg_factory;
			oraDB.Parameter_Values[1] = arg_pg_name;
			oraDB.Parameter_Values[2] = "";

			oraDB.Add_Select_Parameter(true);
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			
			return  DS_Ret.Tables[Proc_Name];
		}

		#endregion

		#region 공백 처리 함수들 


		/// <summary>
		/// Combo 선택된 항목이 없는경우 리턴값
		/// </summary>
		/// <param name="sCombo">해당 ComboList</param>
		/// <param name="sReturn">공백일때 리턴값</param>
		/// <returns>리턴값</returns>
		public static string Empty_Combo(C1.Win.C1List.C1Combo arg_Cmb,string arg_Ret)
		{
			if (arg_Cmb.SelectedIndex == -1 )
			{
				return arg_Ret;
			}
			else
			{
				return arg_Cmb.SelectedValue.ToString();
			}
		}



		/// <summary>
		/// Combo 선택된 항목이 null인 경우 리턴값
		/// </summary>
		/// <param name="sCombo">해당 ComboList</param>
		/// <param name="sReturn">공백일때 리턴값</param>
		/// <returns>리턴값</returns>

		public static string Param_Combo(C1.Win.C1List.C1Combo arg_Cmb,string arg_Ret)
		{
			if (arg_Cmb.SelectedIndex == -1 )
			{
				return arg_Ret;
			}
			else
			{
				if(arg_Cmb.SelectedValue.ToString().Trim() == "")
					return arg_Ret; 
				else
					return arg_Cmb.SelectedValue.ToString().Trim();
			}
		}





		/// <summary>
		/// TextBox가 공백일때 변환 값
		/// </summary>
		/// <param name="arg_Txt">해당 TextBox</param>
		/// <param name="arg_Ret">공백일때 리턴값</param>
		/// <returns>리턴값</returns>
		public static string Empty_TextBox(TextBox arg_Txt,string arg_Ret)
		{
			if (arg_Txt.Text.Trim() == "" )
			{
				return arg_Ret;
			}
			else
			{
				return arg_Txt.Text.Trim();
			}
		}


		/// <summary>
		/// 문자열이 공백이면 변환 값
		/// </summary>
		/// <param name="arg_Str">해당 문자열 변수</param>
		/// <param name="arg_Ret">공백일때 리턴값</param>
		/// <returns>리턴값</returns>
		public static string Empty_String(string arg_Str,string arg_Ret)
		{
			if (arg_Str.Trim() == "" )
			{
				return arg_Ret;
			}
			else
			{
				return arg_Str.Trim();
			}
		}


		/// <summary>
		/// 숫자값이 공백이면 변환 값
		/// </summary>
		/// <param name="arg_Num">해당 숫자변수</param>
		/// <param name="arg_Ret">공백일때 리턴값</param>
		/// <returns></returns>
		public static int Empty_Number(string arg_Num,string arg_Ret)
		{
			if (arg_Num.Trim() == "" )
			{
				return Convert.ToInt32(arg_Ret);
			}
			else
			{
				return Convert.ToInt32(arg_Num.Trim());
			}
		}




		#endregion 
		
		#region Value Check (숫자만 허용, 실수 체크, 정수 체크..)


		/// <summary>
		/// TextBox에 숫자만 허용됨
		/// </summary>
		/// <param name="arg_Text">대상 TextBox</param>
		/// <param name="arg_limit">숫자 허용 자리수</param>
		public static void Set_NumberTextBox(TextBox arg_Text,int arg_limit)
		{
			
			if (arg_Text.Text.Trim() == "")			//공백이면 0
			{
				arg_Text.Text = "0";
			}
			else 
			{
				for (int i=0;i < arg_Text.Text.Length ;i++)
				{
					if (Char.IsNumber(arg_Text.Text,i) == false)
					{
						MessageBox.Show("Only number data is allowed !!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
						arg_Text.Text = arg_Text.Text.Substring(0,i);
						arg_Text.Focus();
						return; 
					}
				}
			}
			
			if(arg_Text.Text.Length > arg_limit)
			{
				MessageBox.Show("Too many number( " +arg_limit.ToString() + " digit is allowed) !!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
				arg_Text.Text = arg_Text.Text.Substring(0,arg_limit);
				return;
			}

		}



		/// <summary>
		/// TextBox에 숫자만 허용됨, 정수형 또는 실수형 구분
		/// </summary>
		/// <param name="arg_Text">대상 TextBox</param>
		/// <param name="arg_limit">숫자 허용 자리수</param>
		public static bool Set_NumberTextBox(TextBox arg_Text,int arg_limit, string arg_type)
		{
			 
			if (arg_Text.Text.Trim() == "")			//공백이면 0
			{
				arg_Text.Text = "0";
			}
			else 
			{
				for (int i=0;i < arg_Text.Text.Length ;i++)
				{
					if (Char.IsNumber(arg_Text.Text,i) == false)
					{
						MessageBox.Show("Only number data is allowed !!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
						arg_Text.Text = arg_Text.Text.Substring(0,i);
						arg_Text.Focus();
						return false; 
					}
				}
			}
			
			if(arg_Text.Text.Length > arg_limit)
			{
				MessageBox.Show("Too many number( " +arg_limit.ToString() + " digit is allowed) !!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
				arg_Text.Text = arg_Text.Text.Substring(0,arg_limit);
				return false;
			}
			 


			return true;

		}


		 

		/// <summary>
		/// Check_Decimal : 실수형 여부 Check
		/// </summary>
		/// <param name="strValue">input string</param>
		/// <returns>bool</returns>
		//public static bool Check_Decimal(string strValue, C1.Win.C1FlexGrid.KeyPressEditEventArgs arg_e )
		public static bool Check_Decimal(string strValue)
		{
			Boolean r = true;			
			
			for (int i=0; i< strValue.Length; i++) 
			{	
				string str = strValue.Substring(i, 1).ToString();
	
				if ( (char.IsDigit(strValue,i) == false) && (str != ".") )
				{				
					if ( (i == 0) && (str == "-") ) 
					{
						r = true;
					}
						//else if (str.IndexOf(".", 0) != str.LastIndexOf(".", 0))
						//{
						//	r = true;
						//}
					else
					{
						r = false;				
						MessageBox.Show("Decimal digit is allowed !!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
						break;					
					}
				}					
			}
			return r;			
		}



		/// <summary>
		/// Check_Decimal : 숫자형 여부 Check
		/// </summary>
		/// <param name="strValue">input string</param>
		/// <returns>bool</returns>
		public static bool Check_Digit(string strValue)
		{
			for (int i=0; i< strValue.Length; i++) 
			{				
				if ( (char.IsDigit(strValue,i) == false) )
				{
					MessageBox.Show("Numeric digit is allowed !!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning) ;
					return false;											
				}
			}
			return true;	
		}




		#endregion

		#region 업무자동 알림

		/// <summary>
		/// AutoWorkMessage : 자동 업무 알림
		/// </summary>
		/// <param name="arg_pg_id">실행 프로그램</param>
		/// <param name="arg_seq">이벤트 고유 번호</param>
		/// <param name="arg_subject">생성될 메시지 내용</param>
		public void AutoWorkMessage(string arg_pg_id, string arg_seq, string arg_subject)
		{
			string User_ID   = "system";                 //사용자 아이디('system' 으로 고정)
			string User_mail = "";//"haidin@hanmail.net";     //사용자 멜 주소
			
			//int _Factory    = 0;
			//int _User_id    = 1;
			//int _Pg_id      = 2;
			//int _Seq	      = 3;
			//int _Work_event = 4;
			//int _Work_desc  = 5;
			int _Ruser_id	= 6;
			int _Title		= 7;
			int _Body_head	= 8;
			int _Body_tail	= 9;
			int _Mail_yn	= 10;

			//조건에 맞는 이벤트 상세 정보 가져오기

			try
			{


				//COM.Com_Form.Form_PS_NoticeAuto psNoticeAuto = new COM.Com_Form.Form_PS_NoticeAuto(arg_pg_id,arg_seq);
				//psNoticeAuto.ShowDialog();



				DataTable dt = Get_Auto_Message(ComVar.This_Factory, User_ID, arg_pg_id, arg_seq);

				string title   = dt.Rows[0].ItemArray[_Title].ToString();          //타이틀
				string message_head = dt.Rows[0].ItemArray[_Body_head].ToString(); //상당 메시지
				string message_tail = dt.Rows[0].ItemArray[_Body_tail].ToString(); //하단 메시지

				StringBuilder stringBuilder = new StringBuilder();				   //실제로 전달될 메시지 전체
				stringBuilder.Append(message_head);
				stringBuilder.Append("\r\n\r\n");
				stringBuilder.Append(arg_subject);
				stringBuilder.Append("\r\n\r\n");
				stringBuilder.Append(message_tail);


				string mail_yn = dt.Rows[0].ItemArray[_Mail_yn].ToString();       //메일 사용 유무


				string Ruser_id = dt.Rows[0].ItemArray[_Ruser_id].ToString();     //사용자 리스트
				string Ruser_div  = ",";                                          //사용자 구분자
				string[] Receiver = Ruser_id.Split(Ruser_div.ToCharArray());

				for(int i=0; i<Receiver.Length; i++)
				{
					string Receive_id   = Receiver[i];                                           //사용자 아이디
					string Receive_name	= Get_Name(Receiver[i]).Rows[0].ItemArray[1].ToString(); //사용자 이름
					string Receive_mail = Get_Name(Receiver[i]).Rows[0].ItemArray[3].ToString(); //사용자 메일 주소

					//SPS_NOTICE_USER DB에 저장
					Send_Auto_Message("", "I",  "A", User_ID , User_ID, Receive_id , Receive_name, title, stringBuilder.ToString());
				
					//메일 첵크('Y' 메일 보냄)
					Send_Auto_Mail(mail_yn, User_mail, Receive_mail, title, stringBuilder.ToString());
				}
			}
			catch
			{
			}


		}


	    private void Send_Auto_Mail(string arg_check, string arg_frommail, string arg_tomail, string arg_title, string arg_body)
		{
			//string SmtpServer = "haidin.net";

			if(arg_check == "Y" && arg_tomail.Length != 0)
			{
                MailMessage mail = new MailMessage();
				mail.From        = arg_frommail;
				mail.To          = arg_tomail;
				mail.Subject     = arg_title;
				mail.Body        = arg_body;
				mail.BodyFormat  = MailFormat.Text;
				//SmtpMail.SmtpServer = SmtpServer;
				SmtpMail.Send(mail);
			}
		}


		/// <summary>
		/// Get_Auto_Message : 개인 자동 알림 상세 정보 가져오기
		/// </summary>
		/// <param name="arg_factory">공장</param>
		/// <param name="arg_user_id">사용자 아이디(고정)</param>
		/// <param name="arg_pg_id">실행 프로그램</param>
		/// <param name="arg_seq">이벤트 고유 번호</param>
		/// <returns>정상:DdataTable ,오류:null</returns>
		private DataTable Get_Auto_Message(string arg_factory, string arg_user_id, string arg_pg_id, string arg_seq)
		{
			OraDB oraDB = new OraDB();

			string Proc_Name = "PKG_SPS_HOME.SEND_AUTO_MESSAGE";

			oraDB.ReDim_Parameter(5);
			oraDB.Process_Name = Proc_Name;

			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_USER_ID";
			oraDB.Parameter_Name[2] = "ARG_PG_ID";
			oraDB.Parameter_Name[3] = "ARG_SEQ";
			oraDB.Parameter_Name[4] = "OUT_CURSOR"; 
			
			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[3] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[4] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = arg_factory;
			oraDB.Parameter_Values[1] = arg_user_id;
			oraDB.Parameter_Values[2] = arg_pg_id;
			oraDB.Parameter_Values[3] = arg_seq;
			oraDB.Parameter_Values[4] = "";


			oraDB.Add_Select_Parameter(true); 
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			
			return  DS_Ret.Tables[Proc_Name];
		}


		/// <summary>
		/// Send_Auto_Message : 메시지(개인 업무 알림) 보내기
		/// </summary>
		/// <param name="arg_division">Save Code</param>
		/// <param name="arg_div">S/R</param>
		/// <param name="arg_suser_name">보내는 이름</param>
		/// <param name="arg_ruser_id">받는이 아이디</param>
		/// <param name="arg_ruser_name">받는이 이름</param>
		private void Send_Auto_Message(string arg_seq, string arg_division, string arg_div, string arg_suser_id, string arg_suser_name, string arg_ruser_id, string arg_ruser_name, string arg_title, string arg_message)
		{
			OraDB oraDB = new OraDB();

			string Proc_Name = "PKG_SPS_HOME.SAVE_SPS_NOTICE_USER";

			oraDB.ReDim_Parameter(12);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0]  = "ARG_DIVISION";
			oraDB.Parameter_Name[1]  = "ARG_FACTORY";
			oraDB.Parameter_Name[2]  = "ARG_DIV";
			oraDB.Parameter_Name[3]  = "ARG_SEQ";
			oraDB.Parameter_Name[4]  = "ARG_SUSER_ID";
			oraDB.Parameter_Name[5]  = "ARG_SUSER_NAME";
			oraDB.Parameter_Name[6]  = "ARG_RUSER_ID";
			oraDB.Parameter_Name[7]  = "ARG_RUSER_NAME";
			oraDB.Parameter_Name[8]  = "ARG_TITLE";
			oraDB.Parameter_Name[9]  = "ARG_MESSAGE";
			oraDB.Parameter_Name[10] = "ARG_READ_YN";
			oraDB.Parameter_Name[11] = "ARG_UPD_USER";

			oraDB.Parameter_Type[0]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[3]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[4]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[5]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[6]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[7]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[8]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[9]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[10] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[11] = (int)OracleType.VarChar;



			oraDB.Parameter_Values[0]  = arg_division;
			oraDB.Parameter_Values[1]  = ComVar.This_Factory;
			oraDB.Parameter_Values[2]  = arg_div;
			oraDB.Parameter_Values[3]  = arg_seq;
			oraDB.Parameter_Values[4]  = arg_suser_id;
			oraDB.Parameter_Values[5]  = arg_suser_name;
			oraDB.Parameter_Values[6]  = arg_ruser_id;
			oraDB.Parameter_Values[7]  = arg_ruser_name;
			oraDB.Parameter_Values[8]  = arg_title;
			oraDB.Parameter_Values[9]  = arg_message;
			oraDB.Parameter_Values[10] = "N";
			oraDB.Parameter_Values[11] = ComVar.This_User;

			oraDB.Add_Modify_Parameter(true);
			oraDB.Exe_Modify_Procedure();
		}

		/// <summary>
		/// Get_Name : 사용자 이름,메일 주소 가져오기 가져오기
		/// </summary>
		/// <param name="arg_user_id">사용자 아이디</param>
		/// <returns>정상:DataTable ,오류:null</returns>
		private DataTable Get_Name(string arg_user_id)
		{
			OraDB oraDB = new OraDB();

			string Proc_Name = "PKG_SPS_HOME.GET_USER_NAME";

			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0]  = "ARG_FACTORY";
			oraDB.Parameter_Name[1]  = "ARG_USER_ID";
			oraDB.Parameter_Name[2]  = "OUT_CURSOR";

			oraDB.Parameter_Type[0]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1]  = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2]  = (int)OracleType.Cursor;


			oraDB.Parameter_Values[0]  = ComVar.This_Factory;
			oraDB.Parameter_Values[1]  = arg_user_id;
			oraDB.Parameter_Values[2]  = "";

			oraDB.Add_Select_Parameter(true); 
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			
			return  DS_Ret.Tables[Proc_Name];
		}

		#endregion

		#region 메시지 박스

		/// <summary>
		/// User_Message : 메시지 박스 호출(사용자 임의 입력I)
		/// </summary>
		/// <param name="arg_text">메시지 박스 내용</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text)
		{
			DialogResult result = MessageBox.Show(arg_text);
			return result;
		}

		/// <summary>
		/// User_Message : 메시지 박스 호출(사용자 임의 입력II)
		/// </summary>
		/// <param name="arg_text">메시지 박스 내용</param>
		/// <param name="arg_caption">메시지 박스 제목</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text, string arg_caption)
		{
			DialogResult result = MessageBox.Show(arg_text, arg_caption);
			return result;
		}
		
		/// <summary>
		/// User_Message : 메시지 박스 호출(사용자 임의 입력III)
		/// </summary>
		/// <param name="arg_text">메시지 박스 내용</param>
		/// <param name="arg_caption">메시지 박스 제목</param>
		/// <param name="arg_buttons">사용 버튼</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text, string arg_caption, MessageBoxButtons arg_buttons)
		{
			DialogResult result = MessageBox.Show(arg_text, arg_caption, arg_buttons);
			return result;
		}

		/// <summary>
		/// User_Message : 메시지 박스 호출(사용자 임의 입력IV)
		/// </summary>
		/// <param name="arg_text">메시지 박스 내용</param>
		/// <param name="arg_caption">메시지 박스 제목</param>
		/// <param name="arg_buttons">사용 버튼</param>
		/// <param name="aeg_icon">사용 아이콘</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text, string arg_caption, MessageBoxButtons arg_buttons, MessageBoxIcon aeg_icon)		
		{
			DialogResult result = MessageBox.Show(arg_text, arg_caption, arg_buttons, aeg_icon);
			return result;
		}

		/// <summary>
		/// Data_Message : 메시지 박스 호출, 상태 바 없는 폼(DataBase I)
		/// </summary>
		/// <param name="arg_code">코드</param>
		/// <param name="arg_cation">메시지 박스 제목</param>
		/// <returns>DialogResult</returns>
		public static DialogResult Data_Message(string arg_code)
		{
			//메시지 데이터 코드로 추출
			DataTable dt = Select_SPC_Message(arg_code);

			//메시지 제목
			string arg_capt;
			//메시지 내용
			string arg_text;


			//언어 체크
			if(ComVar.This_Lang == "KO")
			{
				arg_capt = dt.Rows[0].ItemArray[1].ToString();
				arg_text = dt.Rows[0].ItemArray[2].ToString();
			}
			else
			{
				arg_capt = dt.Rows[0].ItemArray[3].ToString();
				arg_text = dt.Rows[0].ItemArray[4].ToString();
			}

			//메시지 버튼 유형
			string arg_buttons_code = dt.Rows[0].ItemArray[5].ToString();
			//메시지 아이콘 유형
			string arg_icons_code   = dt.Rows[0].ItemArray[6].ToString();

			//메시지 Show
			DialogResult result = MessageBox.Show( arg_text, arg_capt, Buttons(arg_buttons_code), Icons(arg_icons_code) );
			return result;
		}


		/// <summary>
		/// Data_Message : 메시지 박스 호출, 상태 바 없는 폼(DataBase II)
		/// </summary>
		/// <param name="arg_object">주체</param>
		/// <param name="arg_code">코드</param>
		/// <param name="arg_cation">메시지 박스 제목</param>
		/// <returns>DialogResult</returns>
		public static DialogResult Data_Message( string arg_object, string arg_code )
		{

			
			if(arg_object != "")
				arg_object = arg_object + " : ";

			//메시지 데이터 코드로 추출
			DataTable dt = Select_SPC_Message(arg_code);

			//메시지 제목
			string arg_capt;
			//메시지 내용
			string arg_text;


			//언어 체크
			if(ComVar.This_Lang == "KO")
			{
				if(arg_object != "")
					arg_object = arg_object + ": ";

				arg_capt = dt.Rows[0].ItemArray[1].ToString();
				arg_text = dt.Rows[0].ItemArray[2].ToString();
			}
			else
			{
				if(arg_object != "")
					arg_object = arg_object + " : ";

				arg_capt = dt.Rows[0].ItemArray[3].ToString();
				arg_text = dt.Rows[0].ItemArray[4].ToString();
			}

			//메시지 버튼 유형
			string arg_buttons_code = dt.Rows[0].ItemArray[5].ToString();
			//메시지 아이콘 유형
			string arg_icons_code   = dt.Rows[0].ItemArray[6].ToString();

			//메시지 Show
			DialogResult result = MessageBox.Show(arg_object + arg_text, arg_capt, Buttons(arg_buttons_code), Icons(arg_icons_code) );
			return result;
		}

		/// <summary>
		/// Data_Message : 메시지 박스 호출, 상태 바 있는 폼(DataBase III)
		/// </summary>
		/// <param name="arg_object">주체</param>
		/// <param name="arg_code">코드</param>
		/// <param name="arg_cation">메시지 박스 제목</param>
		/// <param name="arg_Form">state bar가 있는 폼</param>
		/// <returns></returns>
		public static DialogResult Data_Message( string arg_code, System.Windows.Forms.Form arg_Form )
		{

			//메시지 데이터 코드로 추출
			DataTable dt = Select_SPC_Message(arg_code);

			//메시지 제목
			string arg_capt;
			//메시지 내용
			string arg_text;


			//언어 체크
			if(ComVar.This_Lang == "KO")
			{
				arg_capt = dt.Rows[0].ItemArray[1].ToString();
				arg_text = dt.Rows[0].ItemArray[2].ToString();
			}
			else
			{
				arg_capt = dt.Rows[0].ItemArray[3].ToString();
				arg_text = dt.Rows[0].ItemArray[4].ToString();
			}

			//메시지 버튼 유형
			string arg_buttons_code = dt.Rows[0].ItemArray[5].ToString();
			//메시지 아이콘 유형
			string arg_icons_code   = dt.Rows[0].ItemArray[6].ToString();

			try
			{
				//StateBar가 있으면 표시
				string ctlname = "stbar";
				FieldInfo info = arg_Form.GetType().GetField(ctlname,BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
				StatusBar ctl = (System.Windows.Forms.StatusBar) info.GetValue(arg_Form);
				ctl.Panels.Clear();
				ctl.Panels.Add(arg_text);
				ctl.Panels[0].Width = (int)Math.Round((arg_Form.Width * 0.7),0);
				ctl.Panels[1].Width = (int)Math.Round((arg_Form.Width * 0.3),0);
			}
			catch
			{}

			//메시지 Show
			DialogResult result = MessageBox.Show( arg_text, arg_capt, Buttons(arg_buttons_code), Icons(arg_icons_code) );
			return result;
		}

		/// <summary>
		/// Data_Message : 메시지 박스 호출, 상태 바 있는 폼(DataBase IV)
		/// </summary>
		/// <param name="arg_object">주체</param>
		/// <param name="arg_code">코드</param>
		/// <param name="arg_cation">메시지 박스 제목</param>
		/// <param name="arg_Form">state bar가 있는 폼</param>
		/// <returns></returns>
		public static DialogResult Data_Message( string arg_object, string arg_code, System.Windows.Forms.Form arg_Form )
		{
			if(arg_object != "")
				arg_object = arg_object + " : ";

			DataTable dt = Select_SPC_Message(arg_code);

			string arg_capt;
			string arg_text;


			if(ComVar.This_Lang == "KO")
			{
				arg_capt = dt.Rows[0].ItemArray[1].ToString();
				arg_text = dt.Rows[0].ItemArray[2].ToString();
			}
			else
			{
				arg_capt = dt.Rows[0].ItemArray[3].ToString();
				arg_text = dt.Rows[0].ItemArray[4].ToString();
			}

			string arg_buttons_code =dt.Rows[0].ItemArray[5].ToString();
			string arg_icons_code   = dt.Rows[0].ItemArray[6].ToString();

			try
			{
				string ctlname = "stbar";
				FieldInfo info = arg_Form.GetType().GetField(ctlname,BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
				StatusBar ctl = (System.Windows.Forms.StatusBar) info.GetValue(arg_Form);
				ctl.Panels.Clear();
				ctl.Panels[0].Width = (int)Math.Round((arg_Form.Width * 0.7),0);
				ctl.Panels[0].Text = arg_text;
				ctl.Panels[1].Width = (int)Math.Round((arg_Form.Width * 0.3),0);
			}
			catch
			{}

			DialogResult result = MessageBox.Show(arg_object +  arg_text, arg_capt, Buttons(arg_buttons_code), Icons(arg_icons_code));
			return result;
		}


		/// <summary>
		/// Buttons : 메시지 박스 버튼 정의
		/// </summary>
		/// <param name="arg_type"></param>
		/// <returns></returns>
		public static MessageBoxButtons Buttons(string  arg_type)
		{
			if(arg_type == "0")
				return MessageBoxButtons.OK;
			else if(arg_type == "1")
				return MessageBoxButtons.OKCancel;
			else if(arg_type == "2")
				return MessageBoxButtons.AbortRetryIgnore;
			else if(arg_type == "3")
				return MessageBoxButtons.YesNoCancel;
			else if(arg_type == "4")
				return MessageBoxButtons.YesNo;
			else
				return MessageBoxButtons.RetryCancel;
		}

		/// <summary>
		/// Icons : 메시지 박스 아이콘 정의
		/// </summary>
		/// <param name="arg_type"></param>
		/// <returns></returns>
		public static MessageBoxIcon Icons(string  arg_type)
		{
			if(arg_type == "0")
				return MessageBoxIcon.None;
			else if(arg_type == "1")
				return MessageBoxIcon.Information;
			else if(arg_type == "2")
				return MessageBoxIcon.Error;
			else if(arg_type == "3")
				return MessageBoxIcon.Warning;
			else if(arg_type == "4")
				return MessageBoxIcon.Question;
			else if(arg_type == "5")
				return MessageBoxIcon.Hand;
			else if(arg_type == "6")
				return MessageBoxIcon.Stop;
			else if(arg_type == "7")
				return MessageBoxIcon.Asterisk;
			else
				return MessageBoxIcon.Exclamation;

		}



		/// <summary>
		/// Status Bar 메시지
		/// </summary>
		/// <param name="arg_code">메시지 코드</param>
		/// <param name="arg_Form">폼 이름</param>
		public static void Status_Bar_Message(string arg_code, System.Windows.Forms.Form arg_Form)
		{
			DataTable dt = Select_SPC_Message(arg_code);

			string arg_capt;
			string arg_text;


			if(ComVar.This_Lang == "KO")
			{
				arg_capt = dt.Rows[0].ItemArray[1].ToString();
				arg_text = dt.Rows[0].ItemArray[2].ToString();
			}
			else
			{
				arg_capt = dt.Rows[0].ItemArray[3].ToString();
				arg_text = dt.Rows[0].ItemArray[4].ToString();
			}


			string yy = DateTime.Now.Year.ToString();
			string mm = DateTime.Now.Month.ToString();
			string dd = DateTime.Now.Day.ToString();

			string HH = DateTime.Now.Hour.ToString();
			string MM = DateTime.Now.Minute.ToString();

			arg_text = HH + "H "+ MM +"M  " + arg_text;

			try
			{
				string ctlname = "stbar";
				FieldInfo info = arg_Form.GetType().GetField(ctlname,BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
				StatusBar ctl = (System.Windows.Forms.StatusBar) info.GetValue(arg_Form);
				//ctl.Panels.Clear();
				//ctl.Panels.Add(arg_text);
				//ctl.Panels[0].Width = arg_Form.Width;
				ctl.Panels[0].Width = (int)Math.Round((arg_Form.Width * 0.7),0);
				ctl.Panels[0].Text = arg_text;
				ctl.Panels[1].Width = (int)Math.Round((arg_Form.Width * 0.3),0);
			}
			catch
			{}
		}


		/// <summary>
		/// Status Bar 메시지
		/// </summary>
		/// <param name="arg_code">메시지 내용</param>
		/// <param name="arg_Form">폼 이름</param>
		public static void Status_Bar_Message_User(string arg_text, System.Windows.Forms.Form arg_Form)
		{
			string yy = DateTime.Now.Year.ToString();
			string mm = DateTime.Now.Month.ToString();
			string dd = DateTime.Now.Day.ToString();

			string HH = DateTime.Now.Hour.ToString();
			string MM = DateTime.Now.Minute.ToString();

			arg_text = HH + "H "+ MM +"M  " + arg_text;

			try
			{
				string ctlname = "stbar";
				FieldInfo info = arg_Form.GetType().GetField(ctlname,BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
				StatusBar ctl = (System.Windows.Forms.StatusBar) info.GetValue(arg_Form);
				//ctl.Panels.Clear();
				//ctl.Panels.Add(arg_text);
				//ctl.Panels[0].Width = arg_Form.Width;
				ctl.Panels[0].Width = (int)Math.Round((arg_Form.Width * 0.7),0);
				ctl.Panels[0].Text = arg_text;
				ctl.Panels[1].Width = (int)Math.Round((arg_Form.Width * 0.3),0);
			}
			catch
			{}
		}

        public static void Status_Bar_Message_Text(string arg_text, System.Windows.Forms.Form arg_Form)
        {            
            try
            {
                string ctlname = "stbar";
                FieldInfo info = arg_Form.GetType().GetField(ctlname, BindingFlags.GetField | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                StatusBar ctl = (System.Windows.Forms.StatusBar)info.GetValue(arg_Form);                
                ctl.Panels[0].Width = (int)Math.Round((arg_Form.Width * 0.7), 0);
                ctl.Panels[0].Text = arg_text;
                ctl.Panels[1].Width = (int)Math.Round((arg_Form.Width * 0.3), 0);
            }
            catch
            { }
        }

		/// <summary>
		/// Select_SPC_Message : 저장된 메시지를 가져온다.
		/// </summary>
		/// <param name="arg_value">코드</param>
		/// <returns>정상:DataTable, 오류:null</returns>
		public static DataTable Select_SPC_Message(string arg_code)
		{
			COM.OraDB oraDB = new COM.OraDB();
			string Proc_Name = "PKG_SPC_MESSAGE.SELECT_SPC_MESSAGE";

			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_DIVISION";
			oraDB.Parameter_Name[1] = "ARG_VALUE";
			oraDB.Parameter_Name[2] = "OUT_CURSOR";

			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = "C";
			oraDB.Parameter_Values[1] = arg_code;
			oraDB.Parameter_Values[2] = "";

			oraDB.Add_Select_Parameter(true);
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			return  DS_Ret.Tables[Proc_Name];
		}

		#endregion

		#region Factory 조회

		/// <summary>
		/// Select_Factory_List : Factory 조회
		/// </summary>
		/// <returns></returns>
		public static DataTable Select_Factory_List()
		{ 
			COM.OraDB MyOraDB = new COM.OraDB(); 
			DataSet ds_ret;
			
			try
			{
				string process_name = "PKG_SCM_FACTORY.SELECT_FACTORY_LIST";

				MyOraDB.ReDim_Parameter(1);  
				MyOraDB.Process_Name = process_name;
   
				MyOraDB.Parameter_Name[0] = "OUT_CURSOR"; 
				MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor; 
				MyOraDB.Parameter_Values[0] = ""; 

				MyOraDB.Add_Select_Parameter(true); 
				ds_ret = MyOraDB.Exe_Select_Procedure();

				if(ds_ret == null) return null ; 
				return ds_ret.Tables[process_name]; 
			}
			catch
			{
				return null;
			}


		}



        /// <summary>
        /// Select_Factory_List : Factory 조회
        /// </summary>
        /// <returns></returns>
        public static DataTable Select_Factory_List_CDC()
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "PKG_SCM_FACTORY.SELECT_FACTORY_LIST_CDC";

                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "";

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


		
		/// <summary>
		///  Set_Factory_List : DataTable의 내용을 콤보리스트에 추가
		/// </summary>
		/// <param name="dtcmb_list">콤보 박스에 추가될 리스트</param>
		/// <param name="arg_cmb">적용 대상 콤보 박스명</param>
		/// <param name="arg_cd_ix">코드로 사용될 필드 인덱스</param>
		/// <param name="arg_name_ix">코드명으로 사용될 필드 인덱스</param>
		/// <param name="arg_emptyrow">상단에 공백 넣을지 여부</param> 
		/// <param name="arg_visible">보여줄 컬럼 선택</param>
		public static void Set_Factory_List(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix, bool arg_emptyrow, COM.ComVar.ComboList_Visible arg_visible)
		{ 

			DataTable temp_datatable= new DataTable("Combo List"); 
			DataRow newrow; 
  
 
			try 
			{
    
				temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
				temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
 
				if(arg_emptyrow)
				{
					newrow = temp_datatable.NewRow();
					newrow["Code"] = " ";
					newrow["Name"] = "ALL";
					temp_datatable.Rows.Add(newrow);
				}

				for(int i = 0 ; i < dtcmb_list.Rows.Count; i++)
				{

					newrow = temp_datatable.NewRow();
					newrow["Code"] = dtcmb_list.Rows[i].ItemArray[arg_cd_ix];
					newrow["Name"] = dtcmb_list.Rows[i].ItemArray[arg_name_ix];
					temp_datatable.Rows.Add(newrow);  
 
				}  
 

				arg_cmb.DataSource = null; 
				arg_cmb.DataSource = temp_datatable;
   
				arg_cmb.ValueMember = "Code";
				arg_cmb.DisplayMember = "Name"; 

				arg_cmb.SelectedIndex = -1;
				arg_cmb.MaxDropDownItems = 10;
				arg_cmb.Splits[0].DisplayColumns["Code"].Width = 50;
				arg_cmb.Splits[0].DisplayColumns["Name"].Width = 150;
				arg_cmb.ExtendRightColumn = true; 
				arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;
 
				switch(arg_visible)
				{
					case COM.ComVar.ComboList_Visible.Code:
						arg_cmb.Splits[0].DisplayColumns["Name"].Visible = false;
						arg_cmb.DisplayMember = "Code";
						break;

					case COM.ComVar.ComboList_Visible.Name:
						arg_cmb.Splits[0].DisplayColumns["Code"].Visible = false;
						break;

						//case COM.ComVar.ComboList_Visible.Code_Name:
						//break;
				}

				if (COM.ComVar.This_Factory !="DS") 
				{ arg_cmb.ReadOnly = true; arg_cmb.Enabled = false;}

			}
			catch
			{
				//MessageBox.Show(ex.Message.ToString(),"Set_ComboList",MessageBoxButtons.OK,MessageBoxIcon.Error );
			}


 
		}

  


		#endregion

		#region 날짜 셋팅

		/// <summary>
		/// Get_Values
		/// </summary>
		/// <param name="arg_form">적용 폼</param>
		/// <param name="arg_datetype">date type 표시</param>
		/// <param name="arg_ctlname1">컨트롤 이름1</param>
		/// <param name="arg_ctlname2">컨트롤 이름2</param>
		/// <param name="arg_ctlname3">컨트롤 이름3</param>
		public static void Get_Values(System.Windows.Forms.Form arg_form, string arg_ctlname1, string arg_ctlname2, string arg_ctlname3)
		{
			string[] ctl = new string[3];
			ctl[0] = arg_ctlname1;
			ctl[1] = arg_ctlname2;
			ctl[2] = arg_ctlname3;


			string[] txt = new string[3];
			txt[0] = ComVar.This_Date;
			txt[1] = ComVar.This_FormDate;
			txt[2] = ComVar.This_ToDate;

			for(int i=0; i<ctl.Length; i++)
			{
				if(ctl[i] != "")
				{
					FieldInfo info = arg_form.GetType().GetField(ctl[i],BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
					Control cotrol = (Control) info.GetValue(arg_form);
					
					ComFunction cfunc = new ComFunction();
					cotrol.Text = cfunc.ConvertDate2Type(txt[i]);
				}
			}
		}



		public static void Set_Values(System.Windows.Forms.Form arg_form, string arg_ctlname1, string arg_ctlname2, string arg_ctlname3)
		{
			string[] ctl = new string[3];
			ctl[0] = arg_ctlname1;
			ctl[1] = arg_ctlname2;
			ctl[2] = arg_ctlname3;


			for(int i=0; i<ctl.Length; i++)
			{
				if(ctl[i] != "")
				{
					FieldInfo info = arg_form.GetType().GetField(ctl[i],BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
					Control cotrol = (Control) info.GetValue(arg_form);
					
					ComFunction cfunc = new ComFunction();

					if(i==0)
					{
						ComVar.This_Date = cfunc.ConvertDate2DbType(cotrol.Text);
					}
					else if(i==1)
					{
						ComVar.This_FormDate = cfunc.ConvertDate2DbType(cotrol.Text);
					}
					else if(i==2)
					{
						ComVar.This_ToDate = cfunc.ConvertDate2DbType(cotrol.Text);
					}
				}
			}
		}



		/// <summary>
		/// Get_Values
		/// </summary>
		/// <param name="arg_form">적용 폼</param>
		/// <param name="arg_datetype">date type 표시</param>
		/// <param name="arg_ctlname2">컨트롤 이름2</param>
		/// <param name="arg_ctlname3">컨트롤 이름3</param>
		public static void Get_Values(System.Windows.Forms.Form arg_form, string arg_ctlname2, string arg_ctlname3)
		{
			string[] ctl = new string[2];
			ctl[0] = arg_ctlname2;
			ctl[1] = arg_ctlname3;


			string[] txt = new string[2];
			txt[0] = ComVar.This_FormDate;
			txt[1] = ComVar.This_ToDate;

			for(int i=0; i<ctl.Length; i++)
			{
				if(ctl[i] != "")
				{
					FieldInfo info = arg_form.GetType().GetField(ctl[i],BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
					Control cotrol = (Control) info.GetValue(arg_form);

					ComFunction cfunc = new ComFunction();
					cotrol.Text = cfunc.ConvertDate2Type(txt[i]);
				}
			}
		}

		public static void Get_Values(System.Windows.Forms.Form arg_form, string arg_ctlname2)
		{
			if(arg_ctlname2 != "")
			{
				FieldInfo info = arg_form.GetType().GetField(arg_ctlname2,BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
				Control cotrol = (Control) info.GetValue(arg_form);

				ComFunction cfunc = new ComFunction();
				cotrol.Text = cfunc.ConvertDate2Type(ComVar.This_FormDate);
			}

		}


		public static void Set_Values(System.Windows.Forms.Form arg_form, string arg_ctlname2, string arg_ctlname3)
		{
			string[] ctl = new string[2];
			ctl[0] = arg_ctlname2;
			ctl[1] = arg_ctlname3;


			for(int i=0; i<ctl.Length; i++)
			{
				if(ctl[i] != "")
				{
					FieldInfo info = arg_form.GetType().GetField(ctl[i],BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
					Control cotrol = (Control) info.GetValue(arg_form);
					
					ComFunction cfunc = new ComFunction();

					if(i==0)
					{
						ComVar.This_FormDate = cfunc.ConvertDate2DbType(cotrol.Text);
					}
					else if(i==1)
					{
						ComVar.This_ToDate = cfunc.ConvertDate2DbType(cotrol.Text);
					}
				}
			}
		}


		public static void Set_Values(System.Windows.Forms.Form arg_form, string arg_ctlname2)
		{
			if(arg_ctlname2 != "")
			{
				FieldInfo info = arg_form.GetType().GetField(arg_ctlname2,BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
				Control cotrol = (Control) info.GetValue(arg_form);
				
				ComFunction cfunc = new ComFunction();
				ComVar.This_FormDate = cfunc.ConvertDate2DbType(cotrol.Text);
			}
		}





		#endregion

		#region 그리드 글자 크기

		/// <summary>
		/// Set_Grid_Font_Size : 
		/// </summary>
		/// <param name="arg_fgrid"></param>
		/// <param name="arg_font_size"></param>
		public static void Set_Grid_Font_Size(C1FlexGrid arg_fgrid, float arg_font_size)
		{
			arg_fgrid.Font = new System.Drawing.Font("Verdana", arg_font_size);
		}

		#endregion

		#region 자동 업무 알림(plase do it)


		public void Common_WorkInfo()
		{
			Com_Form.Pop_PS_NoticeWrite notice = new COM.Com_Form.Pop_PS_NoticeWrite();
			notice.ShowDialog();
		}


		public static void AutoWorkInfo(string arg_event_id)
		{
			DataTable dt = Select_Work_Info(arg_event_id);

			string event_id = dt.Rows[0].ItemArray[0].ToString();
			string title    = dt.Rows[0].ItemArray[1].ToString();
			string contents = dt.Rows[0].ItemArray[2].ToString();
			string job_cd   = dt.Rows[0].ItemArray[3].ToString();
			string email_yn = dt.Rows[0].ItemArray[4].ToString();
			string use_yn   = dt.Rows[0].ItemArray[5].ToString();
			string open_yn  = dt.Rows[0].ItemArray[6].ToString();


			if(use_yn == "Y")
			{
				if(open_yn == "Y")
				{
					Com_Form.Pop_Work_Info workinfo = new COM.Com_Form.Pop_Work_Info(arg_event_id);
					workinfo.ShowDialog();

					if(!ComVar.event_use) 
					{
						dt = Select_Work_Info(arg_event_id);

						title    = dt.Rows[0].ItemArray[1].ToString();
						contents = dt.Rows[0].ItemArray[2].ToString();
					}
				}


				if(!ComVar.event_use)
				{
					DataTable dt_user = Select_Work_Info_User(arg_event_id);

					int dt_user_row = dt_user.Rows.Count;
					int dt_user_col = dt_user.Columns.Count;

					for(int i=0; i<dt_user_row; i++)
					{
						string[] arrayitem = new string[6];
						arrayitem[0] = ComVar.This_Factory;
						arrayitem[1] = dt_user.Rows[i].ItemArray[0].ToString();
						arrayitem[2] = title;
						arrayitem[3] = contents;
						arrayitem[4] = job_cd;
						arrayitem[5] = ComVar.This_User;

						Save_Work_Info_User(arrayitem);
					}
				}
			}


			ComVar.event_use = true;
		}


		public static void AutoWorkInfo(string arg_event_id, bool arg_new_check)
		{
			DataTable dt = Select_Work_Info(arg_event_id);

			if(dt.Rows.Count == 0) return;

			string event_id = dt.Rows[0].ItemArray[0].ToString();
			string title    = dt.Rows[0].ItemArray[1].ToString();
			string contents = dt.Rows[0].ItemArray[2].ToString();
			string job_cd   = dt.Rows[0].ItemArray[3].ToString();
			string email_yn = dt.Rows[0].ItemArray[4].ToString();
			string use_yn   = dt.Rows[0].ItemArray[5].ToString();
			string open_yn  = dt.Rows[0].ItemArray[6].ToString();


			if(use_yn == "Y")
			{
				if(open_yn == "Y")
				{
					Com_Form.Pop_Work_Info workinfo = new COM.Com_Form.Pop_Work_Info(arg_event_id, arg_new_check);
					workinfo.ShowDialog();

					
					if(!ComVar.event_use)
					{
						dt = Select_Work_Info(arg_event_id);

						title    = dt.Rows[0].ItemArray[1].ToString();
						contents = dt.Rows[0].ItemArray[2].ToString();
					}
				}


				if(!ComVar.event_use)
				{
					DataTable dt_user = Select_Work_Info_User(arg_event_id);

					int dt_user_row = dt_user.Rows.Count;
					int dt_user_col = dt_user.Columns.Count;

					for(int i=0; i<dt_user_row; i++)
					{
						string[] arrayitem = new string[6];
						arrayitem[0] = ComVar.This_Factory;
						arrayitem[1] = dt_user.Rows[i].ItemArray[0].ToString();
						arrayitem[2] = title;
						arrayitem[3] = contents;
						arrayitem[4] = job_cd;
						arrayitem[5] = ComVar.This_User;

						Save_Work_Info_User(arrayitem);
					}
				}
			}

			ComVar.event_use = true;
		}

		public static DataTable Select_Work_Info(string arg_event_id)
		{
			COM.OraDB oraDB = new COM.OraDB();
			string Proc_Name = "PKG_SPS_HOME.SELECT_WORKINFO_SEND";

			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_EVENT_ID";
			oraDB.Parameter_Name[2] = "OUT_CURSOR";

			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = ComVar.This_Factory;
			oraDB.Parameter_Values[1] = arg_event_id;
			oraDB.Parameter_Values[2] = "";

			oraDB.Add_Select_Parameter(true);
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			return  DS_Ret.Tables[Proc_Name];
		}

		public static DataTable Select_Work_Info_User(string arg_event_id)
		{
			COM.OraDB oraDB = new COM.OraDB();
			string Proc_Name = "PKG_SPS_HOME.SELECT_WORKINFO_SEND_USER";

			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_EVENT_ID";
			oraDB.Parameter_Name[2] = "OUT_CURSOR";

			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = ComVar.This_Factory;
			oraDB.Parameter_Values[1] = arg_event_id;
			oraDB.Parameter_Values[2] = "";

			oraDB.Add_Select_Parameter(true);
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			return  DS_Ret.Tables[Proc_Name];
		}

		public static void Save_Work_Info_User(string[] arg_arrayitem)
		{
			COM.OraDB oraDB = new COM.OraDB();
			string Proc_Name = "PKG_SPS_HOME.SAVE_WORKINFO_RUSER";

			oraDB.ReDim_Parameter(arg_arrayitem.Length);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_USER_ID";
			oraDB.Parameter_Name[2] = "ARG_TITLE";
			oraDB.Parameter_Name[3] = "ARG_CONTENTS";
			oraDB.Parameter_Name[4] = "ARG_JOB_CD";
			oraDB.Parameter_Name[5] = "ARG_RUSER_ID";

			for(int i=0; i<arg_arrayitem.Length; i++)
			{
				oraDB.Parameter_Type[i] = (int)OracleType.VarChar;
			}

			for(int i=0; i<arg_arrayitem.Length; i++)
			{
				oraDB.Parameter_Values[i] = arg_arrayitem[i];
			}

			oraDB.Add_Modify_Parameter(true);
			oraDB.Exe_Modify_Procedure();
		}

		#endregion 

		#region Warehouse 조회 

		/// <summary>
		/// Select_Factory_List : Warehouse 조회	//추가
		/// </summary>
		/// <returns></returns>
		public static DataTable Select_Warehouse_List(string factory)
		{
 
			COM.OraDB MyOraDB = new COM.OraDB();

			DataSet ds_ret;
			if(factory.Length < 1)
				factory = "XX";
 
			MyOraDB.ReDim_Parameter(2); 

			//01.PROCEDURE명
			MyOraDB.Process_Name = "PKG_SBC_WAREHOUSE.SELECT_WAREHOUSE_LIST";
 
			//02.ARGURMENT명
			MyOraDB.Parameter_Name[0] = "ARG_FACTORY";
			MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

			//03.DATA TYPE
			MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
			 
			//04.DATA 정의  
			MyOraDB.Parameter_Values[0] = factory; 
			MyOraDB.Parameter_Values[1] = ""; 

			MyOraDB.Add_Select_Parameter(true);
 
			ds_ret = MyOraDB.Exe_Select_Procedure();

			if(ds_ret == null) return null ;
			
			return ds_ret.Tables[MyOraDB.Process_Name]; 
		}
		
		#endregion

 

		#endregion 

		#region 이전 행 데이터 필수 입력 체크

        /// <summary>
        /// Select_SPC_MENU_TBTN : 버튼 권한 가져오기
        /// </summary>
        /// <param name="arg_factory"></param>
        /// <param name="arg_lang_cd"></param>
        /// <param name="arg_user_id"></param>
        /// <param name="arg_menu_pg"></param>
        /// <returns></returns>
        public static DataTable Select_SPC_MENU_TBTN(string arg_factory, string arg_lang_cd, string arg_user_id, string arg_menu_pg)
        {

            COM.OraDB MyOraDB = new COM.OraDB();

            DataSet ds_ret;
            MyOraDB.ReDim_Parameter(5);



            //01.PROCEDURE명
            MyOraDB.Process_Name = "PKG_SPC_MENU.SELECT_SPC_MENU_TBTN";


            //02.ARGURMENT명
            MyOraDB.Parameter_Name[0] = "ARG_FACTORY";
            MyOraDB.Parameter_Name[1] = "ARG_LANG_CD";
            MyOraDB.Parameter_Name[2] = "ARG_USER_ID";
            MyOraDB.Parameter_Name[3] = "ARG_MENU_PG";
            MyOraDB.Parameter_Name[4] = "OUT_CURSOR";


            //03.DATA TYPE
            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;


            //04.DATA 정의  
            MyOraDB.Parameter_Values[0] = arg_factory;
            MyOraDB.Parameter_Values[1] = arg_lang_cd;
            MyOraDB.Parameter_Values[2] = arg_user_id;
            MyOraDB.Parameter_Values[3] = arg_menu_pg;
            MyOraDB.Parameter_Values[4] = "";


            MyOraDB.Add_Select_Parameter(true);

            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret == null) return null;

            return ds_ret.Tables[MyOraDB.Process_Name];



        }





        // <summary>
        /// Select_SPC_MENU_TBTN : 버튼 권한 가져오기
        /// </summary>
        /// <param name="arg_factory"></param>
        /// <param name="arg_lang_cd"></param>
        /// <param name="arg_user_id"></param>
        /// <param name="arg_menu_pg"></param>
        /// <returns></returns>
        public static DataTable Select_SPC_MENU_TBTN(string arg_factory,
            string arg_lang_cd,
            string arg_user_id,
            string arg_menu_pg,
            string arg_parent_menu_key)
        {

            COM.OraDB MyOraDB = new COM.OraDB();

            DataSet ds_ret;
            MyOraDB.ReDim_Parameter(6);



            //01.PROCEDURE명
            MyOraDB.Process_Name = "PKG_SPC_MENU.SELECT_SPC_MENU_TBTN_PARENT";


            //02.ARGURMENT명
            MyOraDB.Parameter_Name[0] = "ARG_FACTORY";
            MyOraDB.Parameter_Name[1] = "ARG_LANG_CD";
            MyOraDB.Parameter_Name[2] = "ARG_USER_ID";
            MyOraDB.Parameter_Name[3] = "ARG_MENU_PG";
            MyOraDB.Parameter_Name[4] = "ARG_PARENT_MENU_KEY";
            MyOraDB.Parameter_Name[5] = "OUT_CURSOR";


            //03.DATA TYPE
            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;


            //04.DATA 정의  
            MyOraDB.Parameter_Values[0] = arg_factory;
            MyOraDB.Parameter_Values[1] = arg_lang_cd;
            MyOraDB.Parameter_Values[2] = arg_user_id;
            MyOraDB.Parameter_Values[3] = arg_menu_pg;
            MyOraDB.Parameter_Values[4] = arg_parent_menu_key;
            MyOraDB.Parameter_Values[5] = "";


            MyOraDB.Add_Select_Parameter(true);

            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret == null) return null;

            return ds_ret.Tables[MyOraDB.Process_Name];


        }

		/// <summary>
		/// Check_Essential_Col : 이전 행 데이터 필수 입력 체크
		/// </summary>
		/// <param name="arg_grid"></param>
		/// <returns>true : 필수 처리 완료, false : 필수 처리 미 완료</returns>
		

		/// <summary>
		/// Check_Essential_Col : Select Row 데이터 필수 입력 체크
		/// </summary>
		/// <param name="arg_grid"></param>
		/// <param name="arg_row"></param>
		/// <returns>true : 필수 처리 완료, false : 필수 처리 미 완료</returns>
		public static bool Check_Essential_Col(COM.SSP arg_grid, int arg_row)
		{
			int count = 0; 
			int header_row = arg_grid.ActiveSheet.ColumnHeader.Rows.Count - 1;
			string first_item = "";
 
			for(int i = 0; i < arg_grid.ActiveSheet.ColumnCount; i++)
			{
				if(arg_grid.arr_essential[i] != "TRUE") continue;
				 
				if(arg_grid.ActiveSheet.Cells[arg_row, i].Value == null
					|| arg_grid.ActiveSheet.Cells[arg_row, i].Value.ToString().Trim() == "" )
				{
					if(first_item.Equals("") ) 
					{
						first_item = arg_grid.ActiveSheet.ColumnHeader.Cells[header_row, i].Text; 
					}

					count++;
				}  
			} // end for i

			if(count > 0) // 필수 처리 미 완료
			{
				User_Message("Essential Input - " + first_item);
				return false;
			}
			else // 필수 처리 완료
			{
				return true;
			} 

		}


		#endregion 

		#region Tree Grid Header Row DataTable Setting

		 

		/// <summary>
		/// Set_TreeHeader_DT : 
		/// </summary>
		/// <param name="arg_fgrid"></param>
		/// <param name="arg_dt"></param>
		public static void Set_TreeHeader(COM.FSP arg_grid)
		{ 
			try
			{
				//첫번째 행 헤더 정보 : 실제 디비 필드명
                //두번째 행 정보 : 그리드 타이틀  

				string now_name = "";

				arg_grid.Rows[0].TextAlign = TextAlignEnum.CenterCenter;

				for(int i = 0; i < arg_grid.Cols.Count; i++)
				{
					arg_grid[0, i] = (arg_grid[0, i] == null) ? "" : arg_grid[0, i].ToString();
					arg_grid[1, i] = (arg_grid[1, i] == null) ? "" : arg_grid[1, i].ToString();

					now_name = arg_grid[0, i].ToString();

					//첫번째 행에 두번째 행 정보 저장 (그리드 타이틀)
					arg_grid[0, i] = arg_grid[1, i].ToString();
					//두번째 행에 첫번째 행 정보 저장 (디비 필드 명)
					arg_grid[1, i] = now_name;

					now_name = ""; 
				} 
				
				
				arg_grid.Rows[0].Visible = true;
				arg_grid.Rows[1].Visible = false;  

			}
			catch(Exception ex)
			{
				User_Message(ex.Message, "Set_TreeHeader", MessageBoxButtons.OK, MessageBoxIcon.Error);
			} 


		}
 


		#endregion 
        
		#region 즐겨찾기 추가
		
		/// <summary>
		/// Save_SPC_MENU_BOOKMARK : 즐겨찾기 추가
		/// </summary>
		/// <param name="arg_factory"></param>
		/// <param name="arg_lang_cd"></param>
		/// <param name="arg_upd_user"></param>
		/// <param name="arg_menu_pg"></param>
		public static void Save_SPC_MENU_BOOKMARK(string arg_factory, 
										   string arg_lang_cd, 
										   string arg_upd_user, 
										   string arg_menu_pg)
		{
			
			bool save_flag = Save_SPC_MENU_BOOKMARK_DB(arg_factory, arg_lang_cd, arg_upd_user, arg_menu_pg);

			if(!save_flag)
			{
				COM.ComFunction.User_Message("Can not add bookmark", "Add Bookmark", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				COM.ComFunction.User_Message("Complete add bookmark", "Add Bookmark", MessageBoxButtons.OK, MessageBoxIcon.None);
			}
		}




		/// <summary>
		/// Save_SPC_MENU_BOOLMARK_DB : 
		/// </summary>
		/// <returns></returns>
		/// <param name="arg_factory"></param>
		/// <param name="arg_lang_cd"></param>
		/// <param name="arg_upd_user"></param>
		/// <param name="arg_menu_pg"></param>
		public static bool Save_SPC_MENU_BOOKMARK_DB(string arg_factory, 
			                                  string arg_lang_cd, 
			                                  string arg_upd_user, 
			                                  string arg_menu_pg)
		{
			try
			{
			 
				OraDB MyOraDB = new OraDB();

				int col_ct = 4;  
  
				 
				MyOraDB.ReDim_Parameter(col_ct);
				MyOraDB.Process_Name = "PKG_SPC_MENU.SAVE_SPC_MENU_BOOKMARK";
 

				MyOraDB.Parameter_Name[0] = "ARG_FACTORY";  
				MyOraDB.Parameter_Name[1] = "ARG_LANG_CD";
				MyOraDB.Parameter_Name[2] = "ARG_UPD_USER";
				MyOraDB.Parameter_Name[3] = "ARG_MENU_PG";
  
  

				for(int i = 0; i < col_ct ; i++) MyOraDB.Parameter_Type[i] = (int)OracleType.VarChar;  

				  
				MyOraDB.Parameter_Values[0] = arg_factory;
				MyOraDB.Parameter_Values[1] = arg_lang_cd;
				MyOraDB.Parameter_Values[2] = arg_upd_user;
				MyOraDB.Parameter_Values[3] = arg_menu_pg;
 

				MyOraDB.Add_Modify_Parameter(true);  
				DataSet ds_ret = MyOraDB.Exe_Modify_Procedure();

				if(ds_ret == null)  // error
				{ 
					return false;
				}
				else
				{ 
					return true;
				}

			}
			catch(Exception ex)
			{
				COM.ComFunction.User_Message(ex.Message, "Save_SPC_MENU_BOOLMARK_DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

		}


		#endregion 

		#region [Window] menuitem 삭제

		/// <summary>
		/// Delete_Window_Menu : 
		/// </summary>
		/// <param name="arg_menupg"></param> 
		public static void Delete_Window_Menu(System.Windows.Forms.Form arg_parent_form, string arg_menupg)
		{


            string window_text = "WINDOW";

            COM.MyItem parent_Menuitem = null;


            if (arg_parent_form == null) return;


            // parent menuitem 찾기
            foreach (MenuItem item in arg_parent_form.Menu.MenuItems)
            {
                COM.MyItem myitem = (COM.MyItem)item;

                //if(myitem._RoleID == role_id)
                //{
                //    parent_Menuitem = myitem;

                //    break;

                //}


                if (myitem._MenuText.ToUpper().Trim() == window_text.ToUpper().Trim())
                {
                    parent_Menuitem = myitem;

                    break;

                }


            } // end foreach




            // 닫혀진 창에 대한 menuitem 삭제 처리
            foreach (COM.MyItem child_item in parent_Menuitem.MenuItems)
            {
                if (child_item._MenuPG == arg_menupg)
                {
                    parent_Menuitem.MenuItems.Remove(child_item);

                    break;
                }

            }



            ////			// 삭제 된 후 다음 활성화된 창에 대한 menuitem 체크 처리
            //
            ////			string active_menupg = arg_parent_form.ActiveMdiChild.GetType().ToString();
            ////
            ////			foreach(COM.MyItem child_item in parent_Menuitem.MenuItems)
            ////			{
            ////				if(child_item._MenuPG == active_menupg)
            ////				{
            ////					child_item.Checked = true;  
            ////				} 
            ////				else
            ////				{
            ////					child_item.Checked = false; 
            ////				}
            ////
            ////			}


            //			foreach(COM.MyItem child_item in parent_Menuitem.MenuItems)
            //			{
            //				child_item.Checked = false;  
            //			} 
            //
            //
            //			if(parent_Menuitem.MenuItems.Count == 0) return;
            //			parent_Menuitem.MenuItems[parent_Menuitem.MenuItems.Count - 1].Checked = true;
            // 


		}


		#endregion

		#region 툴바 버튼 권한 설정

 

        /// <summary>
        /// SELECT_SCM_MENU_USER_TBTN : 버튼 권한 가져오기
        /// </summary>
        /// <param name="arg_factory"></param>
        /// <param name="arg_lang_cd"></param>
        /// <param name="arg_user_id"></param>
        /// <param name="arg_menu_pg"></param>
        /// <returns></returns>
        public static DataTable SELECT_SCM_MENU_USER_TBTN(string arg_factory, 
            string arg_user_id,
            string arg_lang_cd, 
            string arg_menu_pg)
        {

            COM.OraDB MyOraDB = new COM.OraDB();

            DataSet ds_ret;
            MyOraDB.ReDim_Parameter(5);



            //01.PROCEDURE명
            MyOraDB.Process_Name = "PKG_SCM_MENU.SELECT_SCM_MENU_USER_BUTTON";


            //02.ARGURMENT명
            MyOraDB.Parameter_Name[0] = "ARG_FACTORY";
            MyOraDB.Parameter_Name[1] = "ARG_USER_ID";
            MyOraDB.Parameter_Name[2] = "ARG_LANG_CD";
            MyOraDB.Parameter_Name[3] = "ARG_MENU_PG";
            MyOraDB.Parameter_Name[4] = "OUT_CURSOR";


            //03.DATA TYPE
            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;


            //04.DATA 정의  
            MyOraDB.Parameter_Values[0] = arg_factory;
            MyOraDB.Parameter_Values[1] = arg_user_id;
            MyOraDB.Parameter_Values[2] = arg_lang_cd;
            MyOraDB.Parameter_Values[3] = arg_menu_pg;
            MyOraDB.Parameter_Values[4] = "";


            MyOraDB.Add_Select_Parameter(true);

            ds_ret = MyOraDB.Exe_Select_Procedure();

            if (ds_ret == null) return null;

            return ds_ret.Tables[MyOraDB.Process_Name];



        }




		#endregion

		#region 통신 관련


		#region define MyOraDB

		OraDB MyOraDB = new OraDB();


		#endregion

		#region Set Grid Column
		  

		public void Make_CmbDataList(C1FlexGrid arg_grid, ComVar.ComboList_Type arg_div, DataTable arg_dt, int arg_col) 
		{ 
			int sel_code = 0;
			int sel_name = 0;

			try
			{
				switch(arg_div)
				{
					case ComVar.ComboList_Type.ComCode :   //공통코드에서

						sel_code = (int)TBSCM_CODE.IxCOM_VALUE1;

						break; 
					
					case ComVar.ComboList_Type.Query  :   //쿼리문장에서

						if(arg_dt.Columns.Count > 1)
						{
							sel_name = 1;
						}
						else
						{
							sel_name = 0;
						}

						sel_code = 0;

						break; 
		
					case ComVar.ComboList_Type.ComCode_Name : //공통코드에서 코드 : 코드명 

						sel_code = (int)TBSCM_CODE.IxCOM_VALUE1;
						sel_name = (int)TBSCM_CODE.IxCOM_DESC1;

						break;

				}


				System.Collections.Specialized.ListDictionary ld = new System.Collections.Specialized.ListDictionary(); 

				switch(arg_div)
				{
					case ComVar.ComboList_Type.ComCode :   
						
						for(int i = 0; i < arg_dt.Rows.Count; i++)
						{
							ld.Add(arg_dt.Rows[i].ItemArray[sel_code].ToString(), arg_dt.Rows[i].ItemArray[sel_code].ToString());
						} 
			  
						break;

					case ComVar.ComboList_Type.Query  :   //쿼리문장에서
 
						if (sel_name.Equals(0))
						{
							for(int i = 0; i < arg_dt.Rows.Count; i++)
							{
								//"code" or "code : desc" 형태일때
								string[] token = arg_dt.Rows[i].ItemArray[sel_code].ToString().Split(':');

								if(token.Length == 1)
								{
									ld.Add(token[0], token[0]);
								}
								else
								{
									ld.Add(token[0].Trim(), token[1].Trim());
								}

							}
						}
						else
						{ 
							for(int i = 0; i < arg_dt.Rows.Count; i++)
							{
								ld.Add(arg_dt.Rows[i].ItemArray[sel_code].ToString(), arg_dt.Rows[i].ItemArray[sel_name].ToString());
							}
						}

						break;

					case ComVar.ComboList_Type.ComCode_Name :  
						 
						for(int i = 0; i < arg_dt.Rows.Count; i++)
						{
							ld.Add(arg_dt.Rows[i].ItemArray[sel_code].ToString(), arg_dt.Rows[i].ItemArray[sel_name].ToString());
						}

						break;

				}

				
				arg_grid.Cols[arg_col].DataMap = ld;   
  
			}

			catch (Exception ex)
			{
				MessageBox.Show( ex.Message.ToString(),"Make_CmbDataList",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}



		/// <summary>
		/// Make_Query : string으로 받은 쿼리문장에서 @값 추출해서 실제 값 적용 -> 쿼리 실행해서 DataTable 로 반환
		/// </summary>
		/// <param name="arg_query">받은 쿼리문장</param>
		/// <returns>DataTable</returns>
		public DataTable Make_Query(string arg_query)
		{
			DataSet DS_Ret ;

			int index = 0; 

			string strDelimiter = " ";
			char[] delimiter = strDelimiter.ToCharArray();
 
			try
			{
				string[] tokenArray = arg_query.Split(delimiter); 
				string[] query_data = new string[tokenArray.Length]; 

				string real_query = "";
				DataTable return_dt;

				//--------------------------------------------------------------------------------
				//1. 공백으로 먼저 자르기
				//-------------------------------------------------------------------------------- 

				foreach( string token in tokenArray )
				{
					if ( !token.Equals("") || !token.Equals(null) ) 
					{
						query_data[index] = token;
						index++;
					} 
				}


				//--------------------------------------------------------------------------------
				//2. @ 들어있는 query_data 추출
				//-------------------------------------------------------------------------------- 

				for(int i = 0; i < query_data.Length; i++)
				{
					if(query_data[i] == null || query_data[i] == "") continue;

					if("@" == query_data[i].Substring(0, 1))
					{
						query_data[i] = Change_RealValue(query_data[i]);
					}
				}


				//--------------------------------------------------------------------------------
				//3. 실 데이터 값 넣어서 쿼리 만들기 -> 실행
				//-------------------------------------------------------------------------------- 

				for(int i = 0; i < query_data.Length; i++)
				{
					if(query_data[i] == null || query_data[i] == "") continue;

					real_query = real_query + query_data[i] + " ";
				}


				DS_Ret = MyOraDB.Exe_Select_Query(real_query);
				if(DS_Ret == null) return null;

				return return_dt = DS_Ret.Tables[0];
			}
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message.ToString(),"Make_Query",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return null;
			}

		}



		/// <summary>
		/// Change_RealValue : 구분자 들어있는 데이터를 실 데이터 값으로 치환
		/// </summary>
		/// <param name="arg_data">@포함 문자열</param>
		/// <returns></returns>
		public string Change_RealValue(string arg_data)
		{
			string return_value = "";

			switch(arg_data)
			{
				case "@factory":

					return_value = "'" + ComVar.This_Factory + "'";

					break;
 
			}

			return return_value;
		}


		
		#endregion

		#region Set Grid

 
		/// <summary>
		/// Set_Grid : 그리드 설정
		/// </summary>
		/// <param name="arg_pgid">적용시킬 프로그램 아이디</param>
		/// <param name="arg_pgseq">적용시킬 프로그램 순번</param>
		/// <param name="arg_hcount">그리드 헤더 수</param>
		/// <param name="arg_autosize">자동 컬럼 너비 맞추기 여부</param>
		public void Set_Grid(C1FlexGrid arg_grid, string arg_pgid, string arg_pgseq, int arg_hcount, bool arg_autosize)
		{
			
			DataTable dt_list, dt_cmblist; 
			CellStyle cellst; 

			//신규 스타일 생성시 임의로 일련번호 추가해서 생성
			int cellst_count = 0;


			try
			{
				////// DB에서 그리드 정보 추출 
				dt_list = MyOraDB.Select_GridHead(arg_pgid,arg_pgseq);
				if (dt_list== null) return ;
	
				if(dt_list.Rows.Count > 0)
				{
					arg_grid.Clear(C1.Win.C1FlexGrid.ClearFlags.All); 
					arg_grid.Cols.Count = dt_list.Rows.Count + 1; 
					arg_grid.Rows.Count = arg_hcount + 1;
					arg_grid.Rows.Fixed = arg_hcount + 1;
					arg_grid.Rows[0].Visible = false;
					arg_grid.Cols[0].AllowEditing = false;
					arg_grid.Cols[0].Width = 20;
				 

					
					
					#region 헤더 정렬

					arg_grid.Rows[1].TextAlign = TextAlignEnum.CenterCenter;

					if (arg_hcount==2)		// 2번째 Header
					{
						arg_grid.Rows[2].TextAlign = TextAlignEnum.CenterCenter;
					}

					if (arg_hcount==3)		// 3번째 Header
					{
						arg_grid.Rows[2].TextAlign = TextAlignEnum.CenterCenter;
						arg_grid.Rows[3].TextAlign = TextAlignEnum.CenterCenter;
					}

					if (arg_hcount==4)		// 4번째 Header
					{
						arg_grid.Rows[2].TextAlign = TextAlignEnum.CenterCenter;
						arg_grid.Rows[3].TextAlign = TextAlignEnum.CenterCenter;
						arg_grid.Rows[4].TextAlign = TextAlignEnum.CenterCenter;
					}

					#endregion 

					#region 속성 지정

					//--------------------------------------------------
					//전체 속성 지정
					arg_grid.Cols.Frozen = Convert.ToInt32(dt_list.Rows[0].ItemArray[(int)TBSCM_TABLE.IxFROZENCOL].ToString());	// 칼럼 Frozen
					arg_grid.Rows.Frozen = Convert.ToInt32(dt_list.Rows[0].ItemArray[(int)TBSCM_TABLE.IxFROZENROW].ToString());	// 행 Frozen
				
					//-------------------------------------------------
					//Column 속성 설정 
					//alingment cellstyle
					//1. left
					cellst = arg_grid.Styles.Add("LEFT");
					cellst.TextAlign = TextAlignEnum.LeftCenter; 
					cellst.ImageAlign = ImageAlignEnum.LeftCenter; 

					//2. center
					cellst = arg_grid.Styles.Add("CENTER");
					cellst.TextAlign = TextAlignEnum.CenterCenter; 
					cellst.ImageAlign = ImageAlignEnum.CenterCenter; 

					//3. rigth
					cellst = arg_grid.Styles.Add("RIGHT");
					cellst.TextAlign = TextAlignEnum.RightCenter; 
					cellst.ImageAlign = ImageAlignEnum.RightCenter; 


					#endregion

					
					for(int i = 1; i < dt_list.Rows.Count + 1; i++)
					{



						#region 정렬

						switch(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHALIGN].ToString())									// 칼럼정렬
						{
							case "LEFT":  
								arg_grid.Cols[i].Style = arg_grid.Styles["LEFT"]; 
								break;

							case "CENTER": 
								arg_grid.Cols[i].Style = arg_grid.Styles["CENTER"]; 
								break;

							case "RIGHT": 
								arg_grid.Cols[i].Style = arg_grid.Styles["RIGHT"]; 
								break; 
						} 
					  
						#endregion 


						arg_grid.Cols[i].Width = Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxWIDTH].ToString());
						 

						if(Convert.ToBoolean(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxLOCK_YN]) )
						{
							arg_grid.Cols[i].AllowEditing = true; 
						}
						else
						{
							arg_grid.Cols[i].AllowEditing = false;
						}

						arg_grid.Cols[i].Visible = Convert.ToBoolean(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxVISIBLE_YN]);			// 칼럼 visible 
						arg_grid.Cols[i].AllowSorting = Convert.ToBoolean(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxAUTOSORT_YN]);	// 칼럼 별자동 sort

						//헤더 데이터
						arg_grid[0, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxCOL_NAME].ToString();					// 테이블 칼럼명
 

						
						#region cell type
 
						//스타일로 지정되어 정렬되어진 컬럼에 대해서
						//사용자 정의 스타일 동시에 적용시키려 할때
						//이전 스타일 제거되고 신규 스타일만 적용되므로
						//신규 스타일 추가시 이전 스타일 상속받아서 생성

						//신규 스타일로 적용했을때 신규 스타일 이름이 같은 경우
						//기존 정렬이 신규 스타일에 따라서 일괄적으로 변경되기 때문에
						//신규 스타일 생성시 임의로 일련번호 추가해서 생성

						switch(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxCELLTYPE].ToString())				// Cell Type
						{
							case "TEXT":
  
								//기존 컬럼 스타일 상속받아서 새로운 스타일 생성, 임의로 일련번호 추가
								cellst = arg_grid.Styles.Add("TEXT" + cellst_count.ToString(), arg_grid.Cols[i].Style);

								//새로운 스타일의 속성
								cellst.DataType = typeof(string);

								arg_grid.Cols[i].Style = arg_grid.Styles["TEXT" + cellst_count.ToString()]; 
								 
								break;

							case "DATE": 

								cellst = arg_grid.Styles.Add("DATE" + cellst_count.ToString(), arg_grid.Cols[i].Style);
								cellst.DataType = typeof(DateTime);
								cellst.Format = "yyyyMMdd";

								arg_grid.Cols[i].Style = arg_grid.Styles["DATE" + cellst_count.ToString()]; 
 
								break;

							case "CHECKBOX":
								
								cellst = arg_grid.Styles.Add("CHECKBOX" + cellst_count.ToString(), arg_grid.Cols[i].Style);
								cellst.DataType = typeof(bool); 

								arg_grid.Cols[i].Style = arg_grid.Styles["CHECKBOX" + cellst_count.ToString()]; 

								break;

							case "COMBOBOX":
								
								cellst = arg_grid.Styles.Add("COMBO_" + cellst_count.ToString(), arg_grid.Cols[i].Style);
								cellst.DataType = typeof(string);

								arg_grid.Cols[i].Style = arg_grid.Styles["COMBO_" + cellst_count.ToString()]; 
 
								
							switch(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_TYPE].ToString()))	// data_list_type
							{
								case (int)ComVar.ComboList_Type.ComCode :      //공통코드에서 ComboList 추출
											
									if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_CD].ToString() != "")					// Data_LIst_Cd
									{
										//combo_list
										dt_cmblist = MyOraDB.Select_ComCode(ComVar.This_Factory, dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_CD].ToString());
										if(dt_cmblist.Rows.Count != 0) Make_CmbDataList(arg_grid, ComVar.ComboList_Type.ComCode, dt_cmblist, i);
									}

									break;

								case (int)ComVar.ComboList_Type.Query :      //쿼리에서 ComboList 추출	
											
									if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_QUERY].ToString() != "")				//Data_List_Query
									{
												 
										dt_cmblist = Make_Query(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_QUERY].ToString().Trim());
										if(dt_cmblist.Rows.Count != 0) Make_CmbDataList(arg_grid, ComVar.ComboList_Type.Query, dt_cmblist, i);
									}

									break;

								case (int)ComVar.ComboList_Type.ComCode_Name :
											
									if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_CD].ToString() != "")					// Data_LIst_Cd
									{
												 
										dt_cmblist = MyOraDB.Select_ComCode(ComVar.This_Factory, dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_CD].ToString());
										if(dt_cmblist.Rows.Count != 0) Make_CmbDataList(arg_grid, ComVar.ComboList_Type.ComCode_Name, dt_cmblist, i);
									}

									break;

							} 
 
								break;


							case "NUMBER":
								
								cellst = arg_grid.Styles.Add("NUMBER" + cellst_count.ToString(), arg_grid.Cols[i].Style);
								cellst.DataType = typeof(double);
								cellst.Format = "#,##0.##########"; 

								arg_grid.Cols[i].Style = arg_grid.Styles["NUMBER" + cellst_count.ToString()]; 

								break;

 
						} //end switch


						cellst_count++;
					  
						#endregion 

						#region 언어
 
						arg_grid[1, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC1].ToString();					// 상단

						if(arg_hcount == 2)	
						{
							arg_grid[2, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC2].ToString();				// 하단
						}

						if(arg_hcount == 3)	
						{
							arg_grid[2, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC2].ToString();	
							arg_grid[3, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC3].ToString();				// 하단
						}

						if(arg_hcount == 4)	
						{
							arg_grid[2, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC2].ToString();	
							arg_grid[3, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC3].ToString();
							arg_grid[4, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC4].ToString();				// 하단
						}
 
					
						#endregion 

						#region 타이틀 색깔 설정

						//등록된 Title Header에 backcolor,forecolor 설정
						if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxBACKCOLOR].ToString() != "")							// 배경색
						{
							arg_grid.GetCellRange(1, i).StyleNew.BackColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxBACKCOLOR].ToString()));

							if(arg_hcount == 2)
							{
								arg_grid.GetCellRange(2, i).StyleNew.BackColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxBACKCOLOR].ToString()));
							}

							if(arg_hcount == 3)
							{
								arg_grid.GetCellRange(2, i, 3, i).StyleNew.BackColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxBACKCOLOR].ToString()));
							}

							if(arg_hcount == 4)
							{
								arg_grid.GetCellRange(2, i, 4, i).StyleNew.BackColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxBACKCOLOR].ToString()));
							}

						}

						if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxFORECOLOR].ToString() != "")							// 글자색
						{
							arg_grid.GetCellRange(1, i).StyleNew.ForeColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxFORECOLOR].ToString()));

							if(arg_hcount == 2)
							{
								arg_grid.GetCellRange(2, i).StyleNew.ForeColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxFORECOLOR].ToString()));
							}

							if(arg_hcount == 3)
							{
								arg_grid.GetCellRange(2, i, 3, i).StyleNew.ForeColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxFORECOLOR].ToString()));
							}

							if(arg_hcount == 4)
							{
								arg_grid.GetCellRange(2, i, 4, i).StyleNew.ForeColor = Color.FromArgb(Convert.ToInt32(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxFORECOLOR].ToString()));
							}

						 

						}


						#endregion


					} //end for


					if(arg_autosize)
					{
						arg_grid.AutoSizeCols();
					} 
				
					arg_grid.ExtendLastCol = true;		// 그리드 끝에 빈공간없이 last column에 맞춤 
					arg_grid.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
					arg_grid.SelectionMode = SelectionModeEnum.ListBox;
					
					arg_grid.Font = new Font(arg_grid.Font.Name, 8);
 
					arg_grid.AllowMerging = AllowMergingEnum.FixedOnly;

					for(int i = 0; i < arg_grid.Cols.Count; i++)
					{
						arg_grid.Cols[i].AllowMerging = true;
					}

					for(int i = 0; i < arg_grid.Rows.Fixed; i++)
					{
						arg_grid.Rows[i].AllowMerging = true;
					}



				}
				else 
				{	// 그리드 정보 없음을 상태 바에 출력

				}//end if

			
			}	
			catch (Exception ex)
			{
				MessageBox.Show( ex.Message.ToString(),"Set_Grid",MessageBoxButtons.OK,MessageBoxIcon.Error);
				
			}
		}	


 

		
		#endregion 
	
		#region Set Combolist


		/// <summary>
		/// Set_ComboList : DataTable의 내용을 콤보리스트에 추가
		/// </summary>
		/// <param name="dtcmb_list">콤보 박스에 추가될 리스트</param>
		/// <param name="arg_cmb">적용 대상 콤보 박스명</param>
		/// <param name="arg_cd_ix">코드로 사용될 필드 인덱스</param>
		/// <param name="arg_name_ix">코드명으로 사용될 필드 인덱스</param>
		/// <param name="arg_emptyrow">상단에 공백 넣을지 여부</param> 
		/// <param name="arg_visible">보여줄 컬럼 선택</param>
		public static void Set_ComboList(DataTable dtcmb_list, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_ix, int arg_name_ix, bool arg_emptyrow, COM.ComVar.ComboList_Visible arg_visible)
		{ 

			DataTable temp_datatable= new DataTable("Combo List"); 
			DataRow newrow; 
  
 
			try 
			{
				
				temp_datatable.Columns.Add(new DataColumn("Code", Type.GetType("System.String")));
				temp_datatable.Columns.Add(new DataColumn("Name", Type.GetType("System.String")));
 
				if(arg_emptyrow)
				{
					newrow = temp_datatable.NewRow();
					newrow["Code"] = " ";
					newrow["Name"] = "ALL";
					temp_datatable.Rows.Add(newrow);
				}

				for(int i = 0 ; i < dtcmb_list.Rows.Count; i++)
				{

					newrow = temp_datatable.NewRow();
					newrow["Code"] = dtcmb_list.Rows[i].ItemArray[arg_cd_ix];
					newrow["Name"] = dtcmb_list.Rows[i].ItemArray[arg_name_ix];
					temp_datatable.Rows.Add(newrow);  
 
				}  
 

				arg_cmb.DataSource = null; 
				arg_cmb.DataSource = temp_datatable;
			
				arg_cmb.ValueMember = "Code";
				arg_cmb.DisplayMember = "Name"; 

				arg_cmb.SelectedIndex = -1;
				arg_cmb.MaxDropDownItems = 10;
				arg_cmb.Splits[0].DisplayColumns["Code"].Width = 50;
				arg_cmb.Splits[0].DisplayColumns["Name"].Width = 150;
				arg_cmb.ExtendRightColumn = true; 
				arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;
 
				switch(arg_visible)
				{
					case COM.ComVar.ComboList_Visible.Code:
						arg_cmb.Splits[0].DisplayColumns["Name"].Visible = false;
						arg_cmb.DisplayMember = "Code";
						break;

					case COM.ComVar.ComboList_Visible.Name:
						arg_cmb.Splits[0].DisplayColumns["Code"].Visible = false;
						break;

						//case COM.ComVar.ComboList_Visible.Code_Name:
						//break;
				}

 
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Set_ComboList",MessageBoxButtons.OK,MessageBoxIcon.Error );
			}

 
		}


		/// <summary>
		/// Set_ComboList_AddItem : 콤보박스 수정 (AddItem) 위해서 AddItem으로 리스트 한건씩 추가
		/// </summary>
		/// <param name="arg_dt">콤보 박스에 추가될 리스트</param>
		/// <param name="arg_cmb">적용 대상 콤보 박스명</param>
		/// <param name="arg_cd_pos">코드로 사용될 필드 인덱스</param>
		/// <param name="arg_name_pos">코드명으로 사용될 필드 인덱스</param>
		public static void Set_ComboList_AddItem(DataTable arg_dt, C1.Win.C1List.C1Combo arg_cmb, int arg_cd_pos, int arg_name_pos, bool arg_emptyrow)
		{
			int i; 
			
			try
			{
				arg_cmb.DataMode = C1.Win.C1List.DataModeEnum.AddItem; 
				arg_cmb.ClearItems(); 

				arg_cmb.AddItemTitles("Code;Name"); 
			
				arg_cmb.ValueMember = "Code";
				arg_cmb.DisplayMember = "Name"; 

				if(arg_emptyrow)
				{
					arg_cmb.AddItem("" + ";" + "ALL");
				}
 

				for(i = 0; i < arg_dt.Rows.Count; i++) 
				{ 
					arg_cmb.AddItem(arg_dt.Rows[i].ItemArray[arg_cd_pos].ToString() + ";" + arg_dt.Rows[i].ItemArray[arg_name_pos].ToString());
				}  
		

				arg_cmb.SelectedIndex = -1;  

				arg_cmb.MaxDropDownItems = 10;
				arg_cmb.Splits[0].DisplayColumns[0].Width = 50;
				arg_cmb.Splits[0].DisplayColumns[1].Width = 150;

				arg_cmb.ExtendRightColumn = true; 
				arg_cmb.CellTips = C1.Win.C1List.CellTipEnum.Anchored;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString(),"Set_ComboList_AddItem",MessageBoxButtons.OK,MessageBoxIcon.Error );
			}


		}



		#endregion




		#endregion
        */


	}




}
