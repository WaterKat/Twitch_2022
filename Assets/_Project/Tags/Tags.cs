using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaterKatLLC.TagSystem
{
    public class Tags : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private bool edible = false;

        //Getter
        public bool isEdible { get => edible; }
    }
}