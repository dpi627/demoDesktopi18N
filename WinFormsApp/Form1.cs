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
        /// ��sUI����y�t���
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
            string msg = $"{i18N.Form1.MSG_TEXT}�G{nl}{i18N.Form1.DATETIME}�G{dt:D}{nl}{i18N.Form1.AMOUNT}�G{amt:C}";
            MessageBox.Show(msg, i18N.Form1.MSG_TITLE);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // �����y�t��n���}�A���MUI�W���|�����ͮ�
            string language = comboBox1.SelectedItem.ToString()!;
            CultureInfo? culture = CultureInfo.GetCultureInfo(language);

            // �H�U��ӳ]�w�n���ܤ@�Y�i�A���M���t���A�M��]�w���O�o��s UI

            // �]�w���ε{�Ǫ��w�]��Ƹ�T
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            // �]�w���ε{�Ǫ���Ƹ�T
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            UpdateUIWithNewCulture();
        }
    }
}