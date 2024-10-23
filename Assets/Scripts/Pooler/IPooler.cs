using System.Collections.Generic;
using UnityEngine;
namespace Packs.PoolerPack
{
    public interface IPooler
    {
        T GetObj<T>(T template) where T : IObjPooler;
        T GetObj<T>(T template, Transform parent) where T : IObjPooler;
        void InActiveAll();
        Pooler.PoolerStore GetPooler<T>(T template) where T : IObjPooler;
        List<Pooler.PoolerStore> GetListPoolerStore();
    }
}