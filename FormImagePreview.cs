using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS_Collector
{
    public partial class FormImagePreview : Form
    {
         public FormImagePreview(Image cardImage, string cardName, string expansion, string cardText, string cardNumber, string cardID)
         {
            InitializeComponent();
            //m_PictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
            m_PictureBoxPreview.Image = cardImage;

            // Set the text of each label
            m_LabelCardName.Text = $"Name: {cardName}";
            m_LabelExpansion.Text = $"Expansion: {expansion}";
            m_LabelCardText.Text = $"Text: {cardText}";
            m_LabelCardNumber.Text = $"Card Number: {cardNumber}";
            m_LabelCardID.Text = $"Card ID: {cardID}";

            this.Text = cardName + " Card Preview";
         }

    }
}
