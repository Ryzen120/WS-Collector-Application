
namespace WS_Collector
{
    partial class FormImagePreview
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
            this.m_PictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.m_LabelCardName = new System.Windows.Forms.Label();
            this.m_LabelExpansion = new System.Windows.Forms.Label();
            this.m_LabelCardText = new System.Windows.Forms.Label();
            this.m_LabelCardNumber = new System.Windows.Forms.Label();
            this.m_LabelCardID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // m_PictureBoxPreview
            // 
            this.m_PictureBoxPreview.BackColor = System.Drawing.Color.Black;
            this.m_PictureBoxPreview.Location = new System.Drawing.Point(507, 12);
            this.m_PictureBoxPreview.Name = "m_PictureBoxPreview";
            this.m_PictureBoxPreview.Size = new System.Drawing.Size(392, 543);
            this.m_PictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.m_PictureBoxPreview.TabIndex = 0;
            this.m_PictureBoxPreview.TabStop = false;
            // 
            // m_LabelCardName
            // 
            this.m_LabelCardName.AutoSize = true;
            this.m_LabelCardName.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelCardName.Location = new System.Drawing.Point(9, 73);
            this.m_LabelCardName.Name = "m_LabelCardName";
            this.m_LabelCardName.Size = new System.Drawing.Size(60, 13);
            this.m_LabelCardName.TabIndex = 1;
            this.m_LabelCardName.Text = "Card Name";
            // 
            // m_LabelExpansion
            // 
            this.m_LabelExpansion.AutoSize = true;
            this.m_LabelExpansion.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelExpansion.Location = new System.Drawing.Point(9, 116);
            this.m_LabelExpansion.Name = "m_LabelExpansion";
            this.m_LabelExpansion.Size = new System.Drawing.Size(56, 13);
            this.m_LabelExpansion.TabIndex = 2;
            this.m_LabelExpansion.Text = "Expansion";
            // 
            // m_LabelCardText
            // 
            this.m_LabelCardText.AutoSize = true;
            this.m_LabelCardText.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelCardText.Location = new System.Drawing.Point(12, 567);
            this.m_LabelCardText.MaximumSize = new System.Drawing.Size(880, 0);
            this.m_LabelCardText.Name = "m_LabelCardText";
            this.m_LabelCardText.Size = new System.Drawing.Size(53, 13);
            this.m_LabelCardText.TabIndex = 3;
            this.m_LabelCardText.Text = "Card Text";
            // 
            // m_LabelCardNumber
            // 
            this.m_LabelCardNumber.AutoSize = true;
            this.m_LabelCardNumber.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelCardNumber.Location = new System.Drawing.Point(9, 168);
            this.m_LabelCardNumber.Name = "m_LabelCardNumber";
            this.m_LabelCardNumber.Size = new System.Drawing.Size(69, 13);
            this.m_LabelCardNumber.TabIndex = 4;
            this.m_LabelCardNumber.Text = "Card Number";
            // 
            // m_LabelCardID
            // 
            this.m_LabelCardID.AutoSize = true;
            this.m_LabelCardID.ForeColor = System.Drawing.Color.Snow;
            this.m_LabelCardID.Location = new System.Drawing.Point(9, 25);
            this.m_LabelCardID.Name = "m_LabelCardID";
            this.m_LabelCardID.Size = new System.Drawing.Size(43, 13);
            this.m_LabelCardID.TabIndex = 5;
            this.m_LabelCardID.Text = "Card ID";
            // 
            // FormImagePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(917, 716);
            this.Controls.Add(this.m_LabelCardID);
            this.Controls.Add(this.m_LabelCardNumber);
            this.Controls.Add(this.m_LabelCardText);
            this.Controls.Add(this.m_LabelExpansion);
            this.Controls.Add(this.m_LabelCardName);
            this.Controls.Add(this.m_PictureBoxPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormImagePreview";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.m_PictureBoxPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox m_PictureBoxPreview;
        private System.Windows.Forms.Label m_LabelCardName;
        private System.Windows.Forms.Label m_LabelExpansion;
        private System.Windows.Forms.Label m_LabelCardText;
        private System.Windows.Forms.Label m_LabelCardNumber;
        private System.Windows.Forms.Label m_LabelCardID;
    }
}