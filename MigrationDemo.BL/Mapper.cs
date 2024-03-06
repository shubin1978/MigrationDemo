using MigrationDemo.BL.Model;
using PhoneType = MigrationDemo.DAL.Model.PhoneType;

namespace MigrationDemo.BL;

public static class Mapper
{
    public static Dictionary<DAL.Model.PhoneType, BL.Model.PhoneType> PhoneTypes = new()
    {
        {DAL.Model.PhoneType.Unknown, BL.Model.PhoneType.Unknown},
        {DAL.Model.PhoneType.Home, BL.Model.PhoneType.Home},
        {DAL.Model.PhoneType.Mobile, BL.Model.PhoneType.Mobile}
    };
    public static BL.Model.Phone MapPhoneDALToPhineBL(DAL.Model.Phone phone)
    {
        return new Phone()
        {
            Id = phone.Id,
            Number = phone.Number,
            Type = PhoneTypes[phone.Type]
        };
    }
    public static BL.Model.Person? MapPersonDALToPersonBL(DAL.Model.Person? person)
    {
        return person is not null ? 
            new BL.Model.Person()
        {
            Id = person.Id,
            LastName = person.LastName.Name,
            FirstName = person.FirstName.Name,
            Phones = person.Phones.Select(p => MapPhoneDALToPhineBL(p)).ToList()
        }: null;
    }
}