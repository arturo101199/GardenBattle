using UnityEngine;
using UnityEngine.AI;

public class StarterCharactersGenerator
{
    public void GenerateCharacters(int nCharacters, GameObject character, Vector3 baseLocation)
    {
        Debug.Log(nCharacters);
        Vector3[] positions = GeometryUtilities.DivideCircleEquallyXZ(baseLocation, 1f, nCharacters);
        for (int i = 0; i < nCharacters; i++)
        {
            createCharacter(character, positions[i], baseLocation);
        }
    }

    void createCharacter(GameObject character, Vector3 position, Vector3 baseLocation)
    {
        NavMeshHit hit;
        if(NavMesh.SamplePosition(position, out hit, 3f, NavMesh.AllAreas))
        {
            Quaternion lookAt = Quaternion.LookRotation(hit.position - baseLocation);
            Object.Instantiate(character, hit.position, lookAt).SetActive(true);
        }
    }
}