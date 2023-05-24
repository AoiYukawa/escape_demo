using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator Transition;
    public string SceneName;

    public float TransitionTime = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene(SceneName);
        }
    }

    public void LoadNextScene(string Scene)
    {
        StartCoroutine(LoadLevel(Scene));
    }

    IEnumerator LoadLevel(string Scene) 
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransitionTime);

        SceneManager.LoadScene(Scene);
    }
}
