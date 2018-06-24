using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sessionGlobalParams : MonoBehaviour {
    
    public static sessionGlobalParams instance = null;
    private int Usertype = 0; //0 for none, 1 for donor, 2 for shopper
    private string ShopperName = "Rahim";
    private string DonorName = "Dave";

    private string TradeObjectName = "Baby Crib";
    public string getTradeObjectName() { return TradeObjectName; }

    private int TradeKarmaNumber = 30;
    public int getTradeKarmaNumber() { return TradeKarmaNumber; }

    private string TradeFoodName = "Home Made Syrian Kebab for Family of 4";
    public string getTradeFoodName() { return TradeFoodName; }

    private string shopperEmail = "rahim@gmail.com";
    public string getShopperEmail() { return shopperEmail; }

    private bool isShopperLoggedIn = false;
    public bool getIsShopperLoggedIn() { return isShopperLoggedIn; }
    public void setIsShopperLoggedIn(bool logged) { isShopperLoggedIn = logged; }

    private void Awake()
    {
        //check if instance already exists
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void setUsertype(int type){
        Usertype = type;
        Debug.Log("set user type to" + type);
    }

    public int getUsertype(){
        return Usertype;
    }

    public string getShopperName(){
        return ShopperName;
    }

    public string getDonorName(){
        return DonorName;
    }



}
