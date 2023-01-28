using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Carpenter_v1.constants.enums;
using Carpenter_v1.service;

namespace Carpenter_v1.init
{
    class InitializeContent
    {
        private DatabaseContentExtension databaseContentExtension;

        public InitializeContent() =>  databaseContentExtension = DatabaseContentExtension.getInstance();

        private void initComboBox(ComboBox comboBox)
        {    
            if(comboBox != null){
                databaseContentExtension.fillComboBoxDataSource(comboBox, DatabaseSqlCodeExtension.getComboBoxSqlCode(comboBox.Name));
            }
        }

        private void initDataGridView(DataGridView table =null)
        {
            if(table != null){
                databaseContentExtension.fillDataGridViewDataSource(table, DatabaseSqlCodeExtension.getDataGridViewSqlCode(table.Name));
            }
        }
        private void initListBox(ListBox listBox = null)
        {
            if (listBox != null)
            {
                databaseContentExtension.fillListBoxDataSource(listBox, DatabaseSqlCodeExtension.getListBoxSqlCode(listBox.Name));
            }
        }

        public void initItems(Panel panel =null)
        {
           List<Panel> panels = panel.Controls.OfType<Panel>().ToList();
            foreach (Panel item in panels){
                item.Controls.OfType<ComboBox>().ToList().ForEach(temp => initComboBox(temp));
                item.Controls.OfType<DataGridView>().ToList().ForEach(temp => initDataGridView(temp));
                item.Controls.OfType<ListBox>().ToList().ForEach(temp => initListBox(temp));
            }
        }

        public void refresh(DataGridView table = null, ComboBox comboBox =null, ListBox listBox = null)
        {
            if(table != null)
            {
                initDataGridView(table);
            }
            if(comboBox != null)
            {
                initComboBox(comboBox);
            }
            if(listBox != null)
            {
                initListBox(listBox);
            }
        }

    }
}
