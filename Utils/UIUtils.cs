using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFDemo.Utils {

    public class UIUtils {

        private UIUtils() {
        }

        public static BitmapSource CreateBitmapSourceFromVisual(double width, double height,
            Visual visual, bool undoTransformation) {
            if (visual == null) {
                return null;
            }

            RenderTargetBitmap bitmap = new RenderTargetBitmap((int) Math.Ceiling(width),
                (int) Math.Ceiling(height), 96, 96, PixelFormats.Pbgra32);
            if (undoTransformation) {
                DrawingVisual drawingVisual = new DrawingVisual();
                using (DrawingContext context = drawingVisual.RenderOpen()) {
                    VisualBrush visualBrush = new VisualBrush(visual);
                    context.DrawRectangle(visualBrush, null,
                        new Rect(new Point(), new Size(width, height)));
                }

                bitmap.Render(drawingVisual);
            } else {
                bitmap.Render(visual);
            }

            return bitmap;
        }
    }
}