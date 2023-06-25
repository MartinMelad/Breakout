using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private GameObject paddlePrefab;

    [SerializeField] private GameObject standardBlockPrefab;

    private float screenWidth;
    private float screenHight;

    private float blockWidth;
    private float blockHight;

    private int score = 0;

    public int scoreNum
    {
        get { return score; }
    }
    
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
        for (int row = 0; row < 7; row++)
        {
            blockPosition.x += blockWidth / 2;
            for (int column = 0; column < blockPerRow; column++)
            {
                if (column % 2 == 0)
                    Instantiate(standardBlockPrefab, blockPosition, quaternion.identity);
                blockPosition.x += blockWidth;
            }
            blockPosition.y -= blockHight;
            blockPosition.x = ScreenUtils.ScreenLeft;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score++;
    }
}
