using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour {
    public GameObject TradeCompleteShopper;
    public void GoToDiscover(){
        SceneManager.LoadScene(1);

    }

    public void GoToScene(int index){
        if (index <= SceneManager.sceneCount && index >= 0)
            SceneManager.LoadScene(index);
        else
            Debug.Log("wrong scene index");
    }

    public void SetUserType(int type){
        sessionGlobalParams.instance.setUsertype(type);
    }

    public void onShopperConfirmed(){
        //show secuss
        TradeCompleteShopper.SetActive(true);
    }
}
