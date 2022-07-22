using com.oddsmatrix.sepc.connector.sdql;
using com.oddsmatrix.sepc.connector.sportsmodel;
using OddsMatrixConnector.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddsMatrixConnector.SyncConsole
{

    internal class Program
    {
        private static SEPCPushConnector connector;
        private static DateTime start;
        private static string LastBatchUuid;
        private static Dictionary<long, BettingOffer> bettingOffers = new Dictionary<long, BettingOffer>();
        private static string suscriptorId = "";
        private static string checksum = "";
        private static string suscriptorName = ConfigurationManager.AppSettings["suscriptorname"];

        public static void Main()
        {
            string tablees = SQLScriptClass.GetTables();

            connector = new SEPCPushConnector(ConfigurationManager.AppSettings["host"], int.Parse(ConfigurationManager.AppSettings["port"]));
            connector.AddStreamedConnectorListener(new CustomListener());
            connector.SetEntityChangeBatchProcessingMonitor(new Monitor());
            start = DateTime.Now;

            string ids = "";

            try { ids = File.ReadAllText($"Log2\\data.txt"); } catch { ids = ""; }

            if (string.IsNullOrEmpty(ids))
            {
                connector.Start(suscriptorName);
            }
            else
            {
                string[] vec = ids.Split('~');

                checksum = vec[0];
                suscriptorId = vec[1];
                LastBatchUuid = vec[2];

                connector.StartWithResume(suscriptorName, suscriptorId, checksum, LastBatchUuid);
            }
        }

        class CustomListener : IStreamedConnectorListener
        {
            public void NotifyEntityUpdatesRetrieved(EntityChangeBatch entityChangeBatch)
            {
                if (!Directory.Exists("Log2"))
                {
                    Directory.CreateDirectory("Log2");
                }

                var obj = entityChangeBatch.EntityChanges.FirstOrDefault();

                SyncClass.ProcessChange(entityChangeBatch);
                //File.AppendAllText($"Log2\\{DateTime.Now:yyy_MM_dd_hh_mm_ss_fffff}.json", JsonConvert.SerializeObject(entityChangeBatch, Formatting.Indented));
                Console.WriteLine($"{entityChangeBatch} retrieved");
                LastBatchUuid = entityChangeBatch.Uuid;
                suscriptorId = entityChangeBatch.SubscriptionId;
                checksum = entityChangeBatch.SubscriptionChecksum;

                File.WriteAllText($"Log2\\data.txt", $"{checksum}~{suscriptorId}~{LastBatchUuid}");
            }

            public void NotifyInitialDumpRetrieved() =>
                Console.WriteLine($"Initial dump retrieved in {(DateTime.Now - start).TotalMilliseconds} millis");

            public void NotifyInitialDumpToBeRetrieved() =>
                Console.WriteLine("Starting to retrieve initial dump");

            public void NotifyPartialInitialDumpRetrieved(List<Entity> entities)
            {
                if (!Directory.Exists("Log"))
                {
                    Directory.CreateDirectory("Log");
                }
                //File.AppendAllText($"Log\\{DateTime.Now:yyy_MM_dd_hh_mm_ss_fffff}.json", JsonConvert.SerializeObject(entities));

                var xx = entities.Select(x => { SyncClass.GetEntityType(x.EntityType, x); return ""; }).ToList();

                Console.WriteLine($"Retrieved Type {entities.FirstOrDefault().EntityType} entities");
                Console.WriteLine($"Retrieved {entities.Count} entities");
                Console.WriteLine($"---------------------");
            }
        }

        class Monitor : IEntityChangeBatchProcessingMonitor
        {
            public string GetLastAppliedEntityChangeBatchUuid()
            {
                return LastBatchUuid;
            }
        }
    }
}
