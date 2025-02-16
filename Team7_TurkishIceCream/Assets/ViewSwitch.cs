using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewSwitch : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) {
            LoadNewView();
        }
    }

    public void LoadNewView() {
        //change scene names!
        if(SceneManager.GetActiveScene().name == "MaddaView1") {
            SceneManager.LoadScene("MaddaView2");

        } else if(SceneManager.GetActiveScene().name == "MaddaView2") {
            SceneManager.LoadScene("MaddaView1");
        }
    }
}
