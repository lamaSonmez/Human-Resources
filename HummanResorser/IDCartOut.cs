using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HummanResorser
{
    public partial class IDCartOut : DevComponents.DotNetBar.Metro.MetroForm
    {
        List<int> id_information = new List<int>();
        List<Vitl> Vitl1 = new List<Vitl>();
        List<bool> ifHaveCores72 = new List<bool>();
        List<Team> Team1 = new List<Team>();
        public IDCartOut(List<int> id_information )
        {
            InitializeComponent();

            this.id_information = id_information;


        }

        private async void IDCartOut_Load(object sender, EventArgs e)
        {
            foreach (int item in id_information)
            {
                Vitl dw2 = new Vitl();

               await dw2.MakeAsn(item);

                Vitl1.Add(dw2);
                Team1.Add((await (Team.GetByIdVil(item, true)))[0]);
                ifHaveCores72.Add(await Couress.GetIsItHaveCouresByIdInformation(item, 3, true));

                dataGridViewX1.Rows.Add(Vitl1[Vitl1.Count - 1].id, "ALP-" + ClassConvert.ConvIdNumberAdderZero4Digit(Vitl1[Vitl1.Count - 1].Id_course), Vitl1[Vitl1.Count - 1].first_name + " " + Vitl1[Vitl1.Count - 1].Last_name, ClassConvert.ConvStringBoloed(Vitl1[Vitl1.Count - 1].Boold_id), Jop.JopStatic[ClassDataGridViewDo.RetunIndexByIdSech(Team1[Team1.Count - 1].Id_Jop_Ta, Jop.JopStatic)].NvacherWord, Jop.JopStatic[ClassDataGridViewDo.RetunIndexByIdSech(Team1[Team1.Count - 1].Id_Jop_Ta, Jop.JopStatic)].NvacherWordEng,
                  Vitl1[Vitl1.Count - 1].data_barthday.Year.ToString(), Vitl1[Vitl1.Count - 1].nameEnglish);
            }
            MegBox.Show("إنتها");

        }

        private async void buttonX2_Click(object sender, EventArgs e)
        {

            using (FolderBrowserDialog ShowWhereSaveYouPhoto = new FolderBrowserDialog())
            {
                if (ShowWhereSaveYouPhoto.ShowDialog() == DialogResult.OK)
                {
                    string fe = ShowWhereSaveYouPhoto.SelectedPath;
                    await Task.Run(() =>
                   {

                       for (int i = 0; i < Vitl1.Count; i++)
                       {
                           
                               Vitl Vitlnew = new Vitl(Vitl1[i].id);
                               if (Vitlnew.image != null)
                               {
                               dataGridViewX1.Rows[i].Cells[8].Value = "موجود";
                                   Vitlnew.image.Save(fe + "\\" + Vitlnew.first_name + " " + Vitlnew.Last_name + ".jpg");
                               }
                               else
                               {
                               dataGridViewX1.Rows[i].Cells[8].Value = "غير موجود";
                               }

                               Vitlnew.Dispose();
                           }
                       

                   });
                }
            }
        }

        private void SaveImageAll()
        {
            
        }

        private async void buttonX3_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog ShowWhereSaveYouPhoto = new FolderBrowserDialog())
            {
                if (ShowWhereSaveYouPhoto.ShowDialog() == DialogResult.OK)
                {
                    string fe = ShowWhereSaveYouPhoto.SelectedPath;
                    await Task.Run(() =>
                    {

                        for (int i = 0; i < Vitl1.Count; i++)
                        {

                            Vitl Vitlnew = new Vitl(Vitl1[i].id);
                            if (Vitlnew.Image_id_nationl1 != null)
                            {
                                dataGridViewX1.Rows[i].Cells[9].Value = "موجود";
                                Vitlnew.Image_id_nationl1.Save(fe + "\\" + Vitlnew.first_name + " " + Vitlnew.Last_name + "1" + ".jpg");
                            }
                            else
                            {
                                dataGridViewX1.Rows[i].Cells[9].Value = "غير موجود";
                            }
                            if (Vitlnew.Image_id_nationl2 != null)
                            {
                                dataGridViewX1.Rows[i].Cells[10].Value = "موجود";
                                Vitlnew.Image_id_nationl2.Save(fe + "\\" + Vitlnew.first_name + " " + Vitlnew.Last_name + "2" + ".jpg");
                            }
                            else
                            {
                                dataGridViewX1.Rows[i].Cells[10].Value = "غير موجود";
                            }



                            Vitlnew.Dispose();
                        }


                    });
                }
            }
        }
        }
}
