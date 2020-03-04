using ForFun.Playground.SimpleTcpClient.Managers;
using ForFun.Playground.SimpleTcpClient.UI;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LaunchPanel launcherPanel = default;
        [SerializeField] private NetworkClient networkClient = default;
        [SerializeField] private NetworkMonitor networkMonitor = default;
        [SerializeField] private MetaTranslator metaTranslator = default;
        [SerializeField] private ActionHub actionHub = default;
        [SerializeField] private InputController inputController = default;
        [SerializeField] private SceneUpdater sceneUpdater = default;

        void Start()
        {
            Instantiate(launcherPanel).gameObject.name = launcherPanel.name;
            Instantiate(networkClient).gameObject.name = networkClient.name;
            Instantiate(networkMonitor).gameObject.name = networkMonitor.name;
            Instantiate(metaTranslator).gameObject.name = metaTranslator.name;
            Instantiate(actionHub).gameObject.name = actionHub.name;
            Instantiate(inputController).gameObject.name = inputController.name;
            Instantiate(sceneUpdater).gameObject.name = sceneUpdater.name;
        }
    }
}