using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManagerProfile : MonoBehaviour {

    public GameObject profilePanel;
    public GameObject addItemPanel;
    public GameObject emptyItem3;
    public GameObject addedItem3;
    public GameObject returnItemDescription;
    public GameObject karmaRoll;
    public Toggle karma;
    public Toggle item;

    private void Awake()
    {
        profilePanel.SetActive(true);
        addItemPanel.SetActive(false);
        karmaRoll.SetActive(false);
        returnItemDescription.SetActive(true);
    }

    public void addItem(){
        profilePanel.SetActive(false);
        addItemPanel.SetActive(true);
        emptyItem3.SetActive(false);
        addedItem3.SetActive(false);
    }

    public void CancelAddItem(){
        profilePanel.SetActive(true);
        addItemPanel.SetActive(false);
        emptyItem3.SetActive(true);
        addedItem3.SetActive(false);
    }

    public void CompleteAddItem()
    {
        profilePanel.SetActive(true);
        addItemPanel.SetActive(false);
        emptyItem3.SetActive(false);
        addedItem3.SetActive(true);
    }

    public void returnToggle(){
        returnItemDescription.SetActive(!returnItemDescription.activeSelf);
        karmaRoll.SetActive(!karmaRoll.activeSelf);
    }

    public void karmaOnValueChange(){
        item.isOn = false;
    }

    public void itemOnValueChanged(){
        karma.isOn = false;
    }

    public void goToScene(int index){
        if(index>=0 && index <= SceneManager.sceneCount)
        SceneManager.LoadScene(index);
    }


}
