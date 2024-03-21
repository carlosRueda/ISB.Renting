

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing;

namespace ISB.Renting.RentingUI.Services;

public class IsbSettings
{
    public string ApiUrlBase { get; set; }
    #region Endpoints
    private string PropertyEndpoint => $"{ApiUrlBase}/property";
    private string ContactEndpoint => $"{ApiUrlBase}/contact";
    private string DashboardEndpoint => $"{ApiUrlBase}/dashboard";

    #endregion

    #region Methods
    //Dashboard
    internal string Get_Dashboard_List_URL() => $"{DashboardEndpoint}";

    //Property


    //Contact
    internal string Get_Contacts_List_URL(int page, int size) => $"{ContactEndpoint}/{page}/{size}";

    internal string Get_Contacts_URL() => $"{ContactEndpoint}";

    internal string Get_Contacts_WithId_URL(Guid id) => $"{ContactEndpoint}/{id}";


    //internal string Get_Account_LoginWithTokenURL() => $"{AccountEndpoint}/sign-in-with-token";
    //internal string Get_Account_GetAllAvailableForShipment(int shipmentId) => $"{AccountEndpoint}/GetAllAvailableForShipment/{shipmentId}";


    ////Address
    //internal string Get_Address_GetByPersonURL(int personId) => $"{AddressEndpoint}/{personId}/1/10";

    ////Company
    //internal string Get_Company_GetActiveCompaniesFilteredByNameURL(string filter) => $"{CompanyEndpoint}/GetActiveCompaniesFilteredByName/{filter}";

    ////Product
    //internal string Get_Product_GetProductsByRestaurantIdURL(int restaurantId) => $"{ProductEndpoint}/{restaurantId}/1/10";
    //internal string Get_Product_GetByIdURL(int productId) => $"{ProductEndpoint}/{productId}";

    ////Branch
    //internal string Get_Branch_GetByRestaurantURL(int restaurantId) => $"{BranchEndpoint}/{restaurantId}/1/10";

    ////Shipment
    //internal string Get_Shipment_PayURL() => $"{ShipmentEndpoint}/pay";
    //internal string Get_Shipment_GetListByTransactionIdURL(string TransactionId) => $"{ShipmentEndpoint}/shipments-by-transaction-id/{TransactionId}";
    //internal string Get_Shipment_GetForCustomerURL() => $"{ShipmentEndpoint}/for-client/1/10";
    //internal string Get_Shipment_GetForManagerURL() => $"{ShipmentEndpoint}/for-manager/1/10";
    //internal string Get_Shipment_GetForCheffURL() => $"{ShipmentEndpoint}/for-cheff/1/10";
    //internal string Get_Shipment_GetForDeliveryURL() => $"{ShipmentEndpoint}/for-delivery/1/10";
    //internal string Get_Shipment_GetByIdURL(int shipmentId) => $"{ShipmentEndpoint}/{shipmentId}";
    //internal string Get_Shipment_AssignAccountURL() => $"{ShipmentEndpoint}/assign-account";
    //internal string Get_Shipment_SelfAssignAccountURL() => $"{ShipmentEndpoint}/self-assign-account";
    //internal string Get_Shipment_DetailURL(int detailId) => $"{ShipmentEndpoint}/detail/{detailId}";
    //internal string Get_Shipment_FinishProductPreparationURL(int detailId) => $"{ShipmentEndpoint}/finish-product-preparation/{detailId}";
    //internal string Get_Shipment_DeliverURL(int shipmentId) => $"{ShipmentEndpoint}/deliver/{shipmentId}";
    //internal string Get_Shipment_ReverseAssignmentURL(int shipmentId) => $"{ShipmentEndpoint}/revert-assignment/{shipmentId}";
    #endregion

}
