using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    static class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;

            rl.InitWindow(screenWidth, screenHeight, "Collisions");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------
            MyShape triangle = new MyShape();
            triangle.MyPoints.Add(new Vector2(10, 10));
            triangle.MyPoints.Add(new Vector2(20, 30));
            triangle.MyPoints.Add(new Vector2(30, 10));
            triangle.MyPoints.Add(new Vector2(10, 10));
            triangle.MyPoints.Add(new Vector2(40, 30));
            triangle.MyPoints.Add(new Vector2(50, 10));
            triangle.position = new Vector2(100, 100);

            MyShape sphere = new MyShape();
            sphere.MyPoints.Add(new Vector2(10, 10));
            sphere.position = new Vector2(100, 320);

            //TODO:Create another object with a different shape
            MyShape freakyLine = new MyShape();
            freakyLine.MyPoints.Add(new Vector2(0, 0));
            freakyLine.MyPoints.Add(new Vector2(10, 40));
            freakyLine.MyPoints.Add(new Vector2(30, 20));
            freakyLine.MyPoints.Add(new Vector2(50, 20));
            freakyLine.MyPoints.Add(new Vector2(30, 30));
            freakyLine.position = new Vector2(300, 100);

            MyShape sphere2 = new MyShape();
            sphere2.MyPoints.Add(new Vector2(10, 10));
            sphere2.position = new Vector2(300, 320);

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);

                triangle.Draw();
                triangle.position.x += .5f;
                for (int i = 0; i < triangle.MyPoints.Count; i++)
                {
                    triangle.MyPoints[i] = new Vector2(triangle.MyPoints[i].y / 5, triangle.MyPoints[i].x / 5);
                }

                sphere.Circle(8);
                sphere.position.x += .5f;

                freakyLine.Draw();
                freakyLine.position.x -= .5f;

                sphere2.Circle(15);
                sphere2.position.x -= .5f;

                //TODO:Move the 2nd object so that it is on a collision course with the triangle
                //TODO:Implement AABB Collision detection so you know when they hit.
                //Recommend adding the AABB Functionality to the myshape class.
                //Add a method to the myshape class that causes the Bounding box to be recalculated and
                //stored in the myshape class (with the corners/vectors relative to itself)

                freakyLine.boxVSbox(triangle.boundingBox);
                triangle.boxVSbox(freakyLine.boundingBox);
 

                //Spheres
                //sphere.circleVSbox(freakyLine.boundingBox);
                sphere.circleVScircle(sphere2.sphere);
                sphere2.circleVScircle(sphere.sphere);

                //TODO:Bonus have your AABB Box drawn as a green outline to the shapes, and then turn red
                //When they collide.


                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
