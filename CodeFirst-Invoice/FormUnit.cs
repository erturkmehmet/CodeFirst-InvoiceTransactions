using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst_Invoice
{
    public partial class FormUnit : Form
    {
        public FormUnit()
        {
            InitializeComponent();
        }
        InvoiceContext db = new InvoiceContext();
        private static int choosenUnitID;

        private void FormUnit_Load(object sender, EventArgs e)
        {
            FillUnit();
        }
        private void FillUnit()
        {
            dgvUnit.DataSource = db.Units.Select(x => new
            {
                x.UnitID,
                x.UnitName
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Unit u = new Unit();
                u.UnitName = txtUnitName.Text;
                db.Units.Add(u);
                db.SaveChanges();
                FillUnit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Unit u = db.Units.Where(x => x.UnitID == choosenUnitID).Select(x => x).FirstOrDefault();
                u.UnitName = txtUnitName.Text;
                db.SaveChanges();
                FillUnit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnit.SelectedRows.Count > 1)
                {
                    MessageBox.Show("For multiple delete please choose 'Delete Selected Items'");
                }
                else
                {
                    Unit u = db.Units.Where(x => x.UnitID == choosenUnitID).Select(x => x).FirstOrDefault();
                    db.Units.Remove(u);
                    db.SaveChanges();
                    FillUnit();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnMultipleDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnit.SelectedRows.Count < 2)
                {
                    MessageBox.Show("For the delete please choose 'Delete'");
                }
                else
                {
                    foreach (DataGridViewRow item in dgvUnit.SelectedRows)
                    {

                        choosenUnitID = Convert.ToInt32(item.Cells[0].Value);
                        Unit u = db.Units.Find(choosenUnitID);
                        db.Units.Remove(u);
                    }
                }
                db.SaveChanges();
                FillUnit();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosenUnitID = Convert.ToInt32(dgvUnit.CurrentRow.Cells[0].Value);
                Unit u = db.Units.Where(x => x.UnitID == choosenUnitID).FirstOrDefault();
                txtUnitName.Text = u.UnitName;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

