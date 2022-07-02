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
    public partial class ProductsControl : UserControl
    {
        public ProductsControl()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.ShowDialog();

            actualizarTabla();
        }

        private void ProductsControl_Load(object sender, EventArgs e)
        {
            actualizarTabla();
        }

        private void actualizarTabla()
        {
            using (GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
            {
                var lista = from d in db.Products
                            select d;
                

                if (!txtSearch.Text.Trim().Equals(""))
                {
                    lista = lista.Where(d => d.name.Contains(txtSearch.Text.Trim()));
                }

               

                gridProducts.DataSource = lista.ToList();
            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(gridProducts.Rows[gridProducts.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch 
            {

                return null;
            }


        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if(id != null)
            {
                AddProducts addProducts = new AddProducts(id);
                addProducts.ShowDialog();

                actualizarTabla();
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int? id = GetId();

            if (id != null)
            {
               using(GamerSCerberusDBEntities db = new GamerSCerberusDBEntities())
                {
                    Products table = db.Products.Find(id);
                    db.Products.Remove(table);

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
