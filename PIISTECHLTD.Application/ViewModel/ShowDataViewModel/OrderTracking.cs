namespace PIISTECHLTD.Application.ViewModel.ShowDataViewModel;

public record OrderTracking(string ConsignmentNumber,
    string Status, 
    decimal ShipmentCost, 
    DateTime ShipmentDate,
    string ShipperName
);

