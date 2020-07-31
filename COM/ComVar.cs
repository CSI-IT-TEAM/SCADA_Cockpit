using System;
using System.Data;
using System.Data.OracleClient;


namespace COM
{
	/// <summary>
	/// ComVar :공통변수 클래스
	/// </summary>
	public class ComVar
	{
		public ComVar()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//


		}


        #region 로그인 정보

		
		//----- 로그인시 정보 ---------
		/// <summary>
		/// 접속 작업 공장
		/// </summary>
		public static string This_Factory = "VJ";


        /// <summary>
        /// 접속 작업 공장
        /// </summary>
        public static string This_CDC_Factory = "DS";
        
        
		/// <summary>
		/// 접속 User
		/// </summary>
		public static string This_User = "admin";

         

		public static string This_Domain = @"@dskorea.com";
		/// <summary>
		/// This_User_AD : User ID + Domain
		/// </summary>
		public static string This_User_AD = "";



		public static string This_PassWD = "";

        public static string This_Area_CD = "";

        public static string This_Gen = "";

		/// <summary>
		/// 접속 User Name
		/// </summary>
		public static string This_Name = "어드민";
		/// <summary>
		/// 접속 업무
		/// </summary>
		public static string This_SysJob="P" ;
		/// <summary>
		/// 접속 언어
		/// </summary> 
		public static string This_Lang = "KO";
		/// <summary>
		/// 관리자 여부
		/// </summary> 
		public static string This_Admin_YN ="Y";

		/// <summary>
		/// 접속 업무II
		/// </summary>
		public static string This_JobCdoe = "M";


		/// <summary>
		/// 접속자 부서II (임시)
		/// </summary>
		public static string This_Dept = "120600";



		public static string This_Form = "FlexPolicy.FrmMain";


		/// <summary>
		/// 업무 라인
		/// </summary>
		public static string This_Line = "";



		/// <summary>
		/// 오늘 날자
		/// </summary>
		public static string This_Date = "";



		/// <summary>
		/// 시작 날짜
		/// </summary>
		public static string This_FormDate = "20051017";




		/// <summary>
		/// 끝 날짜
		/// </summary>
		public static string This_ToDate = "";



		/// <summary>
		/// 기타 변수
		/// </summary>
		public static string This_Order = "";


        public static string This_PowerUser_YN = "";

        public static string This_InsaCd = "";

        public static string This_CDCPower_Level = "";
        public static string This_CDCGroup_Code = "";


        /// <summary>
        /// ConsCDC_ReturnMat
        /// </summary>
        public static string This_Return = "";


		/// <summary>
		///  메뉴얼 언어 선택
		/// </summary>
		public static string This_ManualLanuage = "";





		#endregion

        public enum Log_Type : int
        {
            Write_File_DB = 0,		// flie 저장 and DB저장
            Write_File = 1,			// flie 저장
            Write_DB = 2,			// DB저장
            Write_NOLog = 3			// log 저장 안함
        }

        #region 웹 서비스 참조 선언

        /// <summary>
        /// 
        /// </summary>
        public static WebSvc.OraPKG _WebSvc = new WebSvc.OraPKG();
        public static WebSvcLMES.OraPKG _WebSvcLMES = new WebSvcLMES.OraPKG();

        public static string DS_WebSvc_Url = "";
        public static string QD_WebSvc_Url = "";
        public static string VJ_WebSvc_Url = "";
        public static string JJ_WebSvc_Url = "";
        public static string EIS_WebSvc_Url = "";


        #endregion 


        /*
		#region 로그인 관련

		// login OK Flag
        public static bool _LoginOK = false;
        public static bool _CloseFlg = false;



		#endregion

		#region 공통 변수 정의
        
		
      
		#region 전역변수

		/// <summary>
		/// Pop-Up 창 전달 변수선언
		/// </summary>
		public static string[] Parameter_PopUp;

		// 윤승현 추가
		public static string[] Parameter_PopUp2;



		/// <summary>
		/// Pop-Up 창 전달 데이터셋 선언
		/// </summary>
		public static DataTable Parameter_PopUpTable  = new DataTable(); 
		public static DataTable Parameter_PopUpTable2 = new DataTable();





		/// <summary>
		/// 파일저장 유형 정의
		/// </summary>
		

		/// <summary>
		/// 그리드 칼럼 ComboList 구성 방법
		/// </summary>
		public enum ComboList_Type : int
		{	
			ComCode =0,				// 공통코드로 생성
			Query= 1,				// Query로 생성
			ComCode_Name =2,			// 공통코드 + ":" + 코드이름
            Query_Name = 3,
		}


		/// <summary>
		/// 그리드 스타일
		/// </summary>
		public enum Grid_Type : int
		{	
			ForSearch =0,				// 검색부 그리드 스타일
			ForModify= 1,				// 데이터 그리드 스타일
		}





		/// <summary>
		/// 그리드 스타일
		/// </summary>
		public enum Message_Select : int
		{	
			EndSearch = 11 ,
			EndSave   = 12 ,
			EndDelete = 13 ,
			EndRun    = 14 ,
			EndOK     = 15 ,
			EndSend   = 16 ,


			ChooseSearch = 31 ,
			ChooseSave   = 32 ,
			ChooseDelete = 33 ,
			ChooseRun    = 34 ,
			ChooseOK     = 35 ,
			ChooseSend   = 36 ,
			ChooseExit	 = 37 ,


			DoNotSearch = 31 ,
			DoNotSave   = 32 ,
			DoNotDelete = 33 ,
			DoNotRun    = 34 ,
			DoNotSelect = 35 ,
			DoNotSend   = 36 ,


			ChooseSelect = 51 ,

			WrongInput   = 91 , 

			NotnoHaveData = 92
		}


		/// <summary>
		/// Combo List Visible 속성 구분
		/// </summary>
		public enum ComboList_Visible : int
		{	
			Code =0,				// 코드만 보임
			Name= 1,				// Description 만 보임
			Code_Name =2			// 코드, Description 모두 보임
		}




		/// <summary>
		/// DSFactory : 'DS' 이면 arg_cmb.enable = true; 처리 하기 위한 변수 처리
		/// </summary>
		public static string DSFactory = "DS";




		public static string MarkGrid_Symbol = "*";
		public static Color MarkGrid_BackColor = Color.FromArgb(217, 250, 216);
		public static Color MarkGrid_ForeColor = Color.Black;





		// 업무 부서 코드
		public const string CxJobCd_Material = "B";
		public const string CxJobCd_Cost = "J";
		public const string CxJobCd_Trade = "T";



		#endregion

		

		#region 시스템 정보

		//------- 시스템 정보 ---------
		/// <summary>
		/// Date Type
		/// </summary>
		public static string This_SetedDateType = "yyyy-MM-dd";

		/// <summary>
		/// 
		/// </summary>
		public static string This_SetedDBType = "yyyyMMdd";

		/// <summary>
		/// Date Type 구분 기호
		/// </summary>
		public static string This_SetedDateSign = "-";

		/// <summary>
		/// Date Type 테이블에 INSERT 및 UPDATE 구분 변수
		/// </summary>
		//public static string This_InNUpCheck = "U";

		#endregion 

		#region 그리드 정의 정보
 
		/// <summary>
		/// Grid의 칼럼 Fixed
		/// </summary>
		public static int GridCol_Fixed = 0;			
		/// <summary>
		/// Grid의 칼럼0 의 width
		/// </summary>
		public static int GridCol0_Width = 20;			
		//		/// <summary>
		//		/// Grid의 칼럼0 의 color
		//		/// </summary>
		//		public static Color GridCol0_Color = Color.FromArgb(193, 221, 253);	
 

		
		//생산쪽 컬러
		public static Color GridAlternate_Color = Color.FromArgb(240, 244, 250);     //상호 반복 컬러
		public static Color GridDarkFixed_Color = Color.FromArgb(122, 160, 200);     //Modify용 그리드 헤더 컬러
		public static Color GridLightFixed_Color = Color.FromArgb(135, 179, 234);    //Search용 그리드 헤더 컬러
		public static Color GridHigh_Color = Color.FromArgb(193, 221, 253);          //선택시 로우 컬러
		public static Color GridHighFore_Color = Color.Black;
		public static Color GridCol0_Color = Color.FromArgb(193, 221, 253);          //컬럼 0 컬러
		public static Color GridForeColor = Color.White;                             //글자색
		public static Color GridEmptyColor = Color.White;
 
		 

		//수출쪽 컬러
		//		public static Color GridAlternate_Color = Color.FromArgb(245, 248, 232);
		//		public static Color GridDarkFixed_Color = Color.FromArgb(208, 227, 135);
		//		public static Color GridLightFixed_Color = Color.FromArgb(226, 245, 153);
		//		public static Color GridHigh_Color = Color.FromArgb(236, 247, 187);
		//		public static Color GridCol0_Color = Color.FromArgb(236, 247, 187);
		//		public static Color GridForeColor = Color.Black;
		//		public static Color GridEmptyColor = Color.White;



		#endregion 

		#region 색깔 정보

		#region 생산

		public static Color ClrDarkSel = Color.LightSteelBlue;

 
		public static Color ClrLightSel = Color.Lavender;
		public static Color ClrWarning = Color.Red;
		public static Color ClrWarning_Back = Color.Pink;
		public static Color ClrImportant = Color.Blue;
 
		public static Color ClrSel_Green = Color.FromArgb(217, 250, 216);
		public static Color ClrSel_Yellow = Color.FromArgb(251, 248, 185);
		public static Color ClrOA = Color.SeaShell;  

		public static Color ClrDisableHead = Color.FromKnownColor(System.Drawing.KnownColor.Control); 
 
		public static Color ClrCalHoli = Color.Red;
		public static Color ClrCalSat = Color.Blue;
		public static Color ClrCalSun = Color.SeaShell;
		public static Color ClrCalShift = Color.Lavender; 

		public static Color ClrReadOnly = Color.WhiteSmoke;
		public static Color ClrReadOnlyN = Color.FromKnownColor(System.Drawing.KnownColor.Window);
		public static Color ClrBorder = Color.DarkGray;

		
		//SubTotal Style 색깔
		public static Color ClrSubTotal0 = Color.Silver;
		public static Color ClrSubTotal1 = Color.Lavender;
		public static Color ClrSubTotal2 = Color.WhiteSmoke;
		public static Color ClrSubTotal3 = Color.SeaShell;


		//작업지시 내릴때 버튼 색깔 표시
		public static Color ClrReleaseAll_Y = Color.FromArgb(180, 180, 255);
		public static Color ClrReleaseMix_YN = Color.FromArgb(255, 255, 166);
		public static Color ClrReleaseAll_N = Color.FromArgb(255, 213, 213);
		public static Color ClrReleaseNone = Color.FromKnownColor(System.Drawing.KnownColor.Control); 



		//MPS 색깔처리
		public static Color ClrRealLOT = Color.FromArgb(180, 180, 255);
		public static Color ClrVirtualLOT = Color.FromArgb(255, 255, 166);
		public static Color ClrRelease = Color.FromArgb(255, 213, 213);

		//ts_finish_yn = 'y' 일때 색깔 처리
		public static Color ClrFinishY = Color.FromArgb(251, 248, 185);



		#endregion

		#region 수출

		public static Color ClrError		= Color.Red;	
		public static Color Clrwarn			= Color.Blue;                    //blue
		public static Color ClrTransparent  = Color.Transparent;	
		public static Color ClrHead         = Color.FromArgb(245, 248, 232);
		
		public static Color ClrBlack        = Color.FromArgb(0,0,0);     //Black
		public static Color ClrPink         = Color.FromArgb(255,221,255);     //light pink
		public static Color ClrBlue         = Color.FromArgb(215,236,235);     //light  skyblue
		public static Color ClrComplete     = Color.FromArgb(245, 192, 250);               //PINK
		public static Color ClrUnComplete   = Color.FromArgb(253, 228, 187);               //BROWN
		public static Color ClrTotFirst     = Color.FromArgb(251, 248, 185);
		public static Color ClrTotSecond    = Color.FromArgb(202, 241,84);
		public static Color ClrTotThird     = Color.GreenYellow;
		public static Color ClrTotForth     = Color.Green;


		//Grid Head Setting
		public static Color Clr_Grid_Base         = Color.FromArgb(255,255,157);     //light Yellow
		public static Color Clr_Head_Pink         = Color.FromArgb(255,0,255);       //light Pink 
		public static Color Clr_Head_Blue         = Color.FromArgb(155,155,255);     //light skyblue
		public static Color Clr_Head_Red          = Color.FromArgb(255,0,0);         //light red
		public static Color Clr_Head_Crimson      = Color.FromArgb(255,158,62);      //light Crimson
		public static Color Clr_Head_RYellow      = Color.FromArgb(255,255,187);     //more  light Yellow
		
		public static Color Clr_Text_Pink         = Color.FromArgb(128,0,128);         //light Pink 
		public static Color Clr_Text_Blue         = Color.FromArgb(0,0,255);         //light skyblue
		public static Color Clr_Text_Red          = Color.FromArgb(255,0,0);         //light Red
		public static Color Clr_Text_Crimson      = Color.FromArgb(128,0,0);         //light Crimson
		public static Color Clr_Text_SeaBlue      = Color.Blue;                      //Blue


		#endregion

		#region 자재

		//레벨에 따른 배경색
		public static Color ClrLevel_1st = Color.FromArgb(239, 231, 241);
		public static Color ClrLevel_2nd = Color.FromArgb(255, 242, 238);
		public static Color ClrLevel_3rd = Color.FromArgb(249, 249, 251);
		

		//채산 표시할 때 사이즈 자재 표시 글자색
		public static Color ClrYield_SizeY = Color.Magenta;


		public static Color ClrEdit = Color.Magenta;
		public static Color ClrFormulaEdit = Color.Blue;



		#endregion

        #region  CDC

        public static Color ClrLightPink = Color.FromArgb(255, 221, 255);     //light pink

        #endregion  

		#endregion 

		#region 공통코드


		#region 공통


		/// <summary>
		/// 메뉴얼 언어코드 선택
		/// </summary>
        public const string CxManualLanguage = "SCML1"; 

		#endregion

		#region 메뉴, 로그인 관련


		/// <summary>
		/// CxRoleID : Menu Role ID 
		/// </summary>
		public const string CxRoleID = "SPC09"; 



		/// <summary>
		/// CxLangCode : 언어 공통 코드 
		/// </summary>
		public const string CxLangCode = "DA02";



		/// <summary>
		/// CxERPUseCode : ERP 계정 사용 유무
		/// </summary>
		public const string CxERPUseCode = "PS04";


		/// <summary>
		/// CxAdminReqCode : 관리자 설정 기본 코드
		/// </summary>
		public const string CxAdminReqCode = "PS05";


		/// <summary>
		/// CxLogTypeCode : 사용자 접속 관련 기본 코드
		/// </summary>
		public const string CxLogTypeCode = "PS06";


		/// <summary>
		/// CxLogOnOffCode : 사용자 접속/비접속 코드
		/// </summary>
		public const string CxLogOnOffCode = "PS07";



		#endregion

		#region 생산 공통코드

		/// <summary>
		/// CxJobCd : 업무 공통코드
		/// </summary>
		public const string CxJobCd = "CM01";


		/// <summary>
		/// CxCategory : 카테고리 Code
		/// </summary>
		public const string CxCategory = "MD02";
 


		/// <summary>
		/// CxMoldPart : 몰드유형 공통코드
		/// </summary>
		public const string CxMoldPart = "MD03";

		/// <summary>
		/// CxMoldType : Mold Type Code
		/// </summary>
		public const string CxMoldType = "MD03";


		/// <summary>
		/// CxRoutType : 라우팅타입 공통코드
		/// </summary>
		public const string CxRoutType = "RT01"; 


		/// <summary>
		/// CxOverType : 오버랩 타입 공통코드
		/// </summary>
		public const string CxOverType = "RT02";
 
		/// <summary>
		/// CxSDateType : 날짜 형태 공통코드
		/// </summary>
		public const string CxSDateType = "PS01";


		/// <summary>
		/// CxSDateType : 날짜 구분 기호 공통코드
		/// </summary>
		public const string CxSDateSign = "PS02";


		


		/// <summary>
		/// CxAssignItem : 배치 타입 적용 기준
		/// </summary>
		public const string CxAssignWays = "SPO_LT13";

 

		/// <summary>
		/// CxYesNo : Yes/No
		/// </summary>
		public const string CxYesNo = "CM04";

 

		/// <summary>
		/// CxDaySeqDiv : Day Seq 산정방법
		/// </summary>
		public const string CxDaySeqDiv = "SPO_LT01";

		/// <summary>
		/// CxMultiLineDiv : 한 LOT에 대한 라인 분할 방법
		/// </summary>
		public const string CxMultiLineDiv = "SPO_LT02";

		/// <summary>
		/// CxLineAssignDiv : 수량 배치 방법
		/// </summary>
		public const string CxLineAssignDiv = "SPO_LT03";

		/// <summary>
		/// CxEndDaySeqDiv : 마지막 DaySeq가 line max capa 를 초과하지 않는 경우 
		/// </summary>
		public const string CxEndDaySeqDiv = "SPO_LT04";

		/// <summary>
		/// CxLineCapaAssignDiv : 라인 Capacity 적용 방법
		/// </summary>
		public const string CxLineCapaAssignDiv = "SPO_LT05";

		/// <summary>
		/// CxLineCapaDiv : 라인 Capacity
		/// </summary>
		public const string CxLineCapaDiv = "SPO_LT06";

		/// <summary>
		/// CxAssignWay : 배치 일자 적용 기준
		/// </summary>
		public const string CxAssignWay = "SPO_LT07";


		/// <summary>
		/// CxAssignWay : 배치 일자 적용 기준
		/// </summary>
		public const string CxLineTypeDiv = "SPO_LT08";


		/// <summary>
		/// CxAssignItem : 배치 타입 적용 기준
		/// </summary>
		public const string CxAssignItem = "SPO_LT09";

 

		/// <summary>
		/// CxRscType : 리소스 유형 
		/// </summary>
		public const string CxRscType = "SPB_RSC01";


 

		/// <summary>
		/// CsProdUnit : 생산단위
		/// </summary>
		public const string CxProdUnit = "CM02";


 

		/// <summary>
		/// ComCalType : 공통 카렌더 타입
		/// </summary>
		public const string ComCalType = "COMMON"; 

		/// <summary>
		/// ComShiftType : 공통 교대 타입
		/// </summary>
		public const string ComShiftType = "COMMON";

 

		/// <summary>
		/// CxPlanSt : LOT Plan Status
		/// </summary>
		public const string CxLOTPlanSt = "SPO_LT10";

		/// <summary>
		/// CxLOTOaAppDiv : OA 계획 여부 구분
		/// </summary>
		public const string CxLOTOaAppDiv = "SPO_LT11";

		/// <summary>
		/// CxLOTDiv : LOT Div(실LOT, 가상LOT)
		/// </summary>
		public const string CxLOTDiv = "SPO_LT12";
 

		/// <summary>
		/// CxLineType : 라인타입
		/// </summary>
		public const string CxLineType = "SPB_LINE01";



		/// <summary>
		/// CxREFDay : REF_DAY
		/// </summary>
		public const string CxREFDay = "SPO_LT14";



		/// <summary>
		/// CxPhType : CxPhTypeCd Type Code
		/// </summary>
		public const string CxPhType = "MD04";



		/// <summary>
		/// CxJitReqDivision : shortage 구분
		/// </summary>
		public const string CxJitReqDivision = "SPO_JIT01";


		#endregion

		#region 수출 공통코드



		/// <summary>
		//		/// _CxJobCd : 업무 공통코드
		//		/// </summary>
		//		public const string CxJobCd = "CM01";

		/// <summary>
		/// CxGen : 성별 공통코드
		/// </summary>
		public const string CxGen = "SEM01";


		/// <summary>
		/// CxPst_yn : Presto 공통코드
		/// </summary>
		public const string CxPst_yn = "SEM02";


		/// <summary>
		/// CxOBS_Div : Real Obs Div 공통코드
		/// </summary>
		public const string CxOBS_Div = "SEM03";
		


		/// <summary>
		/// CxOBS_Type : OBS Type 공통코드
		/// </summary>
		public const string CxOBS_Type = "SEM10";

		/// <summary>
		/// CxOBS_Path : Local DBF file path
		/// </summary>
		public const string CxOBS_Path = "SEM11";

		/// <summary>
		/// CxBP_Path : Local Excel file path
		/// </summary>
		public const string CxBP_Path = "SEM17";

		/// <summary>
		/// CxBP_Sheet : Local Excel file Sheetname
		/// </summary>
		public const string CxBP_Sheet = "SEM18";

		/// <summary>
		/// CxReq_yn : Y/N
		/// </summary>
		public const string CxReq_yn = "SEM07";

		/// <summary>
		/// CxSeason : Season Code
		/// </summary>
		public const string CxSeason = "SEM15";

		/// <summary>
		/// CxMonth_Eng : Month English Code
		/// </summary>
		public const string CxMonth_Eng = "SEM16";

		/// <summary>
		/// CxCO_Limite : Month English Code
		/// </summary>
		public const string CxCO_Limite = "SEM20";

		/// <summary>
		/// CxJob : Job Code
		/// </summary>
		public const string CxJob = "SEM21";


		/// <summary>
		///  CxOBS_Clr : OBS Color Code
		/// </summary>
		public const string CxOBS_Clr = "SEM22";


		/// <summary>
		/// CxSQL : MSSQL Info
		/// </summary>
		public const string CxSQL = "SEM24";

		
		/// <summary>
		/// CxLoadPG : Loading Pg Name
		/// </summary>
		public const string CxLoadPG = "SEM25";
		
				
		/// <summary>
		/// CxPGS_Path : Local Pegasus Excel file path
		/// </summary>
		public const string CxPGS_Path = "SEM26";


		/// <summary>
		/// CxPGS_Sheet : Local Pegasus Excel  file Sheetname
		/// </summary>
		public const string CxPGS_Sheet = "SEM27";


		// <summary>
		/// CxRPM_Path : Local RPM Excel file path
		/// </summary>
		public const string CxRPM_Path = "SEM28";

		
		// <summary>
		/// CxRPM_Sheet : RPM OBS Size file Sheetname
		/// </summary>
		public const string CxRPM_Sheet = "SEM29";


		// <summary>
		/// CxQTY_Div : Weekly Order Qty Division
		/// </summary>
		public const string CxQTY_Div = "SEM30";

		// <summary>
		/// CxEOBS_Type : Weekly Order Type
		/// </summary>
		public const string CxEOBS_Type = "SEM31";

		
		/// <summary>
		/// CxComponent : Component  공통코드
		/// </summary>
		public const string CxComponent = "SEM38";



		/// <summary>
		/// ConsType : Base Type Info
		/// </summary>
		public const string ConsType = "FT";

		/// <summary>
		/// ConsReal : Base Type Info
		/// </summary>
		public const string ConsReal_Y = "Y";
		public const string ConsReal_N = "N";


		/// <summary>
		/// ConsGab : Gab Allowance
		/// </summary>
		public const int ConsGab = 7;


		/// <summary>
		/// ConsJob :  insert, delete, update 구분자
		/// </summary>
		public const string ConsJob_I = "I";
		public const string ConsJob_D = "D";
		public const string ConsJob_U = "U";
		public const string ConsJob_N = "N";


		/// <summary>
		/// ConsOBS : OBS (DPO,GPO)
		/// </summary>
		public const string ConsOBS_G= "G";
		public const string ConsOBS_D= "D";
		public const string ConsOBS_R= "R";

		/// <summary>
		/// ConsOBS : OBS (DPO,GPO)
		/// </summary>
		public const string ConsCFM_R= "R";
		public const string ConsCFM_C= "C";
		public const string ConsCFM_P= "P";


		/// <summary>
		/// ConsGen : GENDER 위치
		/// </summary>
		public const int ConsPosME= 1;
		public const int ConsPosWO= 2;
		public const int ConsPosGS= 3;
		public const int ConsPosPS= 4;
		public const int ConsPosIN= 5;

		/// <summary>
		/// ConsGen명 : GENDER 명
		/// </summary>
		public const string ConsME= "ME";
		public const string ConsWO= "WO";
		public const string ConsGS= "GS";
		public const string ConsPS= "PS";
		public const string ConsIN= "IN";


		/// <summary>
		/// ConsFactory명 : Factory명
		/// </summary>
		public const string ConsFactoryQD= "QD";
		public const string ConsFactoryVJ= "VJ";
		public const string ConsFactoryJJ= "JJ";




		#endregion

		#region 자재 공통코드

		#region 콤보 공통 코드

		/// <summary>
		/// CxSpecDiv : Yes/ No List
		/// </summary>
		public const string CxUseYN = "SBC00";


		/// <summary>
		/// CxPurDiv : 구매구분
		/// </summary>
		public const string CxPurDiv = "SBC01";



		/// <summary>
		/// CxPurUnit : 단위 
		/// </summary>
		public const string CxPurUnit = "SBC02";


		/// <summary>
		/// CxUBDiv : 스타일 자재 분류 (Upper/ Bottom)
		/// </summary>
		public const string CxUBDiv = "SBC04";


		/// <summary>
		/// CxABCDiv : ABC 분류
		/// </summary>
		public const string CxABCDiv = "SBC05";


		/// <summary>
		/// CxMonetaryUnit : 화폐 단위
		/// </summary>
		public const string CxMonetaryUnit = "SBC06";


		/// <summary>
		/// CxAccountDiv : 회계 구분
		/// </summary>
		public const string CxAccountDiv = "SBC07";


		/// <summary>
		/// CxDeliveryDiv : 장/ 단기 구분
		/// </summary>
		public const string CxDeliveryDiv = "SBC08"; 


		/// <summary>
		///CxTradeGroup : Trade Goup
		/// </summary>
		public const string CxTradeGroup = "SBC19";


		/// <summary>
		/// CxPurchaseTracking_PrintType : 긴급분 모니터링 프린트 타입
		/// </summary>
		public const string CxPurchaseTracking_PrintType = "SBP12";


		/// <summary>
		/// CxSpecDiv : Specification Division
		/// </summary>
		public const string CxSpecDiv = "SBCS1";


		/// <summary>
		/// CxSpecUnit : Specification Unit
		/// </summary>
		public const string CxSpecUnit = "SBCS2";


		/// <summary>
		/// CxSpecWeight : Specification Weight
		/// </summary>
		public const string CxSpecWeight = "SBCS3";


		/// <summary>
		/// CxSpecEtc : Specification Etc.
		/// </summary>
		public const string CxSpecEtc = "SBCS4";

		
		/// <summary>
		/// CxFormulaDiv : Formula Division
		/// </summary>
		public const string CxFormulaDiv = "SBCY1";


		/// <summary>
		/// CxYieldType : Yield Value Type (Yield (E), Yield (M), Specification)
		/// </summary>
		public const string CxYieldType = "SBCY2";


		/// <summary>
		/// CxYieldStatus : 채산값 상태 (SS, INTERIM, STANDARD, TRIAL)
		/// </summary>
		public const string CxYieldStatus = "SBCY3";


		/// <summary>
		/// CxFormulaDiv : 채산 Check in/out cancel 여부
		/// </summary>
		public const string CxYieldCheckinCancel = "SBCY4";



		/// <summary>
		/// CxYear : 년도 구분
		/// </summary>
		public const string CxYear = "SBC11"; 

 
		/// <summary>
		/// Status : Yes, No
		/// </summary>
		public const string CxStatus = "SBC00";

		/// <summary>
		/// Ship Type : Upper, Sole..
		/// </summary>
		public const string CxShipType = "SBS02";  
		
		
		/// <summary>
		/// Request Reason
		/// </summary>
		public const string CxReqReason = "SBM07";


		/// <summary>
		/// Item Division : DS, LOCAL..
		/// </summary>
		public const string CxItemDivision = "SBM08";


		/// <summary>
		/// Ship Type : Shipping DS..
		/// </summary>
		public const string CxMRPShipType = "SBM09";

		/// <summary>
		/// Item Division : Upper, Buttom, Order
		/// </summary>
		public const string CxMRPItemDivision = "SBM10";



		/// <summary>
		/// CxLocalSearchOption : Local/ LLT Monitoring By Style Search Option
		/// </summary>
		public const string CxLocalSearchOption = "SBM18";

		/// <summary>
		/// CxYieldSearchOptionFrom : Yield analysis Search Otion
		/// </summary>
		public const string CxYieldSearchOptionFrom = "SBM19";
 
		/// <summary>
		/// CxYieldSearchOptionTo : Yield analysis Search Otion
		/// </summary>
		public const string CxYieldSearchOptionTo = "SBM20";



		/// <summary>
		/// OBS Type
		/// </summary>
		public const string CxOBSType = "SEM10";
		
		/// <summary>
		/// Incoming Type : Container Incoming, Conatainer DoorToDoor, Warehouse Incoming
		/// </summary>
		public const string CxIncomingType = "SBS05";

		/// <summary>
		/// Outgoing Type
		/// </summary>
		public const string CxOutgoingType = "SBS08";

		/// <summary>
		/// Barcode Status : Not Scan, Scam Scan, Scan
		/// </summary>
		public const string CxBarcodeState = "SBS06";

		/// <summary>
		/// IN / OUT : incoming, outgoing
		/// </summary>
		public const string CxInOutType = "SBS07";

		 

		/// <summary>
		/// Vrigin Reason
		/// </summary>
		public const string CxVirginReason = "SBS09";



		
		/// <summary>
		/// Use Division ( MRP, LOCAL, NOT USING )
		/// </summary>
		public const string CxUseDivision = "SBP07";



		/// <summary>
		/// Local /LLT Division ( Local, LLT, No, DS Shipping )
		/// </summary>
		public const string CxLocalLLTDivision = "SBP13";



		/// <summary>
		/// Lab Component Code : Lab Component
		/// </summary>
		public const string CxLabComponent = "SQC01";






		/// <summary>
		/// CxWorkflowPropDiv : Workflow property division
		/// </summary>
		public const string CxWorkflowPropDiv = "SBW01";

		/// <summary>
		/// CxYieldTrackDateDiv: Yield Tracking Date Division
		/// </summary>
		public const string CxYieldTrackDateDiv = "SBW02";


		/// <summary>
		/// CxGACUploadProperty01 : GAC Upload Column Property 01
		/// </summary>
		public const string CxGACUploadProperty01 = "SBW03";

		/// <summary>
		/// CxGACScoreMetrics : GAC Score Metrics
		/// </summary>
		public const string CxGACScoreMetrics = "SBW04";


		/// <summary>
		/// CxGACUploadProperty02 : GAC Upload Column Property 02
		/// </summary>
		public const string CxGACUploadProperty02 = "SBW05";


		// SBW06 : Production Daily Report Priority

        

		/// <summary>
		///CxFormulaComponent : CxFormulaComponent Division
		/// </summary>
		public const string CxFormulaComponent= "SBC16";


		/// <summary>
		/// CxSillhuoette : 스타일 마스터 실루엣 구분
		/// </summary>
		public const string CxSillhuoette = "SBC17";


		/// <summary>
		/// CxWidthDivision : 스타일 마스터 Width 구분
		/// </summary>
		public const string CxWidthDivision = "SBC18";



		/// <summary>
		/// CxOutType : Outgoing type
		/// </summary>
		public const string CxOutType = "SBO01";


		/// <summary>
		/// CxOutDivision : Outgoing Division
		/// </summary>
		public const string CxOutDivision = "SBO02";



		/// <summary>
		/// CxInType : Incoming Type
		/// </summary>
		public const string CxInType  = "SBI01";



		#endregion



		/// <summary>
		/// ConsAll : ALL
		/// </summary>
		public const string ConsAll= "All";

		/// <summary>
		/// ConsBaseSN  : SP
		/// </summary>
		public const string ConsBaseSN= "SP";


		/// <summary>
		/// ConsY/ConsN  : Y/N
		/// </summary>
		public const string ConsY= "Y";
		public const string ConsN= "N";



		
 


		#endregion

        #region CDC 공통코드


        /// <summary>
        /// 업무 관리자 여부
        /// </summary> 
        public static string This_Power = "Y";



        /// <summary>
        /// CxCDC_Request_Reason :  Request Reason
        /// </summary>
        /// 
        public const string CxCDC_Request_Reason = "SBM07";




        /// <summary>
        /// CxCDC_Request_Status :  Request Status
        /// </summary>
        /// 
        public const string CxCDC_Request_Status_nomal = "SXP01";
        public const string CxCDC_Request_Status_admin = "SXP02";



        //레벨에 따른 배경색
        //		public static Color CDCClrLevel_1st = Color.FromArgb(239, 231, 241);
        //		public static Color CDCClrLevel_2nd = Color.FromArgb(255, 242, 238);
        //		public static Color CDCClrLevel_3rd = Color.FromArgb(249, 249, 251);


        public static Color CDCClrLevel_1st = Color.FromArgb(196, 154, 199);
        public static Color CDCClrLevel_2nd = Color.FromArgb(243, 236, 244);
        public static Color CDCClrLevel_3rd = Color.FromArgb(237, 223, 238);
        public static Color CDCClrLevel_4rd = Color.FromArgb(241, 239, 245);





        /// <summary>
        /// CxCDC_Pur_Manager
        /// </summary>
        /// 
        public const string CxCDC_PurManaget_Status = "SXP03";
        public const string CxCDC_PurManaget_MatDiv = "SXC25";
        public const string CxCDC_PurManaget_DataType = "SXP04";
        public const string CxCDC_PurOrder_Status = "SXP09";


        /// <summary>
        /// CxCDC_Out_sch
        /// </summary>
        /// 
        public const string CxCDC_OutSch_Order_type = "SXO02";
        public const string CxCDC_OutSch_status = "SXO03";

        /// <summary>
        /// CxCDC_Out_Outgoing
        /// </summary>
        /// 
        public const string CxCDC_Outgoing_div = "SXO01";
        public const string CxCDC_Outgoing_status = "SXO05";
        public const string CxCDC_OutRequest_Div = "SXP06";
        public const string CxCDC_OutRequest_Status = "SXP07";
        public const string CxCDC_OutRequest_Ouy_yn = "SXP08";





        /// <summary>
        //		/// _CxJobCd : 업무 공통코드
        //		/// </summary>
        //		public const string CxJobCd = "CM01";

        /// <summary>
        /// CxCategory : 성별 공통코드
        /// </summary>
        public const string CxCDC_Category = "SXB03";




        /// <summary>
        /// CxCategory : 성별 공통코드
        /// </summary>
        public const string CxCDC_Purcahse_Status = "SXC08";


        /// <summary>
        /// CxCDC_LoadingType : Base Info LoadingType 
        /// </summary>
        public const string CxCDC_LoadingType = "SXC22";



        /// <summary>
        /// CxCDC_Style_Loading_Sheet :  Base Info Loading SheetName
        /// </summary>
        /// 
        public const string CxCDC_Style_Loading_Sheet = "SXC24";




        /// <summary>
        /// CxCDC_XML_Sheet 
        /// </summary>
        /// 
        public const string CxCDC_XML_Sheet = "SXC23";


        /// <summary>
        /// 
        /// </summary>
        public static string ConsCDC_MaterialXML_Factory = "";
        public static string ConsCDC_MaterialXML_UpdDate = "";




        /// <summary>
        /// ConsCDC_NA
        /// </summary>
        public const string ConsCDC_NA = "NA";


        /// <summary>
        /// ConsCDC_MoveSheet
        /// </summary>
        public const string ConsCDC_MoveSheet = "";
        public const string ConsCDC_MoveSheet_0 = "0";
        public const string ConsCDC_MoveSheet_1 = "1";
        public const string ConsCDC_MoveSheet_2 = "2";
        public const string ConsCDC_MoveSheet_3 = "3";
        public const string ConsCDC_MoveSheet_4 = "4";
        public const string ConsCDC_MoveSheet_5 = "5";
        public const string ConsCDC_MoveSheet_6 = "6";





        /// <summary>
        /// ConsCDC_SRFType
        /// </summary>
        public const string ConsCDC_SRFType_A = "A";
        public const string ConsCDC_SRFType_B = "B";
        public const string ConsCDC_SRFType_C = "C";
        public const string ConsCDC_SRFType_D = "D";
        public const string ConsCDC_SRFType_X = "X";



        /// <summary>
        /// ConsCDC_PopBominfo
        /// </summary>
        public const string ConsCDC_PopBominfo = "";
        public const string ConsCDC_PopBominfo_Project = "P";
        public const string ConsCDC_PopBominfo_Bom = "B";



        /// <summary>
        /// ConsCDC_SRFCol
        /// </summary>
        public const string ConsCDC_SRFCol_SampleRequestNo = "Sample Request#";
        public const string ConsCDC_SRFCol_BomId = "BOM ID";
        public const string ConsCDC_SRFCol_SRLineItemId = "SR Line Item ID";
        public const string ConsCDC_SRFCol_State = "State";
        public const string ConsCDC_SRFCol_PrimaryProdFactory = "Primary Prod Factory";
        public const string ConsCDC_SRFCol_ProductCode = "Product Code";
        public const string ConsCDC_SRFCol_None = "None";


        /// <summary>
        /// ConsCDC_MaterialInfo
        /// </summary>

        //Part_seq  -0, Part_Type  - 1, Part_Desc -2, Mat_cd -3, Mat_Comment_Seq -4,Mat_Description - 5 
        //Mat_Name -6, Mat_Comment -7, Spec_cd  -8, Spec_desc -9, Color_cd -10, Color_desc - 11, Color_Commnet -12,
        //Mcs_cd -13, Mcs_name - 14;

        public const int IntCDC_MatPartSeq = 0;
        public const int IntCDC_MatPartType = 1;
        public const int IntCDC_MatPartDesc = 2;
        public const int IntCDC_MatMatCd = 3;
        public const int IntCDC_MatMatCommentSeq = 4;
        public const int IntCDC_MatMatName = 5;
        public const int IntCDC_MatMatComment = 6;
        public const int IntCDC_MatMatDescription = 7;
        public const int IntCDC_MatSpecCd = 8;
        public const int IntCDC_MatSpecDesc = 9;
        public const int IntCDC_MatColorCd = 10;
        public const int IntCDC_MatColorDesc = 11;
        public const int IntCDC_MatColorComment = 12;
        public const int IntCDC_MatMcsCd = 13;
        public const int IntCDC_MatMcsName = 14;





        /// <summary>
        /// ConsCDC_NIKE
        /// </summary>
        public const string ConsCDC_NIKE = "NIKE";


        /// <summary>
        /// ConsCDC_PAIR
        /// </summary>
        public const string ConsCDC_PAIR = "PAIR";


        /// <summary>
        /// ConsCDC_R
        /// </summary>
        public const string ConsCDC_R = "R";


        /// <summary>
        /// ConsCDC_Y
        /// </summary>
        public const string ConsCDC_Y = "Y";


        /// <summary>
        /// ConsCDC_N
        /// </summary>
        public const string ConsCDC_N = "N";


        /// <summary>
        /// ConsCDC_Y
        /// </summary>
        public const string ConsCDC_C = "C";


        /// <summary>
        /// ConsCDC_N
        /// </summary>
        public const string ConsCDC_D = "D";


        /// <summary>
        /// ConsCDC_N
        /// </summary>
        public const string ConsCDC_X = "X";

        /// <summary>
        /// ConsCDC_U
        /// </summary>
        public const string ConsCDC_U = "I";


        /// <summary>
        /// ConsCDC_S
        /// </summary>
        public const string ConsCDC_S = "U";





        /// <summary>
        /// ConsCDC_P
        /// </summary>
        public const string ConsCDC_P = "P";



        /// <summary>
        /// ConsCDC_Complete
        /// </summary>
        public const string ConsCDC_Complete = "Complete";






        /// <summary>
        /// ConsCDC_Fail
        /// </summary>
        public const string ConsCDC_Fail = "Fail";



        // <summary>
        /// ConsCDC_CheckData
        /// </summary>
        public const string ConsCDC_CheckData = "Check data";



        /// <summary>
        /// ConsCDC_Including 
        /// </summary>
        public const string ConsCDC_Including = "Including";


        /// <summary>
        /// ConsCDC_NotIncluding 
        /// </summary>
        public const string ConsCDC_NotIncluding = "Not Including";




        /// <summary>
        /// ConsCDC_Ready
        /// </summary>
        public const string ConsCDC_Ready = "Ready";


        /// <summary>
        /// ConsCDC_Inserted
        /// </summary>
        public const string ConsCDC_Inserted = "Inserted";


        /// <summary>
        /// ConsCDC_Updated
        /// </summary>
        public const string ConsCDC_Updated = "Updated";


        /// <summary>
        /// ConsCDC_Deleted
        /// </summary>
        public const string ConsCDC_Deleted = "Deleted";


        /// <summary>
        /// ConsCDC_Pending
        /// </summary>
        public const string ConsCDC_Pending = "Pending";




        /// <summary>
        /// ConsCDC_N
        /// </summary>
        public const string ConsCDC_Editing = "Editing ";


        /// <summary>
        /// ConsCDC_U
        /// </summary>
        public const string ConsCDC_Comfirmed = "Comfirmed";


        /// <summary>
        /// ConsCDC_S
        /// </summary>
        public const string ConsCDC_Canceled = "Canceled";



        /// <summary>
        /// ConsCDC_S
        /// </summary>
        public const string ConsCDC_Closed = "Closed";



        /// <summary>
        /// ConsCDC_Gen
        /// </summary>
        public const string ConsCDC_ME = "ME";
        public const string ConsCDC_WO = "WO";
        public const string ConsCDC_GS = "GS";
        public const string ConsCDC_PS = "PS";
        public const string ConsCDC_IN = "IN";




        /// <summary>
        /// ConsCDC_Loading_S : OBS (DPO,GPO)
        /// </summary>
        public const string ConsCDC_Loading_S = "S";
        public const string ConsCDC_Loading_C = "C";



        /// <summary>
        /// ConsCDC_LoadingFrom_Type : Loading화면 Type설정
        /// </summary>
        public static string ConsCDC_LoadingFrom_Type = "";
        public const string ConsCDC_LoadingFrom_Type_A = "A";    //Excel Loading시
        public const string ConsCDC_LoadingFrom_Type_B = "B";    //Search 혹은 가공시




        /// <summary>
        /// ConsCDC_MatInfo_Type
        /// </summary>
        public const string ConsCDC_MatInfo_Type = "";
        public const string ConsCDC_MatInfo_Type_Part = "P";
        public const string ConsCDC_MatInfo_Type_Material = "M";
        public const string ConsCDC_MatInfo_Type_Spec = "S";
        public const string ConsCDC_MatInfo_Type_Color = "C";
        public const string ConsCDC_MatInfo_Type_Mcs = "Z";




        /// <summary>
        /// ConsCDC_Bom
        public static string ConsCDC_SR_No = "";
        public static string ConsCDC_SRF_No = "";
        public static string ConsCDC_Bom_Id = "";
        public static string ConsCDC_Bom_Level = "";
        public static string ConsCDC_NF_Cd = "";





        /// <summary>
        /// ConsCDC_MRP
        public static string ConsCDC_MRP_Factory = "";
        public static string ConsCDC_MRP_MatDiv = "";
        public static string ConsCDC_MRP_No = "";
        public static string ConsCDC_MRP_ProdFrom = "";
        public static string ConsCDC_MRP_ProdTo = "";


        /// <summary>
        /// CxCDC_Incomming_Manager : Incomming Impoort Y/N 
        /// </summary>
        ///
        public const string CxCDC_Incomming_Import = "SXC28";


        /// <summary>
        /// CxCDC_Incomming_Manager : Incomming Division  
        /// </summary>
        /// 
        public const string CxCDC_Incomming_In_Div = "SXC26";



        /// <summary>
        /// Purchase Division 
        /// </summary>
        ///
        public const string CxCDC_Pur_Division = "SXC25";

        /// <summary>
        /// Incomming Print Type
        /// </summary>
        ///
        public const string CxCDC_Incomming_Print = "SXI01";

        /// <summary>
        /// ConsCDC_Vendor
        /// </summary>
        public static string ConsCDC_Vendor = "Vendor Code";


        /// <summary>
        /// ConsCDC_TransType
        /// </summary>
        public static string ConsCDC_TransType = "Transport";




        /// <summary>
        /// ConsCDC_TransType
        /// </summary>
        public static string ConsCDC_Season = "Season";




        /// <summary>
        /// ConsCDC_User
        /// </summary>
        public static string ConsCDC_User = "User";



        /// <summary>
        /// ConsCDC_M_Vendor
        /// </summary>
        public static string ConsCDC_M_Vendor = "M_Vendor";






        #endregion


        #endregion 

		#region 통신 관련


		public const string CxXML_SAVE_YN = "SCMC1";
		public const string CxXML_TRANS_YN = "SCMC2";
		public const string CxCOMM_FG = "SCMC3";
		public const string CxTRANS_FG = "SCMC4";
		public const string CxSEND_FG = "SCMC5";
		public const string CxRECEIVE_FG = "SCMC6";



		#endregion

		#endregion 

		#region 메시지 박스 코드

		/// <summary>
		/// MgsEndSearch : 정상적으로 조회 하였습니다.
		/// </summary>
		public const string MgsEndSearch = "11";


		/// <summary>
		/// MgsEndSave : 정상적으로 저장 하였습니다.
		/// </summary>
		public const string MgsEndSave = "12";


		/// <summary>
		/// MgsEndDelete : 정상적으로 삭제 하였습니다.
		/// </summary>
		public const string MgsEndDelete = "13";


		/// <summary>
		/// MgsEndRun : 정상적으로 실행 하였습니다.
		/// </summary>
		public const string MgsEndRun = "14";


		/// <summary>
		/// MgsEndOK : 정상적으로 확정 하였습니다.
		/// </summary>
		public const string MgsEndOK = "15";


		/// <summary>
		/// MgsEndSend : 정상적으로 전송 하였습니다.
		/// </summary>
		public const string MgsEndSend = "16";


        /// <summary>
        /// MgsNotPrint : 출력할 수 없습니다.
        /// </summary>
        public const string MgsNotPrint = "21";

        /// <summary>
        /// MgsNotClear : Clear 할 수 없습니다.
        /// </summary>
        public const string MgsNotClear = "22";

        /// <summary>
        /// MgsDuplication : 중복 자료입니다.
        /// </summary>
        public const string MgsDuplication = "23";



		/// <summary>
		/// MgsChooseSearch : 조회 하시겠습니까?
		/// </summary>
		public const string MgsChooseSearch = "31";


		/// <summary>
		/// MgsChooseSave : 저장 하시겠습니까?
		/// </summary>
		public const string MgsChooseSave = "32";


		/// <summary>
		/// MgsChooseDelete : 삭제 하시겠습니까?
		/// </summary>
		public const string MgsChooseDelete = "33";


		/// <summary>
		/// MgsChooseRun : 실행 하시겠습니까?
		/// </summary>
		public const string MgsChooseRun = "34";


		/// <summary>
		/// MgsChooseOK : 확정 하시겠습니까?
		/// </summary>
		public const string MgsChooseOK = "35";


		/// <summary>
		/// MgsChooseExit : 종료 하시겠습니까?
		/// </summary>
		public const string MgsChooseExit = "36";



		/// <summary>
		/// MgsDoNotSearch : 조회 할 수 없습니다.
		/// </summary>
		public const string MgsDoNotSearch = "41";


		/// <summary>
		/// MgsDoNotSave : 저장 할 수 없습니다.
		/// </summary>
		public const string MgsDoNotSave = "42";


		/// <summary>
		/// MgsDoNotDelete : 삭제 할 수 없습니다.
		/// </summary>
		public const string MgsDoNotDelete = "43";


		/// <summary>
		/// MgsDoNotRun : 실행 할 수 없습니다.
		/// </summary>
		public const string MgsDoNotRun = "44";


		/// <summary>
		/// MgsDoNotSelect : 선택 할 수 없습니다.
		/// </summary>
		public const string MgsDoNotSelect = "45";


		/// <summary>
		/// MgsDoNotSend : 전송 할 수 없습니다.
		/// </summary>
		public const string MgsDoNotSend = "46";



		/// <summary>
		/// MgsChooseSelect : 선택 하시겠습니까?
		/// </summary>
		public const string MgsChooseSelect = "51";



		/// <summary>
		/// MgsWrongInput : 잘못 입력 하였습니다.
		/// </summary>
		public const string MgsWrongInput = "91";



		/// <summary>
		/// MgsNotnoHaveData : 원하시는 데이터가 없습니다.
		/// </summary>
		public const string MgsNotHaveData = "92";



		#endregion

		#region 프로시져 에러 첵크

		/// <summary>
		/// CxErrorCheck_ASP : 생산 업무
		/// </summary>
		public const string CxErrorCheck_APS = "APS";

		/// <summary>
		/// CxErrorCheck_Order : 수출 업무
		/// </summary>
		public const string CxErrorCheck_Order = "Order";


		/// <summary>
		/// CxErrorCheck_Error : 에러만 첵크
		/// </summary>
		public const string CxErrorCheck_Error = "E";


		/// <summary>
		/// CxReeoeCheck_Warning : 경고도 첵크
		/// </summary>
		public const string CxErrorCheck_Warning = "W";

		#endregion

		#region 버튼 제어 컬럼

		/// <summary>
		/// 그리드 스타일
		/// </summary>
		public enum Btn_Control : int
		{	
			ColSearch = 0,
			ColSave   = 1,
			ColPrint  = 2,


			IxTB_NONE_YN   = 0,
			IxTB_ALL_YN    = 1,
			IxTB_SEARCH_YN = 2,
			IxTB_SAVE_YN   = 3,
			IxTB_PRINT_YN  = 4, 

		}

 
		#endregion 

		#region 업무 변수

		public static string ToolingCheckList_From_DPO = "";
		public static string ToolingCheckList_To_DPO = "";


		public static string PlanMoldCapacity_Plan_Date = "";

		public static string ShortMold_From_Date = "";
		public static string ShortMold_To_Date = "";


		public static string Model_ModelCd = "";
		public static string Style_ModelCd = "";
		public static string Style_StyleCd = "";
		

		public static string Job_Process = "";
		public static string Job_Line = "";
		public static string Job_No   ="";

		#endregion

		#region MPS제어

		public static bool mps_check = false;
		public static bool mpsop_check = false;

		#endregion

		#region 자동 업무 알림 이벤트 사용 제어

		public static bool event_use = true;

		#endregion

		#region 공통사용 메소드 정의


		/// <summary>
		/// Select_ComCode : 공통코드 리스트 SELECT
		/// </summary>
		/// <param name="arg_factory">공장</param>
		/// <param name="arg_code">해당 코드</param>
		/// <returns>DataTable</returns>
		public static DataTable Select_ComCode(string arg_factory, string arg_code)
		{

			OraDB oraDB = new OraDB();



			string Proc_Name = "PKG_SCM_CODE.SELECT_COM_CODE";

			//// DB에서 언어 Dictionary 추출
			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_COM_CD";
			oraDB.Parameter_Name[2] = "OUT_CURSOR";

			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = arg_factory;
			oraDB.Parameter_Values[1] = arg_code;
			oraDB.Parameter_Values[2] = "";

			oraDB.Add_Select_Parameter(false);
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			
			return  DS_Ret.Tables[Proc_Name];

			 
		}


		/// <summary>
		/// Select_ComCode : 공통코드 리스트 SELECT
		/// </summary>
		/// <param name="arg_factory">공장</param>
		/// <param name="arg_code">해당 코드</param>
		/// <returns>DataTable</returns>
		public static DataTable Select_ComFilterCode(string arg_factory, string arg_code)
		{

			OraDB oraDB = new OraDB();



			string Proc_Name = "PKG_SCM_CODE.SELECT_COM_FILTER_CODE_LIST";

			//// DB에서 언어 Dictionary 추출
			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_COM_CD";
			oraDB.Parameter_Name[2] = "OUT_CURSOR";

			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = arg_factory;
			oraDB.Parameter_Values[1] = arg_code;
			oraDB.Parameter_Values[2] = "";

			oraDB.Add_Select_Parameter(false);
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			
			return  DS_Ret.Tables[Proc_Name];

			 
		}


		/// <summary>
		/// Select_DP_DPO_List : dp, dpo list 
		/// </summary>
		/// <param name="arg_factory"></param>
		/// <param name="arg_division"></param>
		/// <returns></returns>
		public static DataTable Select_DP_DPO_List(string arg_factory, string arg_division)
		{

			try 
			{

				OraDB oraDB = new OraDB();
				oraDB.ReDim_Parameter(3);  

				//01.PROCEDURE명
				oraDB.Process_Name = "PKG_SBM_SHIPPING_LOCAL.SELECT_SBM_DP_DPO_LIST";

				//02.ARGURMENT 명
				oraDB.Parameter_Name[0] = "ARG_FACTORY";
				oraDB.Parameter_Name[1] = "ARG_DIVISION";
				oraDB.Parameter_Name[2] = "OUT_CURSOR"; 

				//03.DATA TYPE 정의
				oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
				oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
				oraDB.Parameter_Type[2] = (int)OracleType.Cursor; 

				//04.DATA 정의
				oraDB.Parameter_Values[0] = arg_factory;
				oraDB.Parameter_Values[1] = arg_division;
				oraDB.Parameter_Values[2] = ""; 

				oraDB.Add_Select_Parameter(true);
				DataSet DS_Ret = oraDB.Exe_Select_Procedure();

				if(DS_Ret == null) return null;
				return DS_Ret.Tables[oraDB.Process_Name];

			}
			catch //(Exception ex)
			{
				//ClassLib.ComFunction.User_Message(ex.Message, "SELECT_SBM_DP_DPO_LIST", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return null;
			}


		}



		#endregion
 
		#region 각 프로젝트별 MDI 창으로 팝업 창 띄우기

		

		public static System.Windows.Forms.Form static_form;

		public static System.Windows.Forms.Form MDI_Parent;


		#endregion

        #region 공통 펑션


        /// <summary>
		/// Select_ComCode : 공통코드 리스트 SELECT
		/// </summary>
		/// <param name="arg_factory">공장</param>
		/// <param name="arg_code">해당 코드</param>
		/// <returns>DataTable</returns>
		public static DataTable Select_Currency(string arg_factory, string arg_code)
		{

			OraDB oraDB = new OraDB();



			string Proc_Name = "PKG_SBC_COMMON.SELECT_CURRENCY_LIST";

			//// DB에서 언어 Dictionary 추출
			oraDB.ReDim_Parameter(3);
			oraDB.Process_Name = Proc_Name ;


			oraDB.Parameter_Name[0] = "ARG_FACTORY";
			oraDB.Parameter_Name[1] = "ARG_COM_CD";
			oraDB.Parameter_Name[2] = "OUT_CURSOR";

			oraDB.Parameter_Type[0] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[1] = (int)OracleType.VarChar;
			oraDB.Parameter_Type[2] = (int)OracleType.Cursor;

			oraDB.Parameter_Values[0] = arg_factory;
			oraDB.Parameter_Values[1] = arg_code;
			oraDB.Parameter_Values[2] = "";

			oraDB.Add_Select_Parameter(false);
			DataSet DS_Ret = oraDB.Exe_Select_Procedure();

			if(DS_Ret == null) return null ;
			
			return  DS_Ret.Tables[Proc_Name];
        }



        #endregion

        */
    } 

}
