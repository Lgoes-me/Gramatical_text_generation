using System;
using Debug;
using Domain.Actors;
using Domain.Stories;

namespace Domain.Resolvers
{
    public static class Extensions
    {
        public static Actor ToActor(this StatActor statActor)
        {
            return statActor switch
            {
                StatActor.World => GameplayScene.Instance.World,
                StatActor.Player => GameplayScene.Instance.World.Player,
                StatActor.Chapter => GameplayScene.Instance.Chapter,
                
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}