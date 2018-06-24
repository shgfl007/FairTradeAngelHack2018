using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManagerRegLogin : MonoBehaviour {

    public InputField email;
    public InputField password;
    public GameObject RegPanel;
    public GameObject LoginPanel;

    private string shopperEmail;

    private void Start()
    {
        shopperEmail = sessionGlobalParams.instance.getShopperEmail();
        //Debug.Log(shopperEmail);
    }

    public void submit(){
        //if(email.text.ToString() == shopperEmail){
        if (sessionGlobalParams.instance.getUsertype() != 1){
            //set shopper logged in status
            sessionGlobalParams.instance.setIsShopperLoggedIn(true);
            //go to shopper profile
            SceneManager.LoadScene("Create_item");
        }
    }

    public void goToScene(int index){
        if(index >=0 && index <= SceneManager.sceneCount)
            SceneManager.LoadScene(index);
    }

    public void showRegPanel(){
        RegPanel.SetActive(true);
        LoginPanel.SetActive(false);
    }

    public void showLoginPanel(){
        LoginPanel.SetActive(true);
        RegPanel.SetActive(false);
    }

}
