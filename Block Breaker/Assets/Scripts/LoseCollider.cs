﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        FindObjectOfType<SceneLoader>().LoseGame();
    }
}
