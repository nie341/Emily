using System.Collections;
using System.Collections.Generic;
using ClientConfig;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions;

public class CreatePlayerSystem : ReactiveSystem<GameEntity>
{
    private GameContext _gameContext;

    public CreatePlayerSystem(Contexts contexts)
        : base(contexts.game)
    {
        _gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ResourceInitialize.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var e = entities.SingleEntity();
        Assert.IsNotNull(e);

        CreatePlayer(Consts.ID_HERO_ARCHER, 23.5f, 31.5f, CharacterDirection.Right);

        CreateMonster(Consts.ID_HERO_PANDA, 17.5f, 33.7f, CharacterDirection.Right);
        CreateMonster(Consts.ID_HERO_PANDA, 16.5f, 22.5f, CharacterDirection.Left);
        CreateMonster(Consts.ID_HERO_PHOENIX, 27.5f, 29.5f, CharacterDirection.Left);
    }

    private void CreatePlayer(string id, float x, float y, CharacterDirection direction)
    {
        var characterItem = ConfigManager.Instance.GetItem<CharacterItem>(Consts.ASSET_NAME_CHARACTER, id);
        string path = Utils.GetBundlePathForLoadFromFile(characterItem.path);

        ResourceManager.Instance.GetAssetBundleAsset(path, id, this)
            .Then(result =>
            {
                var e = _gameContext.CreateEntity();
                e.AddResourceAssetBundle(path, this);

                e.AddTag(Consts.TAG_PLAYER);
                e.isControllable = true;
                e.AddIdentifier(id);
                e.AddPosition(new Vector2(x, y));

                string assetName = id;
                e.AddView(null, assetName, true);

                e.AddState(CharacterState.Idle);
                e.AddDirection(direction);

                var asset = result as GameObject;
                Assert.IsNotNull(asset);

                var collectionData = asset.GetComponent<tk2dSpriteCollectionData>();
                Assert.IsNotNull(collectionData);
                e.AddViewAsset(collectionData, null);       // only set collection data, no sprite name
            })
            .Catch(ex => { Debug.LogException(ex); });
    }

    private void CreateMonster(string id, float x, float y, CharacterDirection direction)
    {
        var characterItem = ConfigManager.Instance.GetItem<CharacterItem>(Consts.ASSET_NAME_CHARACTER, id);
        string path = Utils.GetBundlePathForLoadFromFile(characterItem.path);

        ResourceManager.Instance.GetAssetBundleAsset(path, id, this)
            .Then(result =>
            {
                var e = _gameContext.CreateEntity();
                e.AddResourceAssetBundle(path, this);

                e.AddIdentifier(id);
                e.AddPosition(new Vector2(x, y));

                string assetName = id;
                e.AddView(null, assetName, true);

                e.AddState(CharacterState.Idle);
                e.AddDirection(direction);

                var asset = result as GameObject;
                Assert.IsNotNull(asset);

                var collectionData = asset.GetComponent<tk2dSpriteCollectionData>();
                Assert.IsNotNull(collectionData);
                e.AddViewAsset(collectionData, null);       // only set collection data, no sprite name
            })
            .Catch(ex => { Debug.LogException(ex); });
    }
}
