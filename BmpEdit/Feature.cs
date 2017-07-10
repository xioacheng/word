using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmpEdit
{
    public class Feature
    {
        /// <summary>
        /// 已经经过规范化后的bmp图片，长和宽相等
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<List<double>> CunWangGe(Bitmap bmp,int number)
        {
            List<List<double>> array = new List<List<double>>();
            List<double> temp = new List<double>();
            int allBlack = 0;
            int h = bmp.Height, w = bmp.Width;
            int average_h = h / number, average_w = w / number;
            for(int i = 0; i < number; i++)
            {
                temp.Clear();
                for(int j = 0; j < number; j++)
                {
                    temp.Add(0);
                }
                array.Add(temp);
            }
            for(int i=0;i< h; i++)
            {
                for(int j=0;j< w; j++)
                {
                    if(bmp.GetPixel(j, i).B != 255 || bmp.GetPixel(j, i).R != 255 || bmp.GetPixel(j, i).G != 255)//无像素
                    {
                        if (i / average_w == number && j / average_h < number)
                            array[(i / average_w) - 1][j / average_h]++;
                        else if (i / average_w == number && j / average_h == number)
                            array[(i / average_w) - 1][(j / average_h) - 1]++;
                        else if (i / average_w < number && j / average_h == number)
                            array[i / average_w][(j / average_h) - 1]++;
                        else if(i / average_w < number && j / average_h < number) array[i / average_w][j / average_h]++;
                        allBlack++; 
                    }
                }
            }
            //获取向量
            for(int i = 0;i<number; i++)
            {
                for(int j = 0; j < number; j++)
                {
                    array[i][j] = (array[i][j] / allBlack)*1000;
                }
            }
            return array;
        }
    }
}
