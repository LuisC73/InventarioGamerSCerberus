using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioGamerSCerberus.Pages;

namespace InventarioGamerSCerberus
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Products();
        }

        public void Home()
        {
            panelVisor.Controls.Clear();
        }

        #region OpenControls

        private void Products()
        {
            panelVisor.Controls.Clear();
            ProductsControl ctlProducts = new ProductsControl();
            ctlProducts.Dock = DockStyle.Fill;
            panelVisor.Controls.Add(ctlProducts);
            ctlProducts.Show();
            lblpage.Text = "Products";
        }

        private void Users()
        {
            panelVisor.Controls.Clear();
            UsersControl ctlUsers = new UsersControl();
            ctlUsers.Dock = DockStyle.Fill;
            panelVisor.Controls.Add(ctlUsers);
            ctlUsers.Show();
            lblpage.Text = "Users";
        }

        #endregion

        private void btnHome_Click(object sender, EventArgs e)
        {
            Home();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users();
        }
    }
}
