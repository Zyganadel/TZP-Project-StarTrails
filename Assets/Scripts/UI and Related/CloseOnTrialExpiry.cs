using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseOnTrialExpiry : MonoBehaviour
{
    public bool quit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5); 

        if (quit) { Application.Quit(); }
        else { SceneManager.LoadScene(0); }
    }
}
