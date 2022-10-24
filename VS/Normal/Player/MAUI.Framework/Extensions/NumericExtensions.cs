using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIApp.Framework.Extensions
{
    public static class NumericExtensions
    {
        public static string FormattedNumber(this double number) =>
            number switch
	        {
                >= 1000000 => (number / 1000000D).ToString("0.#M"),
                >= 10000   => (number / 10000).ToString("0.#K"),
                _ => number.ToString("#,0")
	        };
    }
}
