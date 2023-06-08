using System.Collections.Generic;
using Exiled.API.Features;
using MapEditorReborn.API.Features;
using MapEditorReborn.API.Features.Objects;
using MEC;
using Mirror;
using UnityEngine;

public class BoobsComponent : MonoBehaviour
{
    public SchematicObject self;
    public SchematicObject external;

    public CoroutineHandle selfhandle;
    public CoroutineHandle externalhandle;

    public void SpawnBoobs()
    {
        var player = Player.Get(gameObject);
        self = ObjectSpawner.SpawnSchematic("boobs", Vector3.one);
        external  = ObjectSpawner.SpawnSchematic("boobs", Vector3.one);
        self.Scale = Vector3.one * SexUpdate.Instance.Config.SelfSize;
        external.Scale = Vector3.one * SexUpdate.Instance.Config.ExternalSize;

        foreach (var ply in Player.List)
        {
            if(player == ply)
                continue;
            foreach (var o in self.AttachedBlocks)
            {
                if (o.gameObject.TryGetComponent<NetworkIdentity>(out var net))
                    DespawnForOnePlayer(net, ply);
            }

        }

        foreach (var o in external.AttachedBlocks)
        {
            if (o.gameObject.TryGetComponent<NetworkIdentity>(out var net))
                DespawnForOnePlayer(net,player);
        }
            
        selfhandle = Timing.RunCoroutine(FollowPlayer(player, self.gameObject).CancelWith(self.gameObject));
        externalhandle = Timing.RunCoroutine(FollowPlayerExternal(player, external.gameObject).CancelWith(external.gameObject));




    }

    public void RemoveBoobs()
    {
        if(externalhandle != null)
            Timing.KillCoroutines(externalhandle);
        if(selfhandle != null)
            Timing.KillCoroutines(selfhandle);
        if(self != null)
            self.Destroy();
        if(external != null)
            external.Destroy();
        DestroyImmediate(this);



    }
    public void DespawnForOnePlayer(NetworkIdentity identity, Player player)
    {
        var msg = new ObjectDestroyMessage { netId = identity.netId };
        player.Connection.Send(msg);
    }


    public IEnumerator<float> FollowPlayer(Player player, GameObject boobs)
    {
        for (;;)
        {
            boobs.transform.position = player.Transform.position + boobs.transform.TransformDirection(SexUpdate.Instance.Config.OffSet);
            boobs.transform.rotation = player.Transform.rotation;
            yield return Timing.WaitForSeconds(0.1f);
        }
    }
    public IEnumerator<float> FollowPlayerExternal(Player player, GameObject boobs)
    {
        for (;;)
        {
            boobs.transform.position = player.Transform.position + boobs.transform.TransformDirection(SexUpdate.Instance.Config.ExternalOffSet);
            boobs.transform.rotation = player.Transform.rotation;
            yield return Timing.WaitForSeconds(0.1f);
        }
    }

}