using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int gold;

    public void AddGold(int i)
    {
        gold += i;
        gold = Mathf.Clamp(gold, 0, 10000);
    }
}
