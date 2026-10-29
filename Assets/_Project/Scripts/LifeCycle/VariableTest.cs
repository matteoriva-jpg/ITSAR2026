using System;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class VariableTest : MonoBehaviour
{
    [SerializeField] public int shopIndex = 8;
    #region INCAPSULAMENTO
    //INCAPSULAMENTO
    public int ShopIndexBis { get; private set; }
    public int ShopIndex => ShopIndex;

    public void SetShopIndexValue(int _shopIndex)
    {
        if(shopStateBase != ShopState.CLOSING)
        {
            shopIndex = _shopIndex;
        }
    }
        //
    #endregion
        [SerializeField] float shopRevenues = 50.5f;
    [SerializeField] bool shopOpen = false;

    public enum ShopState { OPENING = 0, SELLING, RESTOCKING, CLOSING }
    [SerializeField] ShopState shopStateBase = ShopState.OPENING;
    [SerializeField] ShopState shopStateAdvanced = ShopState.RESTOCKING;

    [SerializeField] string shopName = "shop";

    [SerializeField] int[] productArray = new int[5];

    [SerializeField] List<int> productlist = new List<int>();

    //keys = nome prodotto; float = prezzo prodotto;
    Dictionary<string, float> productDictionary = new Dictionary<string, float>();
    HashSet<Product> productHashSet = new HashSet<Product>();

    [SerializeField] List<Product> productList = new List<Product>();

}


[Serializable]
public class Product
{
    public string Name;
    public float Price;
}
