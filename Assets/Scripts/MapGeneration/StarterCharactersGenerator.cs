﻿using UnityEngine;
using UnityEngine.AI;

public class StarterCharactersGenerator
{
    int nCharacters = 0;
    GameObject character = null;
    Vector3 baseLocation = Vector3.zero;

    public void GenerateCharacters(int nCharacters, GameObject character, Vector3 baseLocation)
    {
        this.nCharacters = nCharacters;
        this.character = character;
        this.baseLocation = baseLocation;

        float angleOffset = 0f;
        int loops = 0;
        while (this.nCharacters > 0 && loops < 15) 
        {
            this.nCharacters = createCharacters(8, 2f, angleOffset);
            angleOffset += 15f;
            loops += 1;
        }
    }

    int createCharacters(int charactersPerCircle, float radius, float angleOffset)
    {
        int charactersNotPlaced = 0;
        while (nCharacters > 0)
        {
            if (nCharacters < charactersPerCircle)
            {
                charactersPerCircle = nCharacters;
            }
            nCharacters -= charactersPerCircle;
            Vector3[] positions = GeometryUtilities.DivideCircleEquallyXZ(baseLocation, radius, charactersPerCircle, angleOffset);
            for (int i = 0; i < charactersPerCircle; i++)
            {
                if (!spawnCharacter(character, positions[i], baseLocation)) charactersNotPlaced += 1;
            }
            charactersPerCircle = (int)(charactersPerCircle * 1.25f);
            radius += 1.4f;
            angleOffset += 15f;
        }
        return charactersNotPlaced;
    }

    bool spawnCharacter(GameObject character, Vector3 position, Vector3 baseLocation)
    {
        NavMeshHit hit;
        if(NavMesh.SamplePosition(position, out hit, 3f, NavMesh.AllAreas))
        {
            Quaternion lookAt = Quaternion.LookRotation(hit.position - baseLocation);
            Object.Instantiate(character, hit.position, lookAt).SetActive(true);
            return true;
        }
        else
        {
            return false;
        }
    }
}