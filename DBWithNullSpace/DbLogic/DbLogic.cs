using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DbLogic.Entities;

namespace DbLogic
{
    
    public class DbHandle
    {
        ///<summary>
        ///Add rows to DataBase
        /// </summary>
        public void AddRecords(IEnumerable<NumberValueEntity> tableStringParam)
        {
            using(NumberValueContext nvc=new NumberValueContext())
            {
                try
                {
                    nvc.NumberValue.AddRange(tableStringParam);
                    nvc.SaveChanges();
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        ///<summary>
        ///Add row to DataBase
        /// </summary>
        /// <param name="tableStringParam">The entity to add</param>
        public void AddRecord(NumberValueEntity tableStringParam)
        {
            using (NumberValueContext nvc = new NumberValueContext())
            {
                try
                {
                    nvc.NumberValue.Add(tableStringParam);
                    nvc.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        /// <summary>
        /// Delete row from DataBase
        /// </summary>
        /// <param name="idToDelete">Id to remove from table</param>
        public void DeleteRecord(int idToDelete)
        {
            using(NumberValueContext nvc=new NumberValueContext())
            {
                try
                {
                    NumberValueEntity nve = nvc.NumberValue.Find(idToDelete);
                    if (nve != null)
                    {
                        nvc.NumberValue.Remove(nve);
                    }
                    else
                    {
                        throw new Exception($"The row with id {idToDelete} didn't found");
                    }
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Delete rows from DataBase
        /// </summary>
        /// <param name="entitiesToRemove">Entities to remove from table</param>
        public void DeleteRecords(IEnumerable<NumberValueEntity> entitiesToRemove)
        {
            using (NumberValueContext nvc = new NumberValueContext())
            {
                try
                {
                    nvc.NumberValue.RemoveRange(entitiesToRemove);
                    nvc.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Update records
        /// </summary>
        /// <param name="recordsToUpdate"> Records to update </param>
        public void UpdateRecords(IEnumerable<NumberValueEntity> recordsToUpdate)
        {
            using(NumberValueContext nvc =new NumberValueContext())
            {
                try
                {
                    foreach(NumberValueEntity n in recordsToUpdate)
                    {
                        nvc.NumberValue.Find(n.NumberId).Value = n.Value;
                    }
                    nvc.SaveChanges();
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Take all records from db
        /// </summary>
        /// <param name=""></param>
        public IEnumerable<NumberValueEntity> GetAllRecords()
        {
            List<NumberValueEntity> entitiesList = new List<NumberValueEntity>();

            using(NumberValueContext nvc =new NumberValueContext())
            {
                foreach(NumberValueEntity n in nvc.NumberValue)
                {
                    entitiesList.Add(n);
                }
            }

            return entitiesList;
        }

        public DbHandle() { }
    }
}
