using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GlobalInstaller : IInstaller
{
    // Сюда мы перетащим наш ScriptableObject из инспектора
    private readonly GameSettings _gameSettings;

    public GlobalInstaller(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
    }

    public void Install(IContainerBuilder builder)
    {
        // Регистрируем GameSettings как экземпляр.
        // Теперь любой класс в любом контейнере (глобальном или на сцене)
        // сможет запросить GameSettings.
        builder.RegisterInstance(_gameSettings);
    }
}