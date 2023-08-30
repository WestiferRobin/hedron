using System;
using UnityEngine.Analytics;

public class PrismName
{
    public string FirstName { get; set; }
    public string lastName { get; set; }

    public readonly string FullName;
    public PrismName(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.lastName = lastName;
        this.FullName = $"{this.FirstName}, {this.lastName}";
    }

    public PrismName(PrismGender gender, string firstName = null, string lastName = null)
    {
        firstName ??= PrismNameGenerator.RandomFirstName(gender);
        lastName ??= PrismNameGenerator.RandomLastName();
        this.FirstName = firstName;
        this.lastName = lastName;
    }

    public override string ToString() {
        return FullName;   
    }
}