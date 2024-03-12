using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Stock.WCF
{
    [Serializable]
    public abstract class DataTableConvertibleClass<T> where T : new()
    {
        protected T currentObject;

        /// <summary>
        /// Converti l'objet courant en DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable()
        {
            return AutoBinding.DataTableFromObject<T>(currentObject);
        }

        /// <summary>
        /// Converti l'objet courant en DataRow
        /// </summary>
        /// <returns></returns>
        public DataRow ToDataRow()
        {
            return AutoBinding.DataRowFromObject<T>(currentObject);
        }

        /// <summary>
        /// Converti l'objet courant en DataTable
        /// </summary>
        /// <returns></returns>
        public DataSet ToDataSet()
        {
            return this.ToDataSet("defaultDataset");
        }

        /// <summary>
        /// Converti l'objet courant en DataTable
        /// </summary>
        /// <param name="dataSetName">Name of DataSet</param>
        /// <returns></returns>
        public DataSet ToDataSet(string dataSetName)
        {
            DataSet ds = new DataSet(dataSetName);
            ds.Tables.Add(this.ToDataTable());
            return ds;
        }

        /// <summary>
        /// Crée une nouvelle instance d'un objet de type T à partir de 
        /// l'objet DataRow fournit
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T FromDataRow(DataRow row)
        {
            if (row == null)
            {
                throw new ArgumentNullException("row");
            }
            return AutoBinding.ObjectFromDataRow<T>(row);
        }

        /// <summary>
        /// Crée une nouvelle collection par rapport à la DataTable fournit
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> FromDataTable(DataTable table)
        {
            if (table == null)
            {
                throw new ArgumentNullException("table");
            }

            return AutoBinding.CollectionFromDataTable<T>(table);
        }

        private static class AutoBinding
        {

            /// <summary>
            /// Crée une nouvelle instance d'un objet de type T et le renseigne
            /// avec les valeurs du DataRow
            /// </summary>
            /// <typeparam name="T">Type de l'objet à créer</typeparam>
            /// <param name="row"></param>
            /// <returns></returns>
            public static T ObjectFromDataRow<T>(DataRow row) where T : new()
            {
                T obj = new T();

                Type t = typeof(T);
                // parcours la liste des propriétés du type T
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    if (pi.CanWrite && row[pi.Name] != null && !Convert.IsDBNull(row[pi.Name]))
                    {
                        pi.SetValue(obj, row[pi.Name], null);
                    }
                }

                return obj;
            }

            /// <summary>
            /// Crée une collection d'objet de type T à partir de la DataTable fournit
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="table"></param>
            /// <returns></returns>
            public static List<T> CollectionFromDataTable<T>(DataTable table) where T : new()
            {
                List<T> col = new List<T>();
                foreach (DataRow row in table.Rows)
                {
                    col.Add(ObjectFromDataRow<T>(row));
                }

                return col;
            }

            /// <summary>
            /// Crée un DataRow par rapport à l'objet obj de type T
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="obj"></param>
            /// <returns></returns>
            public static DataRow DataRowFromObject<T>(T obj)
            {
                return DataTableFromObject<T>(obj).Rows[0];
            }

            /// <summary>
            /// Charge le contenu de l'objet obj dans row
            /// </summary>
            /// <typeparam name="T">Type de obj</typeparam>
            /// <param name="obj">Objet de type T</param>
            /// <param name="row">DataRow à renseigner</param>
            public static void LoadObjectInDataRow<T>(T obj, DataRow row)
            {
                Type t = typeof(T);

                foreach (PropertyInfo pi in t.GetProperties())
                {
                    if (row.Table.Columns.Contains(pi.Name))
                    {
                        row[pi.Name] = pi.GetValue(obj, null);
                    }
                }
            }

            /// <summary>
            /// Crée une DataTable de l'objet obj de type T
            /// </summary>
            /// <typeparam name="T">Type de l'objet obj</typeparam>
            /// <param name="obj">Objet de type T</param>
            /// <returns></returns>
            public static DataTable DataTableFromObject<T>(T obj)
            {
                DataTable table = new DataTable();
                Type t = typeof(T);

                table = CreateEmpyDataTableFromType(typeof(T));
                DataRow row = table.NewRow();
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    if (pi.CanWrite)
                    {
                        row[pi.Name] = pi.GetValue(obj, null);
                    }
                }

                table.Rows.Add(row);

                return table;
            }

            /// <summary>
            /// Crée une DataTable vierge à partir du type t
            /// </summary>
            /// <param name="t"></param>
            /// <returns></returns>
            public static DataTable CreateEmpyDataTableFromType(Type t)
            {
                DataTable table = new DataTable();
                table.TableName = t.Name;
                foreach (PropertyInfo pi in t.GetProperties())
                {
                    if (pi.CanWrite)
                    {
                        table.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                return table;
            }
        }

    }
}