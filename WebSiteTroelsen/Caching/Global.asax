<%@ Application Language="C#" %>
<%@ Import Namespace="AutoLotConnectedLayer" %>
<%@ Import Namespace="System.Data" %>

<script runat="server">

    static Cache theCache;

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        theCache = Context.Cache;
        InventoryDAL dal = new InventoryDAL();
        dal.OpenConnection(@"Data Source=DIMA-PC\MSSQLSERVER2014;Initial Catalog=master;Integrated Security=True");
        DataTable theCars = dal.GetAllInventoryAsDataTable();
        dal.CloseConnection();

        theCache.Insert("AppDataTable", theCars, null, DateTime.Now.AddSeconds(15), Cache.NoSlidingExpiration, CacheItemPriority.Default, new CacheItemRemovedCallback(UpdateCarInventory));
    }

    static void UpdateCarInventory(string key, object item, CacheItemRemovedReason reason)
    {
        InventoryDAL dal = new InventoryDAL();
        dal.OpenConnection(@"Data Source=DIMA-PC\MSSQLSERVER2014;Initial Catalog=master;Integrated Security=True");
        DataTable theCars = dal.GetAllInventoryAsDataTable();
        dal.CloseConnection();

        theCache.Insert("AppDataTable", theCars, null, DateTime.Now.AddSeconds(15), Cache.NoSlidingExpiration, CacheItemPriority.Default, new CacheItemRemovedCallback(UpdateCarInventory));
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
