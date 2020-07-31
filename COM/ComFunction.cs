using System;
using System.Data;
using System.Data.OracleClient;



namespace COM
{
	/// <summary>
	/// ComFunction : :�����Լ� Ŭ����
	/// </summary>
	public class ComFunction
	{
		public ComFunction()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
		}

		#region Webservice URL ����


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
		#region ���� �޼ҵ�

		#region ����� ���� �޼ҵ�

		


		#endregion

		#region ConvertDate

		/// <summary>
		/// ConvertDate : �����ͺ��̽� �Է� ����(yyyyMMdd)�� ��¥���� ���� date���Ŀ� ����
		/// </summary>
		/// <param name="arg_yyyyMMdd">arg_date : DB�� ��¥����(yyyyMMdd�� ����) </param>
		/// <returns>date�������� ����� ��</returns>
		public  string ConvertDate2Type(string arg_yyyyMMdd)
		{
			try
			{
				string sdatetype = ComVar.This_SetedDateType;			//������ ��¥ ����
				string sdatesign = ComVar.This_SetedDateSign ;			//��ȣ����

				int firstsign = sdatetype.IndexOf(sdatesign);			// ù ��° ��ȣ �ڸ���
				int secondsign = sdatetype.LastIndexOf(sdatesign);		// �ι�° ��ȣ �ڸ� ��

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
		/// ConvertDate2DbType : ���������� ��¥�� DB ������������ ����
		/// </summary>
		/// <param name="arg_Date">���������� ��¥</param>
		/// <returns>DB ������ ��¥</returns>
		public string ConvertDate2DbType(string arg_Date)
		{
			return ConvertDate(arg_Date,ComVar.This_SetedDateSign,ComVar.This_SetedDateType,"",ComVar.This_SetedDBType);
		}


		/// <summary>
		/// ConvertDate : ��¥���İ� DataBase��������(yyyyMMdd) �Ǵ� �������İ� ��ȣ ��ȯ
		/// </summary>
		/// <param name="arg_Date">�Է³��� </param>
		/// <param name="arg_inSign">�Է� ���ڱ�����</param>
		/// <param name="arg_inType">�Ϸ� ��������</param>
		/// <param name="arg_outSign">��� ���ڱ�����</param>
		/// <param name="arg_outType">��� ��������</param>
		/// <returns>����� ��</returns>
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

				indate = y + m + d ;   // yyyyMMdd (����ȭ)

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
		/// GetDatevalue : date type ���ǿ� �´� ��¥ ���� �޼ҵ� 
		/// </summary>
		/// <param name="arg_datetyep">��¥ ����</param>
		/// <param name="arg_date"> DB�� ��¥����(yyyyMMdd�� ����)</param>
		/// <returns>��¥ ���Ŀ� �´� ��Ȯ�� , ���н� :null</returns>
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

		#region ��� ó�� �޼ҵ�

		/// <summary>
		/// SetLangDic : �� ���� �������� ����
		/// </summary>
		/// <param name="arg_Form">���̸�</param>
		/// <param name="arg_pg_id">���α׷� id</param>
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


			////// DB���� ������ ȣ�� 
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
					if(ctlname == "Form")		// Form Head Title ó��
					{
						arg_Form.Text    =     ctltext;
					}
					else						
					{	
						// Control Text ó��
						info = arg_Form.GetType().GetField(ctlname, BindingFlags.GetField |BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
						ctl = (Control) info.GetValue(arg_Form);
						ctl.Text = ctltext;


						// ��Ÿ ó��??????
					}
				}
				catch//(Exception ex)
				{
					//MessageBox.Show(ctlname + " : " + ctltext);
				}
			}







			try
			{
				//StateBar�� ������ ǥ��
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

		#region ���� ó�� �Լ��� 


		/// <summary>
		/// Combo ���õ� �׸��� ���°�� ���ϰ�
		/// </summary>
		/// <param name="sCombo">�ش� ComboList</param>
		/// <param name="sReturn">�����϶� ���ϰ�</param>
		/// <returns>���ϰ�</returns>
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
		/// Combo ���õ� �׸��� null�� ��� ���ϰ�
		/// </summary>
		/// <param name="sCombo">�ش� ComboList</param>
		/// <param name="sReturn">�����϶� ���ϰ�</param>
		/// <returns>���ϰ�</returns>

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
		/// TextBox�� �����϶� ��ȯ ��
		/// </summary>
		/// <param name="arg_Txt">�ش� TextBox</param>
		/// <param name="arg_Ret">�����϶� ���ϰ�</param>
		/// <returns>���ϰ�</returns>
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
		/// ���ڿ��� �����̸� ��ȯ ��
		/// </summary>
		/// <param name="arg_Str">�ش� ���ڿ� ����</param>
		/// <param name="arg_Ret">�����϶� ���ϰ�</param>
		/// <returns>���ϰ�</returns>
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
		/// ���ڰ��� �����̸� ��ȯ ��
		/// </summary>
		/// <param name="arg_Num">�ش� ���ں���</param>
		/// <param name="arg_Ret">�����϶� ���ϰ�</param>
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
		
		#region Value Check (���ڸ� ���, �Ǽ� üũ, ���� üũ..)


		/// <summary>
		/// TextBox�� ���ڸ� ����
		/// </summary>
		/// <param name="arg_Text">��� TextBox</param>
		/// <param name="arg_limit">���� ��� �ڸ���</param>
		public static void Set_NumberTextBox(TextBox arg_Text,int arg_limit)
		{
			
			if (arg_Text.Text.Trim() == "")			//�����̸� 0
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
		/// TextBox�� ���ڸ� ����, ������ �Ǵ� �Ǽ��� ����
		/// </summary>
		/// <param name="arg_Text">��� TextBox</param>
		/// <param name="arg_limit">���� ��� �ڸ���</param>
		public static bool Set_NumberTextBox(TextBox arg_Text,int arg_limit, string arg_type)
		{
			 
			if (arg_Text.Text.Trim() == "")			//�����̸� 0
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
		/// Check_Decimal : �Ǽ��� ���� Check
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
		/// Check_Decimal : ������ ���� Check
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

		#region �����ڵ� �˸�

		/// <summary>
		/// AutoWorkMessage : �ڵ� ���� �˸�
		/// </summary>
		/// <param name="arg_pg_id">���� ���α׷�</param>
		/// <param name="arg_seq">�̺�Ʈ ���� ��ȣ</param>
		/// <param name="arg_subject">������ �޽��� ����</param>
		public void AutoWorkMessage(string arg_pg_id, string arg_seq, string arg_subject)
		{
			string User_ID   = "system";                 //����� ���̵�('system' ���� ����)
			string User_mail = "";//"haidin@hanmail.net";     //����� �� �ּ�
			
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

			//���ǿ� �´� �̺�Ʈ �� ���� ��������

			try
			{


				//COM.Com_Form.Form_PS_NoticeAuto psNoticeAuto = new COM.Com_Form.Form_PS_NoticeAuto(arg_pg_id,arg_seq);
				//psNoticeAuto.ShowDialog();



				DataTable dt = Get_Auto_Message(ComVar.This_Factory, User_ID, arg_pg_id, arg_seq);

				string title   = dt.Rows[0].ItemArray[_Title].ToString();          //Ÿ��Ʋ
				string message_head = dt.Rows[0].ItemArray[_Body_head].ToString(); //��� �޽���
				string message_tail = dt.Rows[0].ItemArray[_Body_tail].ToString(); //�ϴ� �޽���

				StringBuilder stringBuilder = new StringBuilder();				   //������ ���޵� �޽��� ��ü
				stringBuilder.Append(message_head);
				stringBuilder.Append("\r\n\r\n");
				stringBuilder.Append(arg_subject);
				stringBuilder.Append("\r\n\r\n");
				stringBuilder.Append(message_tail);


				string mail_yn = dt.Rows[0].ItemArray[_Mail_yn].ToString();       //���� ��� ����


				string Ruser_id = dt.Rows[0].ItemArray[_Ruser_id].ToString();     //����� ����Ʈ
				string Ruser_div  = ",";                                          //����� ������
				string[] Receiver = Ruser_id.Split(Ruser_div.ToCharArray());

				for(int i=0; i<Receiver.Length; i++)
				{
					string Receive_id   = Receiver[i];                                           //����� ���̵�
					string Receive_name	= Get_Name(Receiver[i]).Rows[0].ItemArray[1].ToString(); //����� �̸�
					string Receive_mail = Get_Name(Receiver[i]).Rows[0].ItemArray[3].ToString(); //����� ���� �ּ�

					//SPS_NOTICE_USER DB�� ����
					Send_Auto_Message("", "I",  "A", User_ID , User_ID, Receive_id , Receive_name, title, stringBuilder.ToString());
				
					//���� ýũ('Y' ���� ����)
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
		/// Get_Auto_Message : ���� �ڵ� �˸� �� ���� ��������
		/// </summary>
		/// <param name="arg_factory">����</param>
		/// <param name="arg_user_id">����� ���̵�(����)</param>
		/// <param name="arg_pg_id">���� ���α׷�</param>
		/// <param name="arg_seq">�̺�Ʈ ���� ��ȣ</param>
		/// <returns>����:DdataTable ,����:null</returns>
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
		/// Send_Auto_Message : �޽���(���� ���� �˸�) ������
		/// </summary>
		/// <param name="arg_division">Save Code</param>
		/// <param name="arg_div">S/R</param>
		/// <param name="arg_suser_name">������ �̸�</param>
		/// <param name="arg_ruser_id">�޴��� ���̵�</param>
		/// <param name="arg_ruser_name">�޴��� �̸�</param>
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
		/// Get_Name : ����� �̸�,���� �ּ� �������� ��������
		/// </summary>
		/// <param name="arg_user_id">����� ���̵�</param>
		/// <returns>����:DataTable ,����:null</returns>
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

		#region �޽��� �ڽ�

		/// <summary>
		/// User_Message : �޽��� �ڽ� ȣ��(����� ���� �Է�I)
		/// </summary>
		/// <param name="arg_text">�޽��� �ڽ� ����</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text)
		{
			DialogResult result = MessageBox.Show(arg_text);
			return result;
		}

		/// <summary>
		/// User_Message : �޽��� �ڽ� ȣ��(����� ���� �Է�II)
		/// </summary>
		/// <param name="arg_text">�޽��� �ڽ� ����</param>
		/// <param name="arg_caption">�޽��� �ڽ� ����</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text, string arg_caption)
		{
			DialogResult result = MessageBox.Show(arg_text, arg_caption);
			return result;
		}
		
		/// <summary>
		/// User_Message : �޽��� �ڽ� ȣ��(����� ���� �Է�III)
		/// </summary>
		/// <param name="arg_text">�޽��� �ڽ� ����</param>
		/// <param name="arg_caption">�޽��� �ڽ� ����</param>
		/// <param name="arg_buttons">��� ��ư</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text, string arg_caption, MessageBoxButtons arg_buttons)
		{
			DialogResult result = MessageBox.Show(arg_text, arg_caption, arg_buttons);
			return result;
		}

		/// <summary>
		/// User_Message : �޽��� �ڽ� ȣ��(����� ���� �Է�IV)
		/// </summary>
		/// <param name="arg_text">�޽��� �ڽ� ����</param>
		/// <param name="arg_caption">�޽��� �ڽ� ����</param>
		/// <param name="arg_buttons">��� ��ư</param>
		/// <param name="aeg_icon">��� ������</param>
		/// <returns>DialogResult</returns>
		public static DialogResult User_Message(string arg_text, string arg_caption, MessageBoxButtons arg_buttons, MessageBoxIcon aeg_icon)		
		{
			DialogResult result = MessageBox.Show(arg_text, arg_caption, arg_buttons, aeg_icon);
			return result;
		}

		/// <summary>
		/// Data_Message : �޽��� �ڽ� ȣ��, ���� �� ���� ��(DataBase I)
		/// </summary>
		/// <param name="arg_code">�ڵ�</param>
		/// <param name="arg_cation">�޽��� �ڽ� ����</param>
		/// <returns>DialogResult</returns>
		public static DialogResult Data_Message(string arg_code)
		{
			//�޽��� ������ �ڵ�� ����
			DataTable dt = Select_SPC_Message(arg_code);

			//�޽��� ����
			string arg_capt;
			//�޽��� ����
			string arg_text;


			//��� üũ
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

			//�޽��� ��ư ����
			string arg_buttons_code = dt.Rows[0].ItemArray[5].ToString();
			//�޽��� ������ ����
			string arg_icons_code   = dt.Rows[0].ItemArray[6].ToString();

			//�޽��� Show
			DialogResult result = MessageBox.Show( arg_text, arg_capt, Buttons(arg_buttons_code), Icons(arg_icons_code) );
			return result;
		}


		/// <summary>
		/// Data_Message : �޽��� �ڽ� ȣ��, ���� �� ���� ��(DataBase II)
		/// </summary>
		/// <param name="arg_object">��ü</param>
		/// <param name="arg_code">�ڵ�</param>
		/// <param name="arg_cation">�޽��� �ڽ� ����</param>
		/// <returns>DialogResult</returns>
		public static DialogResult Data_Message( string arg_object, string arg_code )
		{

			
			if(arg_object != "")
				arg_object = arg_object + " : ";

			//�޽��� ������ �ڵ�� ����
			DataTable dt = Select_SPC_Message(arg_code);

			//�޽��� ����
			string arg_capt;
			//�޽��� ����
			string arg_text;


			//��� üũ
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

			//�޽��� ��ư ����
			string arg_buttons_code = dt.Rows[0].ItemArray[5].ToString();
			//�޽��� ������ ����
			string arg_icons_code   = dt.Rows[0].ItemArray[6].ToString();

			//�޽��� Show
			DialogResult result = MessageBox.Show(arg_object + arg_text, arg_capt, Buttons(arg_buttons_code), Icons(arg_icons_code) );
			return result;
		}

		/// <summary>
		/// Data_Message : �޽��� �ڽ� ȣ��, ���� �� �ִ� ��(DataBase III)
		/// </summary>
		/// <param name="arg_object">��ü</param>
		/// <param name="arg_code">�ڵ�</param>
		/// <param name="arg_cation">�޽��� �ڽ� ����</param>
		/// <param name="arg_Form">state bar�� �ִ� ��</param>
		/// <returns></returns>
		public static DialogResult Data_Message( string arg_code, System.Windows.Forms.Form arg_Form )
		{

			//�޽��� ������ �ڵ�� ����
			DataTable dt = Select_SPC_Message(arg_code);

			//�޽��� ����
			string arg_capt;
			//�޽��� ����
			string arg_text;


			//��� üũ
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

			//�޽��� ��ư ����
			string arg_buttons_code = dt.Rows[0].ItemArray[5].ToString();
			//�޽��� ������ ����
			string arg_icons_code   = dt.Rows[0].ItemArray[6].ToString();

			try
			{
				//StateBar�� ������ ǥ��
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

			//�޽��� Show
			DialogResult result = MessageBox.Show( arg_text, arg_capt, Buttons(arg_buttons_code), Icons(arg_icons_code) );
			return result;
		}

		/// <summary>
		/// Data_Message : �޽��� �ڽ� ȣ��, ���� �� �ִ� ��(DataBase IV)
		/// </summary>
		/// <param name="arg_object">��ü</param>
		/// <param name="arg_code">�ڵ�</param>
		/// <param name="arg_cation">�޽��� �ڽ� ����</param>
		/// <param name="arg_Form">state bar�� �ִ� ��</param>
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
		/// Buttons : �޽��� �ڽ� ��ư ����
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
		/// Icons : �޽��� �ڽ� ������ ����
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
		/// Status Bar �޽���
		/// </summary>
		/// <param name="arg_code">�޽��� �ڵ�</param>
		/// <param name="arg_Form">�� �̸�</param>
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
		/// Status Bar �޽���
		/// </summary>
		/// <param name="arg_code">�޽��� ����</param>
		/// <param name="arg_Form">�� �̸�</param>
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
		/// Select_SPC_Message : ����� �޽����� �����´�.
		/// </summary>
		/// <param name="arg_value">�ڵ�</param>
		/// <returns>����:DataTable, ����:null</returns>
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

		#region Factory ��ȸ

		/// <summary>
		/// Select_Factory_List : Factory ��ȸ
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
        /// Select_Factory_List : Factory ��ȸ
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
		///  Set_Factory_List : DataTable�� ������ �޺�����Ʈ�� �߰�
		/// </summary>
		/// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
		/// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
		/// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
		/// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
		/// <param name="arg_emptyrow">��ܿ� ���� ������ ����</param> 
		/// <param name="arg_visible">������ �÷� ����</param>
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

		#region ��¥ ����

		/// <summary>
		/// Get_Values
		/// </summary>
		/// <param name="arg_form">���� ��</param>
		/// <param name="arg_datetype">date type ǥ��</param>
		/// <param name="arg_ctlname1">��Ʈ�� �̸�1</param>
		/// <param name="arg_ctlname2">��Ʈ�� �̸�2</param>
		/// <param name="arg_ctlname3">��Ʈ�� �̸�3</param>
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
		/// <param name="arg_form">���� ��</param>
		/// <param name="arg_datetype">date type ǥ��</param>
		/// <param name="arg_ctlname2">��Ʈ�� �̸�2</param>
		/// <param name="arg_ctlname3">��Ʈ�� �̸�3</param>
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

		#region �׸��� ���� ũ��

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

		#region �ڵ� ���� �˸�(plase do it)


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

		#region Warehouse ��ȸ 

		/// <summary>
		/// Select_Factory_List : Warehouse ��ȸ	//�߰�
		/// </summary>
		/// <returns></returns>
		public static DataTable Select_Warehouse_List(string factory)
		{
 
			COM.OraDB MyOraDB = new COM.OraDB();

			DataSet ds_ret;
			if(factory.Length < 1)
				factory = "XX";
 
			MyOraDB.ReDim_Parameter(2); 

			//01.PROCEDURE��
			MyOraDB.Process_Name = "PKG_SBC_WAREHOUSE.SELECT_WAREHOUSE_LIST";
 
			//02.ARGURMENT��
			MyOraDB.Parameter_Name[0] = "ARG_FACTORY";
			MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

			//03.DATA TYPE
			MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
			 
			//04.DATA ����  
			MyOraDB.Parameter_Values[0] = factory; 
			MyOraDB.Parameter_Values[1] = ""; 

			MyOraDB.Add_Select_Parameter(true);
 
			ds_ret = MyOraDB.Exe_Select_Procedure();

			if(ds_ret == null) return null ;
			
			return ds_ret.Tables[MyOraDB.Process_Name]; 
		}
		
		#endregion

 

		#endregion 

		#region ���� �� ������ �ʼ� �Է� üũ

        /// <summary>
        /// Select_SPC_MENU_TBTN : ��ư ���� ��������
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



            //01.PROCEDURE��
            MyOraDB.Process_Name = "PKG_SPC_MENU.SELECT_SPC_MENU_TBTN";


            //02.ARGURMENT��
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


            //04.DATA ����  
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
        /// Select_SPC_MENU_TBTN : ��ư ���� ��������
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



            //01.PROCEDURE��
            MyOraDB.Process_Name = "PKG_SPC_MENU.SELECT_SPC_MENU_TBTN_PARENT";


            //02.ARGURMENT��
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


            //04.DATA ����  
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
		/// Check_Essential_Col : ���� �� ������ �ʼ� �Է� üũ
		/// </summary>
		/// <param name="arg_grid"></param>
		/// <returns>true : �ʼ� ó�� �Ϸ�, false : �ʼ� ó�� �� �Ϸ�</returns>
		

		/// <summary>
		/// Check_Essential_Col : Select Row ������ �ʼ� �Է� üũ
		/// </summary>
		/// <param name="arg_grid"></param>
		/// <param name="arg_row"></param>
		/// <returns>true : �ʼ� ó�� �Ϸ�, false : �ʼ� ó�� �� �Ϸ�</returns>
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

			if(count > 0) // �ʼ� ó�� �� �Ϸ�
			{
				User_Message("Essential Input - " + first_item);
				return false;
			}
			else // �ʼ� ó�� �Ϸ�
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
				//ù��° �� ��� ���� : ���� ��� �ʵ��
                //�ι�° �� ���� : �׸��� Ÿ��Ʋ  

				string now_name = "";

				arg_grid.Rows[0].TextAlign = TextAlignEnum.CenterCenter;

				for(int i = 0; i < arg_grid.Cols.Count; i++)
				{
					arg_grid[0, i] = (arg_grid[0, i] == null) ? "" : arg_grid[0, i].ToString();
					arg_grid[1, i] = (arg_grid[1, i] == null) ? "" : arg_grid[1, i].ToString();

					now_name = arg_grid[0, i].ToString();

					//ù��° �࿡ �ι�° �� ���� ���� (�׸��� Ÿ��Ʋ)
					arg_grid[0, i] = arg_grid[1, i].ToString();
					//�ι�° �࿡ ù��° �� ���� ���� (��� �ʵ� ��)
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
        
		#region ���ã�� �߰�
		
		/// <summary>
		/// Save_SPC_MENU_BOOKMARK : ���ã�� �߰�
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

		#region [Window] menuitem ����

		/// <summary>
		/// Delete_Window_Menu : 
		/// </summary>
		/// <param name="arg_menupg"></param> 
		public static void Delete_Window_Menu(System.Windows.Forms.Form arg_parent_form, string arg_menupg)
		{


            string window_text = "WINDOW";

            COM.MyItem parent_Menuitem = null;


            if (arg_parent_form == null) return;


            // parent menuitem ã��
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




            // ������ â�� ���� menuitem ���� ó��
            foreach (COM.MyItem child_item in parent_Menuitem.MenuItems)
            {
                if (child_item._MenuPG == arg_menupg)
                {
                    parent_Menuitem.MenuItems.Remove(child_item);

                    break;
                }

            }



            ////			// ���� �� �� ���� Ȱ��ȭ�� â�� ���� menuitem üũ ó��
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

		#region ���� ��ư ���� ����

 

        /// <summary>
        /// SELECT_SCM_MENU_USER_TBTN : ��ư ���� ��������
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



            //01.PROCEDURE��
            MyOraDB.Process_Name = "PKG_SCM_MENU.SELECT_SCM_MENU_USER_BUTTON";


            //02.ARGURMENT��
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


            //04.DATA ����  
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

		#region ��� ����


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
					case ComVar.ComboList_Type.ComCode :   //�����ڵ忡��

						sel_code = (int)TBSCM_CODE.IxCOM_VALUE1;

						break; 
					
					case ComVar.ComboList_Type.Query  :   //�������忡��

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
		
					case ComVar.ComboList_Type.ComCode_Name : //�����ڵ忡�� �ڵ� : �ڵ�� 

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

					case ComVar.ComboList_Type.Query  :   //�������忡��
 
						if (sel_name.Equals(0))
						{
							for(int i = 0; i < arg_dt.Rows.Count; i++)
							{
								//"code" or "code : desc" �����϶�
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
		/// Make_Query : string���� ���� �������忡�� @�� �����ؼ� ���� �� ���� -> ���� �����ؼ� DataTable �� ��ȯ
		/// </summary>
		/// <param name="arg_query">���� ��������</param>
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
				//1. �������� ���� �ڸ���
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
				//2. @ ����ִ� query_data ����
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
				//3. �� ������ �� �־ ���� ����� -> ����
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
		/// Change_RealValue : ������ ����ִ� �����͸� �� ������ ������ ġȯ
		/// </summary>
		/// <param name="arg_data">@���� ���ڿ�</param>
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
		/// Set_Grid : �׸��� ����
		/// </summary>
		/// <param name="arg_pgid">�����ų ���α׷� ���̵�</param>
		/// <param name="arg_pgseq">�����ų ���α׷� ����</param>
		/// <param name="arg_hcount">�׸��� ��� ��</param>
		/// <param name="arg_autosize">�ڵ� �÷� �ʺ� ���߱� ����</param>
		public void Set_Grid(C1FlexGrid arg_grid, string arg_pgid, string arg_pgseq, int arg_hcount, bool arg_autosize)
		{
			
			DataTable dt_list, dt_cmblist; 
			CellStyle cellst; 

			//�ű� ��Ÿ�� ������ ���Ƿ� �Ϸù�ȣ �߰��ؼ� ����
			int cellst_count = 0;


			try
			{
				////// DB���� �׸��� ���� ���� 
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
				 

					
					
					#region ��� ����

					arg_grid.Rows[1].TextAlign = TextAlignEnum.CenterCenter;

					if (arg_hcount==2)		// 2��° Header
					{
						arg_grid.Rows[2].TextAlign = TextAlignEnum.CenterCenter;
					}

					if (arg_hcount==3)		// 3��° Header
					{
						arg_grid.Rows[2].TextAlign = TextAlignEnum.CenterCenter;
						arg_grid.Rows[3].TextAlign = TextAlignEnum.CenterCenter;
					}

					if (arg_hcount==4)		// 4��° Header
					{
						arg_grid.Rows[2].TextAlign = TextAlignEnum.CenterCenter;
						arg_grid.Rows[3].TextAlign = TextAlignEnum.CenterCenter;
						arg_grid.Rows[4].TextAlign = TextAlignEnum.CenterCenter;
					}

					#endregion 

					#region �Ӽ� ����

					//--------------------------------------------------
					//��ü �Ӽ� ����
					arg_grid.Cols.Frozen = Convert.ToInt32(dt_list.Rows[0].ItemArray[(int)TBSCM_TABLE.IxFROZENCOL].ToString());	// Į�� Frozen
					arg_grid.Rows.Frozen = Convert.ToInt32(dt_list.Rows[0].ItemArray[(int)TBSCM_TABLE.IxFROZENROW].ToString());	// �� Frozen
				
					//-------------------------------------------------
					//Column �Ӽ� ���� 
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



						#region ����

						switch(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHALIGN].ToString())									// Į������
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

						arg_grid.Cols[i].Visible = Convert.ToBoolean(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxVISIBLE_YN]);			// Į�� visible 
						arg_grid.Cols[i].AllowSorting = Convert.ToBoolean(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxAUTOSORT_YN]);	// Į�� ���ڵ� sort

						//��� ������
						arg_grid[0, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxCOL_NAME].ToString();					// ���̺� Į����
 

						
						#region cell type
 
						//��Ÿ�Ϸ� �����Ǿ� ���ĵǾ��� �÷��� ���ؼ�
						//����� ���� ��Ÿ�� ���ÿ� �����Ű�� �Ҷ�
						//���� ��Ÿ�� ���ŵǰ� �ű� ��Ÿ�ϸ� ����ǹǷ�
						//�ű� ��Ÿ�� �߰��� ���� ��Ÿ�� ��ӹ޾Ƽ� ����

						//�ű� ��Ÿ�Ϸ� ���������� �ű� ��Ÿ�� �̸��� ���� ���
						//���� ������ �ű� ��Ÿ�Ͽ� ���� �ϰ������� ����Ǳ� ������
						//�ű� ��Ÿ�� ������ ���Ƿ� �Ϸù�ȣ �߰��ؼ� ����

						switch(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxCELLTYPE].ToString())				// Cell Type
						{
							case "TEXT":
  
								//���� �÷� ��Ÿ�� ��ӹ޾Ƽ� ���ο� ��Ÿ�� ����, ���Ƿ� �Ϸù�ȣ �߰�
								cellst = arg_grid.Styles.Add("TEXT" + cellst_count.ToString(), arg_grid.Cols[i].Style);

								//���ο� ��Ÿ���� �Ӽ�
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
								case (int)ComVar.ComboList_Type.ComCode :      //�����ڵ忡�� ComboList ����
											
									if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_CD].ToString() != "")					// Data_LIst_Cd
									{
										//combo_list
										dt_cmblist = MyOraDB.Select_ComCode(ComVar.This_Factory, dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxDATA_LIST_CD].ToString());
										if(dt_cmblist.Rows.Count != 0) Make_CmbDataList(arg_grid, ComVar.ComboList_Type.ComCode, dt_cmblist, i);
									}

									break;

								case (int)ComVar.ComboList_Type.Query :      //�������� ComboList ����	
											
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

						#region ���
 
						arg_grid[1, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC1].ToString();					// ���

						if(arg_hcount == 2)	
						{
							arg_grid[2, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC2].ToString();				// �ϴ�
						}

						if(arg_hcount == 3)	
						{
							arg_grid[2, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC2].ToString();	
							arg_grid[3, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC3].ToString();				// �ϴ�
						}

						if(arg_hcount == 4)	
						{
							arg_grid[2, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC2].ToString();	
							arg_grid[3, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC3].ToString();
							arg_grid[4, i] = dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxHEAD_DESC4].ToString();				// �ϴ�
						}
 
					
						#endregion 

						#region Ÿ��Ʋ ���� ����

						//��ϵ� Title Header�� backcolor,forecolor ����
						if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxBACKCOLOR].ToString() != "")							// ����
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

						if(dt_list.Rows[i - 1].ItemArray[(int)TBSCM_TABLE.IxFORECOLOR].ToString() != "")							// ���ڻ�
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
				
					arg_grid.ExtendLastCol = true;		// �׸��� ���� ��������� last column�� ���� 
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
				{	// �׸��� ���� ������ ���� �ٿ� ���

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
		/// Set_ComboList : DataTable�� ������ �޺�����Ʈ�� �߰�
		/// </summary>
		/// <param name="dtcmb_list">�޺� �ڽ��� �߰��� ����Ʈ</param>
		/// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
		/// <param name="arg_cd_ix">�ڵ�� ���� �ʵ� �ε���</param>
		/// <param name="arg_name_ix">�ڵ������ ���� �ʵ� �ε���</param>
		/// <param name="arg_emptyrow">��ܿ� ���� ������ ����</param> 
		/// <param name="arg_visible">������ �÷� ����</param>
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
		/// Set_ComboList_AddItem : �޺��ڽ� ���� (AddItem) ���ؼ� AddItem���� ����Ʈ �ѰǾ� �߰�
		/// </summary>
		/// <param name="arg_dt">�޺� �ڽ��� �߰��� ����Ʈ</param>
		/// <param name="arg_cmb">���� ��� �޺� �ڽ���</param>
		/// <param name="arg_cd_pos">�ڵ�� ���� �ʵ� �ε���</param>
		/// <param name="arg_name_pos">�ڵ������ ���� �ʵ� �ε���</param>
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
