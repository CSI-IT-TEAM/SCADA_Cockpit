using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM.UC
{
    public partial class UCTitle : UserControl
    {
        public UCTitle()
        {
            InitializeComponent();
            setDisplay();
            
        }
        public delegate void ButtonDetailClick(ChartModel model,string YearValue);
        public ButtonDetailClick OnButtonDetailClick = null;

        public delegate void ButtonYearClick(ChartModel model, string YearValue);
        public ButtonYearClick OnButtonYearClick = null;

        private ChartModel _model = null;
        public TypeDisplay _typeDisplay = TypeDisplay.YEAR;


        public enum TypeDisplay
        {
            MONTH,
            YEAR,
            SEASON,
        }

        [Browsable(true)]
        public event EventHandler ValueChangeEvent;

        private string sValue = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00");
        private string sYearValue = DateTime.Now.Year.ToString();
        private string sMonthValue = DateTime.Now.Month.ToString("00");
        private string[] _arrMonthValue = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        private string[] _arrMonthShortName = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private string[] _arrMonthLongName = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "Novvember", "December" };
        private bool isMonthValueChange = false;
        private string[] _arrSeasonValue = { "SP","SU", "FA", "HO" };
        private string sSeasonValue;

        public void setDisplay()
        {
            if (_typeDisplay == TypeDisplay.MONTH)
            {
                lblYear.Text = sYearValue.ToString() + "-" + _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString(); 
            }
            if (_typeDisplay == TypeDisplay.SEASON)
            {
                sSeasonValue = Season;
                lblYear.Text = sSeasonValue;
            }
            else
            {
                lblYear.Text = sYearValue.ToString();
            }
        }

        public void SetStatus(string argStatus)
        {
            cmdStatus.BackColor = Color.FromName(argStatus);
        }

        public void SetTitle(string argTitle)
        {
            cmdTitle.Text = argTitle;
        }

        public void SetText(string argText)
        {
            //cmdText.Text = argText;
        }

        public void SetModels(ChartModel model)
        {
            cmdTitle.Text = model.Title;
            this.Tag = model.Code;
            _model = model;

            if (
                model.Code.Equals("RW") || model.Code.Equals("ELEC")
               )
                panel1.Visible = false;
            else
                panel1.Visible = true;

        }

        public string GetValue()
        {
            return _typeDisplay == TypeDisplay.MONTH ? sValue : sValue.Substring(0,4);
        }

        private string Season
        {
            get
            {
                string season = "";
                
                int month;
                int.TryParse(sMonthValue, out month);

                season = _arrSeasonValue[month / 4] + sYearValue.Substring(2,2);
                return season;
            }
        }

        #region Year,Month
        private void btnPrevYear_Click(object sender, EventArgs e)
        {

            sYearValue = (Convert.ToInt32(sYearValue) - 1).ToString();
            sValue = sYearValue + sMonthValue;
            SetShortName(sYearValue, sMonthValue);
            this.btnPrevYear.Focus();
            if (OnButtonYearClick != null)
                OnButtonYearClick(_model, sYearValue);
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            if (_typeDisplay == TypeDisplay.SEASON)
            {
                

            }
            else
            {
                if (DateTime.Now.Year < Convert.ToInt32(sYearValue) + 1) return;
                if (Convert.ToDouble(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("00"))
                       < Convert.ToDouble((Convert.ToInt32(sYearValue) + 1).ToString() + (Convert.ToInt32(sMonthValue)).ToString("00")))
                {
                    sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
                    sMonthValue = DateTime.Now.Month.ToString("00");
                    sValue = sYearValue + sMonthValue;
                    SetShortName(sYearValue, sMonthValue);
                    this.btnNextYear.Focus();
                }
                else
                {
                    sYearValue = (Convert.ToInt32(sYearValue) + 1).ToString();
                    sValue = sYearValue + sMonthValue;
                    SetShortName(sYearValue, sMonthValue);
                    this.btnNextYear.Focus();
                }
                if (OnButtonYearClick != null)
                    OnButtonYearClick(_model, sYearValue);
            }

            if (DateTime.Now.Year == Convert.ToInt32(sYearValue))
            {
                btnNextYear.Enabled = false;
            }
            else
            {
                btnNextYear.Enabled = true;
            }

        }
        public string yearValue()
        {
            return sYearValue;
        }

        private void lblYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // EnableControl(false);
                if (this.ValueChangeEvent != null && !isMonthValueChange)
                {
                    this.ValueChangeEvent(this, e);
                    isMonthValueChange = false;
                }
               // EnableControl(true);

                if (Convert.ToInt32(sYearValue) >= DateTime.Now.Year)
                {
                    this.btnNextYear.Enabled = false;
                }
                else
                {
                    this.btnNextYear.Enabled = true;
                    this.btnNextYear.Focus();
                }

            }
            catch (Exception)
            {
              //  EnableControl(true);
            }

        }

        public void SetShortName(string _sYearValue, string _sMonthValue)
        {
            sYearValue = _sYearValue;
            sMonthValue = _sMonthValue;
            setDisplay();
            //lblYear.Text = sYearValue.ToString();
            //lblMonth.Text = _arrMonthShortName[Convert.ToInt32(sMonthValue) - 1].ToString();
        }

        #endregion

        private void cmdStatus_Click(object sender, EventArgs e)
        {
            if (OnButtonDetailClick != null)
            {
                OnButtonDetailClick(_model, sYearValue);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
