using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioGamerSCerberus.Models;

namespace InventarioGamerSCerberus.Pages
{
    public partial class UsersForm : Form
    {

        public int? id_user;
        Users table;
        public UsersForm(int? id_user = null)
        {
            InitializeComponent();

            this.id_user = id_user;
            if (id_user != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            using (GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
            {
                table = db.Users.Find(id_user);
                txtName.Text = table.name;
                txtEmail.Text = table.email;
                txtPassword.Text = table.password;
                txtAddress.Text = table.address;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
            {
                if (id_user == null)
                    table = new Users();

                table.name = txtName.Text;
                table.email = txtEmail.Text;
                table.password = txtPassword.Text;
                table.address = txtAddress.Text;


                if (id_user == null)
                    db.Users.Add(table);
                else
                {
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;

                }

                db.SaveChanges();

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
