using System;
using System.Reflection;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UIElements;

public class Prism : MonoBehaviour
{
    public Guid Id { get; private set; }
    //public BoardPosition Position { get; private set; }
    public PrismBody Body { get; private set; }
    public PrismStats Stats { get; private set; }
    public PrismGender Gender { get; private set; }
    public PrismName Name { get; private set; }


    public void Start()
    {
        this.InitalizePrism();
    }

    public void InitalizePrism(PrismName name = null, PrismGender gender = PrismGender.Unknown, PrismStats stats = null)
    {
        this.Id = Guid.NewGuid();

        this.Body = new PrismBody();

        stats ??= new DefaultIdentity();
        this.Stats = stats;

        if (gender == PrismGender.Unknown)
        {
            gender = PrismGenderHelper.RandomPrismGender();
        }
        this.Gender = gender;

        if (name == null)
        {
            string firstName = PrismNameGenerator.RandomFirstName(Gender);
            string lastName = PrismNameGenerator.RandomLastName();
            this.Name = new PrismName(firstName, lastName);
            this.transform.name = this.Name.FullName;
        }
        else
        {
            this.Name = name;
        }
    }

    public bool Equals(Prism other)
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

    public void ApplyDamage(int damage, BodyPart part)
    {
        if (Body.BodyParts.ContainsKey(part))
        {
            int bodyDamage = Body.BodyParts[part] - damage;
            if (bodyDamage <= 0)
                Body.BodyParts.Remove(part);
            else
                Body.BodyParts[part] = bodyDamage;
        }
    }

    public void Update()
    {
        // Implement the update logic
    }

    public bool IsDamaged()
    {
        return Body.IsDamaged();
    }

    public bool CanFight()
    {
        return Body.BodyParts.ContainsKey(BodyPart.Arms) && CanMove() && IsAlive();
    }

    public void Fight(Prism target)
    {
        if (!CanFight())
            return;
        if (!InRange(target, maxRange: 1))
            return;
        Body.Fight(target);
    }

    public bool CanMove()
    {
        return Body.BodyParts.ContainsKey(BodyPart.Legs);
    }

    public bool IsAlive()
    {
        if (Body.BodyParts.Count <= 0)
            return false;
        if (!Body.BodyParts.ContainsKey(BodyPart.Head))
            return false;
        if (!Body.BodyParts.ContainsKey(BodyPart.Torso))
            return false;
        return true;
    }

    public void Move(int? x = null, int? y = null)
    {
        if (x == null && y == null)
        {
            int scaler = UnityEngine.Random.Range(1, 4);
            x = UnityEngine.Random.Range(-1, 2) * scaler + (int) this.transform.position.x;
            y = UnityEngine.Random.Range(-1, 2) * scaler + (int)this.transform.position.y;
        }
        this.transform.position = new Vector3((int)x, (int)y, 0);
    }

    public bool InRange(Prism target, float maxRange = 3)
    {
        float xDiff = target.transform.position.x - this.transform.position.x;
        float yDiff = target.transform.position.y - this.transform.position.y;

        // Calculate the Euclidean distance
        float distance = Mathf.Sqrt(xDiff * xDiff + yDiff * yDiff);

        // Check if the distance is within the specified range
        return distance <= maxRange;
    }

    public void Rest()
    {
        Body = new PrismBody();
    }
}