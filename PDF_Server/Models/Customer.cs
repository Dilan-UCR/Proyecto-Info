public class Customer
{
    public int CustomerID { get; set; }
    public int? PersonID { get; set; }      // FK a Person.Person
    public int? StoreID { get; set; }
    public int? TerritoryID { get; set; }
    public string AccountNumber { get; set; }
    public DateTime ModifiedDate { get; set; }
}
