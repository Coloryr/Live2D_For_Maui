using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Live2D;
using MauiApp1.Live2D;

namespace MauiApp1;
public partial class OpenGLPage : ContentPage
{
	public static OpenGLPage page;
	unsafe public OpenGLPage()
    {
		page = this;

		InitializeComponent();

        Title = "OpenGL";

        Live2DBinding.SetMoveTaskToBackCall(MoveTaskToBack);
        Live2DBinding.SetLoadFileCall(LoadFile);

        Live2DBinding.OnStart();
        Live2DBinding.OnSurfaceCreated();

		bool load = false;

		glview.OnDisplay = r => {
			if (!load)
			{
				Live2DBinding.OnSurfaceChanged((int)r.Width, (int)r.Height);
				load = true;
			}
			else
			{
				Live2DBinding.OnDrawFrame();
			}
		};

		glview.HasRenderLoop = true;
		glview.Display();

		TouchEffect touchEffect = new TouchEffect();
		touchEffect.TouchAction += OnTouchEffectAction;
		glview.Effects.Add(touchEffect);
	}

	bool isBind = false;

	public void bind() 
	{
		Dispatcher.Dispatch(() =>
		{
			var testEffect = Effect.Resolve("XamarinDocs.TouchEffect");

			if (isBind || testEffect is NullEffect)
				return;

			glview.Effects.Clear();

			TouchEffect touchEffect = new TouchEffect();
			touchEffect.TouchAction += OnTouchEffectAction;
			glview.Effects.Add(touchEffect);

			isBind = true;
		});
	}

    private void OnTouchEffectAction(object sender, TouchActionEventArgs args)
    {
		if (args.Type == TouchActionType.Pressed)
		{
			Live2DBinding.OnTouchesBegan((float)args.Location.X, (float)args.Location.Y);
		}
		else if (args.Type == TouchActionType.Moved)
		{
			Live2DBinding.OnTouchesMoved((float)args.Location.X, (float)args.Location.Y);
		}
		else
		{
			Live2DBinding.OnTouchesEnded((float)args.Location.X, (float)args.Location.Y);
		}
    }

    private void MoveTaskToBack()
	{

	}

	unsafe private byte* LoadFile(string name, uint* ptr)
	{
		Debug.WriteLine($"load file:{name}");
		byte[] temp = null;
		if (name.StartsWith("Haru/"))
		{
			name = name.Substring(5);
			if (name.Contains("/"))
			{
				if (name.StartsWith("expressions/"))
				{
					name = name.Replace("expressions/", "");
					if (name == "F01.exp3.json")
					{
						temp = HaruExpressions.F01_exp3;
					}
					else if (name == "F02.exp3.json")
					{
						temp = HaruExpressions.F02_exp3;
					}
					else if (name == "F03.exp3.json")
					{
						temp = HaruExpressions.F03_exp3;
					}
					else if (name == "F04.exp3.json")
					{
						temp = HaruExpressions.F04_exp3;
					}
					else if (name == "F05.exp3.json")
					{
						temp = HaruExpressions.F05_exp3;
					}
					else if (name == "F06.exp3.json")
					{
						temp = HaruExpressions.F06_exp3;
					}
					else if (name == "F07.exp3.json")
					{
						temp = HaruExpressions.F07_exp3;
					}
					else if (name == "F08.exp3.json")
					{
						temp = HaruExpressions.F08_exp3;
					}
				}
				else if (name.StartsWith("motions/"))
				{
					name = name.Replace("motions/", "");
					if (name == "haru_g_idle.motion3.json")
					{
						temp = HaruMotions.haru_g_idle_motion3;
					}
					else if (name == "haru_g_m01.motion3.json")
					{
						temp = HaruMotions.haru_g_m01_motion3;
					}
					else if (name == "haru_g_m02.motion3.json")
					{
						temp = HaruMotions.haru_g_m02_motion3;
					}
					else if (name == "haru_g_m03.motion3.json")
					{
						temp = HaruMotions.haru_g_m03_motion3;
					}
					else if (name == "haru_g_m04.motion3.json")
					{
						temp = HaruMotions.haru_g_m04_motion3;
					}
					else if (name == "haru_g_m05.motion3.json")
					{
						temp = HaruMotions.haru_g_m05_motion3;
					}
					else if (name == "haru_g_m06.motion3.json")
					{
						temp = HaruMotions.haru_g_m06_motion3;
					}
					else if (name == "haru_g_m07.motion3.json")
					{
						temp = HaruMotions.haru_g_m07_motion3;
					}
					else if (name == "haru_g_m08.motion3.json")
					{
						temp = HaruMotions.haru_g_m08_motion3;
					}
					else if (name == "haru_g_m09.motion3.json")
					{
						temp = HaruMotions.haru_g_m09_motion3;
					}
					else if (name == "haru_g_m10.motion3.json")
					{
						temp = HaruMotions.haru_g_m10_motion3;
					}
					else if (name == "haru_g_m11.motion3.json")
					{
						temp = HaruMotions.haru_g_m11_motion3;
					}
					else if (name == "haru_g_m12.motion3.json")
					{
						temp = HaruMotions.haru_g_m12_motion3;
					}
					else if (name == "haru_g_m13.motion3.json")
					{
						temp = HaruMotions.haru_g_m13_motion3;
					}
					else if (name == "haru_g_m14.motion3.json")
					{
						temp = HaruMotions.haru_g_m14_motion3;
					}
					else if (name == "haru_g_m15.motion3.json")
					{
						temp = HaruMotions.haru_g_m15_motion3;
					}
					else if (name == "haru_g_m16.motion3.json")
					{
						temp = HaruMotions.haru_g_m16_motion3;
					}
					else if (name == "haru_g_m17.motion3.json")
					{
						temp = HaruMotions.haru_g_m17_motion3;
					}
					else if (name == "haru_g_m18.motion3.json")
					{
						temp = HaruMotions.haru_g_m18_motion3;
					}
					else if (name == "haru_g_m19.motion3.json")
					{
						temp = HaruMotions.haru_g_m19_motion3;
					}
					else if (name == "haru_g_m20.motion3.json")
					{
						temp = HaruMotions.haru_g_m20_motion3;
					}
					else if (name == "haru_g_m21.motion3.json")
					{
						temp = HaruMotions.haru_g_m21_motion3;
					}
					else if (name == "haru_g_m22.motion3.json")
					{
						temp = HaruMotions.haru_g_m22_motion3;
					}
					else if (name == "haru_g_m23.motion3.json")
					{
						temp = HaruMotions.haru_g_m23_motion3;
					}
					else if (name == "haru_g_m24.motion3.json")
					{
						temp = HaruMotions.haru_g_m24_motion3;
					}
					else if (name == "haru_g_m25.motion3.json")
					{
						temp = HaruMotions.haru_g_m25_motion3;
					}
					else if (name == "haru_g_m26.motion3.json")
					{
						temp = HaruMotions.haru_g_m26_motion3;
					}
				}
				else if (name.StartsWith("Haru.2048/"))
				{
					name = name.Replace("Haru.2048/", "");
					if (name == "texture_00.png")
					{
						temp = Haru_2048.texture_00;
					}
					else if (name == "texture_01.png")
					{
						temp = Haru_2048.texture_01;
					}
				}
			}
			else
			{
				if (name == "Haru.moc3")
				{
					temp = Haru.Haru_moc3;
				}
				else if (name == "Haru.cdi3.json")
				{
					temp = Haru.Haru_cdi3;
				}
				else if (name == "Haru.model3.json")
				{
					temp = Haru.Haru_model3;
				}
				else if (name == "Haru.physics3.json")
				{
					temp = Haru.Haru_physics3;
				}
				else if (name == "Haru.pose3.json")
				{
					temp = Haru.Haru_pose3;
				}
				else if (name == "Haru.userdata3.json")
				{
					temp = Haru.Haru_userdata3;
				}
			}
		}

		ptr[0] = (uint)temp.Length;
		byte* temp1 = (byte*)Marshal.AllocHGlobal(temp.Length);
		for (int i = 0; i < temp.Length; i++)
			temp1[i] = temp[i];
		return temp1;
	}
}