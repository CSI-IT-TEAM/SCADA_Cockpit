using System;
using System.Data;
using System.Drawing;
using System.Data.OracleClient;


namespace FORM
{
	/// <summary>
	/// ComVar에 대한 요약 설명입니다.
	/// </summary>
	public class Var 
	{
		public Var()
		{
			//
			// TODO: 여기에 생성자 논리를 추가합니다.
			//
		}
        public static string Form_Type = "1";


        public enum Area
        {
            Nosew = 1, Stockfit = 2, Assembly = 3
        }
	}
}
