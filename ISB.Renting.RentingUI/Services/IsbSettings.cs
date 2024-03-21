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
    internal string Get_Properties_List_URL(int page, int size) => $"{PropertyEndpoint}/{page}/{size}";
    internal string Get_Properties_URL() => $"{PropertyEndpoint}";
    internal string Get_Properties_WithId_URL(Guid id) => $"{PropertyEndpoint}/{id}";
    internal string Get_Properties_Buy_URL() => $"{PropertyEndpoint}/buy";

    //Contact
    internal string Get_Contacts_List_URL(int page, int size) => $"{ContactEndpoint}/{page}/{size}";
    internal string Get_Contacts_URL() => $"{ContactEndpoint}";
    internal string Get_Contacts_WithId_URL(Guid id) => $"{ContactEndpoint}/{id}";
    #endregion

}
