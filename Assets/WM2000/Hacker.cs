using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menuHint = "Type menu to return to the main menu";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "face", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "astronauts", "telescope", "environment", "exploration", "starfield" };

    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    void Start()
    {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for Stu's FaceBook account");
        Terminal.WriteLine("Press 2 for Ian's PornHub account");
        Terminal.WriteLine("Press 3 for EJ's DarkWeb account");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "4")
        {
            Terminal.WriteLine("Virus downloading!");
        }
        else if (input == "5")
        {
            Terminal.WriteLine("Really more virus?");
        }
        else if (input == "6")
        {
            Terminal.WriteLine("Knock Knock!");
        }
        else if (input == "7")
        {
            Terminal.WriteLine("Follow the white rabbit!");
        }
        else if (input == "8")
        {
            Terminal.WriteLine("The Matrix has you");
        }
        else if (input == "9")
        {
            Terminal.WriteLine("OMG what the actual! Just choose 1,2 or 3");
        }
        else if (input == "whos there?")
        {
            Terminal.WriteLine("Go fuck yourself and choose 1,2 or 3");
        }
        else
        {
            Terminal.WriteLine("Choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Password Required, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)

        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Access granted...");
                Terminal.WriteLine(@"
---------------------
| FACEBOOK    Log.in|
|                   |
| Welcome Back:     |
| Stuart.           |
|                   |
---------------------
 Access granted...                                   ");
                break;
            case 2:
                Terminal.WriteLine("Access granted...");
                Terminal.WriteLine(@"
 | \ ||(___  )  Access granted...
// / \|_)o (  ) Slurp!
\\ ///|)\_(    )
 ||   |\ )(    )
 ||   ) \/(____)_     ___
 ||   |\___/     `---' `.`.
 ||   | :   _       .'   ))
 ||   | `..' `~~~-.'   .'__ _
 \\  /           '.______  ( (
                                    ");
                break;
            case 3:
                Terminal.WriteLine("Access granted...");
                Terminal.WriteLine(@"
░░░░▄▀░░░░░░░░▐░▄▄▀░░░░
░░▄▀░░░▐░░░░░█▄▀░▐░░░░░
░░█░░░▐░░░░░░░░▄░█░░░░░
░░░█▄░░▀▄░░░░▄▀▐░█░░░░░
░░░█▐▀▀▀░▀▀▀▀░░▐░█░░░░░
░░▐█▐▄░░▀░░░░░░▐░█▄▄░░░
░░░▀▀▄░░░░░░░░▄▐▄▄▄▀░░░
                                    ");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}


