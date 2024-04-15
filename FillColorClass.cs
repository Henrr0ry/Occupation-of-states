using System;
using System.Drawing;

namespace Occupation_of_states
{
    public class FillColorClass
    {
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFOHEADER pBitmapInfo, int un, ref IntPtr lplpVoid, int handle, int dw);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern int BitBlt(IntPtr hDestDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern int ExtFloodFill(IntPtr hdc, int X, int Y, int crColor, int wFillType);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern IntPtr CreateSolidBrush(int crColor);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern int GetPixel(IntPtr hdc, int X, int Y);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern int DeleteObject(IntPtr hObject);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern int DeleteDC(IntPtr hdc);
        [System.Runtime.InteropServices.DllImport("gdi32")]
        private static extern int GdiFlush();
        private const int SRCCOPY = 0xCC0020;

        struct BITMAPINFOHEADER
        {
            public int biSize;
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public int biClrUsed;
            public int biClrImportant;
        }

        public void FloodFill(ref Bitmap bm, Color col, Point Pt)
        {
            if (bm == null)
                return;
            IntPtr srcDC = CreateCompatibleDC(IntPtr.Zero);
            IntPtr dstDC = CreateCompatibleDC(IntPtr.Zero);

            BITMAPINFOHEADER dstBMI = new BITMAPINFOHEADER();
            dstBMI.biBitCount = 24;
            dstBMI.biHeight = bm.Height;
            dstBMI.biSize = System.Runtime.InteropServices.Marshal.SizeOf(dstBMI);
            dstBMI.biWidth = bm.Width;
            dstBMI.biPlanes = 1;

            IntPtr dstBits = new IntPtr();
            IntPtr mbmpGetHbitmap = bm.GetHbitmap();
            // Select the bitmap into an HDC
            IntPtr Obmp = SelectObject(srcDC, mbmpGetHbitmap);
            // Create a DIB
            IntPtr dstBMP = CreateDIBSection(dstDC, ref dstBMI, 0, ref dstBits, 0, 0);
            IntPtr Obmp2 = SelectObject(dstDC, dstBMP);
            // Place our bitmap in the DIB
            BitBlt(dstDC, 0, 0, bm.Width, bm.Height, srcDC, 0, 0, SRCCOPY);
            GdiFlush();
            // Create a brush to use to FloodFill
            IntPtr mBrush = CreateSolidBrush(System.Drawing.ColorTranslator.ToOle(col));
            IntPtr hmm = SelectObject(dstDC, mBrush);
            // Fill with color
            ExtFloodFill(dstDC, Pt.X, Pt.Y, GetPixel(dstDC, Pt.X, Pt.Y), 1);
            // Get the bitmap back with the Filled Color
            bm = Bitmap.FromHbitmap(dstBMP);
            // Go berserk clearing memory
            // ExtFloodFill has a bad reputation for gobbling up memory
            // if you dont clean up properly
            DeleteObject(mBrush);
            DeleteObject(SelectObject(dstDC, mBrush));
            DeleteObject(SelectObject(dstDC, dstBMP));
            DeleteObject(SelectObject(srcDC, mbmpGetHbitmap));
            DeleteObject(hmm);
            DeleteObject(dstBits);
            DeleteObject(Obmp2);
            DeleteObject(Obmp);
            DeleteObject(dstBMP);
            DeleteDC(dstDC);
            DeleteDC(srcDC);
            mbmpGetHbitmap = default(IntPtr);
            hmm = default(IntPtr);
            dstBits = default(IntPtr);
            Obmp2 = default(IntPtr);
            Obmp = default(IntPtr);
            dstBMP = default(IntPtr);
            dstDC = default(IntPtr);
            srcDC = default(IntPtr);
            dstBMI = new BITMAPINFOHEADER();
            /* TODO Change to default(_) if this is not a reference type */
        }

    }
}
