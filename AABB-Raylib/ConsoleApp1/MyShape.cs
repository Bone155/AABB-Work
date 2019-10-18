using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace ConsoleApp1
{
    class MyShape
    {
        public Vector2 position = new Vector2();
        public List<Vector2> MyPoints = new List<Vector2>();

        public AABB ab = new AABB();

        public void Draw()
        {
            Vector2 Last = new Vector2(); 
            for(int idx = 0; idx < MyPoints.Count; idx++)
            {
                if(idx>0)
                    DrawLineEx(position+Last, position+MyPoints[idx], 2, Color.BLACK);

                Last = MyPoints[idx];
            }

            ab.Fit(MyPoints);
            DrawLine((int)ab.min2.x + (int)position.x, (int)ab.min2.y + (int)position.y, (int)ab.max2.x + (int)position.x, (int)ab.min2.y + (int)position.y, Color.GREEN);
            DrawLine((int)ab.max2.x + (int)position.x, (int)ab.min2.y + (int)position.y, (int)ab.max2.x + (int)position.x, (int)ab.max2.y + (int)position.y, Color.GREEN);
            DrawLine((int)ab.max2.x + (int)position.x, (int)ab.max2.y + (int)position.y, (int)ab.min2.x + (int)position.x, (int)ab.max2.y + (int)position.y, Color.GREEN);
            DrawLine((int)ab.min2.x + (int)position.x, (int)ab.max2.y + (int)position.y, (int)ab.min2.x + (int)position.x, (int)ab.min2.y + (int)position.y, Color.GREEN);
        }

        public void Collide(AABB other)
        {
            if (ab.Overlaps(other))
            {
                DrawLine((int)ab.min2.x + (int)position.x, (int)ab.min2.y + (int)position.y, (int)ab.max2.x + (int)position.x, (int)ab.min2.y + (int)position.y, Color.RED);
                DrawLine((int)ab.max2.x + (int)position.x, (int)ab.min2.y + (int)position.y, (int)ab.max2.x + (int)position.x, (int)ab.max2.y + (int)position.y, Color.RED);
                DrawLine((int)ab.max2.x + (int)position.x, (int)ab.max2.y + (int)position.y, (int)ab.min2.x + (int)position.x, (int)ab.max2.y + (int)position.y, Color.RED);
                DrawLine((int)ab.min2.x + (int)position.x, (int)ab.max2.y + (int)position.y, (int)ab.min2.x + (int)position.x, (int)ab.min2.y + (int)position.y, Color.RED);
            }
        }

        public void Collide(MyShape other)
        {
            if (ab.Overlaps(other.position))
            {
                DrawLine((int)ab.min2.x + (int)position.x, (int)ab.min2.y + (int)position.y, (int)ab.max2.x + (int)position.x, (int)ab.min2.y + (int)position.y, Color.RED);
                DrawLine((int)ab.max2.x + (int)position.x, (int)ab.min2.y + (int)position.y, (int)ab.max2.x + (int)position.x, (int)ab.max2.y + (int)position.y, Color.RED);
                DrawLine((int)ab.max2.x + (int)position.x, (int)ab.max2.y + (int)position.y, (int)ab.min2.x + (int)position.x, (int)ab.max2.y + (int)position.y, Color.RED);
                DrawLine((int)ab.min2.x + (int)position.x, (int)ab.max2.y + (int)position.y, (int)ab.min2.x + (int)position.x, (int)ab.min2.y + (int)position.y, Color.RED);
            }
        }
    }
}
