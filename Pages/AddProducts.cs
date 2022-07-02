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
    public partial class AddProducts : Form
    {

        public int? id;
        Products table;
        public AddProducts(int? id=null)
        {
            InitializeComponent();

            this.id = id;
            if(id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            using (GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
            {
                table = db.Products.Find(id);
                txtName.Text = table.name;
                txtValue.Text = table.value.ToString();
                txtBrand.Text = table.brand.ToString();
                txtCategory.Text = table.category;

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
            {
                if(id==null)
                    table = new Products();

                table.name = txtName.Text;
                table.value = Convert.ToInt32(txtValue.Text);
                table.brand = Convert.ToInt32(txtBrand.Text);
                table.category = txtCategory.Text;


                if (id == null)
                    db.Products.Add(table);
                else
                {
                    db.Entry(table).State = System.Data.Entity.EntityState.Modified;

                }

                db.SaveChanges();

                this.Close();
            }
        }
    }
}
