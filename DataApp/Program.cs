// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;//use to get the all class of sql 
using System.Data;//use to get dataset datatable.....etc

using System;
//Show();
//AddRecord();
AddDisconnect();
ShowDisconnect();

//--------------------------------- Disconnected -----------------------------------------------
void AddDisconnect()
{
    string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=PratDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
   
    Console.WriteLine("Enter ID");
    int id=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Product Name");
    string name=Console.ReadLine();
    Console.WriteLine("Enter Price");
    int price=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Stock");
    int stock=Convert.ToInt32(Console.ReadLine());
    SqlConnection connection=null;
    SqlDataAdapter adapter=null;
    DataSet ds=null;
    DataTable prodTable=null;
    git remote add origin https://github.com/PratikLohakare07/Day4-and-3-.git
    try
    {
      ds=new DataSet();
        connection=new SqlConnection(connectionString);
        adapter=new SqlDataAdapter("select * from product",connection);
        adapter.Fill(ds,"Prods");
        prodTable=ds.Tables["Prods"];
        DataRow prodrow=prodTable.NewRow();
        prodrow["id"]=id;
        prodrow["name"]=name;
        prodrow["price"]=price;
        prodrow["stock"]=stock;
        prodTable.Rows.Add(prodrow);

        SqlCommandBuilder scd=new SqlCommandBuilder(adapter);//it provides the command to the adapter select update delete
        
        Console.WriteLine(scd.GetInsertCommand().CommandText);
       adapter.Update(prodTable);
        Console.WriteLine("Row added");
  
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}




void ShowDisconnect()
{
    string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=PratDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
     string cmdtext="insert into product values(@id,@name,@price,@stock)";
     SqlConnection connection =null;
     SqlDataAdapter adapter=null;
     DataSet ds=null;
     DataTable prodTable=null;
     try
     {
        ds=new DataSet();
        connection=new SqlConnection(connectionString);
        adapter=new SqlDataAdapter("select * from product",connection);
        adapter.Fill(ds,"Prods");
        prodTable=ds.Tables["Prods"];

        Console.WriteLine($"Rows={prodTable.Rows.Count}");
        Console.WriteLine($"Columns={prodTable.Columns.Count}");
        foreach(DataRow row in prodTable.Rows)
        {
            Console.WriteLine($"{row["id"]} -- {row["name"]} -- {row["price"]} -- {row["stock"]} ");
        }

    
     }
     catch(Exception ex)
     {
        Console.WriteLine(ex.Message);
     }

}

//--------------------------Connected Architecture------------------------------------------------------------------------------------


void AddRecord()
{
    string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=PratDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
    string cmdtext="insert into product values(@id,@name,@price,@stock)";
    Console.WriteLine("Enter ID");
    int id=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Product Name");
    string name=Console.ReadLine();
    Console.WriteLine("Enter Price");
    int price=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Stock");
    int stock=Convert.ToInt32(Console.ReadLine());
    SqlConnection con=null;
    SqlCommand  command=null;
    try{
        con=new SqlConnection(connectionString);
        command=new SqlCommand(cmdtext,con);
        command.Parameters.AddWithValue("@id",id);
        command.Parameters.AddWithValue("@name",name);
        command.Parameters.AddWithValue("@price",price);
        command.Parameters.AddWithValue("@stock",stock);
        con.Open();
        command.ExecuteNonQuery();
        Console.WriteLine("Record Added");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        con.Close();
    }

}
void Show(){
 string connectionString = "User ID=sa;password=examlyMssql@123; server=localhost;Database=PratDB;trusted_connection=false;Persist Security Info=False;Encrypt=False";
string cmdtext="select * from product";

try{
   SqlConnection con=new SqlConnection(connectionString);
   con.Open();
   Console.WriteLine("Connection Opened Successfully");
   SqlCommand command=new SqlCommand(cmdtext,con);//what to execute where to execute
   SqlDataReader reader =command.ExecuteReader();//Datareader class cannot be instantiated like  other classes

   while(reader.Read())
   {
    Console.WriteLine($"{reader["id"]} --- {reader["Name"]} --- {reader["Price"]} --- {reader["Stock"]}");
   }

con.Close();
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}}
//---------------------------------------------------end of connected --------------------------------------