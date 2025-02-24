using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing;

public class Purchaser : MonoBehaviour
{
    public void OnPurchaseCompleted(UnityEngine.Purchasing.Product product)
    {
        switch (product.definition.id)
        {
            case "BuyingCrystalsOneCristal":
                AddCrystal(500);
                break;
            case "BuyingCrystalsTwoCristal":
                AddCrystal(1000);
                break;
            case "BuyingCrystalsThreeCristal":
                AddCrystal(2000);
                break;
            case "BuyingCrystalsFourCristal":
                AddCrystal(4000);
                break;
        }
    }

    private void AddCrystal(float crystalsCount)
    {
        float crystal = PlayerPrefs.GetFloat("Crystals");
        crystal += crystalsCount;
        PlayerPrefs.SetFloat("Crystals", crystal);
    }
}
