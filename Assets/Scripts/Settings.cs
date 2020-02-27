using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public SetingsData _data;    
    void Awake()
    {
        string path = Application.dataPath + "/config.json";
        string jsonSettings = File.ReadAllText(path);
        _data = JsonUtility.FromJson<SetingsData>(jsonSettings);
    }
    [System.Serializable]
    public class SetingsData
    {
        public int _enemyCount;
        public Colors _colors;
    }
    [System.Serializable]
    public class Colors
    {
        public User _user;
        public Enemy _enemy;
    }
    [System.Serializable]
    public class User
    {
        public int[] _color;
    }
    [System.Serializable]
    public class Enemy
    {
        public int[] _color1;
        public int[] _color2;
    }
}
