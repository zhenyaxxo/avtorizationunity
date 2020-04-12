using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;
public class AddOptions : MonoBehaviour
{
    public Dropdown m_Dropdown;
    private string JsonString;
    private JsonData itemData;
    List<string> m_DropOptions = new List<string>();
    private string temp;
    void Start()
    {
        JsonString = File.ReadAllText(Application.dataPath + "/login.json");
        itemData = JsonMapper.ToObject(JsonString);
        for(int i = 0; i < 5; i++)
        {
            temp = itemData[i]["login"].ToString();
            m_DropOptions.Add(temp);
        }
        m_Dropdown.AddOptions(m_DropOptions);
    }
}
