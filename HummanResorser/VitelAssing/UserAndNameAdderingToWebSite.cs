using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HummanResorser
{
    public partial class UserAndNameAdderingToWebSite :DevComponents.DotNetBar.Metro.MetroForm
    {

        List< Vitl > Vite = new List<Vitl>();
        DownloadDataFromWebCliend DownloadDataFromWebCliend = new DownloadDataFromWebCliend();
        List<UserNameGetWebSite> UserNameGetWebSite1 = new List<UserNameGetWebSite>();
        public UserAndNameAdderingToWebSite()
        {
            InitializeComponent();
         
        }

        private void UserAndNameAdderingToWebSite_Load(object sender, EventArgs e)
        {
            try
            {
                DownloadDataFromWebCliend.LoginSet("m5524512", "m5524512");

            }
            catch (Exception ex)
            {
                ErrorClass.SaveErrorFile(ex, true);

                this.Close();
            }
            UserNameGetWebSite1= DownloadDataFromWebCliend.GetInfrmationofdateGet();
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx2, Valuationname.Valuationnamelist);
            ClassDataGridViewDo.DataGridAddVuleComBoxEx(comboBoxEx1, UserNameGetWebSite1);

        }

        private async void buttonX1_Click(object sender, EventArgs e)
        {
            SerchNameBynameRetu SerchNameBynameRetu1 = new SerchNameBynameRetu();

            if (SerchNameBynameRetu1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Vite.Add(new Vitl(SerchNameBynameRetu1.Id));

                ClassDataGridViewDo.DataGridEnterGridSerc(dataGridViewX1, Vite[Vite.Count - 1], await Team.GetByIdVil(Vite[Vite.Count - 1].id, true));
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            List<ValuationForm> ValuationForm1 = ValuationForm.GetAllbyIdValuationname(Valuationname.Valuationnamelist[comboBoxEx2.SelectedIndex].id);
            XDocument XDocument = new XDocument(new XElement("Asset"));

         

            XDocument.Root.Add(new XElement("DateTime", DateTime.Now.ToShortDateString()));
            XDocument.Root.Add(new XElement("IdForm", Valuationname.Valuationnamelist[comboBoxEx2.SelectedIndex].id.ToString()));
            XElement Qustion = new XElement("Qustion");
            XElement QustionId = new XElement("QustionId");
            XElement AllName = new XElement("AllName");
            XElement AllNameId = new XElement("AllNameId");
            for (int i = 0; i < ValuationForm1.Count; i++)
            {
                Qustion.Add(new XElement("Q" +i.ToString(),Qustiones.Qustioneslist[ClassDataGridViewDo.RetunIndexByIdSech( ValuationForm1[i].id_qustion , Qustiones.Qustioneslist)].name));
                QustionId.Add(new XElement("Q" + i.ToString(), Qustiones.Qustioneslist[ClassDataGridViewDo.RetunIndexByIdSech(ValuationForm1[i].id_qustion, Qustiones.Qustioneslist)].id.ToString()));

            }
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                AllNameId.Add( new XElement (
                    "N" + i.ToString(), dataGridViewX1.Rows[i].Cells[0].Value.ToString()));
                AllName.Add(new XElement(

                        "N" + i.ToString(), dataGridViewX1.Rows[i].Cells[1].Value.ToString()));
            }
            XDocument.Root.Add(Qustion);
            XDocument.Root.Add(QustionId);
            XDocument.Root.Add(AllName);
            XDocument.Root.Add(AllNameId);
            XDocument.Root.Add(new XElement("idOprtion", "Deb"));
            DownloadDataFromWebCliend.RetXmlFile(DownloadDataFromWebCliend.EnumGetXML.MakeAssetGet, XDocument, UserNameGetWebSite1[comboBoxEx1.SelectedIndex].id);
        }
    }
}
