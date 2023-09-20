using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharp.Video
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    [AddComponentMenu("Udon Sharp/Video/Utilities/Renderer GI Update")]
    public class RendererGIUpdate2 : UdonSharpBehaviour
    {
        Renderer targetRenderer;
        int contador = 0;
        public int SlowRefreshByFPS = 180;
        void Start()
        {
            targetRenderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            if (contador == SlowRefreshByFPS)
            {
                RendererExtensions.UpdateGIMaterials(targetRenderer);
                contador = 0;
            }
            else
            {
                contador++;
            }
        }
    }
}