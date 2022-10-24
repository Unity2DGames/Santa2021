using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Unlock_level : MonoBehaviour
{
    public Button[] LvlButton;

	void Start () {

	int levelAt = PlayerPrefs.GetInt("levelAt", 2);
    for (int i=0; i <LvlButton.Length; i++){

        if(i+2>levelAt){
            LvlButton[i].interactable=true;
        }
    }

}
}

