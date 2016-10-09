using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace HummanResorser
{
    public partial class SelectInformationDate : DevComponents.DotNetBar.Metro.MetroForm
    {

        public List<string> list = new List<string>();
        public ParamterrMakeSql ParamterrMakeSql1 = new ParamterrMakeSql();


        public SelectInformationDate()
        {
            InitializeComponent();
        }

        private void SelectInformationDate_Load(object sender, EventArgs e)
        {
            ParamterrMakeSql1 = new ParamterrMakeSql();
        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (first_name.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.first_name, "", ParamterrMakeSql.Condtion.like, ParamterrMakeSql.Between.And);
            if (Last_name.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Last_name, "", ParamterrMakeSql.Condtion.like, ParamterrMakeSql.Between.And);
            if (Father_name.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Father_name, "", ParamterrMakeSql.Condtion.like, ParamterrMakeSql.Between.And);
            if (Mather_name.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Mather_name, "", ParamterrMakeSql.Condtion.like, ParamterrMakeSql.Between.And);
            if (natiol_id.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.natiol_id,0, ParamterrMakeSql.Condtion.Eqial, ParamterrMakeSql.Between.And);
            if (Id_course_no.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Id_course, 0, ParamterrMakeSql.Condtion.Eqial, ParamterrMakeSql.Between.And);
            if (Id_course.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Id_course, 0, ParamterrMakeSql.Condtion.MoreThen, ParamterrMakeSql.Between.And);
            if (image.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.image, DBNull.Value, ParamterrMakeSql.Condtion.isnulldb, ParamterrMakeSql.Between.And);
            if (Image_id_nationl1.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Image_id_nationl1, DBNull.Value, ParamterrMakeSql.Condtion.isnulldb, ParamterrMakeSql.Between.And);
            if (data_barthday.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.data_barthday, new DateTime(1800,1,1), ParamterrMakeSql.Condtion.lessThen, ParamterrMakeSql.Between.And);
            if (data_regs.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.data_regs, new DateTime(1800, 1, 1), ParamterrMakeSql.Condtion.lessThen, ParamterrMakeSql.Between.And);
            if (Boold_id.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Boold_id, -1, ParamterrMakeSql.Condtion.Eqial, ParamterrMakeSql.Between.And);
            if (natiol_id.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.natiol_id, 0, ParamterrMakeSql.Condtion.Eqial, ParamterrMakeSql.Between.And);
            if (Image_id_nationl2.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Image_id_nationl2, DBNull.Value, ParamterrMakeSql.Condtion.isnulldb, ParamterrMakeSql.Between.And);
            if (Hanei_whare1.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Hanei_whare1, "", ParamterrMakeSql.Condtion.like, ParamterrMakeSql.Between.And);
            if (Hanei_whare.Checked)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Hanei_whare, "", ParamterrMakeSql.Condtion.like, ParamterrMakeSql.Between.And);
            if (study.Text.Trim() !="")
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.study, ClassDataGridViewDo.LograthemChangEverAleffToAll(study.Text,true), ParamterrMakeSql.Condtion.WhildCart, ParamterrMakeSql.Between.And);
            if (yearstudy.SelectedIndex != -1)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.yearstudy, yearstudy.SelectedIndex, ParamterrMakeSql.Condtion.Eqial, ParamterrMakeSql.Between.And);
            if (Boold_id1.SelectedIndex != -1)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.Boold_id, Boold_id1.SelectedIndex, ParamterrMakeSql.Condtion.Eqial, ParamterrMakeSql.Between.And);
            if (birthdayFrom.Value != DateTime.MinValue)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.data_barthday, birthdayFrom.Value, ParamterrMakeSql.Condtion.EqMoreThen, ParamterrMakeSql.Between.And);
            if (birthdayTo.Value != DateTime.MinValue)
                ParamterrMakeSql1.AdderParmtaer(Vitl.vitl.data_barthday, birthdayTo.Value, ParamterrMakeSql.Condtion.EqlessThen, ParamterrMakeSql.Between.And);
     

            DialogResult = DialogResult.OK;

           
        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void image_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}