namespace HummanResorser
{
    partial class IdVitel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // IdVitel
            // 
            // 
            // 
            // 
            this.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.Mask = "AAA-9999";
            this.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Text = "_______";
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePrompt;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IdVitel_KeyPress);
            this.Leave += new System.EventHandler(this.IdVitel_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
