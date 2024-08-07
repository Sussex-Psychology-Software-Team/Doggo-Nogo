using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene
using UnityEngine.UI; // Slider
using System.Diagnostics; // Stopwatch

public class skipIntro : MonoBehaviour
{
    public Stopwatch spacebarHoldTimer = new Stopwatch(); // High precision timer: https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-8.0&redirectedfrom=MSDN#remarks
    public double timeToSkip = 2.0;
    public Slider slider;

    public void loadNextScene(){
        SceneManager.LoadScene("Simple RT");
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space)){
            spacebarHoldTimer.Start();
        } else if(Input.GetKeyUp(KeyCode.Space)){
            spacebarHoldTimer.Reset();
        }

        slider.value = (float)(spacebarHoldTimer.Elapsed.TotalSeconds / timeToSkip);

        if (Input.GetKey(KeyCode.Escape) || spacebarHoldTimer.Elapsed.TotalSeconds >= timeToSkip){
            loadNextScene();
        }
    }
}
