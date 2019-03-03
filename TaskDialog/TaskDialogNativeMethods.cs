﻿using System;
using System.Runtime.InteropServices;

namespace KPreisser.UI
{
    internal static class TaskDialogNativeMethods
    {
        public const int WM_USER = 0x400;

        public const int S_OK = 0x0;

        public const int S_FALSE = 0x1;

        public const int PBST_NORMAL = 0x0001;

        public const int PBST_ERROR = 0x0002;

        public const int PBST_PAUSED = 0x0003;

        [Flags]
        internal enum TASKDIALOG_FLAGS : int
        {
            TDF_ENABLE_HYPERLINKS = 0x0001,

            TDF_USE_HICON_MAIN = 0x0002,

            TDF_USE_HICON_FOOTER = 0x0004,

            TDF_ALLOW_DIALOG_CANCELLATION = 0x0008,

            TDF_USE_COMMAND_LINKS = 0x0010,

            TDF_USE_COMMAND_LINKS_NO_ICON = 0x0020,

            TDF_EXPAND_FOOTER_AREA = 0x0040,

            TDF_EXPANDED_BY_DEFAULT = 0x0080,

            TDF_VERIFICATION_FLAG_CHECKED = 0x0100,

            TDF_SHOW_PROGRESS_BAR = 0x0200,

            TDF_SHOW_MARQUEE_PROGRESS_BAR = 0x0400,

            TDF_CALLBACK_TIMER = 0x0800,

            TDF_POSITION_RELATIVE_TO_WINDOW = 0x1000,

            TDF_RTL_LAYOUT = 0x2000,

            TDF_NO_DEFAULT_RADIO_BUTTON = 0x4000,

            TDF_CAN_BE_MINIMIZED = 0x8000,

            /// <summary>
            /// "Don't call SetForegroundWindow() when activating the dialog"
            /// </summary>
            /// <remarks>
            /// This flag is available on Windows NT 6.2 ("Windows 8") and higher.
            /// </remarks>
            TDF_NO_SET_FOREGROUND = 0x00010000,

            /// <summary>
            /// "used by ShellMessageBox to emulate MessageBox sizing behavior"
            /// </summary>
            TDF_SIZE_TO_CONTENT = 0x01000000
        }

        public enum TASKDIALOG_MESSAGES : int
        {
            TDM_NAVIGATE_PAGE = WM_USER + 101,

            /// <summary>
            /// "wParam = Button ID"
            /// </summary>
            TDM_CLICK_BUTTON = WM_USER + 102,

            /// <summary>
            /// "wParam = 0 (nonMarque) wParam != 0 (Marquee)"
            /// </summary>
            TDM_SET_MARQUEE_PROGRESS_BAR = WM_USER + 103,

            /// <summary>
            /// "wParam = new progress state"
            /// </summary>
            TDM_SET_PROGRESS_BAR_STATE = WM_USER + 104,

            /// <summary>
            /// "lParam = MAKELPARAM(nMinRange, nMaxRange)"
            /// </summary>
            TDM_SET_PROGRESS_BAR_RANGE = WM_USER + 105,

            /// <summary>
            /// "wParam = new position"
            /// </summary>
            TDM_SET_PROGRESS_BAR_POS = WM_USER + 106,

            /// <summary>
            /// "wParam = 0 (stop marquee), wParam != 0 (start marquee),
            /// lparam = speed (milliseconds between repaints)"
            /// </summary>
            TDM_SET_PROGRESS_BAR_MARQUEE = WM_USER + 107,

            /// <summary>
            /// "wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)"
            /// </summary>
            TDM_SET_ELEMENT_TEXT = WM_USER + 108,

            /// <summary>
            /// "wParam = Radio Button ID"
            /// </summary>
            TDM_CLICK_RADIO_BUTTON = WM_USER + 110,

            /// <summary>
            /// "lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID"
            /// </summary>
            TDM_ENABLE_BUTTON = WM_USER + 111,

            /// <summary>
            /// "lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID"
            /// </summary>
            TDM_ENABLE_RADIO_BUTTON = WM_USER + 112,

            /// <summary>
            /// "wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)"
            /// </summary>
            TDM_CLICK_VERIFICATION = WM_USER + 113,

            /// <summary>
            /// "wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)"
            /// </summary>
            TDM_UPDATE_ELEMENT_TEXT = WM_USER + 114,

            /// <summary>
            /// "wParam = Button ID, lParam = 0 (elevation not required),
            /// lParam != 0 (elevation required)"
            /// </summary>
            TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = WM_USER + 115,

            /// <summary>
            /// "wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon
            /// (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)"
            /// </summary>
            TDM_UPDATE_ICON = WM_USER + 116
        }

        public enum TASKDIALOG_NOTIFICATIONS : int
        {
            TDN_CREATED = 0,

            TDN_NAVIGATED = 1,

            /// <summary>
            /// "wParam = Button ID"
            /// </summary>
            TDN_BUTTON_CLICKED = 2,

            /// <summary>
            /// "lParam = (LPCWSTR)pszHREF"
            /// </summary>
            TDN_HYPERLINK_CLICKED = 3,

            /// <summary>
            /// "wParam = Milliseconds since dialog created or timer reset"
            /// </summary>
            TDN_TIMER = 4,

            TDN_DESTROYED = 5,

            /// <summary>
            /// "wParam = Radio Button ID"
            /// </summary>
            TDN_RADIO_BUTTON_CLICKED = 6,

            TDN_DIALOG_CONSTRUCTED = 7,

            /// <summary>
            /// "wParam = 1 if checkbox checked, 0 if not, lParam is unused and always 0"
            /// </summary>
            TDN_VERIFICATION_CLICKED = 8,

            TDN_HELP = 9,

            /// <summary>
            /// "wParam = 0 (dialog is now collapsed), wParam != 0 (dialog is now expanded)"
            /// </summary>
            TDN_EXPANDO_BUTTON_CLICKED = 10
        }

        public enum TASKDIALOG_ELEMENTS
        {
            TDE_CONTENT,

            TDE_EXPANDED_INFORMATION,

            TDE_FOOTER,

            TDE_MAIN_INSTRUCTION
        }

        public enum TASKDIALOG_ICON_ELEMENTS
        {
            TDIE_ICON_MAIN,

            TDIE_ICON_FOOTER
        }

        // Packing is defined as 1 in CommCtrl.h ("pack(1)").
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TASKDIALOGCONFIG
        {
            public uint cbSize;
            public IntPtr hwndParent; // "incorrectly named, this is the owner window, not a parent."
            public IntPtr hInstance; // "used for MAKEINTRESOURCE() strings"
            public TASKDIALOG_FLAGS dwFlags;
            public TaskDialogButtons dwCommonButtons;
            public IntPtr pszWindowTitle;
            public IntPtr mainIconUnion;
            public IntPtr pszMainInstruction;
            public IntPtr pszContent;
            public uint cButtons;
            public IntPtr pButtons;
            public int nDefaultButton;
            public uint cRadioButtons;
            public IntPtr pRadioButtons;
            public int nDefaultRadioButton;
            public IntPtr pszVerificationText;
            public IntPtr pszExpandedInformation;
            public IntPtr pszExpandedControlText;
            public IntPtr pszCollapsedControlText;
            public IntPtr footerIconUnion;
            public IntPtr pszFooter;
            public IntPtr pfCallback;
            public IntPtr lpCallbackData;
            public uint cxWidth; // "width of the Task Dialog's client area in DLU's. If 0, Task Dialog will calculate the ideal width."
        }

        // Packing is defined as 1 in CommCtrl.h ("pack(1)").
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TASKDIALOG_BUTTON
        {
            public int nButtonID;
            public IntPtr pszButtonText;
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate int PFTASKDIALOGCALLBACK(
                IntPtr hwnd,
                TASKDIALOG_NOTIFICATIONS msg,
                IntPtr wParam,
                IntPtr lParam,
                IntPtr lpRefData);

        [DllImport("comctl32.dll",
                EntryPoint = "TaskDialogIndirect",
                ExactSpelling = true,
                SetLastError = true)]
        public static extern int TaskDialogIndirect(
                IntPtr pTaskConfig,
                [Out] out int pnButton,
                [Out] out int pnRadioButton,
                [MarshalAs(UnmanagedType.Bool), Out] out bool pfVerificationFlagChecked);

        [DllImport("user32.dll",
                EntryPoint = "SendMessageW",
                ExactSpelling = true, 
                SetLastError = true)]
        public static extern IntPtr SendMessage(
                IntPtr hWnd,
                int Msg,
                IntPtr wParam,
                IntPtr lParam);

        [DllImport("user32",
                CharSet = CharSet.Unicode,
                EntryPoint = "SetWindowTextW",
                ExactSpelling = true,
                SetLastError = true)]
        public static extern bool SetWindowText(
                IntPtr hWnd,
                string lpString);
    }
}
