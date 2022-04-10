using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupButton : MonoBehaviour
{
    [SerializeField] Popup popup;

    public void click(){
        GameObject popupObj = popup.gameObject;
        if (popupObj.activeInHierarchy){
            popup.gameObject.SetActive(false);
        }
        else {
            popup.gameObject.SetActive(true);
        }
        
    }
}
