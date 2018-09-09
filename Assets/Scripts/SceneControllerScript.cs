using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllerScript : MonoBehaviour {

	void Start () {

	}
	
	void Update () {
		
	}

    public void LoadNewScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName,LoadSceneMode.Single);
    }
}
