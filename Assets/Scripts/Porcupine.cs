using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Pv.Unity;

public class Porcupine : MonoBehaviour
{
    
#if UNITY_EDITOR
        private const string ACCESS_KEY = "uVKTJzxBwLyJUkQRp4HfwDxTgSWh40bQJCf0Pq79KV/TYL6P+oXDkg==";
#else
    private const string ACCESS_KEY = "8O85q7ZW9GE2symXlO5ftSrwhZqNEJkonNXeOcJxXRtiMIP6Sqqyag=="; 
#endif
    PorcupineManager _porcupineManager;
    private MagicCast _magicCast; 

    private void Start()
    {
#if UNITY_EDITOR
        var keywordPaths = new[]
        {
            Path.Combine(Application.streamingAssetsPath, "keyword_files/windows/temp-e-stas_windows.ppn"),
            Path.Combine(Application.streamingAssetsPath, "keyword_files/windows/Ignition_en_windows.ppn"),
            Path.Combine(Application.streamingAssetsPath, "keyword_files/windows/Adamas_en_windows.ppn")
        };
#else
        var keywordPaths = new[]
        {
            Path.Combine(Application.streamingAssetsPath, "keyword_files/windows/temp-e-stas_android.ppn"),
            Path.Combine(Application.streamingAssetsPath, "keyword_files/windows/Ignition_en_android.ppn"),
        };
#endif
        print(keywordPaths[0]);
        try
        {
            _porcupineManager = PorcupineManager.FromKeywordPaths(ACCESS_KEY, 
                keywordPaths,
                OnWakeWordDetected, processErrorCallback: ErrorCallback,
                sensitivities: Enumerable.Repeat(0.8f, keywordPaths.Length));
        }
        catch (PorcupineInvalidArgumentException ex)
        {
            print(ex.Message);
        }
        catch (PorcupineActivationException)
        {
            print("AccessKey activation error");
        }
        catch (PorcupineActivationLimitException)
        {
            print("AccessKey reached its device limit");
        }
        catch (PorcupineActivationRefusedException)
        {
            print("AccessKey refused");
        }
        catch (PorcupineActivationThrottledException)
        {
            print("AccessKey has been throttled");
        }
        catch (PorcupineException ex)
        {
            print("PorcupineManager was unable to initialize: " + ex.Message);
        }
        
        _porcupineManager.Start();
        _magicCast = GetComponent<MagicCast>();
    }

    private void OnWakeWordDetected(int keywordIndex)
    {
        print(keywordIndex);
        if(_magicCast!= null) _magicCast.Cast(keywordIndex);
        if (keywordIndex == 0)
        {
            _magicCast.Cast(keywordIndex);
        }
        else if (keywordIndex == 1)
        {

        }
        else if (keywordIndex == 2)
        {

        }
    }

    private void ErrorCallback(Exception e)
    {
        print(e.Message);
    }
}