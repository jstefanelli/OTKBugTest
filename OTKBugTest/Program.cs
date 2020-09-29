using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;
using System;
using OpenTK.Mathematics;

namespace OTKBugTest
{
	class Program
	{
		private static GameWindow Window { get; set; }
		static void Main(string[] args)
		{
			Window = new GameWindow(new GameWindowSettings()
			{
				UpdateFrequency = 60.0,
				RenderFrequency = 60.0
			}, new NativeWindowSettings()
			{
				API = ContextAPI.OpenGL,
				APIVersion = new Version(3, 3),
				Profile = ContextProfile.Core,
				Flags = ContextFlags.ForwardCompatible,
				Title = "OTK Bug Test",
				WindowBorder = WindowBorder.Fixed,
				Size = new Vector2i(800, 600)
			});

			Window.RenderFrame += Window_RenderFrame;
			Window.UpdateFrame += Window_UpdateFrame;
			Window.Resize += Window_Resize;
			Window.KeyDown += Window_KeyDown;
			Window.KeyUp += Window_KeyUp;
			Window.Load += Window_Load;
			Window.Run();
		}

		private static void Window_Resize(ResizeEventArgs obj)
		{
			GL.Viewport(0, 0, obj.Size.X, obj.Size.Y);
		}

		private static void Window_KeyUp(KeyboardKeyEventArgs obj)
		{
			if(obj.Key == Keys.W){
				Console.WriteLine("Keyup: W");
			}
		}

		private static void Window_KeyDown(KeyboardKeyEventArgs obj)
		{
			if(obj.Key == Keys.W){
				Console.WriteLine("Keydown: W");
			}
		}

		private static void Window_Load()
		{
			
		}
		

		private static void Window_UpdateFrame(FrameEventArgs obj)
		{
			KeyboardState st = Window.KeyboardState;

			if(st.IsKeyDown(Keys.W)){
				Console.WriteLine("KBState: W pressed");
			}
		}

		private static void Window_RenderFrame(FrameEventArgs obj)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);

			Window.SwapBuffers();
		}
	}
}
