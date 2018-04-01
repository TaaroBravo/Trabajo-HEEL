using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VelocityManager {

    private static float gameVelocity;

    public static float GetGameVelocity()
    {
        return gameVelocity;
    }

    public static void ChangeVelocity(float newVelocity)
    {
        gameVelocity = newVelocity;
    }
}
