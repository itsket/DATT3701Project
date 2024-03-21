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
        if (number == "Clear")
        {
            //if Clear button pressed
            Clear();
            return;
        }
        else if(number == "Enter")
        {
            //if Enter button pressed

            Enter();
            return;
        }

        int length = passwordText.text.ToString().Length;
       
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

            passwordText.color = Color.red;
            Clear();
        }
    }

  


}
