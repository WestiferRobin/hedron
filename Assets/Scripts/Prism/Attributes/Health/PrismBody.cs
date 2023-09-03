using Assets.Scripts.Prism;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum BodyPart
{
    Unknown = 0,
    Head = 1,
    Torso = 2,
    Arms = 3,
    Legs = 4,
}


public class PrismBody
{

    public Dictionary<BodyPart, int> BodyParts { get; internal set; }

    public void Start()
    {
        this.BodyParts = PrismBodyBuilder.CreateDefaultBody();
    }

    public bool IsDamaged()
    {
        var defaultParts = PrismBodyBuilder.CreateDefaultBody();
        var defaultHealthScore = PrismScoreHelper.calculateHealthScore(defaultParts);
        var ourHealthScore = PrismScoreHelper.calculateHealthScore(this.BodyParts);
        if (defaultHealthScore <= 0)
        {
            return true;
        }
        int ratioScore = ourHealthScore / defaultHealthScore;
        return ratioScore <= 0.5;

    }

    public bool IsAlive()
    {
        if (BodyParts.Count <= 0)
            return false;
        if (!BodyParts.ContainsKey(BodyPart.Head))
            return false;
        if (!BodyParts.ContainsKey(BodyPart.Torso))
            return false;
        return true;
    }

    public void Rest()
    {
        Start();
    }
}