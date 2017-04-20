using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3c_tcp
{
    class positional
    {
        public double[] pos = new double[8];
    }
    class Direction
    {
        private double []dir=new double[8];
        private int[] GoStop = new int[8];
        private double vl, vr;
        public Direction(double[]dir1,int m)
        {
            dir = dir1;
            for (int i = 0; i < dir.Length; i++)
            {
                if (dir[i] > 20 && dir[i] < 30)
                {
                    GoStop[i] = 0;
                }
                else if (dir[i] <= 150)
                {
                    GoStop[i] = 1;
                }
                else
                {
                    GoStop[i] = 0;
                }

            }
            int direction;
            direction = moved(GoStop, 8);
            
            switch (direction)
            {
                case 0: vl = 0; vr = 0; break;
                case 1: vl = 0.3; vr = 0.3; break;
                case 2: vl = 0.3; vr = 0; break;
                case 3: vl = 0; vr = 0.3; break;
                case 4: vl = 0.3; vr = 0.1; break;
                case 5: vl = 0.1; vr = 0.3; break;
                default:vl = 0; vr = 0; break;
            }

        }
        public  double[] getDir()
        {
            return new double[2] { vl, vr };
        }
        
        int moved(int[]x,int m)//根据障碍信息输出方向：0--停止；1--前行；2--原地右转；3--原地左转；4--右转；5--左转；
        {
	        int d;
	        int num=0;
	        for (int i = 0; i < m; i++)
	        {
		        num = Convert.ToInt32(num + Math.Pow(2, i)*x[i]);
	        }
	        switch (num)
	        {
	        case 0:case 184: case 224:case 129:case 131:case 195:case 225:case 226:
	        case 227:case 243:case 249:case 251:case 190:case 238:case 248:case 254:
		           d = 1; break;
	        case 128:case 32:case 46:case 207:
		        d = 2; break;
	        case 8:
		        d = 4; break;
	        case 47:case 62:case 63: case 143 : case 175:case 191 : case 239:
	         d = 4; break;
	         case 64:
		         d = 3; break;
           case 120:
	           d = 5; break;
            case  160:case 161:case 163:
		        d = 3; break;
            default:
		        d = 0;
		        break;
	        }
	        return d;
        }
    }
}
