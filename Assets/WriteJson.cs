using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System;
using UnityEngine;
using LitJson;
using System.IO;
public class WriteJson : MonoBehaviour
{
    public User User1 = new User("User1", "489cd5dbc708c7e541de4d7cd91ce6d0f1613573b7fc5b40d3942ccb9555cf35"); //pass: qwe
    public User User2 = new User("User2", "f0b8fd442e97d1306a9639f6350a986b17afed2e2d71b94ea73540a81102fb72"); //pass: ewq
    public User User3 = new User("User3", "fbd77bc68717f45eedbf71d09826c4a64c0447da1f42c7a6dbf608fa7c97f710"); //pass: 123q
    public User User4 = new User("User4", "7020e57625b6a6695ffd51ed494fbfc56c699eaceca4e77bf7ea590c7ebf3879"); //pass: zxcv
    public User User5 = new User("Artem Pachev", "5723360ef11043a879520412e9ad897e0ebcb99cc820ec363bfecc9d751a1a99"); //pass: god
    JsonData UserJson;

    private List<User> Users = new List<User>();
    void Start()
    {
        Users.Add(User1);
        Users.Add(User2);
        Users.Add(User3);
        Users.Add(User4);
        Users.Add(User5);

        if (!System.IO.File.Exists(Application.dataPath + "/login.json"))
        {
            UserJson += JsonMapper.ToJson(Users);
            File.WriteAllText(Application.dataPath + "/login.json", UserJson.ToString());
        }
    }

}

public class User
{
    public string login;
    public string password;

    public User(string login, string password)
    {
        this.login = login;
        this.password = password;
    }

}
