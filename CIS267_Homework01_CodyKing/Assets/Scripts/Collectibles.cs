using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public int collectableValue;
    public string milkFlavor;
    // Start is called before the first frame update
    void Start()
    {

    }


    public void destroyCollectable()
    {
        Destroy(this.gameObject);
    }

    public int getCollectableValue()
    {
        return collectableValue;
    }

    public string getMilkType()
    {
        return milkFlavor;
    }

    public void setCollectableValue(int value)
    {
        collectableValue = value;
    }

    public void setMilkFlavor(string melk)
    {
        milkFlavor = melk;
    }
}
