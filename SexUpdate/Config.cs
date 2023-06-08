using Exiled.API.Interfaces;
using UnityEngine;

public class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; } = false;

    public Vector3 OffSet { get; set; } = new Vector3(0, 0, 0);
    public Vector3 ExternalOffSet { get; set; } = new Vector3(0, 0, 0);

    public float ExternalSize { get; set; } = 1;
    public float SelfSize { get; set; } = 1;

}