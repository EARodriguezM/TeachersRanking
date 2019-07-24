using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRESENTATION
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }

        private void MainUI_Load(object sender, EventArgs e)
        {
            Renderers();
            MainUIDesign();
            MainHeaderFormat();
            MainHeaderSetColor();
            MainHeaderContent();
        }

        int SizeWidth, SizeHeight;

        private void MainUIDesign()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            SizeWidth = Screen.PrimaryScreen.WorkingArea.Size.Width;
            SizeHeight = Screen.PrimaryScreen.WorkingArea.Size.Height;
        }

        private void MainHeaderFormat()
        {

            #region Header
            Header.Dock = DockStyle.Top;
            Header.Height = 50;
            #endregion

            #region BotBorder
            BotBorder.Dock = DockStyle.Bottom;
            BotBorder.Height = 2;
            #endregion

            #region MainSideBar
            MainSideBar.Dock = DockStyle.Left;
            MainSideBar.Width = Convert.ToInt32(SizeWidth * 0.12);
            MainSideBar.BorderStyle = BorderStyle.FixedSingle;
            MainSideBar.AutoScroll = true;
            #endregion

            int headerHeight = Header.Height;

            #region Logo
            Logo.Anchor = AnchorStyles.Left & AnchorStyles.Top;
            Logo.Width = MainSideBar.Width;
            Logo.Height = headerHeight;
            #endregion

            #region NavigationBar
            NavigationBar.Anchor = AnchorStyles.Right & AnchorStyles.Top;
            NavigationBar.Width = Convert.ToInt32(SizeWidth * 0.88);
            NavigationBar.Height = headerHeight;
            NavigationBar.Location = new Point(Logo.Width, 0);

            #region SideBarToggle
            SideBarToggle.Width = 42;
            SideBarToggle.Height = headerHeight;
            SideBarToggle.Location = new Point(0, 0);
            #endregion

            #region NavigationBarMenu
            NavigationBarMenu.Anchor = AnchorStyles.Right & AnchorStyles.Top;
            NavigationBarMenu.Width = Convert.ToInt32(NavigationBar.Width * 0.203);
            NavigationBarMenu.Height = headerHeight;
            int navigationBarMenuLocationX = (NavigationBar.Width - NavigationBarMenu.Width);
            NavigationBarMenu.Location = new Point(navigationBarMenuLocationX, 0);

            #region Btn_Comment
            Btn_Comment.Width = Convert.ToInt32(NavigationBarMenu.Width / 3);
            Btn_Comment.Height = headerHeight;
            Btn_Comment.Location = new Point(0, 0);
            #endregion

            #region MultiContainerInNBM
            MultiContainerInNBM.Width = Convert.ToInt32((2 * NavigationBarMenu.Width) / 3);
            MultiContainerInNBM.Height = headerHeight;
            MultiContainerInNBM.Location = new Point(Btn_Comment.Width, 0);
            MultiContainerInNBM.Controls.Add(Btn_Register);
            MultiContainerInNBM.Controls.Add(Btn_Login);

            #region Btn_Register
            Btn_Register.Width = Convert.ToInt32(MultiContainerInNBM.Width / 2);
            Btn_Register.Height = headerHeight;
            Btn_Register.Location = new Point(0, 0);
            #endregion
            #region Btn_Login
            Btn_Login.Width = Convert.ToInt32(MultiContainerInNBM.Width / 2);
            Btn_Login.Height = headerHeight;
            Btn_Login.Location = new Point(Btn_Register.Width, 0);
            #endregion

            #endregion
            #endregion

            #endregion

        }

        private void MainHeaderSetColor()
        {
            Header.BackColor = Color.FromArgb(0, 166, 90);

            BotBorder.BackColor = Color.FromArgb(22, 196, 217);

            MainSideBar.BackColor = Color.FromArgb(34, 45, 50);

            Logo.BackColor = Color.FromArgb(0, 141, 76);

            SideBarToggle.BackColor = Color.FromArgb(0, 141, 76);

            NavigationBar.BackColor = Color.FromArgb(0, 166, 90);

            NavigationBarMenu.BackColor = Color.Transparent;            

            MultiContainerInNBM.BackColor = Color.Transparent;

            Btn_Comment.BackColor = Color.Transparent;

            Btn_Register.BackColor = Color.Transparent;

            Btn_Login.BackColor = Color.Transparent;
        }
        
        private void MainHeaderContent()
        {
            Btn_Comment.Text = "Comentar";
            Btn_Register.Text = "Registrar";
            Btn_Login.Text = "Ingresar";
        }

        private void Renderers()
        {
            
        }
    }
}
