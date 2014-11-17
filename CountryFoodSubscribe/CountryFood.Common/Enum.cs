namespace CountryFood.Common
{
    using System;
    using System.ComponentModel;

    public static class Enum<T>
    {
        public static string Description(T value)
        {
            DescriptionAttribute[] da = (DescriptionAttribute[])
                typeof(T)
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return da.Length > 0 ? da[0].Description : value.ToString();
        }
    }
}
