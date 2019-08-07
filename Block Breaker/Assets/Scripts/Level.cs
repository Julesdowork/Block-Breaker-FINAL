using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;       // only serialized for debugging

    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        CountBlocks();
    }

    private void CountBlocks()
    {
        breakableBlocks = GameObject.FindGameObjectsWithTag("Breakable").Length;
    }

    public void DestroyBlock()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
