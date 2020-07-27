using System;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            IComparable comparable = obj as IComparable;
            if (comparable == null ||
                comparable.CompareTo(this.minValue) < 0 ||
                comparable.CompareTo(this.maxValue) > 0)
            {
                return false;
            }

            return true;
        }
    }
}