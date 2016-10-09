using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HummanResorser
{

    /// <summary>
    /// هنا يتم حفظ معلومات المتطوع المقيم من الأسائلة و النتيجة
    /// </summary>
  public  class vitelAssingInformation :IaddName
    {

           List<int> IdQustion = new List<int>();

           List<int> Resuit    = new List<int>();
        List<int> mark = new List<int>();
        int idInformation = 0;
           int IdForm = 0;
        List<ValuationForm> ValuationFormall = new List<ValuationForm>();

        public int count { private set; get; }

        public int GetidInformation()
        {

            return idInformation;
        }

        public float GetResut()
        {
            
            float AllMark = 0;
            float Mark = 0;
            for (int i = 0; i < mark.Count; i++)
            {
                AllMark += (Resuit[i] * (mark[i] / 100f))  ;
                Mark += (mark[i] / 100f);
            }

            AllMark /= Mark;
            return AllMark;
        }
        public vitelAssingInformation(List<int> IdQustion, List<int> Resuit ,int idInformation, int IdForm) {
            this.IdQustion = IdQustion;
            this.Resuit = Resuit;
            this.idInformation = idInformation;
            count = IdQustion.Count;
            this.IdForm = IdForm;
            List<ValuationForm> ValuationFormall = ValuationForm.GetAllbyIdValuationname(IdForm);
            mark.Clear();
            foreach (ValuationForm item in ValuationFormall)
            {
                mark.Add(item.mark);

            }

        }
        public vitelAssingInformation (int idInformation )
        {
            this.idInformation = idInformation;
      
        }
        /// <summary>
        /// إضافة تقيم مع أي دي السؤال في قاعدة البيانات
        /// </summary>
        /// <param name="IdQustion">id السؤال</param>
        /// <param name="Resuit">النتيجة التقيم</param>
        public void Addresuit (int IdQustion , int Resuit)
        {
            this.IdQustion.Add(IdQustion);
            this.Resuit.Add(Resuit);
            this.count = this.IdQustion.Count;
        }
        public int retuIdQustion(int index)
        {
            if (index >= 0 && IdQustion.Count > index)
                return IdQustion[index];
            else
                return 0;
        }
        public int retuResuit(int index)
        {
            if (index >= 0 && Resuit.Count > index)
                return Resuit[index];
            else
                return 0;
        }
        public XDocument XDocumentconvert ()
        {
            XDocument XDocument = new XDocument(new XElement("Asset"));

            XElement Resuit = new XElement("Resuit");
           
            for (int i = 0; i < this.IdQustion.Count; i++)
            {
               
                Resuit.Add(new XElement("R" + i.ToString(), this.Resuit[i].ToString()));

            }

        
            XDocument.Root.Add(Resuit);
       
            return XDocument;
        }
        public int GetIDform()
        {
            return IdForm;

        }

        public string RetunNameString()
        {
            return "no name";
        }

        public int RetunIdNumber()
        {
            return this.idInformation;
        }
    }
}
