using Godot;
using System;
using System.Diagnostics;

public partial class VolumeSlider : HSlider
{
    [Export]
    protected string audioBusName = "Master";

    public virtual void _Ready()
    {
        base._Ready();

        Value = 1.0f;
    }

    public virtual void OnValueChanged(float newValue)
    {
        int busIndex = AudioServer.GetBusIndex(audioBusName);
        AudioServer.SetBusVolumeLinear(busIndex, newValue);

        Debug.WriteLine("new audio!");
    }

}
