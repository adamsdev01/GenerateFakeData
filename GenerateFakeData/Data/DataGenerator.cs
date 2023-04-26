using Bogus;

namespace GenerateFakeData.Data;

public class DataGenerator
{
    Faker<PersonModel> personModelFake;

    public DataGenerator()
    {
        Randomizer.Seed = new Random(Seed: 123);

        var date1 = new DateTime(1951, 1, 1);
        var date2 = new DateTime(2005, 1, 1);

        personModelFake = new Faker<PersonModel>()
            .RuleFor(u => u.Id, f => f.Random.Int(min: 1, max: 10000))
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.DOB, f => f.Date.Between(date1, date2))
            .RuleFor(u => u.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(u => u.StreetAddress, f => f.Address.StreetAddress())                
            .RuleFor(u => u.Address2, f => f.Address.SecondaryAddress())
            .RuleFor(u => u.City, f => f.Address.City())
            .RuleFor(u => u.State, f => f.Address.State())
            .RuleFor(u => u.ZipCode, f => f.Address.ZipCode());
    }

    public PersonModel GeneratePerson()
    {
        return personModelFake.Generate();
    }

    public IEnumerable<PersonModel> GeneratePeople()
    {
        return personModelFake.GenerateForever();
    }
}
