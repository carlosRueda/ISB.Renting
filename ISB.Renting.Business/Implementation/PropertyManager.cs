using AutoMapper;
using ISB.Renting.Business.Interface;
using ISB.Renting.Cross;
using ISB.Renting.Data.Interface;
using ISB.Renting.Models.Data;
using ISB.Renting.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ISB.Renting.Business.Implementation;

public class PropertyManager : BaseManager, IPropertyManager
{
    private readonly IUnitOfWork _unitOfWork;
    public PropertyManager(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper)
    {
        _unitOfWork = unitOfWork;
    }

    public PaginatedResultDTO<PropertyDTO> GetAll(PaginatedSearchDTO pagination)
    {
        var query = _unitOfWork.Property.GetAll();
        return GetPaged<Property, PropertyDTO>(query, pagination);
    }

    public PropertyDTO Get(Guid id)
    {
        var property = _unitOfWork.Property.Find(x => x.Id == id, includes: x => x.Include(r => r.PriceHistories)).FirstOrDefault();
        return _mapper.Map<PropertyDTO>(property);
    }

    public void Create(List<PropertyDTO> properties)
    {
        var dbProperties = _mapper.Map<List<Property>>(properties);
        dbProperties.ForEach(Property => { Property.Id = Guid.NewGuid(); });

        _unitOfWork.Property.AddRange(dbProperties);
        _unitOfWork.Save();
    }

    public bool Update(List<PropertyDTO> properties)
    {
        var allUpdated = true;
        foreach (var property in properties)
        {
            var dbProperty = _unitOfWork.Property.GetById(property.Id);

            if (dbProperty == null)
            {
                allUpdated = false;
                continue;
            }

            if (property.Price != dbProperty.Price)
            {
                _unitOfWork.PriceHistory.Add(new PriceHistory()
                {
                    Id = Guid.NewGuid(),
                    PropertyId = property.Id,
                    NewPrice = property.Price,
                    CreationDate = DateTime.Now,
                });
            }

            _mapper.Map(property, dbProperty);
        }
        _unitOfWork.Save();
        return allUpdated;
    }

    public bool Delete(Guid id)
    {
        var dbProperty = _unitOfWork.Property.GetById(id);

        if (dbProperty == null)
            return false;

        _unitOfWork.Property.Remove(dbProperty);
        _unitOfWork.Save();

        return true;
    }

    public string Buy(PurchaseDTO purchase)
    {
        var contact = _unitOfWork.Contact.GetById(purchase.ContactId);
        if (contact == null)
            return string.Format(AppResources.NoExist, nameof(Contact));

        var property = _unitOfWork.Property.GetById(purchase.PropertyId);
        if (property == null)
            return string.Format(AppResources.NoExist, nameof(Property));

        if (purchase.Price <= 0)
            return AppResources.PriceMustToBePossitive;

        var lastOwnership = _unitOfWork.Ownership.Find(x=> x.PropertyId == purchase.PropertyId && x.EffectiveTill == null).FirstOrDefault();
        if (lastOwnership != null)
        {
            if (lastOwnership.ContactId == purchase.ContactId)
                return AppResources.CantBuyYourOwnProperty;
            
            lastOwnership.EffectiveTill = DateTime.Now;
        }

        _unitOfWork.Ownership.Add(new Ownership()
        {
            PropertyId = property.Id,
            ContactId = contact.Id,
            Price = purchase.Price,
            Id = Guid.NewGuid(),
            EffectiveFrom = DateTime.Now,
        });

        _unitOfWork.Save();

        return AppResources.PropertySold;
    }
}
