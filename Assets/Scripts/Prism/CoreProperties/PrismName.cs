using System;
using UnityEngine.Analytics;

public class PrismName
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public readonly string FullName;
    public PrismName(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.FullName = $"{this.FirstName} {this.LastName}";
    }

    public PrismName(PrismGender gender, PrismRace race)
    {
        this.FirstName = NameFactory.RandomFirstName(gender, race);
        this.LastName = NameFactory.RandomLastName(race);
        this.FullName = $"{this.FirstName} {this.LastName}";
    }

    public override string ToString() {
        return FullName;   
    }
}