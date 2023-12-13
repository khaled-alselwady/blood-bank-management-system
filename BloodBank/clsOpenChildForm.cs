using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank_WindowsForms_
{
    public class clsOpenChildForm
    {
        private static Form activeForm = null;
        private static IconButton currentButton;

        private static void ActivateButton(object btnSender, Panel panelMenu)
        {
            if (btnSender != null)
            {
                if (currentButton != (IconButton)btnSender)
                {


                    DisableMenuButton(panelMenu);

                    currentButton = (IconButton)btnSender;
                    currentButton.BackColor = Color.MidnightBlue;
                    currentButton.IconColor = Color.FromArgb(245, 47, 84);
                    currentButton.ForeColor = Color.Gainsboro;
                }
            }
        }

        private static void DisableMenuButton(Panel panelMenu)
        {
            IconButton iconbutton = new IconButton();

            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    iconbutton = (IconButton)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(11, 7, 17);
                    previousBtn.ForeColor = Color.Gainsboro;
                    iconbutton.IconColor = Color.FromArgb(245, 47, 84);
                }
            }
        }


        public static void OpenChildFormInPanel(Form childForm, Panel panelChildForm, Label lblTitleChildForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitleChildForm.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitleChildForm.Text = childForm.Text;
            }

        }

        public static void OpenChildFormInPanel(Form childForm, Panel panelChildForm, Label lblTitleChildForm, object btnSender, Panel panelMenu)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender, panelMenu);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitleChildForm.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitleChildForm.Text = childForm.Text;
            }

        }

    }
}
