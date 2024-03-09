using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int loop = 0;
    public static ResourceManager instance;
    public Dictionary<Resources, long> resourceDict = new Dictionary<Resources, long>();
    
    public long wood;
    public long stone;
    public long iron;
    public long carbonFiber;
    public long graphene;
    public long voidthium;

    [Header("Temp")]
    public ResourceConverter tree;
    public ResourceConverter startingConverter;
    public ResourceConverter endingConverter;
    public AudioClip treeFall;
    private bool isLooped = false;

    public enum Resources
    {
        Wood,
        Stone,
        Iron,
        CarbonFiber, 
        Graphene,
        Voidthium
    }
        
    private void Awake()
    {
        instance = this;
        resourceDict.Add(Resources.Wood, wood);
        resourceDict.Add(Resources.Stone, stone);
        resourceDict.Add(Resources.Iron, iron);
        resourceDict.Add(Resources.CarbonFiber, carbonFiber);
        resourceDict.Add(Resources.Graphene, graphene);
        resourceDict.Add(Resources.Voidthium, voidthium);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        wood = resourceDict[Resources.Wood];
        stone = resourceDict[Resources.Stone];
        iron = resourceDict[Resources.Iron];
        carbonFiber = resourceDict[Resources.CarbonFiber];
        graphene = resourceDict[Resources.Graphene];
        voidthium = resourceDict[Resources.Voidthium];

        if (endingConverter.unlocked && !isLooped) SwitchLoop();
    }

    void SwitchLoop()
    {
        //TODO: startingConverter.free = false;
        
        //temp
        startingConverter.free = true;
        tree.gameObject.SetActive(false);
        AudioManager.instance.PlaySound(treeFall);
        isLooped = true;
        //temp

        resourceDict[endingConverter.resourceProduce] = 0;
        
        loop++;
        //TODO: endingConverter = next endingConverter
    }
}
