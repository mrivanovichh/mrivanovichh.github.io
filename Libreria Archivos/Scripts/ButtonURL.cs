
using JetBrains.Annotations;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
namespace UdonSharp.Video
{
    [DefaultExecutionOrder(10)]
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    [AddComponentMenu("Udon Sharp/Video/UI/Video Control Handler")]

    public class ButtonURL : UdonSharpBehaviour
    {
        public VRCUrl url;
        [PublicAPI, NotNull]
        public USharpVideoPlayer targetVideoPlayer;

        public void Click()
        {
            targetVideoPlayer.PlayVideo(url);
        }
    }
}