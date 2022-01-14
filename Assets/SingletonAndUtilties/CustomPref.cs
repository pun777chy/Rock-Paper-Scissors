using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// CustomPref is centeralize class to save preferences 
/// Since we are only using preferences with integer so till now we didn't have to implement for other Data types
/// I had plans to write encyption code for preferences to protect from online hacks.
/// </summary>
public static class CustomPref 
{
 public static  void SetPrefs(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }
    public static int GetPrefs(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    public static int GetPrefs(string key, int value)
    {
        return PlayerPrefs.GetInt(key,value);
    }
    public static void SavePrefs()
    {
       PlayerPrefs.Save();
    }
}
