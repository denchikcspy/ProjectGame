using System;

namespace WindowsFormsApp5.Utils
{
    public class ProgressBarValueHelper
    {
        int min = 0;
        int max = 0;
        int current = 0;

        public ProgressBarValueHelper(int max, int min = 0)
        {
            this.min = min;
            this.max = this.current = max;
        }

        public int getMin() => min;
        public int getMax() => max;
        public int getCurrent() => current;

        public void increase(int value)
        {
            if (this.current + value > this.max)
            {
                this.current = this.max;
            } else
            {
                this.current += value;
            }
        }

        public bool decrease(int value)
        {
            if (this.current - value < this.min)
            {
                this.current = this.min;
                return false;
            }
            else
            {
                this.current -= value;
                return true;
            }
        }
    }
}
