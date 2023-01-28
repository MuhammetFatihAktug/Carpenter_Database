using Carpenter_v1.constants.colors;
using Carpenter_v1.constants.enums;
using Carpenter_v1.init;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;                   

namespace Carpenter_v1
{
    public partial class main_page : Form
    {
        private DatabaseManager dm;
        private InitializeContent initializeContent = new InitializeContent();
        private  void changeButtonColor(Button tempButton)
        {
            foreach (Button b in this.Controls.OfType<Button>())
            {
                b.BackColor = ColorTranslator.FromHtml(Colors.white);
            }
            tempButton.BackColor = ColorTranslator.FromHtml(Colors.green);
        }
        private void changePanelVisibility(Panel panel){
            List<Panel> listOfPanel = this.Controls.OfType<Panel>().ToList();
            listOfPanel.ForEach(item => item.Visible = false);
            panel.Visible = true;
            panel.BringToFront();
        }
        public main_page() =>  InitializeComponent();
        private void main_page_FormClosing(object sender, FormClosingEventArgs e) => System.Windows.Forms.Application.Exit();

        private  void button1_ClickAsync(object sender, EventArgs e)
        {
            changePanelVisibility(panel1);
            changeButtonColor(button1);
            initializeContent.initItems(panel1);
        }
        private  void customer_button_Click(object sender, EventArgs e){
            changePanelVisibility(panel5);
            changeButtonColor(customer_button);
            initializeContent.initItems(panel5);
        }

        private  void main_page_Load(object sender, EventArgs e){
            dm = DatabaseManager.getInstance();
            initializeContent.initItems(panel1);
            changeButtonColor(button1);
        }

        private void button6_Click(object sender, EventArgs e){
            String values = "INSERT INTO Amount VALUES ('";
            values += comboBox1.SelectedValue.ToString() +"'";
            values += ",'"  + comboBox2.SelectedValue.ToString() + "'";
            values += "," + comboBox3.SelectedValue.ToString() ;
            values += "," + textBox1.Text;
            values += ");";

            if (dm.insertData(values)){
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly);
                initializeContent.refresh(dataGridView1);
            }
        }
        private void button7_Click(object sender, EventArgs e){
            String values = "UPDATE Amount SET amount = ";
            values += textBox2.Text;
            values += " WHERE material_id ='";
            values +=  comboBox6.SelectedValue.ToString() + "' ";
            values += "and color_id ='";
            values +=  comboBox5.SelectedValue.ToString()+ "' and " ;
            values += " size_id = ";
            values +=  comboBox4.SelectedValue.ToString();
            
            if (dm.updateData(values)){
                MessageBox.Show(MessageBoxContent.dataBaseUpdateDataCorrectly);
                initializeContent.refresh(dataGridView1);
            }   
        }

        private void button9_Click(object sender, EventArgs e){
            String values = "INSERT INTO Customer Values('";
            values += textBox6.Text + "','";
            values += textBox5.Text + "','";
            values += textBox7.Text + "')";

            if (dm.insertData(values)){
                MessageBox.Show(MessageBoxContent.dataBaseUpdateDataCorrectly);
                initializeContent.refresh(dataGridView2);
            }
        }
        private void button5_Click(object sender, EventArgs e){
            changePanelVisibility(panel9);
            changeButtonColor(button5);
            initializeContent.initItems(panel9);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            String customer_id = comboBox7.SelectedValue.ToString();

            String values = "Update Customer set customer_name = '" + textBox4.Text +
                "',customer_phone = '" + textBox8.Text+"',customer_email = '"+
                textBox3.Text+"' where customer_id = " + customer_id ;

            if (dm.updateData(values))
            {
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly); // düzelt
                initializeContent.refresh(dataGridView2, comboBox7);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String s = comboBox8.SelectedValue.ToString();
            DatabaseSqlCodeExtension.temp = s;
            initializeContent.refresh(dataGridView4);


        }

        private void button3_Click(object sender, EventArgs e){
            changePanelVisibility(panel12);
            changeButtonColor(button3);
            initializeContent.initItems(panel12);
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String s = "insert into Work Values (" +
                comboBox9.SelectedValue.ToString() + ", '";
            s += dateTimePicker1.Value.ToString()+"', '";
            s += textBox10.Text + "')";
            if (dm.insertData(s))
            {
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly); // düzelt
                initializeContent.refresh(null,null,listBox1);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            String values = "insert into Product values(";
            values += listBox1.SelectedValue.ToString();
            values += ", '" + comboBox11.SelectedValue.ToString() + "',";
            values += comboBox10.SelectedValue.ToString();
            values += ", '" + comboBox12.SelectedValue.ToString() + "',";
            values += textBox9.Text;
            values += ");";
            if (dm.insertData(values))
            {
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly); // düzelt
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changePanelVisibility(panel15);
            changeButtonColor(button2);
            initializeContent.initItems(panel15);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //update Carpenter_Stock_Method set method = @method where material_id = @id

            String value = "update Carpenter_Stock_Method set method ='";
            value += textBox18.Text + "' where material_id = '";
            value += comboBox13.SelectedValue.ToString() + "'";
            if (dm.updateData(value))
            {
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly); // düzelt
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            String value = "insert into Carpenter_Material Values('";
            value += textBox15.Text + "','";
            value += textBox16.Text + "');";
            if (dm.insertData(value))
            {
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly); 
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            String value = "insert into Color Values('";
            value += textBox21.Text + "','";
            value += textBox22.Text + "');";
            if (dm.insertData(value))
            {
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly); 
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            String value = "insert into Size Values('";
            value += textBox11.Text + "','";
            value += textBox12.Text + "','";
            value += textBox13.Text + "')";
            if (dm.insertData(value))
            {
                MessageBox.Show(MessageBoxContent.dataBaseInsertDataCorrectly); 
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changePanelVisibility(panel20);
            changeButtonColor(button4);
            initializeContent.initItems(panel20);
            createGraph(zedGraphControl1);
            createGraph(zedGraphControl2);
            createGraph(zedGraphControl3);
        }
        private void createGraph(ZedGraphControl zedGraphControl1)
        {
            
            //int pointCount = 100;

            //var xs = RandomWalk("Select amount from Amount", "amount");
            //var ys1 = RandomWalk("Select Size.size_id,(Size.height + 'x' + Size.width + 'x' + Size.thickness ) as 'size' from Amount,Size where Amount.size_id = Size.size_id order by Size.size_id", "size");
            
            //IPointList list = new PointPairList(xs,ys1);
            //// clear old curves
            //zedGraphControl1.GraphPane.CurveList.Clear();
            ////
            //zedGraphControl1.GraphPane.YAxis.Scale.MinorStep = 1;
            //zedGraphControl1.GraphPane.YAxis.Scale.MinorStepAuto = false;
            //zedGraphControl1.GraphPane.YAxis.Scale.MajorStep = 1;
            //zedGraphControl1.GraphPane.YAxis.Scale.MajorStepAuto = false;
            //zedGraphControl1.GraphPane.YAxis.Scale.Format = "0";
            //zedGraphControl1.GraphPane.XAxis.Scale.Format = "0";
            //// plot the data as curves
            //zedGraphControl1.GraphPane.AddBar("Group A", list, Color.Blue);

            //// style the plot
            //zedGraphControl1.GraphPane.Title.Text = $"Bar Plot ({pointCount:n0} points)";
            //zedGraphControl1.GraphPane.XAxis.Title.Text = "Amount";
            //zedGraphControl1.GraphPane.YAxis.Title.Text = "Size IDs";
            ////zedGraphControl1.YAxis.Scale.Format = "0";
            

            //// auto-axis and update the display
            //zedGraphControl1.GraphPane.XAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            //zedGraphControl1.GraphPane.YAxis.ResetAutoScale(zedGraphControl1.GraphPane, CreateGraphics());
            //zedGraphControl1.Refresh();

        }
        //private Random rand = new Random(0);
        //private String[] RandomWalk(String s, String name)
        //{
        //    String temp = s;
        //    List<String> strDetailIDList = new List<String>();
        //    DataSet set = dm.getData(temp, name);

        //    foreach (DataRow row in set.Tables[0].Rows)     
        //    {
        //        strDetailIDList.Add(row[name].ToString());
        //    }

        //    String[] strDetailID = strDetailIDList.ToArray();
        //    return strDetailID;
        //}
       
    }
}
