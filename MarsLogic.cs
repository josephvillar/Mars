using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsExplorer
{
    public class MarsLogic
    {
        private int _xRoute;
        private int _yRoute;
        private List<string> _routeHistory = new List<string>();

        public int Explored
        {
            get
            {
                return _routeHistory.Distinct().Count();
            }
        }

        public enum Direction
        {
            North,
            East,
            South,
            West
        }


        public MarsLogic(int x, int y)
        {
            this.SetStartingRoute(x, y);
            _routeHistory.Add(this.FormatRoutes());
        }

        public void SetRoute(Direction direction, int steps)
        {
            this.SetAxis((direction == Direction.West || direction == Direction.East), steps, direction);
        }

        private void SetStartingRoute(int x, int y)
        {
            _xRoute = x;
            _yRoute = y;
        }

        private void SetAxis(bool xAxis, int steps, Direction direction)
        {
            bool isNegative = this.IsNegative(steps);
            int stepsPosVal = steps;
            if (isNegative)
            {
                stepsPosVal = Math.Abs(steps);
            }

            if (xAxis)
            {
                do
                {
                    _xRoute = this.CalculateNextRoute(_xRoute, isNegative || (direction == Direction.West));
                    _routeHistory.Add(this.FormatRoutes());
                    stepsPosVal--;
                } while (stepsPosVal != 0);
            }
            else
            {
                do
                {
                    _yRoute = this.CalculateNextRoute(_yRoute, isNegative || (direction == Direction.North));
                    _routeHistory.Add(this.FormatRoutes());
                    stepsPosVal--;
                } while (stepsPosVal != 0);
            }
        }

        private int CalculateNextRoute(int route, bool isNegative)
        {
            int value = 0;

            if (isNegative)
            {
                value = --route;
            }
            else
            {
                value = ++route;
            }

            return value;
        }

        private string FormatRoutes()
        {
            return String.Format("{0}, {1}", _xRoute, _yRoute);
        }

        private bool IsNegative(int value)
        {
            return value < 0;
        }
        
    }
}
