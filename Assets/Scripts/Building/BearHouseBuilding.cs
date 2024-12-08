using UnityEngine;
using UnityEngine.Serialization;

public class BearHouseBuilding : Building
{
    [FormerlySerializedAs("SpawnPoint")] public Transform[] SpawnPoints;
    public BearAgent _agent;

    public override void Build()
    {
        foreach (var point in SpawnPoints)
        {
            var bear = GameObject.Instantiate(_agent, point.position, Quaternion.identity);
            //bear.GoToFlag();
        }
    }
}