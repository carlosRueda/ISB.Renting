using AutoMapper;
using ISB.Renting.Cross;
using ISB.Renting.Models.Data;
using ISB.Renting.Models.DTO;

namespace ISB.Renting.Business.AutoMapper;
internal class BusinessProfile : Profile
{
    public BusinessProfile()
    {
        CreateMap<Contact, ContactDTO>();
        CreateMap<ContactDTO, Contact>();

        CreateMap<Property, PropertyDTO>();
        CreateMap<PropertyDTO, Property>();

        CreateMap<PriceHistory, PriceHistoryDTO>();
        CreateMap<Ownership, DashboardResultDTO>()
            .ForMember(dest => dest.OwnershipId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.PropertyName, opt => opt.MapFrom(src => src.Property.Name))
            .ForMember(dest => dest.AskingPrice, opt => opt.MapFrom(src => src.Property.Price))
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => $"{src.Contact.FirstName} {src.Contact.LastName}"))
            .ForMember(dest => dest.DateOfPurchase, opt => opt.MapFrom(src => src.EffectiveFrom))
            .ForMember(dest => dest.SoldPriceEur, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.SoldPriceUsd, opt => opt.MapFrom(src => Conversor.EUR_To_USD(src.Price)));

    }
}
