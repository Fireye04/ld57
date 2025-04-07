using Godot;
using System;
using System.Diagnostics;

public partial class MainMenuControl : Control
{
    /*********************************************************************************************/
    /** Engine Events */

    public override void _Ready()
    {
        base._Ready();

        InitMenu();
    }

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

    protected virtual void InitMenu()
    {
        mainMenu.Visible = true;
        settingsMenu.Visible = false;
        creditsMenu.Visible = false;
    }

    public virtual void StartGame()
    {
        GetTree().ChangeSceneToFile(gameNodePath);
    }

    public virtual void ToggleSettings()
    {
        settingsMenu.Visible = !settingsMenu.Visible;
        mainMenu.Visible = !settingsMenu.Visible;
    }

    public virtual void ToggleCredits()
    {
        creditsMenu.Visible = !creditsMenu.Visible;
        mainMenu.Visible = !creditsMenu.Visible;
    }

    public virtual void Exit()
    {
        GetTree().Quit();
    }
}
