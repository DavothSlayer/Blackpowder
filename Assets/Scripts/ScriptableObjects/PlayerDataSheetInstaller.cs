using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "PlayerDataSheetInstaller", menuName = "Installers/Player Data Sheet Installer")]
public class PlayerDataSheetInstaller : ScriptableObjectInstaller<PlayerDataSheetInstaller>
{
    [SerializeField] private PlayerDataSheet _playerDataSheet;

    public override void InstallBindings()
    {
        Container.Bind<PlayerDataSheet>().FromInstance(_playerDataSheet).AsSingle();
    }
}