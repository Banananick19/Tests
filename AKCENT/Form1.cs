using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AKCENT.Cor;
using AKCENT.Domain;

namespace AKCENT
{
    public partial class Form1 : Form
    {
        private AkcentApplicationContext _context;
        private string _statusToSearch = null;
        private string _depToSearch = null;
        private string _postToSearch = null;
        private string _textSearch = null;
        private DateTime _dateSearchFrom;
        private DateTime _dateSearchTo;
        private string _searchStatusForStatistic = "Все сотрудники за период";


        public Form1(AkcentApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            dateTimePicker2.Value = dateTimePicker1.MinDate;
            button1.Visible = false;
            UpdateGrid(true);
        }

        public void UpdateStatistic()
        {
            label1.Text = "";
            var personsEmployedInPeriod = 
                _context.Persons.Where(
                    p => p.date_employ >= _dateSearchFrom && p.date_employ <= _dateSearchTo 
                                                          && (_searchStatusForStatistic == "Все сотрудники за период" || p.Status.Name == _searchStatusForStatistic)).ToList();
            var personsUnemployedInPeriod = 
                _context.Persons.Where(
                    p => p.date_uneploy >= _dateSearchFrom && p.date_uneploy <= _dateSearchTo
                                                           && (_searchStatusForStatistic == "Все сотрудники за период" || p.Status.Name == _searchStatusForStatistic)).ToList();
            if (!personsEmployedInPeriod.Any() && !personsUnemployedInPeriod.Any())
            {
                button1.Visible = false;
                label1.Text = "Нет статистики за заданный период";
                return;
            }

            button1.Visible = true;
            if (button1.Text == "Принято на работу")
            {
                var text = new StringBuilder();
                foreach (var person in personsEmployedInPeriod.GroupBy(p => new DateTime(p.date_employ.Value.Year, p.date_employ.Value.Month, p.date_employ.Value.Day)))
                {
                    text.Append($"{(person.Key.ToString($"dd/MM/yy"))} - принято {person.Key}");
                    text.AppendLine();
                }

                label1.Text = text.ToString();
                return;
            }
            if (button1.Text == "Уволено")
            {
                var text = new StringBuilder();
                foreach (var person in personsUnemployedInPeriod.GroupBy(p => new DateTime(p.date_employ.Value.Year, p.date_employ.Value.Month, p.date_employ.Value.Day)))
                {
                    text.Append($"{(person.Key.ToString($"dd/MM/yy"))} - Уволено {person.Key}");
                    text.AppendLine();
                }

                label1.Text = text.ToString();
            }
        }

        public void UpdateGrid(bool firstUpdate = false)
        {
            if (firstUpdate)
            {
                listBox1.Items.Add("Все сотрудники за период");
                foreach (var status in _context.Status.ToList())
                {
                    listBox1.Items.Add(status.Name);
                }
            }
            dataGridView1.Rows.Clear();
            var persons = _context.Persons
                .Include(p => p.Dep)
                .Include(p => p.Status)
                .Include(p => p.Post)
                .Where(p => _depToSearch == null || p.Dep.Name == _depToSearch)
                .Where(p => _statusToSearch == null || p.Status.Name == _statusToSearch)
                .Where(p => _postToSearch == null || p.Post.Name == _postToSearch).ToList()
                .Where(p => string.IsNullOrEmpty(_textSearch) || p.GetFullName().ToLower().Contains(_textSearch.ToLower())).ToList();
            var i = 0;
            foreach (var person in persons)
            {
                dataGridView1.Rows.Add(person.GetFullName(),
                    person.Status.Name, person.Dep.Name,
                    person.Post.Name, person.date_employ, person.date_uneploy);
                if (person.date_uneploy != null)
                {
                    dataGridView1[0, i].Style.BackColor = Color.Red;
                }
                i++;
            }

            dataGridView1.Columns[1].DefaultCellStyle.BackColor = _statusToSearch == null ? Color.White : Color.Aqua;
            dataGridView1.Columns[3].DefaultCellStyle.BackColor = _postToSearch == null ? Color.White : Color.Aqua;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = _depToSearch == null ? Color.White : Color.Aqua;
            if (dateTimePicker1.Value == DateTime.MinValue)
            {
                dateTimePicker1.Value = persons.ToList().Select(p => p.date_employ).Min() ?? DateTime.MinValue;
            }
            if (dateTimePicker2.Value == DateTime.MinValue)
            {
                dateTimePicker2.Value = persons.ToList().Select(p => p.date_employ).Max() ?? DateTime.MaxValue;
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 1 || e.ColumnIndex > 3) return;
            var type = (string)dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            switch (e.ColumnIndex)
            {
                case 1:
                    _statusToSearch = _statusToSearch == null ? type : null;
                    _depToSearch = null;
                    _postToSearch = null;

                    break;
                case 2:
                    _depToSearch = _depToSearch == null ? type : null;
                    _statusToSearch = null;
                    _postToSearch = null;
                    break;
                case 3:
                    _postToSearch = _postToSearch == null ? type : null;
                    _depToSearch =  null;
                    _statusToSearch = null;
                    break;
                        
            }
            UpdateGrid();
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _textSearch = textBox1.Text;
            UpdateGrid();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _dateSearchFrom = dateTimePicker1.Value;
            UpdateStatistic();
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            _dateSearchTo = dateTimePicker2.Value;
            UpdateStatistic();       
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _searchStatusForStatistic = (string)listBox1.Items[listBox1.SelectedIndex];
            UpdateStatistic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = button1.Text == "Принято на работу" ? "Уволено" : "Принято на работу";
            UpdateStatistic();
        }
    }
}
