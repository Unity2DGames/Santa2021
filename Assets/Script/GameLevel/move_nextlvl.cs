using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move_nextlvl : MonoBehaviour
{
    public int nextSceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad=SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            //Move to next level
            SceneManager.LoadScene(nextSceneLoad);

            //Setting Int for Index
            if(nextSceneLoad>PlayerPrefs.GetInt("levelAt")){

                PlayerPrefs.SetInt("levelAt",nextSceneLoad);
            }
        }
    }
}
