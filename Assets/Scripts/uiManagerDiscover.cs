using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManagerDiscover : MonoBehaviour {
    public GameObject WishListPanel;
    public GameObject ItemAvailablePanel;
    public GameObject ItemWishListPanel;
    public GameObject DonorProfile;
    public GameObject LoggedOutProfile;
    public GameObject ShopperProfile;

    private bool changeProfile = false;

    private void Awake()
    {
        if(sessionGlobalParams.instance.getUsertype() == 1){
            //user is a donor, load wish list
            ShowWishList();
            ItemWishListPanel.SetActive(false);
            DonorProfile.SetActive(true);
            LoggedOutProfile.SetActive(false);
            ShopperProfile.SetActive(false);
        }else{
            //user is not a donor, show item available
            ShowItemAvailable();
            ItemWishListPanel.SetActive(false);
            if(sessionGlobalParams.instance.getIsShopperLoggedIn()){
                //shopper is logged in, show user profile
                ShopperProfile.SetActive(true);
                DonorProfile.SetActive(false);
                LoggedOutProfile.SetActive(false);
            }else{
                //shopper is not logged in, show logged out profile
                ShopperProfile.SetActive(false);
                DonorProfile.SetActive(false);
                LoggedOutProfile.SetActive(true);
            }
        }
    }

    private void Update()
    {
        if(changeProfile){
            
        }
    }


    public void ShowWishList(){
        WishListPanel.SetActive(true);
        ItemAvailablePanel.SetActive(false);
        ItemWishListPanel.SetActive(false);
    }

    public void ShowItemAvailable(){
        WishListPanel.SetActive(false);
        ItemAvailablePanel.SetActive(true);
        ItemWishListPanel.SetActive(false);
    }

    public void showItemOnWishList(){
        ItemWishListPanel.SetActive(true);
    }

    public void closeItemWishList(){
        ItemWishListPanel.SetActive(false);
    }

    public void onProfileClicked(){
        if(sessionGlobalParams.instance.getUsertype()==2){
            if (sessionGlobalParams.instance.getIsShopperLoggedIn())
                SceneManager.LoadScene("Create_item");
            else
                SceneManager.LoadScene("RegistrationLogin");
        }
    }
}
