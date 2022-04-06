using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsAppDWM
{
    internal class DWM
    {
        /// <summary>
        /// 一键订阅窗体
        /// </summary>
        /// <param name="CurrentWinformHandle">一般是this.Handle</param>
        /// <param name="TargetFormHandler"> Process[] p = Process.GetProcessesByName("OUTLOOK");取p[0].MainWindowHandle</param>
        /// <param name="control">绘制区域的控件名如panel1</param>
        public static void RegDWM(IntPtr CurrentWinformHandle, IntPtr TargetFormHandler, Control control, out IntPtr thumb)
        {
            int i = DwmRegisterThumbnail(CurrentWinformHandle, TargetFormHandler, out thumb);

            DWM_THUMBNAIL_PROPERTIES props = new DWM_THUMBNAIL_PROPERTIES();

            props.fVisible = true;
            props.dwFlags = DWM_TNP_VISIBLE | DWM_TNP_RECTDESTINATION | DWM_TNP_OPACITY;
            props.opacity = 255;
            props.rcDestination = new Rect(control.Left, control.Top, control.Right, control.Bottom);

            DwmUpdateThumbnailProperties(thumb, ref props);
        }

        /// <summary>
        /// 向DWM管理器订阅某窗口的缩略图
        /// </summary>
        /// <param name="dest">显示缩略图的窗口句柄</param>
        /// <param name="src">被显示缩略图的窗口句柄</param>
        /// <param name="thumb">当获取成功时，缩略图的句柄</param>
        /// <returns>当函数执行成功时，返回S_OK，否则，返回HRESULT错误代码</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr src, out IntPtr thumb);

        /// <summary>
        /// 向DWM退订某个缩略图
        /// </summary>
        /// <param name="thumb">需要退订的缩略图的句柄，null或不存在的句柄将会返回E_INVALIDARG</param>
        /// <returns>当函数执行成功时，返回S_OK，否则，返回HRESULT错误代码</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmUnregisterThumbnail(IntPtr thumb);

        /// <summary>
        /// 查询DWM提供的缩略图的大小
        /// </summary>
        /// <param name="thumb">需要查询的缩略图的句柄</param>
        /// <param name="size">当函数执行成功时，返回带有缩略图Size信息的PSIZE结构体</param>
        /// <returns>当函数执行成功时，返回S_OK，否则，返回HRESULT错误代码</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr thumb, out Size size);

        /// <summary>
        /// 更新DWM的相关属性
        /// </summary>
        /// <param name="hThumb">要更新的缩略图句柄，当这个句柄被其他线程持有时，将会返回E_INVALIDARG。</param>
        /// <param name="props">指向DWM_THUMBNAIL_PROPERTIES结构体的指针，带有更新后的缩略图属性</param>
        /// <returns>当函数执行成功时，返回S_OK，否则，返回HRESULT错误代码。</returns>
        [DllImport("dwmapi.dll")]
        public static extern int DwmUpdateThumbnailProperties(IntPtr hThumb, ref DWM_THUMBNAIL_PROPERTIES props);


        #region 常量定义

        public static readonly int GWL_STYLE = -16;

        public static readonly int DWM_TNP_VISIBLE = 0x8;
        public static readonly int DWM_TNP_OPACITY = 0x4;
        public static readonly int DWM_TNP_RECTDESTINATION = 0x1;

        public static readonly ulong WS_VISIBLE = 0x10000000L;
        public static readonly ulong WS_BORDER = 0x00800000L;
        public static readonly ulong WS_CAPTION = 0x00C00000L;
        public static readonly ulong WS_CHILDWINDOW = 0x40000000L;
        public static readonly ulong TARGETWINDOW = WS_BORDER | WS_VISIBLE;

        #endregion

        #region 结构体定义

        /// <summary>
        /// 缩略图的尺寸
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct PSIZE
        {
            /// <summary>
            /// 缩略图的宽度
            /// </summary>
            public int x;

            /// <summary>
            /// 缩略图的高度
            /// </summary>
            public int y;
        }

        /// <summary>
        /// 缩略图属性
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct DWM_THUMBNAIL_PROPERTIES
        {
            /// <summary>
            /// 标志位常量组，表示结构体中哪些成员被设置
            /// </summary>
            public int dwFlags;

            /// <summary>
            /// 目标窗口中将被用于显示缩略图的区域
            /// </summary>
            public Rect rcDestination;

            /// <summary>
            /// 要显示出缩略图的源窗口区域，默认情况下将会使用全部区域作为缩略图
            /// </summary>
            public Rect rcSource;

            /// <summary>
            /// 缩略图的不透明度，取值范围为0-255，默认值为255
            /// </summary>
            public byte opacity;

            /// <summary>
            /// 缩略图可见性，当该值为true时，缩略图可见。默认值为false
            /// </summary>
            public bool fVisible;

            /// <summary>
            /// 当该值为true时，仅使用缩略图来源的客户区，默认值为false
            /// </summary>
            public bool fSourceClientAreaOnly;
        }

        /// <summary>
        /// 显示应用缩略图的位置
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public Rect(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }

            public Rect(double left, double top, double right, double bottom)
            {
                Left = (int)left;
                Top = (int)top;
                Right = (int)right;
                Bottom = (int)bottom;
            }

            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        #endregion

        /// <summary>
        /// 检索给定句柄的窗口的相关信息
        /// </summary>
        /// <param name="hWnd">窗口的句柄，以及窗口所属的类的句柄。</param>
        /// <param name="nIndex">
        /// <para>需要检索的值对0的偏移常量。有效值的范围是0到额外的窗口内存字节数减4。</para>
        /// <para>例如，如果指定了12个或更多字节的额外内存，则值8将是第三个32位整数的索引</para>
        /// </param>
        /// <returns>如果函数成功，则返回所请求的值。否则，返回0</returns>
        /// <seealso cref="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowlonga"/>
        [DllImport("user32.dll")]
        public static extern ulong GetWindowLongA(IntPtr hWnd, int nIndex);

        /// <summary>
        /// 通过将句柄传递给每个窗口，依次传递给应用程序定义的回调函数，枚举屏幕上的所有顶级窗口。枚举窗口一直持续到最后一个顶级窗口被枚举或回调函数返回FALSE
        /// </summary>
        /// <param name="lpEnumFunc">
        /// <para>指向应用程序定义的回调函数</para>
        /// 参见<seealso cref="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms633498(v=vs.85)"/>
        /// </param>
        /// <param name="lParam">要传递给回调函数的应用程序定义的值</param>
        /// <returns>如果函数执行成功，返回非0值，否则，返回0</returns>
        /// <seealso cref="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumwindows"/>
        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowsCallback lpEnumFunc, int lParam);

        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hwnd, EnumWindowsCallback lpEnumFunc, int lParam);

        /// <summary>
        /// 提供回调函数的委托
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="lParam">传入的自定义值</param>
        /// <returns>继续进行枚举时，返回true，否则返回false</returns>
        public delegate bool EnumWindowsCallback(IntPtr hwnd, int lParam);

        /// <summary>
        /// 将指定窗口标题栏的文本(如果有的话)复制到缓冲区中。如果指定的窗口是控件，则复制该控件的文本。但是，GetWindowText不能在另一个应用程序中检索控件的文本
        /// </summary>
        /// <param name="hWnd">包含文本的窗口或控件的句柄</param>
        /// <param name="lpString">将接收文本的缓冲区。如果字符串与缓冲区一样长或更长，则该字符串将被截断并以空字符结束</param>
        /// <param name="nMaxCount">要复制到缓冲区的最大字符数，包括空字符。如果文本超过这个限制，就会被截断。</param>
        /// <seealso cref="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getwindowtexta"/>
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern void GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 将创建指定窗口的线程带到前台并激活该窗口。键盘输入直接指向窗口，并为用户更改各种视觉提示。系统为创建前台窗口的线程分配的优先级略高于其他线程。
        /// </summary>
        /// <param name="hWnd">需要激活的窗口的句柄</param>
        /// <returns>如果函数执行成功，返回非0值，否则，返回0</returns>
        /// <seealso cref="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setforegroundwindow"/>
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(int hWnd);

        /// <summary>
        /// 获取桌面窗口的句柄
        /// </summary>
        /// <returns>桌面窗口的句柄</returns>
        [DllImport("user32.dll")]
        public static extern int GetDesktopWindow();

        /// <summary>
        /// 设置指定窗口的显示状态
        /// </summary>
        /// <param name="hWnd">指定的窗口句柄</param>
        /// <param name="nCmdShow">相应的状态值</param>
        /// <returns>当指定的窗口可见时，返回true，不可见时则返回false</returns>
        /// <seealso cref="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-showwindow"/>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(int hWnd, int nCmdShow);

        /// <summary>
        /// 检测给定的窗口是否图标化或最小化
        /// </summary>
        /// <param name="hWnd">给定的窗口句柄</param>
        /// <returns>当窗口被最小化时，返回非0值，否则，返回0</returns>
        /// <seealso cref="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-isiconic"/>
        [DllImport("user32.dll")]
        public static extern int IsIconic(int hWnd);
    }
}
