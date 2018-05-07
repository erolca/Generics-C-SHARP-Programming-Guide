using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// this is a generic struct
/// the class variant would be similar
/// this generic allows for the two coordinates
/// to be given as any different type :) 
/// </summary>
/// 


    public struct Point<T>
    {
        //fields of the struct
        private T xPos;
        private T yPos;

        //constructor
        public Point(T xVal, T yVal)
        {
            xPos = xVal;
            yPos = yVal;
        }

        //generic properties :)
        public T X
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public T Y
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public override string ToString()
        {
            return $"{xPos} , {yPos}";
        }

        //reset the values to the defaults of the value type select
        public void ResetPoint()
        {
            xPos = default(T);
            yPos = default(T);
        }
    }
