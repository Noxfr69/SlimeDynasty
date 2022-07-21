using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader 
{
    public static int currentlvl = 0;

    public enum Scene
    {
        MainMenu,
        Loading,
        Level_1,
        Level_2,
        Level_3,
        Level_4,
        WinMenu,
        TD_Level_1

    }



    private static Action onLoaderCallback;

    public static void Load(Scene scene){
        // Set the loader callback action to load the target scene 
        onLoaderCallback = () => {
        SceneManager.LoadScene(scene.ToString());
        };
        // loading scene get to go first in the meantime
        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallback(){
        if(onLoaderCallback != null){
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

}
