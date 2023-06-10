using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactJCTransactionsJCJCM {

    
    public class FactJCTransactionsJCRoot {
        [JsonProperty("odata.metadata")]
        public string odatametadata { get; set; }
        public List<FactJCTransactionsJC> value { get; set; }
    }

    public class FactJCTransactionsJC {
        public object APInvoiceAlternateKey { get; set; }
        public object VendorID { get; set; }
        public string AccountingDateKey { get; set; }
        public string Amount { get; set; }
        public string CostCategoryAlternateKey { get; set; }
        public string CostCodeAlternateKey { get; set; }
        public string Description { get; set; }
        public string GUID { get; set; }
        public string Hours { get; set; }
        public object Notes { get; set; }
        public string ProjectAlternateKey { get; set; }
        public string Ref_1 { get; set; }
        public object Ref_2 { get; set; }
        public object Retainage { get; set; }
        public DateTime TransactionDateKey { get; set; }
        public string TransactionTypeKey { get; set; }
        public string UnitMeasureCode { get; set; }
        public string Units { get; set; }
        public string UMCostCategoryType { get; set; }
        public string UMPMTranTranType { get; set; }
        public string UMProjectBaseType { get; set; }
        public string UMProjectNonProject { get; set; }
        public object UMPMTranOffsetAccountID { get; set; }
        public string UMPMTranAccountID { get; set; }
        public string PayItemAlternateKey { get; set; }
        public object UMAPInvDocType { get; set; }
        public string FinancialPeriodID { get; set; }
        public string TranID { get; set; }
        public string AccountGroupID { get; set; }
        public string CostCode { get; set; }
        public object Type { get; set; }
        public object NoteID { get; set; }
        public string BaseType { get; set; }
        public string ProjectID { get; set; }
        public string BranchID { get; set; }
        public string ProjectID_2 { get; set; }
        public string TaskID { get; set; }
        public string Account { get; set; }
        public object Account_2 { get; set; }
    }

}
