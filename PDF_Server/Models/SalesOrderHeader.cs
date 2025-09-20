public class SalesOrderHeader
{
    public int SalesOrderID { get; set; }          // PK
    public byte RevisionNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ShipDate { get; set; }
    public byte Status { get; set; }
    public bool OnlineOrderFlag { get; set; }
    public string SalesOrderNumber { get; set; }
    public string PurchaseOrderNumber { get; set; }
    public string AccountNumber { get; set; }
    public int CustomerID { get; set; }            // FK a Customer
    public int? SalesPersonID { get; set; }
    public int? TerritoryID { get; set; }
    public int BillToAddressID { get; set; }       // FK a Address
    public int ShipToAddressID { get; set; }       // FK a Address
    public int ShipMethodID { get; set; }
    public int? CreditCardID { get; set; }
    public string CreditCardApprovalCode { get; set; }
    public int? CurrencyRateID { get; set; }
    public decimal SubTotal { get; set; }
    public decimal TaxAmt { get; set; }
    public decimal Freight { get; set; }
    public decimal TotalDue { get; set; }
    public string Comment { get; set; }
    public Guid rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }
}
