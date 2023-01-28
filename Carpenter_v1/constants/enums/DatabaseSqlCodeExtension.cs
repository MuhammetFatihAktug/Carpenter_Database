using System;

namespace Carpenter_v1.constants.enums
{
    class DatabaseSqlCodeExtension
    {
        public static String temp = "1";
       public static String getComboBoxSqlCode(String name)
       {
            if ((name == "comboBox1" || name == "comboBox6") || (name == "comboBox11" || name == "comboBox13"))
            {
                return getCarpenterMaterialTableCode();
            }
            else if ((name == "comboBox2" || name == "comboBox5" ) || name == "comboBox12")
            {
                return getColorTableCode();
            }
            else if ((name == "comboBox3" || name == "comboBox4") || name == "comboBox10")
            {
                return getSizeTableCode();
            
            }else if( (name == "comboBox7" || name == "comboBox8" ) || name == "comboBox9")
            {
                return getCustomerNameCode();
            }

            return null;
       }
        public static String getListBoxSqlCode(String name)
        {
            if (name == "listBox1")
            {
                return getWorkListCode();
            }
            
            return null;
        }
        public static String getDataGridViewSqlCode(String name)
        {
            if (name == "dataGridView1"){
                return getStockData();
            }else if(name == "dataGridView2"){
                return getCustomerTableCode();
            }
            else if (name == "dataGridView3"){
                return getWorkList();
            }
            else if (name == "dataGridView4")
            {
                return getCustomerWorkListCode(temp);
            }
            return null;
        }
        public static String getCustomerWorkListCode(String s = "1") => "Select Product.work_id as 'Work IDs',Customer.customer_name as 'Customer Name',Product.material_id as 'Material IDs',Color.color_name as 'Color name',Size.height + 'x' + Size.width + 'x' + Size.thickness as 'Size',Product.amount as 'Amount' from Work, Product, Customer, Size, Color where Work.work_id = Product.work_id and Customer.customer_id = Work.customer_id and Size.size_id = Product.size_id and Color.color_id = Product.color_id and Customer.customer_id =" +s;

        private static String getWorkListCode() => "select work_id as 'Work Number', (Customer.customer_name +', Work Date = ' + CONVERT(VARCHAR, work_date,101) +', Details = '+ work_detail ) as 'Work İnfo' from Work,Customer where Customer.customer_id = Work.customer_id";
        private static String getStockData() =>     
             "SELECT Amount.material_id as 'Material ID', "
             + "Color.color_name as 'Color Name', "
             + "Size.width as 'Width',Size.height as 'Height', "
             + "Size.thickness as 'Thickness', Amount.amount as 'Amount'"
             + "FROM Amount JOIN Color "
             + "ON Amount.color_id = Color.color_id "
             + "JOIN Size ON Size.size_id = Amount.size_id";
        private static String getWorkList() => "Select Product.work_id as 'Work IDs',Customer.customer_name as 'Customer Name',Product.material_id as 'Material IDs',Color.color_name as 'Color name',Size.height + 'x' + Size.width + 'x' + Size.thickness as 'Size',Product.amount as 'Amount' from Work, Product, Customer, Size, Color where Work.work_id = Product.work_id and Customer.customer_id = Work.customer_id and Size.size_id = Product.size_id and Color.color_id = Product.color_id";

        private static String getCustomerNameCode() => "Select customer_id, customer_name From Customer";
        public static String getConnectionString() => @"server=.;database=Carpenter;integrated security=True;Encrypt=False";
        private static String getCarpenterMaterialTableCode() => "SELECT distinct material_id as 'Material IDs', material_id as 'Material IDs' FROM Carpenter_Material";
        private static String getColorTableCode() => "SELECT color_id as 'Color IDs', color_name as 'Color name' FROM Color";
        private static String getSizeTableCode() => "Select size_id as 'Size IDs' , (height +'x' + width + 'x' + thickness) as 'Size' from Size";
        private static String getCustomerTableCode() => "Select customer_name as 'Customer name', customer_phone as 'Phone', customer_email as 'Email' from Customer";
       

    }
}
