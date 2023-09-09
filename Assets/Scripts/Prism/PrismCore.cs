using System;
using UnityEngine;

public class PrismCore : MonoBehaviour
{
    public readonly Guid Id = Guid.NewGuid();
    public PrismBody Body { get; private set; }
    public PrismStats Stats { get; private set; }
    public PrismGender Gender { get; private set; }
    public PrismName Name { get; private set; }

    public void Start()
    {
        this.Body ??= new PrismBody();

        this.Stats ??= new PrismStats();

        if (this.Gender == PrismGender.Unknown)
        {
            // TODO: Change this when Female Human sprite is ready
            this.Gender = PrismGender.Male;//PrismGenderFactory.RandomGender();
        }

        string firstName = PrismNameFactory.RandomFirstName(Gender);
        string lastName = PrismNameFactory.RandomLastName();
        this.Name ??= new PrismName(firstName, lastName);
        this.transform.name = this.Name.FullName;
    }

    public void Update()
    {
        
    }
}