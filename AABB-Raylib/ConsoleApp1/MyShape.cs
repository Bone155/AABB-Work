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

        public AABB2 boundingBox = new AABB2();

        public Sphere2D sphere;

        public void Draw()
        {
            Vector2 Last = new Vector2(); 
            for(int idx = 0; idx < MyPoints.Count; idx++)
            {
                if(idx > 0)
                    DrawLineEx(position+Last, position+MyPoints[idx], 2, Color.BLACK);

                Last = MyPoints[idx];
            }
            
            boundingBox.Center();
            boundingBox.Extents();
            boundingBox.Corners();
            boundingBox.Fit(MyPoints);
            boundingBox.max += position;
            boundingBox.min += position;
            //Drawing collision box
            DrawLine((int)boundingBox.min.x, (int)boundingBox.min.y, (int)boundingBox.max.x, (int)boundingBox.min.y, Color.GREEN);
            DrawLine((int)boundingBox.max.x, (int)boundingBox.min.y, (int)boundingBox.max.x, (int)boundingBox.max.y, Color.GREEN);
            DrawLine((int)boundingBox.max.x, (int)boundingBox.max.y, (int)boundingBox.min.x, (int)boundingBox.max.y, Color.GREEN);
            DrawLine((int)boundingBox.min.x, (int)boundingBox.max.y, (int)boundingBox.min.x, (int)boundingBox.min.y, Color.GREEN);
        }

        public void Circle(float r)
        {
            sphere = new Sphere2D(position, r);

            DrawCircleLines((int)sphere.center.x, (int)sphere.center.y, sphere.radius, Color.BLACK);

            // Collision circle
            DrawCircleLines((int)sphere.center.x, (int)sphere.center.y, sphere.radius, Color.GREEN);
        }

        public void boxVSbox(AABB2 other)
        {
            if (boundingBox.Overlaps(other))
            {
                DrawLine((int)boundingBox.min.x, (int)boundingBox.min.y, (int)boundingBox.max.x, (int)boundingBox.min.y, Color.RED);
                DrawLine((int)boundingBox.max.x, (int)boundingBox.min.y, (int)boundingBox.max.x, (int)boundingBox.max.y, Color.RED);
                DrawLine((int)boundingBox.max.x, (int)boundingBox.max.y, (int)boundingBox.min.x, (int)boundingBox.max.y, Color.RED);
                DrawLine((int)boundingBox.min.x, (int)boundingBox.max.y, (int)boundingBox.min.x, (int)boundingBox.min.y, Color.RED);
            }
        }

        public void circleVSbox(AABB2 other)
        {
            if (sphere.Overlaps(other))
            {
                DrawCircleLines((int)sphere.center.x, (int)sphere.center.y, sphere.radius, Color.RED);
            }
        }

        public void circleVScircle(Sphere2D other)
        {
            if (sphere.Overlaps(other))
            {
                DrawCircleLines((int)sphere.center.x, (int)sphere.center.y, sphere.radius, Color.RED);
            }
        }

    }
}
