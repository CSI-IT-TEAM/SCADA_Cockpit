using System;
using System.Data;
using System.Drawing;
using System.Data.OracleClient;


namespace FORM
{
	/// <summary>
	/// ComVar�� ���� ��� �����Դϴ�.
	/// </summary>
	public class Var 
	{
		public Var()
		{
			//
			// TODO: ���⿡ ������ ���� �߰��մϴ�.
			//
		}
        public static string Form_Type = "1";


        public enum Area
        {
            Nosew = 1, Stockfit = 2, Assembly = 3
        }
	}
}
