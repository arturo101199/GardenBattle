using UnityEngine;

public static class LayerMaskUtilities
{
    public static LayerMask GetCharactersLayerExceptMyLayer(int myLayer)
    {
        LayerMask layer = 0;
        for (int i = 15; i < 32; i++)
        {
            if (i != myLayer)
            {
                layer = layer | (1 << i);
            }
        }
        return layer;
    }

    public static bool MaskContainsLayer(LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
