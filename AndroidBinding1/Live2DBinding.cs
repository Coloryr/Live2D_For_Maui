using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Live2D
{
    public class Live2DBinding
    {
        public delegate void MoveTaskToBack();
        unsafe
        public delegate byte* LoadFile(string name, uint* ptr);

        private const string LibName = "liblive2d.so";

        [DllImport(LibName, EntryPoint = "SetMoveTaskToBackCall")]
        public static extern void SetMoveTaskToBackCall(MoveTaskToBack call);

        [DllImport(LibName, EntryPoint = "SetLoadFileCall", CharSet = CharSet.Ansi)]
        public static extern void SetLoadFileCall(LoadFile call);

        [DllImport(LibName, EntryPoint = "GetExpression", CharSet = CharSet.Ansi)]
        public static extern string GetExpression(int index);

        [DllImport(LibName, EntryPoint = "GetMotion", CharSet = CharSet.Ansi)]
        public static extern string GetMotion(int index);

        [DllImport(LibName, EntryPoint = "GetExpressionSize")]
        public static extern int GetExpressionSize();

        [DllImport(LibName, EntryPoint = "GetMotionSize")]
        public static extern int GetMotionSize();

        [DllImport(LibName, EntryPoint = "StartMotion", CharSet = CharSet.Ansi)]
        public static extern void StartMotion(string group, int no, int priority);

        [DllImport(LibName, EntryPoint = "StartExpressions", CharSet = CharSet.Ansi)]
        public static extern void StartExpressions(string name);

        [DllImport(LibName, EntryPoint = "ChangeModel")]
        public static extern void ChangeModel();

        [DllImport(LibName, EntryPoint = "OnStart")]
        public static extern void OnStart();

        [DllImport(LibName, EntryPoint = "OnPause")]
        public static extern void OnPause();

        [DllImport(LibName, EntryPoint = "OnStop")]
        public static extern void OnStop();

        [DllImport(LibName, EntryPoint = "OnDestroy")]
        public static extern void OnDestroy();

        [DllImport(LibName, EntryPoint = "OnSurfaceCreated")]
        public static extern void OnSurfaceCreated();

        [DllImport(LibName, EntryPoint = "OnSurfaceChanged")]
        public static extern void OnSurfaceChanged(int width, int height);

        [DllImport(LibName, EntryPoint = "OnDrawFrame")]
        public static extern void OnDrawFrame();

        [DllImport(LibName, EntryPoint = "OnTouchesBegan")]
        public static extern void OnTouchesBegan(float pointX, float pointY);

        [DllImport(LibName, EntryPoint = "OnTouchesEnded")]
        public static extern void OnTouchesEnded(float pointX, float pointY);

        [DllImport(LibName, EntryPoint = "OnTouchesMoved")]
        public static extern void OnTouchesMoved(float pointX, float pointY);

        [DllImport(LibName, EntryPoint = "SetPos")]
        public static extern void SetPos(float pointX, float pointY);

        [DllImport(LibName, EntryPoint = "SetScale")]
        public static extern void SetScale(float scale);

        [DllImport(LibName, EntryPoint = "SetPosX")]
        public static extern void SetPosX(float data);

        [DllImport(LibName, EntryPoint = "SetPosY")]
        public static extern void SetPosY(float data);
    }
}
