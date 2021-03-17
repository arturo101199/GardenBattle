using UnityEngine;

public static class AnimatorUtilities
{
    public static float GetClipLength(Animator anim, string clipName)
    {
        AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in animationClips)
        {
            if (clip.name == clipName)
                return clip.length;
        }
        return 0f;
    }
}