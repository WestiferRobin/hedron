using System;
using UnityEngine;

public class PrismCore : MonoBehaviour
{
    public readonly Guid Id = Guid.NewGuid();
    public PrismBody Body { get; private set; }
    public PrismStats Stats { get; private set; }
    public PrismGender Gender { get; private set; }
    public PrismName Name { get; private set; }

    #region Unity Methods
    public void Start()
    {
        this.Body ??= new PrismBody();

        this.Stats ??= new DefaultIdentity();

        if (this.Gender == PrismGender.Unknown)
        {
            this.Gender = PrismGenderHelper.RandomPrismGender();
        }

        string firstName = PrismNameGenerator.RandomFirstName(Gender);
        string lastName = PrismNameGenerator.RandomLastName();
        this.Name ??= new PrismName(firstName, lastName);
        this.transform.name = this.Name.FullName;
    }

    public void Update()
    {
        
    }
    #endregion

    #region Aux Methods
    public bool Equals(PrismCore other)
    {
        if (other == null)
            return false;

        return other.Id == Id;
    }

    public override string ToString()
    {
        string str = $"Name: {Name}\n";
        str += $"Gender: {Gender}\n";
        str += $"Position: {this.transform.position}\n";
        str += $"Body: {Body}\n";
        return str;
    }
    #endregion
}