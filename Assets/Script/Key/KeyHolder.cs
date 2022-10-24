using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<key.KeyType> keyList;

    private void Awake(){
        keyList= new List<key.KeyType>();
    }


    public void AddKey(key.KeyType keyType){
        Debug.Log("Key Added"+keyType);
        keyList.Add(keyType);

    }

    public void Removekey(key.KeyType keyType){
        Debug.Log("Key Added"+keyType);
        keyList.Remove(keyType);
    }


    public bool ContainKeys(key.KeyType keyType){
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        key key=collider.GetComponent<key>();
        if(key!=null){
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if(keyDoor!=null){
            if(ContainKeys(keyDoor.GetKeyType())){
                //current holding key open the door
                Removekey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
                
            }
        }
    }
}
