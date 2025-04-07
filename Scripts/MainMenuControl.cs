using Godot;
using System;
using System.Diagnostics;

public partial class MainMenuControl : Control
{
    /*********************************************************************************************/
    /** GD Signals */

    private void OnPlayButtonPressed()
    {
        StartGame();
    }

    private void OnSettingsButtonPressed()
    {
        ToggleSettings();
    }

    private void OnCreditsButtonPressed()
    {
        ToggleCredits();
    }

    private void OnExitButtonPressed()
    {
        Exit();
    }

    /*********************************************************************************************/
    /** Menu */

    [Export]
    string gameNodePath;

    [Export]
    Container mainMenu;

    [Export]
    Container settingsMenu;

    [Export]
    Container creditsMenu;


    public virtual void StartGame()
    {
        Debug.WriteLine("start game");
        GetTree().ChangeSceneToFile(gameNodePath);
    }

    public virtual void ToggleSettings()
    {
        Debug.WriteLine("settings");

        settingsMenu.Visible = !settingsMenu.Visible;
        mainMenu.Visible = !settingsMenu.Visible;
    }

    public virtual void ToggleCredits()
    {
        Debug.WriteLine("credits");

        creditsMenu.Visible = !creditsMenu.Visible;
        mainMenu.Visible = !creditsMenu.Visible;
    }

    public virtual void Exit()
    {
        Debug.WriteLine("exit");
        GetTree().Quit();
    }
}
