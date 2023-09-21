using System.Globalization;
using System.Resources;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateUIWithNewCulture();
        }

        /// <summary>
        /// 更新UI元件語系資料
        /// </summary>
        private void UpdateUIWithNewCulture()
        {
            this.Text = i18N.Form1.FORM_TITLE;
            label1.Text = i18N.Form1.LABEL_TEXT;
            button1.Text = i18N.Form1.BTN_TEXT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            decimal amt = 12345.67m;
            var nl = Environment.NewLine;
            string msg = $"{i18N.Form1.MSG_TEXT}：{nl}{i18N.Form1.DATETIME}：{dt:D}{nl}{i18N.Form1.AMOUNT}：{amt:C}";
            MessageBox.Show(msg, i18N.Form1.MSG_TITLE);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 切換語系後要重開，不然UI上不會直接生效
            string language = comboBox1.SelectedItem.ToString()!;
            CultureInfo? culture = CultureInfo.GetCultureInfo(language);

            // 以下兩個設定好像擇一即可，不清楚差異，然後設定完記得更新 UI

            // 設定應用程序的預設文化資訊
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            // 設定應用程序的文化資訊
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            UpdateUIWithNewCulture();
        }
    }
}