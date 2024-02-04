using System.ComponentModel;

namespace PIISTECHLTD.Application.ViewModel.ShowDataViewModel;

public class OrderTracking
{
    [DisplayName("Status Name")]
    public string Name { get; set; }
    [DisplayName("Shipment Cost")]
    public decimal ShipmentCost { get; set; }
    [DisplayName("Pick Up Date")]
    public string ShipmentDate { get; set; }
    [DisplayName("Consignment Number")]
    public string ConsignmentNumber { get; set; }
    [DisplayName("Shipper Name")]
    public string ShipperName { get; set; }
}



