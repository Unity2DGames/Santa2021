using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Level_selector : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text=level.ToString();
    }
    public void OpenScene(){
    SceneManager.LoadScene("Level "+level.ToString());
    } 
}
