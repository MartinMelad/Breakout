using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private GameObject paddlePrefab;

    [SerializeField] private GameObject standardBlockPrefab;

    [SerializeField] private GameObject bonusBlockPrefab;

    [SerializeField] private GameObject effectBlockPrefab;

    private float screenWidth;
    private float screenHight;

    private float blockWidth;
    private float blockHight;

    

   
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject timpBlock;
        Instantiate(paddlePrefab);
        timpBlock = Instantiate(standardBlockPrefab);
        blockWidth = timpBlock.gameObject.GetComponent<BoxCollider2D>().size.x * timpBlock.transform.localScale.x;
        blockHight = timpBlock.gameObject.GetComponent<BoxCollider2D>().size.y * timpBlock.transform.localScale.y;
        Destroy(timpBlock);
        screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        int blockPerRow = (int) (screenWidth / blockWidth); 
        Vector3 blockPosition = new Vector3(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop, 0);
        blockPosition.y -= blockHight + (blockHight / 2);
        for (int row = 0; row < 3; row++)
        {
            blockPosition.x += blockWidth / 2;
            for (int column = 0; column < blockPerRow; column++)
            {   
                if (column != 0 && column != blockPerRow-1)
                    PlaceBlock(blockPosition);
                blockPosition.x += blockWidth;
            }
            blockPosition.y -= blockHight;
            blockPosition.x = ScreenUtils.ScreenLeft;
        }
       
    }
    
    
    void PlaceBlock(Vector2 position)
    {
        float randomBlockType = Random.value;
        if (randomBlockType < ConfigurationUtils.StandardBlockProbability)
        {
            Instantiate(standardBlockPrefab, position, Quaternion.identity);
        }
        else if (randomBlockType <
                 (ConfigurationUtils.StandardBlockProbability + ConfigurationUtils.BonusBlockProbability))
        {
            Instantiate(bonusBlockPrefab, position, Quaternion.identity);
        }
        else if (randomBlockType <
                 (ConfigurationUtils.StandardBlockProbability + ConfigurationUtils.BonusBlockProbability + ConfigurationUtils.FreezerBlockProbability + ConfigurationUtils.SpeedupBlockProbability) )
        {
            // effect block selected
            GameObject effectBlock = Instantiate(effectBlockPrefab, position, Quaternion.identity);
            EffectBlock effectBlockScript = effectBlock.GetComponent<EffectBlock>();

            // set effect
            float freezerThreshold = ConfigurationUtils.StandardBlockProbability +
                                     ConfigurationUtils.BonusBlockProbability +
                                     ConfigurationUtils.FreezerBlockProbability;
            if (randomBlockType < freezerThreshold)
            {
                effectBlockScript.Effect = EffectName.Freezer;
            }
            else
            {
                effectBlockScript.Effect = EffectName.Speedup;
            }
        }
    }
}
