using System;
using System.Collections.Generic;

internal class PrismScoreHelper
{
    internal static int CalculateHealthScore(Dictionary<BodyPart, int> defaultParts)
    {
        /*
         score = 0
        for part in parts:
            if isinstance(part.value, int):
                score += part.value
            else:
                raise ValueError(part)
        return score
         */
        int score = 0;
        foreach (var part in defaultParts.Keys)
        {
            score += defaultParts[part];
        }
        return score;
    }
}