using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager _mInstance;
    public static SaveManager Instance
    {
        get
        {
            if (_mInstance == null)
            {
                GameObject go = new GameObject("-SaveManager-", typeof(SaveManager));
    
                _mInstance = go.GetComponent<SaveManager>();
            }
            return _mInstance;
        }
    }
    
    public DataContainer dataContainer;
    private string _path;
    
    private void Awake()
    {
        _path = Application.dataPath + "/SaveFile/save_inventory.json";
        DontDestroyOnLoad(gameObject);
    }
    
    public DataContainer GetData()
    {
        LoadData();
        return dataContainer;
    }
    
    public void SetScore(int value)
    {
        LoadData();
        dataContainer.lastScore = value;
        if (dataContainer.score < value)
        {
            dataContainer.score = value;
        }
        SaveData();
    }
    
    public void SetSkin(string value)
    {
        dataContainer.skin = value;
        SaveData();
    }

    private void SaveData()
    {
        string json = JsonUtility.ToJson(dataContainer);
        Debug.Log(json);
        File.WriteAllText(_path, json);
    }
    
    [Serializable]
    public class DataContainer
    {
        public string skin;
        public int lastScore;
        public int score;
    }

    private void LoadData()
    {
        Debug.Log(_path);
        
        if (!File.Exists(_path))
            SaveData();
        
        string json = File.ReadAllText(_path);
        
        if (string.IsNullOrEmpty(json))
        {
            dataContainer = new DataContainer();
        }
        else
        {
            dataContainer = JsonUtility.FromJson<DataContainer>(json);
        }
    }
}
