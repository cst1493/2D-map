using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadHexGrid : MonoBehaviour
{
    // 4D array.  1st index holds the x cord, 2nd index holds the y cord, & an int for the energy cost to enter decided by the sprite existing at that cord.
    //short[,,] hexGrid = new short[45, 25, 1];  //covers 1 whole camera at the time of making this.
    //45 wide, 25 high.  Each set of indexes holds x & y pixel locations.

    public float innitXPosition, innitYPosition, distance;
    public int xGrids, yGrids;
    public GameObject hexSprite;

    void Start()
    {
        Vector3 newPos = new Vector3(innitXPosition, innitYPosition, 0);
        SingleHex[,] grid = new SingleHex[xGrids, yGrids];

        for (int yIndex = 0; yIndex < yGrids; yIndex++)
        {
            //Debug.Log("y: "+yIndex);
            for (int xIndex = 0; xIndex < xGrids; xIndex++)
            {
                Instantiate(hexSprite, this.transform.position + newPos, this.transform.rotation); //debugging hexes

                grid[xIndex, yIndex] = new SingleHex(newPos.x, newPos.y); //set coords for map points.

                /*Debug.Log("\n[[x1 -->" + (this.transform.position.x + newPos.x) + "]]\t[[y1 -->" + (this.transform.position.y + newPos.y) + "]] should equal: " + 
                    "\n[[x2 -->" + grid[xIndex,yIndex].GetXCoord() + "]]\t[[y2 -->" + grid[xIndex, yIndex].GetYCoord() + "]]"); //Shows hexes have the same positions as the grid array.*/
                newPos.x += distance;
            }
            //move down and align new line
            newPos.y -= distance;
            if (yIndex % 2 == 0) {
                newPos.x = innitXPosition + (distance/2);
            } 
            else { newPos.x = innitXPosition; }
        }

    }

    //void Update(){}
}

public class SingleHex //index is kept in the array and shouldn't be needed here.
{
    public SingleHex(float xCoord, float yCoord) { this.xCoord = xCoord; this.yCoord = yCoord; }
    public float xCoord = 0, yCoord = 0;
    public int moveCost = 1; //default movement speed-multiplier/energy-cost of moving into this hex.
    public void SetMoveCost(int cost) {
        this.moveCost = cost;
    }
    public float GetXCoord() {
        return this.xCoord;
    }
    public float GetYCoord() {
        return this.yCoord; ;
    }
    public float GetMoveCost() {
        return this.moveCost;
    }

    /*public void SetHex(float x, float y) //set in constructor...
    {
        this.xCoord = x;
        this.yCoord = y;
    }
    public void SetY(float y)//temp???
    {
        this.yCoord = y;
    }
    public void SetX(float x)
    {
        this.xCoord = x;
    }*/
}


/* flat tops & bottoms
 * https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSgynvRaf1JnS6H2bTAxeY6_bUXtRX1XzDltJ2GY9IAyHYiUfgD&usqp=CAU
 * https://orodaelturrim.readthedocs.io/en/latest/_images/position_offset.jpg
 * https://i.stack.imgur.com/nZC1s.png
 *
 * if the flat part of the hex is on the top & bottom instead of the points:
 * Any hex has access to 2 smaller, 2 of the same, & 2 larger 'x' indexes.
 * Difficult to travel on a straight sideways line.
 * 
 * 
 * flat left & right (best option for movement???)
 * Any hex has access to 2 smaller, 2 of the same, & 2 larger 'y' indexes.
 * https://lh3.googleusercontent.com/proxy/2CwQZMktEqVxAINlos1a5zOio4y_WlHPdX0BM_97NsSZ4iD30nwDmVmg1yvRvcuDLuSq2RvA3BaZ_UneZr6TQlFg_A45Iq4JHBjYwwi0pR9jNmA_vvBs0bTLqg
 * https://uploads.gamedev.net/monthly_04_2011/ccs-8549-0-59579000-1303301587_thumb.gif
 * 
 */
