using AutoMapper;
using ISB.Renting.Business.Interface;
using ISB.Renting.Data.Interface;
using ISB.Renting.Models.Data;
using ISB.Renting.Models.DTO;
using System.Linq;

namespace ISB.Renting.Business.Implementation;

public class ContactManager : BaseManager, IContactManager
{
    private readonly IUnitOfWork _unitOfWork;
    public ContactManager(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper)
    {
        _unitOfWork = unitOfWork;
    }

    public PaginatedResultDTO<ContactDTO> GetAll(PaginatedSearchDTO pagination)
    {
        var query = _unitOfWork.Contact.GetAll();
        return GetPaged<Contact, ContactDTO>(query, pagination);
    }

    public ContactDTO Get(Guid id)
    {
        var contact = _unitOfWork.Contact.Find(x => x.Id == id).FirstOrDefault();
        return _mapper.Map<ContactDTO>(contact);
    }

    public void Create(List<ContactDTO> contacts)
    {
        var dbContacts = _mapper.Map<List<Contact>>(contacts);
        dbContacts.ForEach(contact => { contact.Id = Guid.NewGuid(); });

        _unitOfWork.Contact.AddRange(dbContacts);
        _unitOfWork.Save();
    }

    public bool Update(List<ContactDTO> contacts)
    {
        var allUpdated = true;
        foreach (var contact in contacts)
        {
            var dbContact = _unitOfWork.Contact.GetById(contact.Id);

            if (dbContact == null)
            {
                allUpdated = false;
                continue;
            }

            _mapper.Map(contact, dbContact);

        }
        _unitOfWork.Save();
        return allUpdated;
    }

    public bool Delete(Guid id)
    {
        var dbContact = _unitOfWork.Contact.GetById(id);

        if (dbContact == null)
            return false;

        _unitOfWork.Contact.Remove(dbContact);
        _unitOfWork.Save();

        return true;
    }
}
