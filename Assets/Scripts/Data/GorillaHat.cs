using System;
using GorillaCosmetics.Data.Descriptors;
using UnityEngine;

namespace GorillaCosmetics.Data
{
    public class GorillaMaterial
    {
        public string FileName { get; }

        public AssetBundle AssetBundle { get; }

        public GorillaMaterialDescriptor Descriptor { get; }

        public GorillaMaterial(string path)
        {
            bool flag = path != "Default";
            if (flag)
            {
                try
                {
                    this.FileName = path;
                    this.AssetBundle = AssetBundle.LoadFromFile(path);
                    GameObject gameObject = this.AssetBundle.LoadAsset<GameObject>("_Material");
                    this.Material = gameObject.GetComponent<Renderer>().material;
                    this.Descriptor = gameObject.GetComponent<GorillaMaterialDescriptor>();
                }
                catch (Exception message)
                {
                    Debug.Log(message);
                }
            }
        }

        public Material Material;
    }
}