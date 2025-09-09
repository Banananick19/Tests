using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AKCENT.Cor;
using AKCENT.Domain;

namespace AKCENT
{
    public partial class MyForm : Form
    {
        public MyForm(AkcentApplicationContext context)
        {
            
            // Create and configure DataGridView

            foreach (var person in context.Persons.Include(p => p.Status).Include(p => p.Dep).Include(p => p.Post).ToList())
            {
                dataGridView.Rows.Add(person.GetFullName(), person.Status.Name, person.Post.Name, person.Dep.Name,
                    person.date_employ, person.date_uneploy);
            }
           
        }


        private void checkBoxIntern_CheckedChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
        private void checkBoxWorker_CheckedChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void checkBox3Main_CheckedChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}