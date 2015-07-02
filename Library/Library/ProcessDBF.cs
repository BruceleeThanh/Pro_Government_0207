
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.Data.Odbc;
using System.Drawing;
namespace Library
{
    public class ProcessDBF
    {

        private void GetFileNameAndPath(string completePath, ref string fileName, ref string folderPath)
        {
            string[] fileSep = completePath.Split('\\');
            for (int iCount = 0; iCount < fileSep.Length; iCount++)
            {
                if (iCount == fileSep.Length - 2)
                {
                    if (fileSep.Length == 2)
                    {
                        folderPath += fileSep[iCount] + "\\";
                    }
                    else
                    {
                        folderPath += fileSep[iCount];
                    }
                }
                else
                {
                    if (fileSep[iCount].IndexOf(".") > 0)
                    {
                        fileName = fileSep[iCount];
                        fileName = fileName.Substring(0, fileName.IndexOf("."));
                    }
                    else
                    {
                        folderPath += fileSep[iCount] + "\\";
                    }
                }
            }
        }

        //public bool EportDBF(DataSet dsExport, string filePath)
        //{
        //    string tableName = string.Empty;
        //    string folderPath = string.Empty;
        //    bool returnStatus = false;
        //    // This function give the Folder name and table name to use in
        //    // the connection string and create table statement.
        //    GetFileNameAndPath(filePath, ref tableName, ref folderPath);
        //    // here you can use DBASE IV also
        //    string connString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + folderPath + "; Extended Properties=DBASE III;";
        //    string createStatement = "Create Table " + tableName + " ( ";
        //    string insertStatement = "Insert Into " + tableName + " Values ( ";
        //    string insertTemp = string.Empty;
        //    OleDbCommand cmd = new OleDbCommand();
        //    OleDbConnection conn = new OleDbConnection(connString);
        //    if (dsExport.Tables[0].Columns.Count <= 0) { throw new Exception(); }
        //    // This for loop to create "Create table statement" for DBF
        //    // Here I am creating varchar(250) datatype for all column.
        //    // for formatting If you don't have to format data before
        //    // export then you can make a clone of dsExport data and transfer // data in to that no need to add datatable, datarow and
        //    // datacolumn in the code.
        //    for (int iCol = 0; iCol < dsExport.Tables[0].Columns.Count; iCol++)
        //    {
        //        createStatement += dsExport.Tables[0].Columns[iCol].ColumnName.ToString();
        //        if (iCol == dsExport.Tables[0].Columns.Count - 1)
        //        {
        //            createStatement += " varchar(250) )";
        //        }
        //        else
        //        {
        //            createStatement += " varchar(250), ";
        //        }
        //    }
        //    //Create Temp Dateset
        //    DataSet dsCreateTable = new DataSet();
        //    //Open the connection
        //    conn.Open();
        //    //Create the DBF table
        //    DataSet dsFill = new DataSet();
        //    OleDbDataAdapter daInsertTable = new OleDbDataAdapter(createStatement, conn);
        //    daInsertTable.Fill(dsFill);
        //    //Adding One DataTable into the dsCreatedTable dataset
        //    DataTable dt = new DataTable();
        //    dsCreateTable.Tables.Add(dt);
        //    for (int row = 0; row < dsExport.Tables[0].Rows.Count; row++)
        //    {
        //        insertTemp = insertStatement;
        //        //Adding Rows to the dsCreatedTable dataset
        //        DataRow dr = dsCreateTable.Tables[0].NewRow();
        //        dsCreateTable.Tables[0].Rows.Add(dr);
        //        for (int col = 0; col < dsExport.Tables[0].Columns.Count; col++)
        //        {
        //            if (row == 0)
        //            {
        //                //Adding Columns to the dsCreatedTable dataset
        //                DataColumn dc = new DataColumn();
        //                dsCreateTable.Tables[0].Columns.Add(dc);
        //            }
        //            // Remove Special character if any like dot,semicolon,colon,comma // etc
        //            dsExport.Tables[0].Rows[row][col].ToString().Replace("LF", "");
        //            // do the formating if you want like modify the Date symbol , //thousand saperator etc.
        //            dsCreateTable.Tables[0].Rows[row][col] = dsExport.Tables[0].Rows[row][col].ToString().Trim();
        //        } // inner for loop close
        //        // Create Insert Statement

        //        if (col == dsExport.Tables[0].Columns.Count - 1)
        //        {
        //            insertTemp += "'" + dsCreateTable.Tables[0].Rows[row][col] + "' ) ;";
        //        }
        //        else
        //        {
        //            insertTemp += "'" + dsCreateTable.Tables[0].Rows[row][col] + "' , ";
        //        }
        //        // This lines of code insert Row One by one to above created
        //        // datatable.
        //        daInsertTable = new OleDbDataAdapter(insertTemp, conn);
        //        daInsertTable.Fill(dsFill);
        //    } // close outer for loop
        //    //MessageBox.Show("Exported done Successfully to DBF File.");
        //    returnStatus = true;
        //} // close function

        Char decimalSymbol = '/';

        string thousandSeparator = "#" + "" + "###"; // or ","

        string dateFormat = "MM/dd/yyyy";


        public DataTable ImportDBF(string strFileName)
        {
            OdbcConnection conn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + System.IO.Path.GetFullPath(strFileName).Replace(System.IO.Path.GetFileName(strFileName), "") + ";Exclusive=No");
            conn.Open();
            string DBF_File_Name = System.IO.Path.GetFileName(strFileName);
            string strQuery = "SELECT * FROM [" + DBF_File_Name + "]";
            OdbcDataAdapter adap = new OdbcDataAdapter(strQuery, conn);
            DataSet ds = new DataSet();
            adap.Fill(ds);
            DataTable dt = ds.Tables[0];

            return dt;
        } // close function

    }
}
