using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _Instance;
    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType(typeof(T)) as T;
                if (_Instance == null)
                {
                    GameObject obj = new GameObject();
                    //obj.hideFlags = HideFlags.DontSave;
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _Instance = (T)obj.AddComponent(typeof(T));
                }
            }
            return _Instance;
        }
    }
    public virtual void Awake()//所有继承此类的单例脚本在场景变换后依然存在
    {
        DontDestroyOnLoad(this.gameObject);
        if (_Instance == null)
        {
            _Instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
