using System;

namespace window;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Press ESC key to close window");
        var window = new SimpleWindow();
        window.Run();

        Console.WriteLine("All done");
    }
}

internal class SimpleWindow
{
    public void Run()
    {
        var mode = new SFML.Window.VideoMode((800, 600));
        var window = new SFML.Graphics.RenderWindow(mode, "SFML works!");
        window.KeyPressed += Window_KeyPressed;
        window.Closed += (_, _) => window.Close();

        var circle = new SFML.Graphics.CircleShape(10f)
        {
            FillColor = SFML.Graphics.Color.Blue
        };

        // Start the game loop
        while (window.IsOpen)
        {
            // Process events
            window.DispatchEvents();
            window.Clear(SFML.Graphics.Color.White);

            float direction_x = 0f, direction_y = 0f;
            float speed = 0.1f;
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.D))
            {
                direction_x = 1f;
            }
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Q))
            {
                direction_x = -1f;
            }
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.Z))
            {
                direction_y = -1f;
            }
            if (SFML.Window.Keyboard.IsKeyPressed(SFML.Window.Keyboard.Key.S))
            {
                direction_y = 1f;
            }

            Console.WriteLine("Mouse posx : " + SFML.Window.Mouse.GetPosition(window).X.ToString() + " " + "Mouse posy : " + SFML.Window.Mouse.GetPosition(window).Y.ToString());

            circle.Position += new SFML.System.Vector2f(direction_x * speed, direction_y * speed);

            window.Draw(circle);

            // Finally, display the rendered frame on screen
            window.Display();
        }
    }

    /// <summary>
    /// Function called when a key is pressed
    /// </summary>
    private void Window_KeyPressed(object sender, SFML.Window.KeyEventArgs e)
    {
        var window = (SFML.Window.Window)sender;
        if (e.Code == SFML.Window.Keyboard.Key.Escape)
        {
            window.Close();
        }
    }
}