using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseHandeler : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
   
    void Start()
    {
        InputManager.controls.UI.Pause.performed += Pause;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Pause(InputAction.CallbackContext ctx)
    {
        bool isLoaded = SceneManager.GetSceneByName("pause menu").isLoaded;
        if (!isLoaded)
        {
            SceneManager.LoadScene("pause menu", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.UnloadSceneAsync("pause menu");
        }
    }
}
