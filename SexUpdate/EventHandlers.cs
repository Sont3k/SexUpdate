
using Exiled.API.Features;

public class EventHandlers
{
    public void OnRelaod()
    {
        foreach (var player in Player.List)
        {
            if (player.GameObject.TryGetComponent<BoobsComponent>(out BoobsComponent component))
            {
             
                component.RemoveBoobs();
                player.GameObject.AddComponent<BoobsComponent>();
            }
            
        }
    }
}