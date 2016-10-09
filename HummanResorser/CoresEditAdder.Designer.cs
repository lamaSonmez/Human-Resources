namespace HummanResorser
{
    partial class CoresEditAdder
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.comboBoxEx2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.Result = new DevComponents.Editors.DoubleInput();
            this.NumberOfdayregest = new DevComponents.Editors.IntegerInput();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.Result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfdayregest)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(356, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(58, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "وصف الدورة";
            // 
            // comboBoxEx2
            // 
            this.comboBoxEx2.DisplayMember = "Text";
            this.comboBoxEx2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx2.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx2.FormattingEnabled = true;
            this.comboBoxEx2.ItemHeight = 16;
            this.comboBoxEx2.Location = new System.Drawing.Point(14, 1);
            this.comboBoxEx2.Name = "comboBoxEx2";
            this.comboBoxEx2.Size = new System.Drawing.Size(336, 22);
            this.comboBoxEx2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx2.TabIndex = 4;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(354, 57);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(58, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "النتيجة";
            this.labelX3.Click += new System.EventHandler(this.labelX3_Click);
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(354, 29);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(58, 23);
            this.labelX5.TabIndex = 7;
            this.labelX5.Text = "عدد الأيام";
            // 
            // Result
            // 
            this.Result.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.Result.BackgroundStyle.Class = "DateTimeInputBackground";
            this.Result.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Result.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.Result.ForeColor = System.Drawing.Color.Black;
            this.Result.Increment = 1D;
            this.Result.Location = new System.Drawing.Point(190, 57);
            this.Result.MaxValue = 100D;
            this.Result.MinValue = 0D;
            this.Result.Name = "Result";
            this.Result.ShowUpDown = true;
            this.Result.Size = new System.Drawing.Size(158, 22);
            this.Result.TabIndex = 3;
            this.Result.Value = 80D;
            // 
            // NumberOfdayregest
            // 
            this.NumberOfdayregest.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.NumberOfdayregest.BackgroundStyle.Class = "DateTimeInputBackground";
            this.NumberOfdayregest.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NumberOfdayregest.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.NumberOfdayregest.ForeColor = System.Drawing.Color.Black;
            this.NumberOfdayregest.Location = new System.Drawing.Point(190, 29);
            this.NumberOfdayregest.MaxValue = 30;
            this.NumberOfdayregest.MinValue = 0;
            this.NumberOfdayregest.Name = "NumberOfdayregest";
            this.NumberOfdayregest.ShowUpDown = true;
            this.NumberOfdayregest.Size = new System.Drawing.Size(158, 22);
            this.NumberOfdayregest.TabIndex = 2;
            this.NumberOfdayregest.Value = 5;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(83, 85);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(239, 30);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "إضافة دورة ";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxEx1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.ForeColor = System.Drawing.Color.Black;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 16;
            this.comboBoxEx1.Location = new System.Drawing.Point(12, 1);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(338, 22);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 1;
            this.comboBoxEx1.Visible = false;
            this.comboBoxEx1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxEx1_KeyDown);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(354, 0);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 23);
            this.labelX1.TabIndex = 14;
            this.labelX1.Text = "اسم المتطوع";
            this.labelX1.Visible = false;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(12, 28);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(66, 33);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.Symbol = "";
            this.buttonX2.SymbolColor = System.Drawing.Color.Red;
            this.buttonX2.TabIndex = 0;
            this.buttonX2.TabStop = false;
            this.buttonX2.Text = "بحث";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // CoresEditAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 117);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.comboBoxEx1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.NumberOfdayregest);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.comboBoxEx2);
            this.Controls.Add(this.labelX2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "CoresEditAdder";
            this.RenderFormIcon = false;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دورة";
            this.Load += new System.EventHandler(this.CoresEditAdder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfdayregest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.Editors.DoubleInput Result;
        private DevComponents.Editors.IntegerInput NumberOfdayregest;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
    }
}