using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class keypad : MonoBehaviour
{



    public string password;
    public Text passwordText;



    private void Start()
    {
        //Shows what is entered 
        passwordText.text = "";
    }

    public void PasswordEntry(string number)
    {
        int length = passwordText.text.ToString().Length;

        if(length==3){
            Enter();
        } else if(length>3){
            Clear();
        }
        

       
    }

    public void Clear()
    {
        //Clear 
        passwordText.text = "";
        passwordText.color = Color.white;
    }

    private void Enter()
    {
        //Enter
        if (passwordText.text == password)
        {
            //script for unlocked 
          
            passwordText.color = Color.green;
            Clear();
        }
        else
        {
            //script for locked 
            //dont add anything cause if locked it should do nothing

            passwordText.color = Color.red;
            Clear();
        }
    }

  


}
