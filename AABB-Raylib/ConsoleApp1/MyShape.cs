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
            //          top left            bottom right
            DrawLineEx(ab.min2 + position, ab.max2 + position, 3, Color.GREEN);
            DrawLineEx(ab.min2 + position, ab.max2 + position, 3, Color.GREEN);
            //DrawLineEx(ab.min2 - position, ab.max2 - position, 3, Color.GREEN);
            //DrawLineEx(ab.min2 - position, ab.max2 + position, 3, Color.GREEN);
        }

        public void collide(AABB other)
        {
            if (ab.Overlaps(other))
            {
                Console.WriteLine("Hit");
            }
        }
    }
}
