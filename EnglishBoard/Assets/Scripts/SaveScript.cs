using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
[RequireComponent(typeof(UserManager))]
public class SaveScript : MonoBehaviour
{
    private UserManager userManager;
    private string savePath;

    // Start is called before the first frame update
    void Start()
    {
        userManager = GetComponent<UserManager>();
        savePath = Application.persistentDataPath + "/gameSaved.save";
        LoadBallsData();
    }

    public void SaveBallsData()
    {
        var save = new Save()
        {
            SavedSkinList = userManager.skinBought,
            indexSkinSaved = AlternatingBtns.skinArrayIndex,
            SavedDiceList = userManager.diceBought,
            indexDiceSaved = AlternatingBtns.diceArrayIndex,
        };
        var binaryFormatter = new BinaryFormatter();
        using (var fileStream = File.Create(savePath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }
        Debug.Log("[SaveScript] Data Saved.");
    }
    public void LoadBallsData()
    {
        if (File.Exists(savePath))
        {
            Save save;
            var binaryFormatter = new BinaryFormatter();
            using (var fileStream = File.Open(savePath, FileMode.Open))
            {
                save = (Save)binaryFormatter.Deserialize(fileStream);
            }
            userManager.skinBought = save.SavedSkinList;
            AlternatingBtns.skinArrayIndex = save.indexSkinSaved;
            userManager.diceBought = save.SavedDiceList;
            AlternatingBtns.diceArrayIndex = save.indexDiceSaved;
            Debug.Log("[SaveScript] Data Loaded");
        }
        else
        {
            Debug.LogWarning("[SaveScript] File doesn´t exist.");
        }

    }
}
[System.Serializable]
public class Save
{
    //list of Ball that we have bought.
    public List<int> SavedSkinList;
    //last index of our Ball array used.
    public int indexSkinSaved;
    //list of Ball that we have bought.
    public List<int> SavedDiceList;
    //last index of our Ball array used.
    public int indexDiceSaved;
}
