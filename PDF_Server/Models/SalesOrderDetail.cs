public class SalesOrderDetail
{
    public int SalesOrderID { get; set; }          // FK a SalesOrderHeader
    public int SalesOrderDetailID { get; set; }    // PK
    public string CarrierTrackingNumber { get; set; }
    public short OrderQty { get; set; }
    public int ProductID { get; set; }             // FK a Product
    public int SpecialOfferID { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal UnitPriceDiscount { get; set; }
    public decimal LineTotal { get; set; }         // calculado
    public Guid rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }
}
