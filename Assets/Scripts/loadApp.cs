using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadApp : MonoBehaviour {
    public GameObject firstTimePanel;
    public GameObject ShopperConfirmPanel;
    public GameObject TradeCompleteDonor;
    public GameObject TradeCompleteShopper;
	// Use this for initialization
	void Start () {
        firstTimePanel.SetActive(false);ShopperConfirmPanel.SetActive(false);
        TradeCompleteDonor.SetActive(false);TradeCompleteShopper.SetActive(false);
        string arguments = "";
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");


        arguments = intent.Call<string>("getDataString");
        Debug.Log(arguments);

        if(arguments!=null){
            if(arguments.Contains("offers")){
                //load offers page/scene
                Debug.Log("offers received");
                ShopperConfirmPanel.SetActive(true);
            }else if(arguments.Contains("D_offer_confirm")){
                //load donor offer confirmed page/scene
                Debug.Log("donor has confirmed offer");
                TradeCompleteShopper.SetActive(true);
            }else if(arguments.Contains("R_offer_confirm")){
                //load receiver offer confirmed page/scene
                Debug.Log("receiver has confirmed offer");
                TradeCompleteDonor.SetActive(true);
            }
        }else{
            //load first time screen
            firstTimePanel.SetActive(true);
        }
		
	}
	
}
