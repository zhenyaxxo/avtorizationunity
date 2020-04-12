using UnityEngine;
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.UI;
using LitJson;
using System.IO;
using System.Windows;


public class ButtonEnter : MonoBehaviour
{
    private string temp;
    public Button b;
    public InputField username;
    public InputField password;
    string encryptPass;
    string TruePass;
    private string JsonString;
    private JsonData itemData;

    public void OnClick(){
        encryptPass = Encrypt(password.text);
        JsonString = File.ReadAllText(Application.dataPath + "/login.json");
        itemData = JsonMapper.ToObject(JsonString);
        for(int i = 0; i < 5; i++)
        {
            temp = itemData[i]["login"].ToString();
            if(temp == username.text)
            {
                temp = itemData[i]["password"].ToString();
                if (temp == encryptPass)
                {
                    b.image.color = new Color32(0, 255, 47, 255);
                }else
                {
                    b.image.color = new Color32(255, 0, 0, 255);
                }
            }
        }
    }

    void Start()
    {
        b.onClick.AddListener(OnClick);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(username.text != "") OnClick();
        }
    }
    private string Encrypt(string text)
    {
        byte[] data = Encoding.Default.GetBytes(text);            
        var result = new SHA256Managed().ComputeHash(data);
        return BitConverter.ToString(result).Replace("-","").ToLower();                
    }
    
    
}