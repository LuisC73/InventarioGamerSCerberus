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
    public partial class UsersControl : UserControl
    {
        public UsersControl()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            UsersForm addUser = new UsersForm();
            addUser.ShowDialog();

            actualizarTabla();
        }

        private void actualizarTabla()
        {
            using (GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
            {
                var lista = from d in db.Users
                            select d;

                if (!txtSearch.Text.Trim().Equals(""))
                {
                    lista = lista.Where(d => d.name.Contains(txtSearch.Text.Trim()));
                }

                gridUsers.DataSource = lista.ToList();
            }
        }

        private void UsersControl_Load(object sender, EventArgs e)
        {
            actualizarTabla();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(gridUsers.Rows[gridUsers.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {

                return null;
            }


        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            int? id_user = GetId();

            if (id_user != null)
            {
                UsersForm addUser = new UsersForm(id_user);
                addUser.ShowDialog();

                actualizarTabla();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int? id_user = GetId();

            if (id_user != null)
            {
                using (GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
                {
                    Users table = db.Users.Find(id_user);
                    db.Users.Remove(table);

                    db.SaveChanges();
                }

                actualizarTabla();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            actualizarTabla();
        }
    }
}
