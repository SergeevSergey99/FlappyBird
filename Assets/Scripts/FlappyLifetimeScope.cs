using System;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class FlappyLifetimeScope : LifetimeScope
{
    [SerializeField] GameSettings gameSettings;
    [SerializeField] SkinSettings skinSettings;

    protected override void Configure(IContainerBuilder builder)
    {
        // Зарегистрировать ScriptableObject-ы как singleton-инстансы
        builder.RegisterInstance(gameSettings);
        builder.RegisterInstance(skinSettings);

        // GameManager и другие сервисы
        builder.Register<GameManager>(Lifetime.Scoped);
        builder.Register<PipeFactory>(resolver => 
            new(resolver, gameSettings.PipePrefab),Lifetime.Scoped);
        builder.Register<PipePool>(Lifetime.Scoped);
        

        // Внедрять BirdController из сцены
        builder.RegisterComponentInHierarchy<BirdController>();
        builder.RegisterComponentInHierarchy<ScoreView>();
        builder.RegisterComponentInHierarchy<ObstacleSpawner>();
        
        // Внедрять InputController как ITickable
        builder.Register<InputController>(Lifetime.Singleton).AsImplementedInterfaces();
    }
    void Start()
    {
        var gameManager = Container.Resolve<GameManager>();
        gameManager.Restart();
    }
}