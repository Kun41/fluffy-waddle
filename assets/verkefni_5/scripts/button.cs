using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class button : MonoBehaviour
{
    public void MoveToScene(int sceneID)  // bara public variable fyrir val i hvada scena takki loadar
    {
        SceneManager.LoadScene(sceneID);
    }
}