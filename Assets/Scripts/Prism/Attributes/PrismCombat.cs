using System;
using UnityEngine;

public class PrismCombat : MonoBehaviour
{
    private PrismCore model;
    public void Start()
    {
        if (TryGetComponent<PrismCore>(out var foundModel))
        {
            model = foundModel;
        }
        else
        {
            throw new ArgumentNullException("PrismModel not found for PrismMovement");
        }
    }

    public void Update()
    {
        
    }

    public void ApplyDamage(int damage, BodyPart part)
    {
        if (model.Body.BodyParts.ContainsKey(part))
        {
            int bodyDamage = model.Body.BodyParts[part] - damage;
            if (bodyDamage <= 0)
                model.Body.BodyParts.Remove(part);
            else
                model.Body.BodyParts[part] = bodyDamage;
        }
    }

    public bool IsDamaged()
    {
        return model.Body.IsDamaged();
    }

    public bool CanFight()
    {
        return model.Body.BodyParts.ContainsKey(BodyPart.Arms); // && CanMove() && IsAlive();
    }

    public void Fight(PrismCore target)
    {
        if (!CanFight())
            return;
        //if (!InRange(target, maxRange: 1))
        //    return;
        //model.Body.Fight(target);
    }
}

