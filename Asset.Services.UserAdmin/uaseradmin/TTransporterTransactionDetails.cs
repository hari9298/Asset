using System;
using System.Collections.Generic;

namespace Asset.Services.UserAdmin.uaseradmin
{
    public partial class TTransporterTransactionDetails
    {
        public int TransactionId { get; set; }
        public int? TransporterId { get; set; }
        public string ReceiptLocName { get; set; }
        public string UpName { get; set; }
        public string UpK { get; set; }
        public string ReceiptQty { get; set; }
        public string ReceiptRank { get; set; }
        public string DeliveryLocName { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryK { get; set; }
        public string DeliveryQty { get; set; }
        public string DeliveryRank { get; set; }
        public string TransactionInfo { get; set; }
        public string PkgId { get; set; }
        public string NominationSubCycle { get; set; }
        public string FuelRate { get; set; }
        public string FuelQty { get; set; }
        public string PathMiles { get; set; }
        public string Audit { get; set; }

        public virtual TTransporterMaster Transporter { get; set; }
    }
}
