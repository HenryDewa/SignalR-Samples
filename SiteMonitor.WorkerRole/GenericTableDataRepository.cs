using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.StorageClient;
using System.Linq.Expressions;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace SiteMonitor.WorkerRole
{
	public class GenericTableDataRepository<T>
		where T : TableServiceEntity
	{
		static string tableName = typeof(T).Name;
		private string connectionStringName = "Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString";
		private static CloudStorageAccount storageAccount;
		private CloudTableClient tableClient;

		public GenericTableDataRepository(string connectionString)
		{
			this.connectionStringName = !string.IsNullOrEmpty(connectionString) ? connectionString : connectionStringName;
			string cs = RoleEnvironment.GetConfigurationSettingValue(connectionStringName);
			storageAccount = CloudStorageAccount.Parse(cs);
			tableClient = new CloudTableClient(storageAccount.TableEndpoint.AbsoluteUri,
				storageAccount.Credentials);
			tableClient.RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));
			tableClient.CreateTableIfNotExist(tableName);
		}

		public List<T> GetEntries()
		{
			TableServiceContext ctx = tableClient.GetDataServiceContext();
            var results = ctx.CreateQuery<T>(tableName);
            return results.ToList();
		}

        public void Delete(Func<T,bool> query)
        {
            var ctx = tableClient.GetDataServiceContext();
            var target = ctx.CreateQuery<T>(tableName).Where(query).First();
            ctx.DeleteObject(target);
            ctx.SaveChanges();
        }

		public void AddEntry(T entry)
		{
			AddEntry(entry, null);
		}

		public void AddEntry(T entry, Action<TableServiceContext> beforeSave)
		{
			var ctx = tableClient.GetDataServiceContext();
			ctx.AddObject(tableName, entry);

			if (beforeSave != null)
				beforeSave(ctx);

			ctx.SaveChanges();
		}
	}
}
