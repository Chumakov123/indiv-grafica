using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace blank
{
    internal class PolygonTriangulation
    {
        public static List<Triangle> TriangulateMonotonePolygon(List<Point2D> v)
        {
            List<Triangle> triangles = new List<Triangle>();

            if (v.Count < 3)
                return triangles;

            List<int> indices = Enumerable.Range(0, v.Count)
            .OrderBy(i => v[i].x)
            .ToList();

            HashSet<int> chain1 = new HashSet<int>();
            HashSet<int> chain2 = new HashSet<int>();

            int cur_index;

            cur_index = indices[0];
            while (v[cur_index].x < v[indices[indices.Count-1]].x)
            {
                chain1.Add(cur_index);
                cur_index = (cur_index+1)%v.Count;
            }
            chain1.Add(cur_index);

            cur_index = indices[0];
            while (v[cur_index].x < v[indices[indices.Count - 1]].x)
            {
                chain2.Add(cur_index);
                cur_index = (cur_index - 1);
                if (cur_index < 0)
                {
                    cur_index = v.Count - 1;
                }
            }
            chain2.Add(cur_index);

            double chain1Y = chain1.Select(p => v[p].y).Max();
            double chain2Y = chain2.Select(p => v[p].y).Max();

            HashSet<int> upperChain;

            if (chain1Y <= chain2Y)
            {
                upperChain = chain1;
            }
            else
            {
                upperChain = chain2;
            }

            List<int>s = new List<int>();

            s.Add(indices[0]);
            s.Add(indices[1]);

            for (int i = 2; i < indices.Count; ++i)
            {
                s.Add(indices[i]);
                int last = s.Count - 1;

                if ((Math.Abs(s[last] - s[last - 1]) % (v.Count-2) == 1) && (Math.Abs(s[last] - s[0]) % (v.Count - 2) != 1))
                {
                    //Здесь нужно определить к какой цепочке принадлежит вершина
                    if (upperChain.Contains(s[last]))
                    {
                        if (IsConvex(v[s[last - 2]], v[s[last - 1]], v[s[last]]))
                        {
                            triangles.Add(new Triangle(v[s[last - 1]], v[s[last]], v[s[last - 2]]));
                            s.RemoveAt(s.Count - 2);
                        }
                    }
                    else
                    {
                        if (!IsConvex(v[s[last - 2]], v[s[last - 1]], v[s[last]]))
                        {
                            triangles.Add(new Triangle(v[s[last - 1]], v[s[last]], v[s[last - 2]]));
                            s.RemoveAt(s.Count - 2);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < last-1; ++j)
                    {
                        triangles.Add(new Triangle(v[s[j]], v[s[j+1]], v[s[last]]));
                    }
                    s.RemoveRange(0, last-1);
                }
            }
            return triangles;
        }

        public static bool IsConvex(Point2D prev, Point2D current, Point2D next)
        {
            double crossProduct = CrossProduct(prev, current, next);

            return crossProduct >= 0; // Вершина является выпуклой, если векторное произведение неотрицательное
        }

        private static double CrossProduct(Point2D a, Point2D b, Point2D c)
        {
            double x1 = b.x - a.x;
            double y1 = b.y - a.y;
            double x2 = c.x - b.x;
            double y2 = c.y - b.y;
            return (x1 * y2) - (x2 * y1);
        }

        public class Triangle
        {
            public Point2D A { get; set; }
            public Point2D B { get; set; }
            public Point2D C { get; set; }

            public Triangle(Point2D a, Point2D b, Point2D c)
            {
                A = a;
                B = b;
                C = c;
            }
        }
    }
}
