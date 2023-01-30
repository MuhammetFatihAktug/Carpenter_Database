# Welcome to Carpenter Database

I have implemented a desktop application using the database model I created using c#. This project was created for the website [ozelahsap.com](http://www.ozelahsap.com).


## Database Model

This database you see below has been created in a simple and easy to implement manner.

![Database Model](https://github.com/MuhammetFatihAktug/Carpenter_Database/blob/a9ecd7983df3713ad72f90a5b44ff62b1a3c1021/Carpenter_v1/assets/git/database_model_view.png)

## What Was Used
**MSSQL** is used in database design. The desktop interface is designed and coded in **C#**. Coding processes have been tried to be written in accordance with **S.O.L.I.D** principles. **Singleton design pattern** is used for performance and sustainability.

### Database Connection
A folder named **service** has been created for database connection and the necessary classes for database connection have been written in this folder.

![Directory of Service](https://github.com/MuhammetFatihAktug/Carpenter_Database/blob/5835ff67ea855778ef678f58e153ef0972cccbd8/Carpenter_v1/assets/git/directory_of_service.png)

With the **DatabaseManager** class, you can connect to the database, send or receive data.
For example :


    public bool connectDatabase()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                ShowException.ShowSqlException(ex);              
            }
            return false;
        }

        public DataSet getData(String sql, String tableName)
        {
            if (connectDatabase())
            {
                try
                {
                    dataAdapter = new SqlDataAdapter(sql, connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, tableName);
                    connection.Close();
                    dataSet.Dispose();
                    return dataSet;
                }
                catch (SqlException ex)
                {
                    ShowException.ShowSqlException(ex);
                }
            }
            return null;
        }

With the code you see above, the database connection can be called from anywhere or used from within.

Thanks to the **DatabaseContentExtension** and **DatabaseErrorHandling** classes, we can catch database errors that may occur. We can also have it automatically fetch the data displayed in the interface.

### How to Load Items
How to update the screen when the program starts or during updates. For this, a folder named **init** was created and the necessary classes were written there.

![Director of init](https://github.com/MuhammetFatihAktug/Carpenter_Database/blob/68bf1618b5645142e9b3f2a4a393215baf924f75/Carpenter_v1/assets/git/directory_of_init.png)

**InitializeContent** establishes a connection with the database and interface.

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
  
  With the code you see above, it sends data to **comboBox** and **dataGridView**  in the interface.


### Strings and SQL code

Unchanging fonts such as common colors, **SQL** codes, message box texts used in the application were defined as **Magic Word**. Thus, the texts in the entire application change from one place.
A folder named **constants** has been created for this case. Inside this folder is divided into colors and text

![Directory  of constants](https://github.com/MuhammetFatihAktug/Carpenter_Database/blob/93a517c5674211d7f693c829fff6b725cd149f6c/Carpenter_v1/assets/git/directory_of_constant.png)


    class MessageBoxContent
    {
        public static String databaseConnectionError = "We have problem where database";
        public static String dataBaseInsertDataCorrectly = "New item added";
        public static String dataBaseUpdateDataCorrectly = "Item rmoved";
    }

### In Addition
For database security, it ensures the accuracy of the data in case of adding, updating or removing data by typing **trigger** into **msSQL**. 

for example if we are going to delete a product the following **trigger** will work

    USE [Carpenter]
	GO
	/****** Object:  Trigger [dbo].[deleteAmount]    Script Date: 30.01.2023 22:32:37 ******/
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	ALTER trigger [dbo].[deleteAmount]
	on [dbo].[Amount]
	instead of update as
	begin
	declare @material_id nvarchar(10)
	declare @color_id nvarchar(10)
	declare @size_id int
	declare @amount int
	declare @temp_amount int
	select  @temp_amount = amount from deleted
	select  @material_id = material_id, @color_id = color_id, @size_id = size_id, @amount = amount from inserted
	if( @amount > 0 )begin
	if((@temp_amount > @amount or @temp_amount = @amount)) begin
	update Amount set amount =  amount - @amount
	where material_id = @material_id and size_id = @size_id and color_id = @color_id
	DELETE FROM Amount WHERE amount = 0;
	end else begin
	THROW 60000, 'Not enough stock ', 1;
	end
	end else begin
	THROW 60000, 'Amount cannot be negative', 1;
	end
	end

## Interface of Desktop Program
![Onboard Page](https://github.com/MuhammetFatihAktug/Carpenter_Database/blob/a9ecd7983df3713ad72f90a5b44ff62b1a3c1021/Carpenter_v1/assets/git/onboard_screen.png)

![Home Page ](https://github.com/MuhammetFatihAktug/Carpenter_Database/blob/a9ecd7983df3713ad72f90a5b44ff62b1a3c1021/Carpenter_v1/assets/git/home_screen.png)

![Instance of Page](https://github.com/MuhammetFatihAktug/Carpenter_Database/blob/a9ecd7983df3713ad72f90a5b44ff62b1a3c1021/Carpenter_v1/assets/git/ex_screen.png)
