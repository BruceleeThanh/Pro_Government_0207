using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;



namespace BussinessLogic
{
     public class HelperClass
    {
         
        
         public DataTable LinqToDataTable<T>(List<T> varlist)
         {
             var dtReturn = new DataTable();

             try
             {
                 // column names 
                 PropertyInfo[] oProps = null;

                 if (varlist == null) return dtReturn;

                 foreach (var rec in varlist)
                 {
                     // Use reflection to get property names, to create table, Only first time, others 
                     // will follow 
                     if (oProps == null)
                     {
                         oProps = (rec.GetType()).GetProperties();
                         foreach (var pi in oProps)
                         {
                             var colType = pi.PropertyType;

                             if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                                                             == typeof(Nullable<>)))
                             {
                                 colType = colType.GetGenericArguments()[0];
                             }

                             dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                         }
                     }

                     var dr = dtReturn.NewRow();

                     foreach (var pi in oProps)
                     {
                         dr[pi.Name] = pi.GetValue(rec, null) ?? DBNull.Value;
                     }

                     dtReturn.Rows.Add(dr);
                 }
             }
             catch (Exception ex)
             {
                 
             }

             return dtReturn;
         }
    }
}
