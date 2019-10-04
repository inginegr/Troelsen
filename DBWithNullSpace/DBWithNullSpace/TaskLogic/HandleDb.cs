using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbLogic;
using System.Windows.Controls;
using DbLogic.Entities;
using System.Windows;

namespace DBWithNullSpace.TaskLogic
{

    public class DataBaseOperations
    {
        // Exception console
        ListBox tbConsolle = null;

        DbHandle dbh = null;
        
        /// <summary>
        /// Get all rows from db
        /// </summary>
        /// <returns></returns>
        IEnumerable<NumberValueEntity> GetListWithEmptyStrings()
        {
            List<NumberValueEntity> listWithNullString = null;
            try
            {
                listWithNullString = new List<NumberValueEntity>();

                //Get all records from db
                List<NumberValueEntity> allRows = dbh.GetAllRecords().ToList();

                // Get items with empty strings
                foreach(NumberValueEntity n in allRows)
                {
                    if (n.Value == String.Empty)
                    {
                        listWithNullString.Add(n);
                    }
                }
            }catch(Exception ex)
            {
                LogException(ex.Message);
            }

            return listWithNullString;
        }

        /// <summary>
        /// Fill empty strings with <номер> - пропущено values
        /// </summary>
        public void FillEmptyStrings()
        {
            try
            {
                List<NumberValueEntity> numbers = GetListWithEmptyStrings().ToList();

                foreach (NumberValueEntity n in numbers)
                {
                    n.Value = $"<{n.NumberId}> - пропущено";
                }

                dbh.UpdateRecords(numbers);
            }catch(Exception ex)
            {
                LogException(ex.Message);
            }
        }

        /// <summary>
        /// Return all rows from db
        /// </summary>
        /// <returns></returns>
        public void GetData(ListBox listBoxParam)
        {
            try
            {
                listBoxParam.Items.Clear();
                List<NumberValueEntity> listRows = dbh.GetAllRecords().ToList();
                foreach(NumberValueEntity n in listRows)
                {
                    listBoxParam.Items.Add($"{n.NumberId}   {n.Value}");
                }
            }
            catch (Exception ex)
            {
                LogException(ex.Message);
            }

        }
        

        /// <summary>
        /// Log exception
        /// </summary>
        void LogException(string messageParam)
        {
            if (tbConsolle == null)
            {
                MessageBox.Show(messageParam);
            }
            else
            {
                tbConsolle.Items.Add(messageParam);
            }
        }

        public DataBaseOperations() : this(null) { }

        public DataBaseOperations(ListBox tb)
        {
            tbConsolle = tb;
            
            dbh = new DbHandle();
        }
    }
}
