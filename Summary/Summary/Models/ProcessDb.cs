using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.IO;



namespace Summary.Models
{
    public class ProcessDb : Controller
    {
        // Write error to log file
        public void WriteToLog(string st)
        {
            string pth = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/ErrLog.txt");
            
            using(StreamWriter write=new StreamWriter(pth))
            {
                try
                {
                    string tex = DateTime.Now + " " + st;
                    write.WriteLine(tex);
                }catch(Exception ex)
                {
                    return;
                }                
            }
        }

        //Read error from log file
        public string ReadLog()
        {
            string stRet = null;
            string pathString = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/ErrLog.txt");

            using(StreamReader readSt=new StreamReader(pathString))
            {
                try
                {
                    stRet = readSt.ReadToEnd();
                }catch(Exception ex)
                {
                    return null;
                }
            }
            return stRet;
        }


        // Add  record to db
        public void AddRecord(string textParam)
        {
            using(MesInbox mi = new MesInbox())
            {
                try
                {
                    Table tb = new Table { Text = textParam, IsRead = false };

                    mi.Table.Add(tb);
                    mi.SaveChanges();
                }catch(Exception ex)
                {
                    WriteToLog(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        // Updater record in db
        public void UpdateRecord(Table tb)
        {
            using (MesInbox mi = new MesInbox())
            {
                try
                {
                    Table tbl = mi.Table.Find(tb.id);

                    if (tbl != null)
                    {
                        tbl = tb;
                        mi.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    WriteToLog(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        // Change status in DB
        public void ChangeStatusRecord(Table tb)
        {
            tb.IsRead = true;

            UpdateRecord(tb);
        }

        // Remove record from db
        public void RemoveRecord(Table tb)
        {
            using(MesInbox mi=new MesInbox())
            {
                try
                {
                    Table tableToRemove = mi.Table.Find(tb.id);

                    if (tableToRemove != null)
                    {
                        mi.Table.Remove(tableToRemove);
                        mi.SaveChanges();
                    }
                }catch(Exception ex)
                {
                    WriteToLog(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        // Get Record from db
        public IEnumerable<Table> GetRecords()
        {
            List<Table> retTable = new List<Table>();
            using(MesInbox mi = new MesInbox())
            {
                try
                {
                    foreach(Table t in mi.Table)
                    {
                        retTable.Add(t);
                    }
                }catch(Exception ex)
                {
                    WriteToLog(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
            return retTable;
        }
        
        // Get unread records from db
        public IEnumerable<Table> GetUnreadRecords()
        {
            List<Table> retTables = new List<Table>();

            foreach(Table t in GetRecords())
            {
                if (t.IsRead == false)
                {
                    retTables.Add(t);
                    ChangeStatusRecord(t);
                }
            }

            return retTables;
        }

        public ProcessDb()
        {

        }
    }
}