using UnityEngine;
using UnityEngine.UI;

namespace ForFun.Playground.SimpleTcpClient.Misc
{
    public abstract class ButtonActionBase : MonoBehaviour
    {
        void OnEnable() { GetComponent<Button>().onClick.AddListener(Action); }

        void OnDisable() { GetComponent<Button>().onClick.RemoveListener(Action); }

        protected abstract void Action();
    }
}