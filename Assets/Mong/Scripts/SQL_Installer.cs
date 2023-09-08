using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class USerInfo
{ 
    public string U_Name { get; private set; }
    public string U_Password { get; private set; }
    public string U_Birthday { get; private set; }

    public USerInfo(string name,string password, string birthday)
    {
        U_Name = name;
        U_Password = password;
        U_Birthday = birthday;
    }

}
public class SQL_Installer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
