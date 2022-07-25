using System.IO;
using Unity.Entities;

namespace Unity.Scenes.Editor
{
    [UpdateInGroup(typeof(GameObjectConversionGroup))]
    internal class SubSceneConversionSystem : GameObjectConversionSystem
    {
        protected override void OnUpdate()
        {
            Entities.ForEach((SubScene subscene) =>
            {
                var entity = GetPrimaryEntity(subscene);
                DstEntityManager.AddComponentData(entity, new Unity.Entities.SceneReference() {SceneGUID = subscene.SceneGUID});

                if (subscene.AutoLoadScene)
                {
                    DstEntityManager.AddComponentData(entity,
                        new RequestSceneLoaded());
                }
            });
        }
    }
}
