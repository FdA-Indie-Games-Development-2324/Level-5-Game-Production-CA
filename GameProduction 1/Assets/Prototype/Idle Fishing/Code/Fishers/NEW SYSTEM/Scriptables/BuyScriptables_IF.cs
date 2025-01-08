using UnityEngine;

[CreateAssetMenu (menuName = "IF_ShopItems/Items")]
public class BuyScriptables_IF : ScriptableObject
{
    public StoreItem[] storeItem;
}

[System.Serializable]
public class StoreItem
{
    public int StoreIndex;
    // For piers = pier
    // For fishers = fisher
    // Case sensitive
    [Tooltip("What is the prefab? pier or fisher? (CASE SENSITIVE)")]
    public string itemType;
    public GameObject GOPrefab;

    public int ItemCost;
}