using Carpenter_v1.constants.enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carpenter_v1.service
{
    class DatabaseContentExtension
    {
        private DatabaseManager dm = DatabaseManager.getInstance();
        private DataSet dataSet;
        private static DatabaseContentExtension instance;

        private DatabaseContentExtension(){}

        public static DatabaseContentExtension getInstance() => ((instance == null) ? (new DatabaseContentExtension()) : instance);

        public void fillDataGridViewDataSource(DataGridView table, String sql)
        { 
            table.DataSource = dm.getData(sql, table.Name);
            table.DataMember = table.Name;
        }
        public void fillListBoxDataSource(ListBox listBox, String sql)
        {
            this.dataSet = dm.getData(sql, listBox.Name);
            listBox.DataSource = dataSet.Tables[0];
            listBox.DisplayMember = dataSet.Tables[0].Columns[1].ColumnName;
            listBox.ValueMember = dataSet.Tables[0].Columns[0].ColumnName;
        }
        public void fillComboBoxDataSource(ComboBox comboBox, String sqlCommand)
        {
            dm.connectDatabase();
            this.dataSet = dm.getData(sqlCommand, comboBox.Name);
            comboBox.DataSource = dataSet.Tables[0];
            comboBox.DisplayMember = dataSet.Tables[0].Columns[1].ColumnName;
            comboBox.ValueMember = dataSet.Tables[0].Columns[0].ColumnName;
            garbarageCollector();
        }

        private void garbarageCollector()
        {
            dataSet.Dispose();
        }
        
    }
}
