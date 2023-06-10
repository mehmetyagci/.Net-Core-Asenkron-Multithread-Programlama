using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactJCTransactionsJCJCM {
   
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ProjectSummaryRoot {
        [JsonProperty("odata.metadata")]
        public string odatametadata { get; set; }
        public List<ProjectSummary> value { get; set; } = new List<ProjectSummary>();
    }

    public class ProjectSummary  {
        public string Project { get; set; }
        public string Description { get; set; }
        public string ProjectStatus { get; set; }
        public string RevisedEstimate { get; set; }
        public string CoststoDate { get; set; }
        public string OpenCommittedCosts { get; set; }
        public string RemainingEstimate { get; set; }
        public string RemainingEstimate_2 { get; set; }
        public string OriginalContract { get; set; }
        public string ApprovedContractChanges { get; set; }
        public string RevisedContract { get; set; }
        public string RevenueToDate { get; set; }
        public string EstGrossProfit { get; set; }
        public string EstGrossProfit_2 { get; set; }
        public string OriginalEstimate { get; set; }
        public string RevisedCommittedAmount { get; set; }
        public string BaseType { get; set; }
        public int ProjectID { get; set; }
        public int ProjectTaskID { get; set; }
        public string CostCode { get; set; }
        public string AccountGroup { get; set; }
        public string InventoryID { get; set; }
    }



}
