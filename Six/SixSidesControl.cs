using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace SixSides
{

    public class SixSidesControl : MonoBehaviour
    {
        double G3 = Math.Sin(60 * Math.PI / 180);//二分之根号三
        private int m_sideLength = 20;

        public int SideLength
        {
            get { return m_sideLength; }
            set
            {
                m_sideLength = value;
            }
        }


        private float m_lineThickness = 1;

        public float LineThickness
        {
            get { return m_lineThickness; }
            set
            {
                m_lineThickness = value;
            }
        }


        private Color m_lineColor = Color.green;

        public Color LineColor
        {
            get { return m_lineColor; }
            set
            {
                m_lineColor = value;
            }
        }

        void Start()
        {
            OnPaint();
        }
        List<float> xList = new List<float>();
        List<float> yList = new List<float>();

        private void OnPaint()
        {
            //横线，三被的边长
            //纵线，根号三倍的边长
            
            int maxx = 1000 / (3 * m_sideLength);
            int maxy = (int)(1000 / (G3 * m_sideLength));

            for (int y = 0; y <= maxy; y++)
            {
                float curHeight = (float)(y * G3 * m_sideLength);
                for (int x = 0; x <= maxx; x++)
                {
                    float curWidth;
                    if (y % 2 == 0)
                        curWidth = (float)(x * 3 * m_sideLength);
                    else
                        curWidth = (float)((x * 3 + 1.5) * m_sideLength);

                    yList.Add(curHeight);
                    xList.Add(curWidth);
                    Debug.logger.Log(curHeight + " -- " + curWidth);
                }
            }

            

        }

        private void OnPaint(float[] x, float[] y)
        {

            for (int i = 0; i < x.Length; i++)
            {
                //9点方向的点
                float px1 = (float)(x[i] - m_sideLength);
                float py1 = (float)(y[i]);

                ////11点方向的点
                //float px2 = (float)(x[i] - 0.5 * m_sideLength);
                //float py2 = (float)(y[i] - G3 * m_sideLength);

                ////1点方向的点
                //float px3 = (float)(x[i] + 0.5 * m_sideLength);
                //float py3 = (float)(y[i] - G3 * m_sideLength);

                //3点方向的点
                float px4 = (float)(x[i] + m_sideLength);
                float py4 = (float)(y[i]);

                //5点方向的点
                float px5 = (float)(x[i] + 0.5 * m_sideLength);
                float py5 = (float)(y[i] + G3 * m_sideLength);

                //7点方向的点
                float px6 = (float)(x[i] - 0.5 * m_sideLength);
                float py6 = (float)(y[i] + G3 * m_sideLength);

                //pe.Graphics.DrawLine(pen, px1, py1, px2, py2);
                //pe.Graphics.DrawLine(pen, px2, py2, px3, py3);
                //pe.Graphics.DrawLine(pen, px3, py3, px4, py4);
                //pe.Graphics.DrawLine(pen, px4, py4, px5, py5);
                //pe.Graphics.DrawLine(pen, px5, py5, px6, py6);
                //pe.Graphics.DrawLine(pen, px6, py6, px1, py1);

                Draw(new Vector3(px4, py4), new Vector3(px5, py5));
                Draw(new Vector3(px5, py5), new Vector3(px6, py6));
                Draw(new Vector3(px6, py6), new Vector3(px1, py1));
                //Draw(new Vector3(px1, py1), new Vector3(px4, py4));

            }
        }

        private void Draw(Vector3 start, Vector3 end)
        {

            Debug.DrawLine(start, end, this.LineColor);
        }

        void OnDrawGizmos()
        {
            OnPaint(xList.ToArray(), yList.ToArray());
        }
    }
}

