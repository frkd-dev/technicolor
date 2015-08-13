int Amount1 = 30; //[0, 100]Red weight
int Amount2 = 59; //[0, 100]Green weight
int Amount3 = 11; //[0, 100]Blue weight

void Render(Surface dst, Surface src, Rectangle rect)
{
    int r, r2, c;
    int g, g2, m;
    int b, b2, y, l;

    float rWeight = (float)Amount1 / 100.0f;
    float gWeight = (float)Amount2 / 100.0f;
    float bWeight = (float)Amount3 / 100.0f;

    ColorBgra curPix;

    for(int yPos = rect.Top; yPos < rect.Bottom; yPos++)
    {
        for (int xPos = rect.Left; xPos < rect.Right; xPos++)
        {
            curPix = src[xPos,yPos];

            r = curPix.R;
            g = curPix.G;
            b = curPix.B;
/*
            c = ((g + b) / 2);
            m = ((r + b) / 2);
            y = ((r + g) / 2);
*/

            c = Gray(curPix, 0, gWeight, bWeight);
            m = Gray(curPix, rWeight, 0, bWeight);
            y = Gray(curPix, rWeight, gWeight, 0);
            
            r2 = 255 - Clamp(r - c);
            g2 = 255 - Clamp(g - m);
            b2 = 255 - Clamp(b - y);

            r -= 255 - ((g2 * b2) >> 8);
            g -= 255 - ((r2 * b2) >> 8);
            b -= 255 - ((g2 * r2) >> 8);
            
            curPix.R = Clamp(r);
            curPix.G = Clamp(g);
            curPix.B = Clamp(b);

            l = Gray(curPix, rWeight, gWeight, bWeight);

            curPix.B = curPix.G;
            curPix.G = Clamp(l);
            
            dst[xPos,yPos] = curPix;
        }
    }
}

byte Clamp(int num)
{
    return (byte)(num < 0 ? 0 : (num > 255 ? 255 : num));
}

byte Gray(ColorBgra col, float wr, float wg, float wb)
{
    byte res;
    float _r = col.R, _g = col.G, _b = col.B, sum;
    
    sum = Math.Abs(wr + wg + wb);
    
    res = (byte)(_r * (wr/sum) + _g * (wg/sum) + _b * (wb/sum));
    
    return res;
}